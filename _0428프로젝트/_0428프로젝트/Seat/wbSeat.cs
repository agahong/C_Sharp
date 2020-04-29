using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class wbSeat
    {
        public void AddById(ref Seat[,] seatlist, int id, int memid)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (seatlist[row, col].Id == id)
                    {
                        seatlist[row, col].Memberid = memid;
                    }
                }
            }
        }
        
        public int GetId()
        {
            int id;
            while (true)
            {
                id = wbGlobal.InputInt("좌석번호(1~40)>>");
                if (1 <= id && id <= 40)
                    return id;
                Console.WriteLine("범위 내의 값을 입력하세요");
            }
        }

        public Seat GetDataFromId(Seat[,] seatlist, int id)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (seatlist[row, col].Id == id)
                    {
                        return seatlist[row, col];
                    }
                }
            }
            return null;
        }
    }
}
