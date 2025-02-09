using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace DAL
{
    public class TiemChungDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public TiemChungDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable getTiemChung()
        {
            var query = from p in db.ThongTinDangKies
                        join pl in db.KhachHangs on p.maKhachHang equals pl.maKhachHang
                        select new
                        {
                            p.maPhieuDangKy,
                            p.hinhThucTiem,
                            pl.hoTen,
                            pl.gioiTinh,
                            pl.diaChi,
                            pl.ngaySinh,
                            p.ngayDangKy,
                        };
            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maPhieuDangKy");
            dt.Columns.Add("hinhThucTiem");
            dt.Columns.Add("hoTen");
            dt.Columns.Add("gioiTinh");
            dt.Columns.Add("ngaySinh");
            dt.Columns.Add("diaChi");
            dt.Columns.Add("ngayDangKy");

            // Duyệt qua kết quả và thêm vào DataTable
            foreach (var item in query.ToList())
            {
                dt.Rows.Add(item.maPhieuDangKy, item.hinhThucTiem, item.hoTen, item.gioiTinh, item.ngaySinh, item.diaChi, item.ngayDangKy);
            }

            return dt;
        }
        public DataTable getTiemChungDangCho()
        {
            var query = from p in db.ThongTinDangKies
                        join pl in db.KhachHangs on p.maKhachHang equals pl.maKhachHang
                        select new
                        {
                            p.maPhieuDangKy,
                            p.hinhThucTiem,
                            pl.hoTen,
                            pl.gioiTinh,
                            pl.diaChi,
                            pl.ngaySinh,
                            p.ngayDangKy,
                            pl.maKhachHang,
                            p.trangThai,
                        };
            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maPhieuDangKy");
            dt.Columns.Add("hinhThucTiem");
            dt.Columns.Add("hoTen");
            dt.Columns.Add("gioiTinh");
            dt.Columns.Add("ngaySinh");
            dt.Columns.Add("diaChi");
            dt.Columns.Add("ngayDangKy");
            dt.Columns.Add("maKhachHang");
            dt.Columns.Add("trangThai");
            // Duyệt qua kết quả và thêm vào DataTable
            foreach (var item in query.ToList())
            {
                dt.Rows.Add(item.maPhieuDangKy, item.hinhThucTiem, item.hoTen, item.gioiTinh, item.ngaySinh, item.diaChi, item.ngayDangKy, item.maKhachHang, item.trangThai);
            }

            return dt;
        }
        public void SaveTiemChung(ThongTinDangKy thongTinDangKy)
        {
            db.ThongTinDangKies.InsertOnSubmit(thongTinDangKy);
            db.SubmitChanges();
        }

        public int GetMaxMaPhieuDangKy()
        {
            List<string> maPhieuDKs = db.ThongTinDangKies
                .Select(dk => dk.maPhieuDangKy)
                .ToList();

            int maxMaDK = maPhieuDKs
                .Where(mdk => !string.IsNullOrEmpty(mdk) && mdk.Length > 2)
                .Select(mdk => int.Parse(mdk.Substring(3)))
                .DefaultIfEmpty(0)
                .Max();

            return maxMaDK;
        }
        public string GetMaPhieuByTenKhachHang(string tenKhachHang)
        {
            string result = (from p in db.ThongTinDangKies
                             join pl in db.KhachHangs on p.maKhachHang equals pl.maKhachHang
                             where pl.hoTen == tenKhachHang
                             select p.maPhieuDangKy).FirstOrDefault();

            return result;
        }


    }
}
