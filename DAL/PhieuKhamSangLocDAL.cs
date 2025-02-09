using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace DAL
{
    public class PhieuKhamSangLocDAL
    {
        private string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public PhieuKhamSangLocDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public void LuuPhieuKham(PhieuKhamSangLocDTO phieuKham)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "INSERT INTO PhieuKhamSangLoc (MaPhieuKham, ChieuCao, CanNang, ThanNhiet, TrangThai, MaNhanVien, MaPhieuDangKy) " +
                               "VALUES (@MaPhieuKham, @ChieuCao, @CanNang, @ThanNhiet, @TrangThai, @MaNhanVien, @MaPhieuDangKy)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuKham", phieuKham.MaPhieuKham);
                cmd.Parameters.AddWithValue("@ChieuCao", phieuKham.ChieuCao);
                cmd.Parameters.AddWithValue("@CanNang", phieuKham.CanNang);
                cmd.Parameters.AddWithValue("@ThanNhiet", phieuKham.ThanNhiet);
                cmd.Parameters.AddWithValue("@TrangThai", phieuKham.TrangThai);
                cmd.Parameters.AddWithValue("@MaNhanVien", phieuKham.MaNhanVien);
                cmd.Parameters.AddWithValue("@MaPhieuDangKy", phieuKham.MaPhieuDangKy);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public List<PhieuKhamSangLocDTO> getPhieuKhamTheoMaPhieuDangKy(string maPhieuDangKy)
        {
            IQueryable<PhieuKhamSangLocDTO> query = from phieu in db.PhieuKhamSangLocs
                                                    join dangKy in db.ThongTinDangKies on phieu.maPhieuDangKy equals dangKy.maPhieuDangKy
                                                    join kh in db.KhachHangs on dangKy.maKhachHang equals kh.maKhachHang
                                                    where phieu.maPhieuDangKy == maPhieuDangKy
                                                    select new PhieuKhamSangLocDTO
                                                    {
                                                        MaPhieuKham = phieu.maPhieuKham,
                                                        ChieuCao = phieu.chieuCao,
                                                        CanNang = phieu.canNang,
                                                        ThanNhiet = phieu.thanNhiet,
                                                        TrangThai = (int?)phieu.trangThai,
                                                        MaNhanVien = phieu.maNhanVien,
                                                        MaPhieuDangKy = phieu.maPhieuDangKy
                                                    };

            // Trả về danh sách DTO
            return query.ToList();
        }
        public int getMaxMaPhieuKham()
        {
            List<string> maPhieuKhams = db.PhieuKhamSangLocs
                .Select(nv => nv.maPhieuKham)
                .ToList();
            int maxMaPhieuKham = maPhieuKhams
                .Where(mpk => !string.IsNullOrEmpty(mpk) && mpk.Length > 2)
                .Select(mpk => int.Parse(mpk.Substring(2)))
                .DefaultIfEmpty(0)
                .Max();
            return maxMaPhieuKham;
        }


        public List<PhieuKhamDetailsDTO> GetPhieuKhamDetails(string maPhieuKham)
        {
            IQueryable<PhieuKhamDetailsDTO> phieuKhamDetails = from pk in db.PhieuKhamSangLocs
                                                               join dk in db.ThongTinDangKies on pk.maPhieuDangKy equals dk.maPhieuDangKy
                                                               join kh in db.KhachHangs on dk.maKhachHang equals kh.maKhachHang
                                                               join nv in db.NhanViens on pk.maNhanVien equals nv.maNhanVien
                                                               join ct in db.PhieuKham_VacXins on pk.maPhieuKham equals ct.maPhieuKham
                                                               join vc in db.Vaccines on ct.maVaccine equals vc.maVaccine
                                                               where pk.maPhieuKham == maPhieuKham
                                                               select new PhieuKhamDetailsDTO
                                                               {
                                                                   TenVaccine = vc.tenVaccine,
                                                                   MaVaccine = vc.maVaccine,
                                                                   Mui = ct.mui,
                                                                   GiaBan = ct.giaBan,
                                                                   ThanhTien = ct.thanhTien
                                                               };

            return phieuKhamDetails.ToList();
        }

    }
}
