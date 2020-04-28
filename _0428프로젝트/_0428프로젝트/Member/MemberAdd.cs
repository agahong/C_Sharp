using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    /// <summary>
    /// 사용자로부터 회원 정보를 입력받아
    /// Member 객체로 변환하여 제공하는 기능의 함수
    /// </summary>
    class MemberAdd
    {
        //고려사항
        //ID는 중복되면 안됨.
        public Member AddMember(WbMemberList memlist)
        {
            int id, groupid;
            while (true)
            {
                id = wbGlobal.InputInt("아이디 : ");
                if (IdCheck(memlist, id))
                    break;
                Console.WriteLine("중복된 아이디입니다. 재 입력해주세요");
            }

            string name = wbGlobal.InputString("이름 : ");

            while(true)
            {
                groupid = wbGlobal.InputInt("조(1~6) : ");
                if(1<=groupid || groupid<=6)
                    break;
                Console.WriteLine("1부터 6조 사이의 값을 입력해주세요.");
            }

            int subject = wbGlobal.InputInt("학과([[1]COM [2]IT [3]GAME [4]ETC)");

            return new Member(id, name, groupid, NumberToSubject(subject));
        }

        private bool IdCheck(WbMemberList memlist, int id)
        {
            foreach(Member mem in memlist)
            {
                if (mem.Id == id)
                    return false;
            }
            return true;
        }

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

    }
}
