using DAL;
using System;
using System.Data;

namespace BUL
{
    public class LichSuTiemChungBUL
    {
        LichSuTiemChungDAL lichSuTiemChungDAL;
        LichTiemChungDAL lichTiemChungDAL;
        VaccineDAL vaccineDAL;
        public LichSuTiemChungBUL()
        {
            lichSuTiemChungDAL = new LichSuTiemChungDAL();
        }

        public DataTable layDSThongTinLichSuTiemChung()
        {
            return lichSuTiemChungDAL.layDSThongTinLichSuTiemChung();
        }

        public string layMaTuDong()
        {
            return lichSuTiemChungDAL.layMaTuDong();
        }
        public DataTable LayTatCaLichSuTiemChung(string maKhachHang)
        {
            return lichSuTiemChungDAL.LayTatCaLichSuTiemChung(maKhachHang);
        }

        public bool ThemLichSuTiemChung(string maLichSuTiemChung, DateTime ngayTiem, string maLichTiemChung, string maNhanVien)
        {
            return lichSuTiemChungDAL.ThemLichSuTiemChung(maLichSuTiemChung, ngayTiem, maLichTiemChung, maNhanVien);
        }
        public DataTable GetLichSuTiemChungByKhachHang(string maKhachHang)
        {
            return lichSuTiemChungDAL.GetLichSuTiemChungByKhachHang(maKhachHang);
        }
        public DataTable LayTatCaLichTiem()
        {
            return lichTiemChungDAL.LayTatCaLichTiem();
        }

        public DataTable layLichSuTiemChungTiemChungDaTheoDoi()
        {
            return lichSuTiemChungDAL.layLichSuTiemChungTiemChungDaTheoDoi();
        }

    }
}
