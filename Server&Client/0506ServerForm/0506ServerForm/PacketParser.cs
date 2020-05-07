using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _0506ServerForm
{
    class PacketParser
    {
        public static String DataParser(List<Member> memlist, String msg)
        {
            String[] token = msg.Split('\a');
            if (token[0].Equals("WB_ADDMEMBER"))
            {
                return AddMember(memlist, token[1]);
            }
            else if (token[0].Equals("WB_LOGIN"))
            {
                return Login(memlist, token[1]);
            }
            else if(token[0].Equals("WB_SHORTMESSAGE"))
            {
                String[] token1 = token[1].Split('#');
                return ShortMessage(token1[0], token1[1]);
            }
            else
                return String.Empty;
        }

        private static String AddMember(List<Member> memlist, String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            memlist.Add(new Member(token[0], token[1], token[2], token[3]));

            //패킷 생성
            return Packet.AddMember(true, token[0], token[1]);
        }


        private static String Login(List<Member> memlist, String msg)
        {
            String[] tocken = msg.Split('#');
            foreach (Member mem in memlist)
            {
                if(mem.Id.Equals(tocken[0])&&mem.Pw.Equals(tocken[1]))
                {
                    mem.IsLogin = true;
                    return Packet.Login(true, mem.Id, mem.Pw, mem.Name, mem.Phone, memlist);
                }
            }

            return Packet.Login(false, tocken[0], "", "", "", memlist);
        }

        private static String ShortMessage(String id, String msg)
        {
            return Packet.ShortMessage(id, msg);
        }
    }
}
