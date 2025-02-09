using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class NhanVienBUL
    {
        NhanVienDAL nhanVienDAL;

        public NhanVienBUL()
        {
            nhanVienDAL = new NhanVienDAL();
        }
        public DataTable LayTatCaNhanVien()
        {
            return nhanVienDAL.LayTatCaNhanVien();
        }

        public List<NhanVienDTO> GetNhanVienCombo()
        {
            return nhanVienDAL.getNhanVienCombo();
        }

        public NhanVienDTO getNhanVienByTenDangNhap(string maNhanVien)
        {
            return nhanVienDAL.getNhanVienByTenDangNhap(maNhanVien);
        }

        public string taoMaNhanVien()
        {
            return nhanVienDAL.taoMaNhanVien();
        }

        public bool themNhanVien(NhanVienDTO nhanVienDTO)
        {
            return nhanVienDAL.themNhanVien(nhanVienDTO);
        }

        public bool suaNhanVien(NhanVienDTO nhanVienDTO)
        {
            return nhanVienDAL.suaNhanVien(nhanVienDTO);
        }

        public bool xoaNhanVien(string maNhanVien)
        {
            return nhanVienDAL.xoaNhanVien(maNhanVien);
        }

        public DataTable getBacSi()
        {
            return nhanVienDAL.getBacSi();
        }
    }
}
