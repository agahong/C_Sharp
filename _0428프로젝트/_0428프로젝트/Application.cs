using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class Application
    {
        public bool Init()
        {
            wbGlobal.Logo();

            return true;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ConsoleKey key = wbMenu.MainMenu();
                if (key == ConsoleKey.F1)
                {
                    MemberRun();
                }
                else if (key == ConsoleKey.F2)
                {
                    SeatRun();
                }
                else if (key == ConsoleKey.Escape)
                    return;
                else
                    Console.WriteLine("잘못 입력하셨습니다.");
                wbGlobal.Pause();
            }
        }

        private void MemberRun()
        {
            while(true)
            {
                Console.Clear();
                switch(wbMenu.MemberMenu())
                {
                    case ConsoleKey.F1: MemberManager.Singleton.AddMember(); break;
                    case ConsoleKey.F2: MemberManager.Singleton.SelectMemberId(); break;
                    case ConsoleKey.F3: MemberManager.Singleton.SelectMemberGroup(); break;
                    case ConsoleKey.F4: MemberManager.Singleton.SelectMemberSubject(); break;
                    case ConsoleKey.F5: MemberManager.Singleton.UpdateMember(); break;
                    case ConsoleKey.F6: MemberManager.Singleton.DeleteMember(); break;
                    case ConsoleKey.Escape: return;
                }
                wbGlobal.Pause();
            }
        }

        private void SeatRun()
        {
            while (true)
            {
                Console.Clear();
                //전체출력코드
                SeatManager.Singleton.PrintAll();

                switch (wbMenu.SeatMenu())
                {
                    case ConsoleKey.F1: SeatManager.Singleton.AddSeat(); break;
                    case ConsoleKey.F2: SeatManager.Singleton.MoveSeat(); break;
                    case ConsoleKey.F3: SeatManager.Singleton.ChangeSeat(); break;
                    case ConsoleKey.F4: SeatManager.Singleton.DeleteSeat(); break;
                    case ConsoleKey.F5: SeatManager.Singleton.SelectSeat(); break;
                    case ConsoleKey.Escape: return;
                }
                wbGlobal.Pause();
            }
        }

        public void Exit()
        {
            wbGlobal.Ending();
        }
    }
}
