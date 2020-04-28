using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatSelect
    {
        public Seat Select(ref Seat[,] seatlist)
        {
            wbSeat ws = new wbSeat();
            int id = ws.GetId();

            Seat seat = ws.GetDataFromId(seatlist, id);

            if (seat.Memberid == Constant.Empty)
                return null;
            else
                return seat;
        }
    }
}
