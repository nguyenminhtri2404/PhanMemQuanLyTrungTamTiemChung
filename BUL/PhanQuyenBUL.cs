using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class PhanQuyenBUL
    {
        PhanQuyenDAL phanQuyenDAL;

        public PhanQuyenBUL()
        {
            phanQuyenDAL = new PhanQuyenDAL();
        }

        public DataTable layDanhSachQuyen(string maChucVu)
        {
            return phanQuyenDAL.layDanhSachQuyen(maChucVu);
        }

        public DataTable getDSQuyen()
        {
            return phanQuyenDAL.getDSQuyen();
        }

        public bool themPhanQuyen(PhanQuyenDTO phanQuyenDTO)
        {
            return phanQuyenDAL.themPhanQuyen(phanQuyenDTO);
        }

        public bool xoaPhanQuyen(string maManHinh, string maChucVu)
        {
            return phanQuyenDAL.xoaPhanQuyen(maManHinh, maChucVu);
        }

        public bool suaPhanQuyen(PhanQuyenDTO phanQuyenDTO)
        {
            return phanQuyenDAL.suaPhanQuyen(phanQuyenDTO);
        }
    }
}
