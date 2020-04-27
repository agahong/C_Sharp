using System;

namespace cpp2cs
{
    class main
    {
        private enum menu { MAKE = 1, DEPOSIT, WITHDRAW, INQUIRE, EXIT };

        static void Main(String[] args)
        {
            AccManager manager = new AccManager();

            while (true)
            {
                manager.PrintMenu();
                Console.WriteLine("선택: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case (int)menu.MAKE: manager.MakeAccount(); break;
                    case (int)menu.DEPOSIT: manager.Depoist(); break;
                    case (int)menu.WITHDRAW: manager.Withdraw(); break;
                    case (int)menu.INQUIRE: manager.Inquire(); break;
                    case (int)menu.EXIT: return;
                    default:
                        Console.WriteLine("잘못 선택"); break;
                }
            }
        }
    }
}
