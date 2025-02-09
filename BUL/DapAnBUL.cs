using DAL;
using DTO;

namespace BUL
{
    public class DapAnBUL
    {
        private DapAnDAL dapAnDAL;

        public DapAnBUL()
        {
            dapAnDAL = new DapAnDAL();
        }

        public void LuuDapAn(DapAnDTO dapAn)
        {
            dapAnDAL.LuuDapAn(dapAn);
        }
    }
}
