using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberUpdate
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

        public Member GetUpdateMemberFromId(WbMemberList memlist)
        {
            int id = wbGlobal.InputInt("수정하실 분의 아이디 : ");
            foreach (Member mem in memlist)
            {
                if (mem.Id == id)
                {
                    return mem;
                }
            }
            return null;
        }

        public void Update(ref Member member)
        {
            Console.Clear();
            while (true)
            {
                member.GroupNumber = wbGlobal.InputInt("새로 바꿀 조(1~6) : ");
                if (1 <= member.GroupNumber || member.GroupNumber <= 6)
                    break;
                Console.WriteLine("1부터 6조 사이의 값을 입력해주세요.");
            }
            int subnum = wbGlobal.InputInt("새로운 학과([[1]COM [2]IT [3]GAME [4]ETC)");
            member.SName = NumberToSubject(subnum);
        }
    }
}
