using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatManager : wbSeatList
    {
        #region 싱글톤
        public static SeatManager Singleton { get; private set; }

        static SeatManager()  //static 키워드 -> 한번만 호출
        {
            Singleton = new SeatManager();
        }

        private SeatManager() { }
        #endregion

        public void PrintAll()
        {
            Console.WriteLine("     0   1   2   3   4   5   6   7   8   9");
            Console.WriteLine("==========================================");
            for (int row = 0; row < 4; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < 10; col++)
                {
                    if (seatlist[row, col].Memberid != Constant.Empty)
                        Console.Write("○  ");
                    else
                        Console.Write("{0,2}  ", seatlist[row, col].Id);
                }
                Console.WriteLine("");
            }
        }

        public void AddSeat()
        {
            new SeatAdd().Add(ref seatlist);
        }

        public void DeleteSeat()
        {
            new SeatDelete().Delete(ref seatlist);
        }

        public void MoveSeat()
        {
            new SeatMove().Move(ref seatlist);
        }

        public void ChangeSeat()
        {
            new SeatChange().Change(ref seatlist);
        }

        public void SelectSeat()
        {
            SeatSelect ss = new SeatSelect();
            Seat seat = ss.Select(ref seatlist);
            if (seat == null)
                Console.WriteLine("선택하신 좌석에 학생이 없습니다");
            else
                seat.PrintLine();
        }
    }
}
