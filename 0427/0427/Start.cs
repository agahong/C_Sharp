using System;

namespace _0427
{
    class Start
    {
        public static void Main(String[] args)
        {
            MemberList memList = new MemberList(5);

            memList.Add(new Member("홍길동", 1, "010-1111-1111"), 3);

            memList.PrintAll();

            //인덱서의 올바른 사용
            memList[3].Number = 2;
            memList[3].Phone = "010-2222-2222";

            memList.PrintAll();

            //잘못된 인덱서 사용
            try
            {
                memList[100].Number = 22;
                Console.WriteLine("수정 성공");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[수정 에러] " + ex.Message);
            }
            //===============================================
        }

        private static void NewMethod()
        {
            Member mem = new Member("홍길동", "010-7777-7777");
            mem.Print();
            mem.Phone = "010-1111-1111";
            mem.Number = 1;
            mem.Print();
        }
    }
}
