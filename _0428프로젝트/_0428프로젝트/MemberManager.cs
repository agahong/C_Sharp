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
    }
}
