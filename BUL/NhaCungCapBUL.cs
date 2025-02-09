using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class NhaCungCapBUL
    {
        NhaCungCapDAL nccDAL;
        public NhaCungCapBUL()
        {
            nccDAL = new NhaCungCapDAL();
        }

        public DataTable getNhaCungCap()
        {
            return nccDAL.getNhaCungCap();
        }

        public string taoMaNhaCungCap()
        {
            return nccDAL.taoMaNhaCungCap();
        }

        public bool themNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return nccDAL.themNhaCungCap(nhaCungCap);
        }

        public bool suaNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return nccDAL.suaNhaCungCap(nhaCungCap);
        }

        public bool xoaNhaCungCap(string maNCC)
        {
            return nccDAL.xoaNhaCungCap(maNCC);
        }
    }
}
