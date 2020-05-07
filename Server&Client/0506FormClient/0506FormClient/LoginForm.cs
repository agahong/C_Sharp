using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wb31.Client;

namespace _0506FormClient
{
    public partial class LoginForm : Form
    {
        public String Id { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            //자신의 레퍼런스를 RPCControl에 전달
            RPCControl.Singleton.DlgFormRef(this);
        }

        //로그인버튼
        private void button1_Click(object sender, EventArgs e)
        {
            //정보획득
            String id, pw;
            id = textBox1.Text;
            pw = textBox2.Text;

            //아이디 프로퍼티에 보관
            Id = id;

            //패킷 생성
            String msg = Packet.Login(id, pw);

            //소켓 통신(전송)
            RPCControl.Singleton.SendData(msg);
        }

        //회원가입버튼
        private void button2_Click(object sender, EventArgs e)
        {
            AddMemberForm form = new AddMemberForm();
            if (form.ShowDialog() == DialogResult.OK) 
            {
                //정보 획득
                String id, pw, name, phone;
                form.GetData(out id, out pw, out name, out phone);

                //패킷생성
                String msg = Packet.AddMddMember(id, pw, name, phone);

                //소켓통신   
                RPCControl.Singleton.SendData(msg);
            }
        }

        public void LoginAck(bool flag, String msg)
        {
            if (flag == true)
            {
                Thread th = new Thread(new ParameterizedThreadStart(ShowLoginForm));
                th.Start(msg);
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("로그인 실패");
            }
        }

        private void ShowLoginForm(object msg)
        {
            String data = (String)msg;
            //this.Hide();

            //다음 창을 실행(모달리스) 
            ChatForm form = new ChatForm();
            form.SendData(Id, data);
            form.ShowDialog();
        }


        public void AddMemberAck(bool flag, String id, String name)
        {
            if (flag == true)
            {
                MessageBox.Show(String.Format("회원가입 완료!\n\nID : {0}\nPW : {1}",
                id, name));
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show(String.Format("아이디[{0}]님 회원가입 실패", id));
            }
        }
    }
}
