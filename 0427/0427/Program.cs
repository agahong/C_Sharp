using System;

namespace _0427
{
    class Program
    {
        //기본출력
        private static void exam1()
        {
            String name;
            int age;
            float weight;
            char gender;
            String temp;

            Console.Write("이름 : ");
            name = Console.ReadLine();

            Console.WriteLine("나이 : ");
            temp = Console.ReadLine();
            age = int.Parse(temp);

            Console.WriteLine("몸무게 : ");
            weight = float.Parse(Console.ReadLine());

            Console.WriteLine("성별(남/여)");
            temp = Console.ReadLine();
            gender = temp[0];

            Console.WriteLine("이름 : {0} {1}", name, name);
            //문자열 + 문자열 + 문자열
            //문자열 + 기본타입 => 기본타입이 문자열로 변환 " : 문자열 반환
            Console.WriteLine("나이 : " + age + "세");
            Console.WriteLine("몸무게 : {0}kg", weight);
            Console.WriteLine("성별 : " + gender);

        }

        //열거형 체크 : Console,ReadKey()사용
        private static void exam2()
        {
            Console.Write("키 입력 : ");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.F1)
            {
                Console.WriteLine("F1키 입력");
            }
        }

        //var
        private static void exam3()
        {
            var a = 10;
            a = a + 1;

            Console.WriteLine(a);

            int num = a;
        }

        //인자 전달시 ref, out 키워드 의미
        //숫자 2개와 그 합의 결과를 받아 맞으면 true리턴
        //틀리면 false를 리턴하고 sum의 값을 변경
        //즉,sum은 틀릴때만 변경.
        #region ref예제
        private static bool checksum1(int n1, int n2, ref int sum)
        {
            if (n1 + n2 == sum)
                return true;

            sum = n1 + n2;
            return false;
        }

        private static void exam4()
        {
            int num1 = 10, num2 = 20;
            int sum = 40;

            if(checksum1(num1, num2, ref sum)==true)
            {
                Console.WriteLine("동일하다\n");
            }
            else
            {
                Console.WriteLine("다르다 {0}", sum);
            }
        }
        #endregion

        #region C#에서는 초기화되지 않은 변수의 사용은 금지
        private static void exam5_1(int n)
        {

        }

        private static void exm5()
        {
            int n1;
            //int sum = n1;   //error
            //exam5_1(n1);    //error
        }
        #endregion

        #region out예제(out은 인자전달시 반드시 수정할 목적일 때 사용)
        //      #따라서 초기화를 안해도 사용가능
        private static bool checksum2(int n1, int n2, out int sum)
        {
            sum = n1 + n2;
            return false;
        }

        private static void exam6()
        {
            int num1 = 10, num2 = 20;
            int sum = 40;

            if (checksum2(num1, num2, out sum) == true)
            {
                Console.WriteLine("동일하다\n");
            }
            else
            {
                Console.WriteLine("다르다 {0}", sum);
            }
        }
        #endregion

        static void Main(string[] args)
        {
          
        }

        private static void NewMethod1()
        {
            int num1 = 10;

            //boxing
            //값형식을 주소값 형식에 대입할 때 발생되는 기능.
            object obj = num1;

            //boxing
            obj = 20;
        }

        private static void NewMethod()
        {
            //boxing
            object ob1 = 10;    //upcasting

            //unboxing
            int number = (int)ob1;  //downcasting

            Console.WriteLine(ob1);
        }
    }
}
