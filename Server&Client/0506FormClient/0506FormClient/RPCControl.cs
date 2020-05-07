using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wb31.Client;

namespace _0506FormClient
{
    class RPCControl
    {
        private WbClient client;
        private PacketParser parser;

        #region 싱글톤
        public static RPCControl Singleton { get; private set; }

        static RPCControl()  //객체 사용시 최초 한번만 호출 
        {
            Singleton = new RPCControl();
        }

        private RPCControl()
        {
            try
            {
                client = new WbClient(LogMessage, RecvData);
                //client.CreateClient("127.0.0.1", 7000);
                client.CreateClient("61.81.99.67", 9000);

                parser = new PacketParser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.Close(); //폼이 아닌 자신의 프로세스 종료
            }
        }
        #endregion

        #region WbClient ==> Program
        public void LogMessage(LogType lt, String ip, int port)
        {
            DateTime dt = DateTime.Now;

            if (lt == LogType.CONNECT)
            {
                Console.WriteLine("[접속] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if (lt == LogType.DISCONNECT)
            {
                Console.WriteLine("[해제] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if (lt == LogType.ERROR)
            {
                Console.WriteLine("[에러] " + ip + "\t" + dt.ToString());
            }
        }

        public void RecvData(Socket sock, String msg)
        {
            String ip;
            int port;
            client.GetRemoteIpPort(sock, out ip, out port);

            //Console.WriteLine(">> [{0}0:{1}] {2}\t{3}", ip, port, msg, DateTime.Now.ToString());
            parser.DataParser(msg);
        }
        #endregion

        #region Program(Form) ==> WbClient
        public void SendData(String msg)
        {
            client.Send(msg);
        }
        #endregion

        public void DlgFormRef(LoginForm form)
        {
            parser.DlgFormRef(form);
        }

        public void ChatFormRef(ChatForm form)
        {
            parser.ChatFormRef(form);
        }
    }
}
