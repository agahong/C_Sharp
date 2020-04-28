using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatDelete
    {
        public void Delete(ref Seat[,] seatlist)
        {
            wbSeat ws = new wbSeat();
            int id = ws.GetId();
            ws.AddById(ref seatlist, id, Constant.Empty);
        }
    }
}
