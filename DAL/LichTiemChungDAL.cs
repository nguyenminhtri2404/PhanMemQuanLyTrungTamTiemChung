using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class LichTiemChungDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public LichTiemChungDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable LayTatCaLichTiem()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT LichTiemChung.MaLichTiemChung, LichTiemChung.maKhachHang, KhachHang.hoTen AS hoTenKhachHang, " +
                               "NhanVien.hoTen AS hoTenNhanVien, Vaccine.maVaccine, Vaccine.tenVaccine, LichTiemChung.ngayHen, " +
                               "LichTiemChung.mui, LichTiemChung.ghiChu " +
                               "FROM LichTiemChung " +
                               "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                               "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
                               "JOIN NhanVien ON LichTiemChung.maNhanVien = NhanVien.maNhanVien " +
                               "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
                               "WHERE LichTiemChung.trangThai = 1";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }
        public DataTable LayTatCaLichSuTiem()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT LichTiemChung.MaLichTiemChung, LichTiemChung.maKhachHang, KhachHang.hoTen AS hoTenKhachHang, " +
                               "NhanVien.hoTen AS hoTenNhanVien, Vaccine.maVaccine, Vaccine.tenVaccine, LichTiemChung.ngayHen, " +
                               "LichTiemChung.mui, LichTiemChung.ghiChu " +
                               "FROM LichTiemChung " +
                               "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                               "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
                               "JOIN NhanVien ON LichTiemChung.maNhanVien = NhanVien.maNhanVien " +
                               "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
                               "WHERE LichTiemChung.trangThai = 0";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }
        public List<LichTiemChungInfo> getLichTiemChung(string maLichTiemChung)
        {
            List<LichTiemChungInfo> resultList = new List<LichTiemChungInfo>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT LichTiemChung.MaLichTiemChung, KhachHang.hoTen, Vaccine.tenVaccine, LichTiemChung.mui " +
                               "FROM LichTiemChung " +
                               "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                               "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
                               "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
                               "WHERE LichTiemChung.MaLichTiemChung = @maLichTiemChung AND LichTiemChung.trangThai = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichTiemChungInfo item = new LichTiemChungInfo(
                        reader["MaLichTiemChung"].ToString(),
                        reader["hoTen"].ToString(),
                        reader["tenVaccine"].ToString(),
                        (int)reader["mui"]
                    );

                    resultList.Add(item);
                }
            }

            return resultList;
        }

        public string GetMaVaccineByMaTiemChung(string maLichTiemChung)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT KeHoachTiemChung.maVaccine " +
                       "FROM LichTiemChung " +
                       "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                       "WHERE LichTiemChung.maLichTiemChung = @maLichTiemChung";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                return result?.ToString();
            }
        }

        public List<LichTiemChungDTO> getLichTiemChungTheoMaKH(string maKhachHang)
        {
            IQueryable<LichTiemChungDTO> query = from p in db.LichTiemChungs
                                                 join kh in db.KhachHangs on p.maKhachHang equals kh.maKhachHang
                                                 join khtc in db.KeHoachTiemChungs on p.maKeHoach equals khtc.maKeHoach // Join với KeHoachTiemChung
                                                 where p.maKhachHang == maKhachHang
                                                 select new LichTiemChungDTO
                                                 {
                                                     MaLichTiemChung = p.maLichTiemChung,
                                                     MaKeHoach = khtc.maKeHoach,
                                                     NgayHen = p.ngayHen,
                                                     Mui = p.mui,
                                                     GhiChu = p.ghiChu,
                                                     TrangThai = p.trangThai,
                                                     DiaChi = kh.diaChi,
                                                     HoTen = kh.hoTen,
                                                     NgaySinh = kh.ngaySinh,
                                                     GioiTinh = kh.gioiTinh,
                                                     MaKhachHang = p.maKhachHang,
                                                     MaNhanVien = p.maNhanVien // Lấy maNhanVien từ KeHoachTiemChung
                                                 };

            // Trả về danh sách DTO
            return query.ToList();
        }


        public bool themLichTiemChung(LichTiemChungDTO lichtiemchung)
        {
            try
            {
                // Tạo đối tượng LichChieu mới từ DTO
                LichTiemChung newLichTiemChung = new LichTiemChung
                {
                    mui = lichtiemchung.Mui,
                    ngayHen = lichtiemchung.NgayHen,
                    ghiChu = lichtiemchung.GhiChu,
                    maNhanVien = lichtiemchung.MaNhanVien, // Gán mã nhân viên
                    maKhachHang = lichtiemchung.MaKhachHang, // Gán mã khách hàng
                    maLichTiemChung = lichtiemchung.MaLichTiemChung, // Gán mã lịch tiêm chủng
                    maKeHoach = lichtiemchung.MaKeHoach,
                    trangThai = lichtiemchung.TrangThai
                };

                // Thêm đối tượng LichChieu vào bảng
                db.LichTiemChungs.InsertOnSubmit(newLichTiemChung);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public int GetMaxMaLichTiemChung()
        {
            List<string> maLichTiemChungs = db.LichTiemChungs
                .Select(dk => dk.maLichTiemChung)
                .ToList();

            int maxMaLichTiemChung = maLichTiemChungs
                .Where(ml => !string.IsNullOrEmpty(ml) && ml.Length > 2)
                .Select(ml => int.Parse(ml.Substring(3)))
                .DefaultIfEmpty(0)
                .Max();

            return maxMaLichTiemChung;
        }
        public int GetSoMuiTiem(string maLichTiemChung)
        {
            string query = "SELECT mui FROM LichTiemChung WHERE maLichTiemChung = @maLichTiemChung";
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
        public bool KiemTraLichSuTiemChungHopLe(string maLichTiemChung, int soMuiHienTai, string maKhachHang)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM LichSuTiemChung lstc
                INNER JOIN LichTiemChung ltc ON lstc.maLichTiemChung = ltc.maLichTiemChung
                WHERE lstc.maLichTiemChung = @maLichTiemChung 
                AND ltc.mui < @soMuiHienTai - 1
                AND ltc.maKhachHang = @maKhachHang";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
                    command.Parameters.AddWithValue("@soMuiHienTai", soMuiHienTai);
                    command.Parameters.AddWithValue("@maKhachHang", maKhachHang);  // Thêm tham số cho maKhachHang

                    connection.Open();

                    // Thực thi câu truy vấn và lấy kết quả đếm số mũi tiêm đã thực hiện
                    int count = (int)command.ExecuteScalar();

                    // Kiểm tra nếu số mũi tiêm đã có trước đó bằng số mũi cần tiêm trước
                    return count == soMuiHienTai - 1;
                }
            }
        }
        public string GetMaKhachHangByMaLichTiemChung(string maLichTiemChung)
        {
            string maKhachHang = string.Empty;
            string query = @"
                SELECT maKhachHang
                FROM LichTiemChung
                WHERE maLichTiemChung = @maTiemChung";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maTiemChung", maLichTiemChung);
                    connection.Open();
                    maKhachHang = command.ExecuteScalar() as string;
                }
            }

            return maKhachHang;
        }
        public bool KiemTraMuiTruocDaTiem(string maKhachHang, int soMuiHienTai)
        {
            // Kiểm tra xem mũi trước đó đã được tiêm hay chưa
            string query = @"
               SELECT COUNT(*)
                FROM LichSuTiemChung lstc
                JOIN LichTiemChung lt ON lstc.maLichTiemChung = lt.maLichTiemChung
                WHERE lt.maKhachHang = @maKhachHang
                AND lt.mui = @soMuiHienTai - 1";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                    command.Parameters.AddWithValue("@soMuiHienTai", soMuiHienTai);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Nếu đã tiêm mũi trước đó
                }
            }
        }



        public DataTable LayTatCaLichHen()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT LichTiemChung.MaLichTiemChung, LichTiemChung.maKhachHang, KhachHang.hoTen AS hoTenKhachHang, " +
                               "NhanVien.hoTen AS hoTenNhanVien, Vaccine.maVaccine, Vaccine.tenVaccine, LichTiemChung.ngayHen, " +
                               "LichTiemChung.mui, LichTiemChung.ghiChu " +
                               "FROM LichTiemChung " +
                               "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                               "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
                               "JOIN NhanVien ON LichTiemChung.maNhanVien = NhanVien.maNhanVien " +
                               "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
                               "WHERE LichTiemChung.trangThai = 0";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }

        public DataTable LayTatCaLichHenTheoTenKhachHang(string tenKhachHang)
        {
            string query = "SELECT LichTiemChung.MaLichTiemChung, LichTiemChung.maKhachHang, KhachHang.hoTen AS hoTenKhachHang, " +
               "NhanVien.hoTen AS hoTenNhanVien, Vaccine.maVaccine, Vaccine.tenVaccine, LichTiemChung.ngayHen, " +
               "LichTiemChung.mui, LichTiemChung.ghiChu " +
               "FROM LichTiemChung " +
               "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
               "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
               "JOIN NhanVien ON LichTiemChung.maNhanVien = NhanVien.maNhanVien " +
               "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
               "WHERE LichTiemChung.trangThai = 1 AND KhachHang.hoTen LIKE '%' + @tenKhachHang + '%'";


            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable LayTatCaLichHenTheoNgayHen(DateTime ngayHen)
        {
            string query = "SELECT LichTiemChung.MaLichTiemChung, LichTiemChung.maKhachHang, KhachHang.hoTen AS hoTenKhachHang, " +
                           "NhanVien.hoTen AS hoTenNhanVien, Vaccine.maVaccine, Vaccine.tenVaccine, LichTiemChung.ngayHen, " +
                           "LichTiemChung.mui, LichTiemChung.ghiChu " +
                           "FROM LichTiemChung " +
                           "JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach " +
                           "JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang " +
                           "JOIN NhanVien ON LichTiemChung.maNhanVien = NhanVien.maNhanVien " +
                           "JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine " +
                           "WHERE LichTiemChung.trangThai = 1 AND CAST(LichTiemChung.ngayHen AS DATE) = @NgayHen";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Truyền tham số ngày hẹn
                    command.Parameters.AddWithValue("@NgayHen", ngayHen.Date);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public List<(LichTiemChungDTO, LichSuTiemChungDTO)> LayLichHenVaLichSu()
        {
            List<(LichTiemChungDTO, LichSuTiemChungDTO)> danhSach = new List<(LichTiemChungDTO, LichSuTiemChungDTO)>();

            string query = @"
               SELECT 
                lt.MaLichTiemChung, 
                lt.MaKhachHang, 
                lt.MaNhanVien, 
                khtc.MaVaccine,
                v.TenVaccine,    
                lt.NgayHen, 
                kh.HoTen, 
                kh.GioiTinh, 
                kh.NgaySinh, 
                kh.DiaChi, 
                lt.Mui, 
                lt.GhiChu, 
                lt.TrangThai, 
                lstc.MaLichSuTiemChung, 
                lstc.NgayTiem, 
                lstc.MaNhanVien AS NV_Tiem, 
                lt.Mui AS MuiTiem 
            FROM 
                LichTiemChung lt
            LEFT JOIN 
                LichSuTiemChung lstc ON lt.MaLichTiemChung = lstc.MaLichTiemChung
            LEFT JOIN 
                KhachHang kh ON lt.MaKhachHang = kh.MaKhachHang
            LEFT JOIN 
                KeHoachTiemChung khtc ON lt.MaKeHoach = khtc.MaKeHoach 
            LEFT JOIN 
                Vaccine v ON khtc.MaVaccine = v.MaVaccine;";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LichTiemChungDTO lichTiemChung = new LichTiemChungDTO
                            {
                                MaLichTiemChung = reader["MaLichTiemChung"].ToString(),
                                MaKhachHang = reader["MaKhachHang"].ToString(),
                                MaNhanVien = reader["MaNhanVien"].ToString(),
                                MaVaccine = reader["MaVaccine"].ToString(),
                                NgayHen = Convert.ToDateTime(reader["NgayHen"]),
                                HoTen = reader["HoTen"].ToString(),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                NgaySinh = reader["NgaySinh"] as DateTime?,
                                DiaChi = reader["DiaChi"].ToString(),
                                Mui = Convert.ToInt32(reader["Mui"]),
                                GhiChu = reader["GhiChu"].ToString(),
                                TrangThai = reader["TrangThai"] as int?
                            };

                            LichSuTiemChungDTO lichSuTiemChung = reader["MaLichSuTiemChung"] == DBNull.Value
                                ? null
                                : new LichSuTiemChungDTO
                                {
                                    MaLichSuTiemChung = reader["MaLichSuTiemChung"].ToString(),
                                    NgayTiem = Convert.ToDateTime(reader["NgayTiem"]),
                                    MaLichTiemChung = reader["MaLichTiemChung"].ToString(),
                                    MaNhanVien = reader["NV_Tiem"].ToString(),
                                    Mui = Convert.ToInt32(reader["MuiTiem"]),
                                    MaVaccine = reader["VaccineTiem"].ToString(),
                                    TenVaccine = reader["TenVaccine"].ToString()
                                };

                            danhSach.Add((lichTiemChung, lichSuTiemChung));
                        }
                    }
                }
            }

            return danhSach;
        }
        public string LayEmailTheoMaKhachHang(string maKhachHang)
        {
            string email = string.Empty;

            string query = "SELECT email FROM KhachHang WHERE maKhachHang = @maKH";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maKH", maKhachHang);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }

            return email;
        }


        public string LayTenVaccineTheoMaLich(string maLichTiemChung)
        {
            string tenVaccine = string.Empty;
            string query = @"
            SELECT V.tenVaccine 
            FROM LichTiemChung L
            INNER JOIN KeHoachTiemChung K ON L.maKeHoach = K.maKeHoach
            INNER JOIN Vaccine V ON K.maVaccine = V.maVaccine
            WHERE L.maLichTiemChung = @maLich";
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maLich", maLichTiemChung);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenVaccine = reader["tenVaccine"].ToString();
                        }
                    }
                    connection.Close();
                }
            }
            return tenVaccine;
        }
        public int LaySoMuiTheoMaLich(string maLichTiemChung)
        {
            int soMui = 0;
            string query = @"
            SELECT mui 
            FROM LichTiemChung 
            WHERE maLichTiemChung = @maLich";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maLich", maLichTiemChung);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soMui = Convert.ToInt32(reader["mui"]);
                        }
                    }
                    connection.Close();
                }
            }
            return soMui;
        }



    }
}
