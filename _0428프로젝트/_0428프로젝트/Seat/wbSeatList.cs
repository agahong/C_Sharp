using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class wbSeatList
    {
        public Seat[,] seatlist = new Seat[4, 10];

        public wbSeatList()
        {
            int idx = 0;
            for(int row = 0; row < 4; row++)
            {
                for(int col = 0; col < 10; col++)
                {
                    seatlist[row, col] = new Seat(++idx, row, col);
                }
            }   
        }
    }
}
