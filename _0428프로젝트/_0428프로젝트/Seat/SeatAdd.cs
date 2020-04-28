using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatAdd
    {
        public void Add(ref Seat[,] seatlist)
        {
            int memid, id;

            while (true)
            {
                memid = wbGlobal.InputInt("학생 아이디>>");
                if (IdCheck(seatlist, memid) == false)
                {
                    Console.WriteLine("중복된 id");
                    continue;
                }
                break;
            }

            id = new wbSeat().GetId();

            new wbSeat().AddById(ref seatlist, id, memid);
        }

        private bool IdCheck(Seat[,] Seatlist, int memid)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (Seatlist[row, col].Memberid == memid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
