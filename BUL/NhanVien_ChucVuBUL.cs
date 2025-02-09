using DAL;
using System.Data;

namespace BUL
{
    public class NhanVien_ChucVuBUL
    {
        NhanVien_ChucVuDAL nhanVien_ChucVuDAL;
        public NhanVien_ChucVuBUL()
        {
            nhanVien_ChucVuDAL = new NhanVien_ChucVuDAL();
        }

        public DataTable layDanhSachNhanVienChucVu()
        {
            return nhanVien_ChucVuDAL.layDanhSachNhanVienChucVu();
        }

        public bool themNhanVienChucVu(DTO.NhanVien_ChucVuDTO nhanVien_ChucVuDTO)
        {
            return nhanVien_ChucVuDAL.themNhanVienChucVu(nhanVien_ChucVuDTO);
        }

        public bool xoaNhanVienChucVu(string tenDangNhap, string maChucVu)
        {
            return nhanVien_ChucVuDAL.xoaNhanVienChucVu(tenDangNhap, maChucVu);
        }

        public bool suaNhanVienChucVu(DTO.NhanVien_ChucVuDTO nhanVien_ChucVuDTO)
        {
            return nhanVien_ChucVuDAL.suaNhanVienChucVu(nhanVien_ChucVuDTO);
        }
    }
}
