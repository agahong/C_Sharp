using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberDelete
    {
        public bool Delete(WbMemberList memlist)
        {
            int id = wbGlobal.InputInt("삭제하실 분의 아이디 : ");
            foreach (Member mem in memlist)
            {
                if (mem.Id == id)
                {
                    memlist.Remove(mem);
                    Console.WriteLine("[" + id + "]님이 삭제되었습니다.");
                    return true;
                }
            }
            return false;
        }
    }
}
