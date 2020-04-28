using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberSelect
    {
        private SubjectName NumberToSubject(int id)
        {
            SubjectName sn;
            switch (id)
            {
                case 1: sn = SubjectName.COM; break;
                case 2: sn = SubjectName.IT; break;
                case 3: sn = SubjectName.GAME; break;
                case 4: sn = SubjectName.ETC; break;
                default: sn = SubjectName.ERROR; break;
            }
            return sn;
        }

        public Member MemberSelectById(WbMemberList memlist)
        {
            int id = wbGlobal.InputInt("아이디 : ");
            foreach (Member mem in memlist)
            {
                if(mem.Id == id)
                {
                    return mem;
                }
            }
            return null;
        }

        public void MemberSelectByGroup(WbMemberList memlist)
        {
            int groupnumber = wbGlobal.InputInt("조 번호(1~6) : ");

            Console.WriteLine("아이디 | 이름 | 조 번호 | 학과");
            Console.WriteLine("=================================");
            foreach(Member mem in memlist)
            {
                if (mem.GroupNumber == groupnumber)
                {
                    mem.Print();
                }
            }
        }

        public void MemberSelectBySubject(WbMemberList memlist)
        {
            int subject = wbGlobal.InputInt("학과([[1]COM [2]IT [3]GAME [4]ETC) : ");
            SubjectName sn = NumberToSubject(subject);

            Console.WriteLine("아이디 | 이름 | 조 번호 | 학과");
            Console.WriteLine("=================================");
            foreach (Member mem in memlist)
            {
                if (mem.SName == sn) 
                {
                    mem.Print();
                }
            }
        }
    }
}
