using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatMove
    {
        public void Move(ref Seat[,] seatlist)
        {
            wbSeat ws = new wbSeat();
            Console.WriteLine("이동시킬 좌석 선택");
            int id1 = ws.GetId();

            Console.WriteLine("이동하고싶은 좌석 선택");
            int id2 = ws.GetId();

            Seat seat1 = ws.GetDataFromId(seatlist, id1);
            Seat seat2 = ws.GetDataFromId(seatlist, id2);

            if(seat2.Memberid==Constant.Empty)
            {
                seat2.Memberid = seat1.Memberid;
                seat1.Memberid = Constant.Empty;
            }
            else
            {
                Console.WriteLine("선택하신 좌석에 이미 학생이 있습니다.");
            }
        }
    }
}
