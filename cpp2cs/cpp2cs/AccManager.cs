using System;

namespace cpp2cs
{
    class AccManager
    {
        #region 계정정보 배열
        private Account[] pArray;
        private int index;
        #endregion

        #region 프로퍼티
        public Account this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= pArray.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                return pArray[idx];
            }
            set
            {
                if (idx < 0 || idx >= pArray.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                pArray[idx] = value;
            }
        }
        #endregion

        //생성자
        public AccManager()
        {
            pArray = new Account[100];
            index = 0;
        }

        #region 내부함수
        private int SelectAccount()
        {
            Console.WriteLine("개설할 계좌의 종류........");
            Console.WriteLine("1.일반 계좌 ");
            Console.WriteLine("2.신용 계좌 ");
            Console.WriteLine("3.기부 계좌 ");
            Console.Write(" >> ");
            return int.Parse(Console.ReadLine());
        }

        private void SetTempData(ref Account temp)
        {
            Console.WriteLine("개좌 개설 ------");
            Console.WriteLine("개좌  ID: ");
            temp.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("이    름: ");
            temp.Name = Console.ReadLine();
            Console.WriteLine("입 금 액: ");
            temp.Balance = int.Parse(Console.ReadLine());
        }
        #endregion

        #region 메서드
        public void PrintMenu()     //메뉴출력
        {
            Console.WriteLine("----- MENU ----- ");
            Console.WriteLine("1.개 좌  개 설 ");
            Console.WriteLine("2.입        금 ");
            Console.WriteLine("3.출        금 ");
            Console.WriteLine("4.잔 액  조 회 ");
            Console.WriteLine("5.프로그램 종료 ");
        }

        public void MakeAccount()      // 계좌 개설
        {
            int sel = SelectAccount();
            Account temp = new Account();

            SetTempData(ref temp);

            try
            {
                if (sel == 1)
                    pArray[index++] = temp;
                else if (sel == 2)
                    pArray[index++] = new FaitAccount(temp.Id, temp.Name, temp.Balance) as Account;
                else if (sel == 3)
                    pArray[index++] = new ContriAccount(temp.Id, temp.Name, temp.Balance) as Account;
                else
                    Console.WriteLine("선택 오류");

                Console.WriteLine("계좌개설 완료");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[계좌개설 에러]" + ex.Message);
            }
            
        }
        
        public void Depoist()          // 입 금
        {
            Console.Write("계좌 ID : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("입금액  : ");
            int money = int.Parse(Console.ReadLine());

            for(int i=0;i<index;i++)
            {
                if (pArray[i].Id == id) 
                {
                    pArray[i].AddMoney(money);
                    Console.WriteLine("입금 완료");
                    return;
                }
            }
            Console.WriteLine("유효하지 않은 ID입니다");
        }
        
        public void Withdraw()         // 출 금
        {
            Console.Write("계좌 ID : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("출금액  : ");
            int money = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                if (pArray[i].Id == id)
                {
                    if (pArray[i].Balance < money)
                    {
                        Console.WriteLine("잔액 부족");
                        return;
                    }

                    pArray[i].MinMoney(money);
                    Console.WriteLine("출금완료");
                    return;
                }
            }
            Console.WriteLine("유효하지 않은 ID입니다");
        }

        public void Inquire()          // 잔액 조회
        {
            for (int i = 0; i < index; i++)
            {
                pArray[i].ShowAllData();
            }
        }

        #endregion
    }
}
