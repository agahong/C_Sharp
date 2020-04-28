using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatChange
    {
        public void Change(ref Seat[,] seatlist)
        {
            wbSeat ws = new wbSeat();
            Console.WriteLine("이동시킬 좌석 선택");
            int id1 = ws.GetId();

            Console.WriteLine("이동하고싶은 좌석 선택");
            int id2 = ws.GetId();

            Seat seat1 = ws.GetDataFromId(seatlist, id1);
            Seat seat2 = ws.GetDataFromId(seatlist, id2);

            if (seat2.Memberid == Constant.Empty)
            {
                Console.WriteLine("선택하신 좌석에 학생이 없습니다.");
            }
            else
            {
                //멤버 아이디 교환
                int temp;
                temp = seat2.Memberid;
                seat2.Memberid = seat1.Memberid;
                seat1.Memberid = temp;
            }
        }
    }
}
