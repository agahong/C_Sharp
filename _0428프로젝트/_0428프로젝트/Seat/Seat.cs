using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    /// <summary>
    /// Id좌석에 memberid에 해당하는 학생이 앉아있다.
    /// 만약 좌석이 비어있다면 memberid의 값은 -1이다.
    /// 좌석은 2차원 배열로 관리가 되어질것이다.
    /// 따라서 Id좌석이 몇행 몇열의 값인지에 대한 저장정보가 필요하다.
    /// </summary>
    class Seat
    {
        public int Id { get; private set; }
        public int Memberid { get; set; }

        public int RowId { get; private set; }
        public int ColId { get; private set; }

        public Seat(int id, int rid, int cid)
        {
            Id = id;
            RowId = rid;
            ColId = cid;
            Memberid = Constant.Empty;  //-1
        }

        public void PrintLine()
        {
            Console.WriteLine("좌석번호   : {0}", Id);
            Console.WriteLine("학생아이디 : {0}", Memberid);
            Console.WriteLine("좌석위치   : ({0},{1})", RowId, ColId);
        }
    }
}
