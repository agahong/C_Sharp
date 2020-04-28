using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberManager
    {
        #region 싱글톤
        public static MemberManager Singleton { get; private set; }

        static MemberManager()  //static 키워드 -> 한번만 호출
        {
            Singleton = new MemberManager();
        }

        private MemberManager() { }
        #endregion

        WbMemberList memlist = new WbMemberList();

        public void AddMember()
        {
            //1.정보를 획득 & 저장 객체 생성
            //            MemberAdd ma = new MemberAdd();
            //            Member member = ma.AddMember();
            //이름이 없는 객체 생성(딱 한번 맴버함수를 호출하고자 할때)
            Member member = new MemberAdd().AddMember(memlist);

            //3.저장
            memlist.Add(member);

            //4.결과출력
            Console.WriteLine("저장되었습니다.");
        }

        public void SelectMemberId()
        {
            MemberSelect ms = new MemberSelect();
            Member mem = ms.MemberSelectById(memlist);
            mem.PrintLine();
        }

        public void SelectMemberGroup()
        {
            new MemberSelect().MemberSelectByGroup(memlist);
        }

        public void SelectMemberSubject()
        {
            new MemberSelect().MemberSelectBySubject(memlist);
        }

        public void UpdateMember()
        {
            MemberUpdate mm = new MemberUpdate();
            Member member = mm.GetUpdateMemberFromId(memlist);
            if (member == null) 
            {
                Console.WriteLine("선택하신 아이디가 없습니다");
                return;
            }

            mm.Update(ref member);

            Console.WriteLine("수정되었습니다");
            member.Print();
        }

        public void DeleteMember()
        {
            MemberDelete md = new MemberDelete();
            if(md.Delete(memlist)==false)
                Console.WriteLine("선택하신 아이디가 존재하지 않습니다.");
        }
    }
}
