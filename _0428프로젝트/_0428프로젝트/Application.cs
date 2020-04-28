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
                    case ConsoleKey.F2: Console.WriteLine("F2"); break;
                    case ConsoleKey.F3: Console.WriteLine("F3"); break;
                    case ConsoleKey.F4: Console.WriteLine("F4"); break;
                    case ConsoleKey.F5: Console.WriteLine("F5"); break;
                    case ConsoleKey.F6: Console.WriteLine("F6"); break;
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

                switch (wbMenu.SeatMenu())
                {
                    case ConsoleKey.F1: Console.WriteLine("F1"); break;
                    case ConsoleKey.F2: Console.WriteLine("F2"); break;
                    case ConsoleKey.F3: Console.WriteLine("F3"); break;
                    case ConsoleKey.F4: Console.WriteLine("F4"); break;
                    case ConsoleKey.F5: Console.WriteLine("F5"); break;
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
