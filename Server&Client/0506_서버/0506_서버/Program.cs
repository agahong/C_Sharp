using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _0506_서버
{
    class Program
    {
        private WbServer server;

        public Program()
        {
            server = new WbServer(LogMessage, RecvData);
        }

        public void LogMessage(LogType lt, String ip, int port)
        {
            DateTime dt = DateTime.Now;

            if(lt == LogType.SERVERRUN)
            {
                Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
                Console.WriteLine("{0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if(lt == LogType.CONNECT)
            {
                Console.WriteLine("[접속] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if (lt == LogType.DISCONNECT)
            {
                Console.WriteLine("[해제] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if(lt==LogType.ERROR)
            {
                Console.WriteLine("[에러] " + ip + "\t" + dt.ToString());
            }
        }

        public void RecvData(Socket sock, String msg)
        {
            String ip;
            int port;
            server.GetRemoteIpPort(sock, out ip, out port);
            Console.WriteLine(">> {0}:{1} {2}\t{3}",
                ip, port, msg, DateTime.Now.ToString());

            try
            {
                server.SendAllData(sock, msg, msg.Length);
                //server.SendData(sock, msg, msg.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine("[전송에러]" + ex.Message);
            }
        }

        //==========================================================
        static void Main(string[] args)
        {
            Program pr = new Program();

            if(pr.server.CreateSocket(9000) == false)
            {
                Console.WriteLine("소켓 생성 오류");
            }

            pr.server.ServerThread.Join();
        }
    }
}
