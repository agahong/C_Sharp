using System;

namespace cpp2cs
{
    class WbGlobal
    {
        public static void Pause()
        {
            Console.WriteLine("아무키나 누르세요.....");
            Console.ReadKey();
        }

        public static int InputInt(String msg)
        {
            int result;
            while (true)
            {
                Console.Write("{0} : ", msg);

                if (int.TryParse(Console.ReadLine(), out result) == true)
                    return result;
            }
        }

        public static String InputString(String msg)
        {
            while (true)
            {
                Console.Write("{0} : ", msg);

                return Console.ReadLine();
            }
        }
    }
}
