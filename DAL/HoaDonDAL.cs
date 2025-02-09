using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoaDonDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public HoaDonDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable LayThongTinPhieuKhamVaccine(string maPhieuKham)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                 SELECT 
                    pk.maPhieuKham,
                    v.tenVaccine,
                    pk.mui,
                    pk.giaBan,
                    (pk.mui * pk.giaBan) AS thanhTien,
                    kh.hoTen AS tenKhachHang
                FROM 
                    PhieuKham_VacXin pk
                INNER JOIN 
                    Vaccine v ON pk.maVaccine = v.maVaccine
                INNER JOIN 
                    PhieuKhamSangLoc pks ON pk.maPhieuKham = pks.maPhieuKham
                INNER JOIN 
                    ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
                INNER JOIN 
                    KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
                WHERE 
                    pk.maPhieuKham = @maPhieuKham";
            ;

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maPhieuKham", maPhieuKham);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log them)
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
        public DataTable LayDSChoThanhToan()
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT 
                    pks.maPhieuKham,
                    kh.hoTen AS tenKhachHang,
                    FORMAT(CONVERT(DATE, kh.ngaySinh, 101), 'dd/MM/yyyy') AS ngaySinh,
                    FORMAT(tdk.ngayDangKy, 'dd/MM/yyyy') AS ngayDangKy,
                    tdk.hinhThucTiem
                FROM 
                    PhieuKhamSangLoc pks
                INNER JOIN 
                    ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
                INNER JOIN 
                    KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
                WHERE 
                    pks.maPhieuKham NOT IN (SELECT maPhieuKham FROM HoaDon)
            ";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log them)
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }

        public string taoMaHoaDon()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 MaHoaDon FROM HoaDon ORDER BY MaHoaDon DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "HD001";
            string maHD = dt.Rows[0]["maHoaDon"].ToString();
            int so = int.Parse(maHD.Substring(2)) + 1;
            if (so < 10)
                return "HD00" + so;
            if (so < 100)
                return "HD0" + so;
            return "HD" + so;
        }

        public bool LayThongTinHoaDon(string maHoaDon, decimal tienTra, decimal tienThua, decimal tongTien, string phuongThucThanhToan, string noiDung, string maPhieuKham)
        {
            try
            {
                string query = "INSERT INTO HoaDon (MaHoaDon, NgayLap, TienTra, TienThua, TongTien, PhuongThucThanhToan, KieuThanhToan, TrangThai, NoiDung, maPhieuKham) " +
                               "VALUES (@MaHoaDon, @NgayLap, @TienTra, @TienThua, @TongTien, @PhuongThucThanhToan, 'Thanh toán hết', 1, @NoiDung, @maPhieuKham)";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);  // Ngày giờ hiện tại
                        cmd.Parameters.AddWithValue("@TienTra", tienTra);
                        cmd.Parameters.AddWithValue("@TienThua", tienThua);
                        cmd.Parameters.AddWithValue("@TongTien", tongTien);
                        cmd.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThucThanhToan);
                        cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                        cmd.Parameters.AddWithValue("@maPhieuKham", maPhieuKham);

                        // Thực thi câu lệnh
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;  // Trả về true nếu lưu thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, có thể log lỗi hoặc trả về false
                Console.WriteLine("Lỗi khi lưu hóa đơn: " + ex.Message);
                return false;
            }
        }
        public DataTable LayThongTinPhieuKhamGoiVaccine(string maPhieuKham)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT 
                    pk.maPhieuKham,
                    g.tenGoi AS tenGoiVaccine,
                    pk.mui,
                    pk.giaBan,
                    (pk.mui * pk.giaBan) AS thanhTien,
                    kh.hoTen AS tenKhachHang
                FROM 
                    PhieuKham_GoiVacXin pk
                INNER JOIN 
                    GoiVaccine g ON pk.maGoi = g.maGoi
                INNER JOIN 
                    PhieuKhamSangLoc pks ON pk.maPhieuKham = pks.maPhieuKham
                INNER JOIN 
                    ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
                INNER JOIN 
                    KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
                WHERE 
                    pk.maPhieuKham = @maPhieuKham";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maPhieuKham", maPhieuKham);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log them)
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
        public DataTable GetLSThanhToan()
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                kh.hoTen AS tenKhachHang,
                FORMAT(hd.ngayLap, 'dd/MM/yyyy') AS ngayLap,
                hd.tienTra,
                hd.tongTien,
                hd.phuongThucThanhToan,
                CASE 
                    WHEN hd.trangThai = 1 THEN N'Đã thanh toán'
                END AS trangThai,
                hd.noiDung,
                pks.maPhieuKham
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log them)
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
        public DataTable LayDSChoThanhToanTheoTenKhachHang(string tenKhachHang)
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                    pks.maPhieuKham,
                    kh.hoTen AS tenKhachHang,
                    FORMAT(CONVERT(DATE, kh.ngaySinh, 101), 'dd/MM/yyyy') AS ngaySinh,
                    FORMAT(tdk.ngayDangKy, 'dd/MM/yyyy') AS ngayDangKy,
                    tdk.hinhThucTiem
                FROM 
                    PhieuKhamSangLoc pks
                INNER JOIN 
                    ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
                INNER JOIN 
                    KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
                WHERE 
                    pks.maPhieuKham NOT IN (SELECT maPhieuKham FROM HoaDon)
                    AND kh.hoTen LIKE '%' + @tenKhachHang + '%'
            ";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Thêm tham số tên khách hàng
                        command.Parameters.AddWithValue("@tenKhachHang", tenKhachHang);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }



        public DataTable LayTatCaHoaDon()
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
        public DataTable LayHoaDonTheoPhuongThucTienMat()
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
            WHERE 
                hd.phuongThucThanhToan = N'Tiền mặt'";  // Lọc các hóa đơn có phương thức thanh toán là 'Tiền mặt'

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);  // Điền dữ liệu vào DataTable
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in BUL: " + ex.Message);  // Thông báo lỗi
                    }
                }
            }

            return dataTable;  // Trả về bảng dữ liệu chứa thông tin hóa đơn
        }
        public DataTable LayHoaDonTheoPhuongThucChuyenKhoan()
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
            WHERE 
                hd.phuongThucThanhToan = N'Chuyển khoản'";  // Lọc các hóa đơn có phương thức thanh toán là 'Tiền mặt'

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);  // Điền dữ liệu vào DataTable
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in BUL: " + ex.Message);  // Thông báo lỗi
                    }
                }
            }

            return dataTable;  // Trả về bảng dữ liệu chứa thông tin hóa đơn
        }
        public DataTable LayTatCaHoaDonTheoThangNam(int thang, int nam)
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
            WHERE 
                MONTH(hd.ngayLap) = @thang AND YEAR(hd.ngayLap) = @nam";

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Gán tham số cho truy vấn
                        command.Parameters.AddWithValue("@thang", thang);
                        command.Parameters.AddWithValue("@nam", nam);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable; // Trả về DataTable
        }
        public DataTable LayHoaDonTheoPhuongThucTienMatThangNam(int thang, int nam)
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
            WHERE 
                 MONTH(hd.ngayLap) = @thang AND YEAR(hd.ngayLap) = @nam AND hd.phuongThucThanhToan = N'Tiền mặt'";  // Lọc các hóa đơn có phương thức thanh toán là 'Tiền mặt'

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Gán tham số cho truy vấn
                        command.Parameters.AddWithValue("@thang", thang);
                        command.Parameters.AddWithValue("@nam", nam);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;  // Trả về bảng dữ liệu chứa thông tin hóa đơn
        }
        public DataTable LayHoaDonTheoPhuongThucChuyenKhoanThangNam(int thang, int nam)
        {
            DataTable dataTable = new DataTable();

            string query = @"
            SELECT 
                hd.maHoaDon,
                hd.ngayLap,
                hd.tongTien,
                hd.phuongThucThanhToan,
                kh.hoTen
            FROM 
                HoaDon hd
            INNER JOIN 
                PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
            INNER JOIN 
                ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
            INNER JOIN 
                KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
            WHERE 
                 MONTH(hd.ngayLap) = @thang AND YEAR(hd.ngayLap) = @nam AND hd.phuongThucThanhToan = N'Chuyển khoản'";  // Lọc các hóa đơn có phương thức thanh toán là 'Tiền mặt'

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Gán tham số cho truy vấn
                        command.Parameters.AddWithValue("@thang", thang);
                        command.Parameters.AddWithValue("@nam", nam);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        throw new Exception("Error retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;  // Trả về bảng dữ liệu chứa thông tin hóa đơn
        }
        public DataTable LayTongDoanhThuTheoThang(int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                string query = @"
                SELECT MONTH(hd.NgayLap) AS Thang, SUM(DISTINCT hd.TongTien) AS DoanhThu 
                FROM HoaDon hd
                WHERE YEAR(hd.NgayLap) = @Nam 
                GROUP BY MONTH(hd.NgayLap)
                ORDER BY Thang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nam", nam);

                SqlDataAdapter da = new SqlDataAdapter(command);

                connection.Open();
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ThongKeSoLuongKhachHang(int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                string query = @"
                SELECT 
                    MONTH(hd.NgayLap) AS Thang, 
                    COUNT(DISTINCT kh.maKhachHang) AS SoLuongKhachHang 
                FROM HoaDon hd
                INNER JOIN PhieuKhamSangLoc pks ON hd.maPhieuKham = pks.maPhieuKham
                INNER JOIN ThongTinDangKy tdk ON pks.maPhieuDangKy = tdk.maPhieuDangKy
                INNER JOIN KhachHang kh ON tdk.maKhachHang = kh.maKhachHang
                WHERE YEAR(hd.NgayLap) = @Nam 
                GROUP BY MONTH(hd.NgayLap)
                ORDER BY Thang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nam", nam);

                SqlDataAdapter da = new SqlDataAdapter(command);

                connection.Open();
                da.Fill(dt);
            }
            return dt;
        }

        public List<DanhSachGoiVaccineDTO> GetPhieuKhamByHoaDonId(string maPhieuKham)
        {
            List<DanhSachGoiVaccineDTO> danhSachGoiVacXin = new List<DanhSachGoiVaccineDTO>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                string query = @"
                SELECT 
                    pk.MaGoi,
                    pk.MaPhieuKham,
                    pk.GhiChu,
                    pk.MoTa,
                    pk.Mui,
                    pk.GiaBan,
                    pk.ThanhTien,
                    gv.tenGoi  
                FROM PhieuKham_GoiVacXin pk
                JOIN GoiVaccine gv ON pk.MaGoi = gv.MaGoi  
                WHERE pk.MaPhieuKham  = @MaPhieuKham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    connection.Open();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        danhSachGoiVacXin.Add(new DanhSachGoiVaccineDTO
                        {
                            MaGoi = row["MaGoi"].ToString(),
                            TenGoi = row["TenGoi"].ToString(),
                            MaPhieuKham = row["MaPhieuKham"].ToString(),
                            GhiChu = row["GhiChu"].ToString(),
                            MoTa = row["MoTa"].ToString(),
                            Mui = row["Mui"] != DBNull.Value ? Convert.ToInt32(row["Mui"]) : 0,
                            GiaBan = row["GiaBan"] != DBNull.Value ? Convert.ToDecimal(row["GiaBan"]) : 0,
                            ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0
                        });
                    }
                }
            }

            return danhSachGoiVacXin;
        }
        //public HoaDonKhachHangDTO GetHoaDonKhachHangByMaPhieuKham(string maPhieuKham)
        //{
        //    string query = @"
        //          SELECT 
        //        hd.PhuongThucThanhToan,
        //        hd.TongTien,
        //        hd.TienTra,
        //        hd.TienThua,
        //        kh.GioiTinh,
        //        kh.HoTen AS HoTenKhachHang,
        //        kh.MaKhachHang,
        //        kh.SDT,
        //        kh.NgaySinh,
        //        kh.DiaChi,
        //        ngh.hoTen AS HoTenNguoiGiamHo
        //    FROM HoaDon hd
        //    INNER JOIN PhieuKhamSangLoc pk ON hd.MaPhieuKham = pk.MaPhieuKham
        //    INNER JOIN ThongTinDangKy tt ON pk.MaPhieuDangKy = tt.MaPhieuDangKy
        //    INNER JOIN KhachHang kh ON tt.MaKhachHang = kh.MaKhachHang
        //    LEFT JOIN NguoiGiamHo ngh ON kh.maNguoiGiamHo = ngh.maNguoiGiamHo
        //    WHERE hd.MaPhieuKham = @MaPhieuKham";

        //    using (SqlConnection connection = new SqlConnection(strConn)) // Thêm phần khai báo kết nối
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);

        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    return new HoaDonKhachHangDTO
        //                    {
        //                        PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString(),
        //                        TongTien = Convert.ToDecimal(reader["TongTien"]),
        //                        TienTra = Convert.ToDecimal(reader["TienTra"]),
        //                        TienThua = Convert.ToDecimal(reader["TienThua"]),
        //                        GioiTinh = reader["GioiTinh"].ToString(),
        //                        Tuoi = DateTime.Now.Year - Convert.ToDateTime(reader["NgaySinh"]).Year,
        //                        HoTenKhachHang = reader["HoTenKhachHang"].ToString(),
        //                        MaKH = reader["MaKhachHang"].ToString(),
        //                        HoTenNguoiGiamHo = reader["HoTenNguoiGiamHo"].ToString(),
        //                        SDT = reader["SDT"].ToString(),
        //                        DiaChi = reader["DiaChi"].ToString()
        //                    };
        //                }
        //            }
        //            connection.Close();
        //        }
        //    }

        //    return null; // Không tìm thấy dữ liệu
        //}

        public HoaDonKhachHangDTO GetHoaDonKhachHangByMaPhieuKham(string maPhieuKham)
        {
            string query = @"
        SELECT 
            hd.PhuongThucThanhToan,
            hd.TongTien,
            hd.TienTra,
            hd.TienThua,
            kh.GioiTinh,
            kh.HoTen AS HoTenKhachHang,
            kh.MaKhachHang,
            kh.SDT,
            kh.NgaySinh,
            kh.DiaChi,
            ngh.hoTen AS HoTenNguoiGiamHo
        FROM HoaDon hd
        INNER JOIN PhieuKhamSangLoc pk ON hd.MaPhieuKham = pk.MaPhieuKham
        INNER JOIN ThongTinDangKy tt ON pk.MaPhieuDangKy = tt.MaPhieuDangKy
        INNER JOIN KhachHang kh ON tt.MaKhachHang = kh.MaKhachHang
        LEFT JOIN NguoiGiamHo ngh ON kh.maNguoiGiamHo = ngh.maNguoiGiamHo
        WHERE hd.MaPhieuKham = @MaPhieuKham";

            using (SqlConnection connection = new SqlConnection(strConn)) // Thêm phần khai báo kết nối
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime ngaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                            int age = CalculateAge(ngaySinh);

                            return new HoaDonKhachHangDTO
                            {
                                PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString(),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                TienTra = Convert.ToDecimal(reader["TienTra"]),
                                TienThua = Convert.ToDecimal(reader["TienThua"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                Tuoi = age,
                                HoTenKhachHang = reader["HoTenKhachHang"].ToString(),
                                MaKH = reader["MaKhachHang"].ToString(),
                                HoTenNguoiGiamHo = reader["HoTenNguoiGiamHo"].ToString(),
                                SDT = reader["SDT"].ToString(),
                                DiaChi = reader["DiaChi"].ToString()
                            };
                        }
                    }
                    connection.Close();
                }
            }

            return null; // Không tìm thấy dữ liệu
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public List<DanhSachVaccineDTO> GetPhieuKhamByHoaDon(string maPhieuKham)
        {
            List<DanhSachVaccineDTO> danhSachVacXin = new List<DanhSachVaccineDTO>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                string query = @"
                    SELECT 
                        pk.MaVaccine,
                        pk.MaPhieuKham,
                        pk.GhiChu,
                        pk.Mui,
                        pk.GiaBan,
                        pk.ThanhTien,
                        gv.tenVaccine  
                    FROM PhieuKham_VacXin pk
                    JOIN Vaccine gv ON pk.MaVaccine = gv.MaVaccine  
                    WHERE pk.MaPhieuKham  = @MaPhieuKham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieuKham", maPhieuKham);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    connection.Open();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        danhSachVacXin.Add(new DanhSachVaccineDTO
                        {
                            MaVaccine = row["MaVaccine"].ToString(),
                            TenVaccine = row["TenVaccine"].ToString(),
                            MaPhieuKham = row["MaPhieuKham"].ToString(),
                            GhiChu = row["GhiChu"].ToString(),
                            Mui = row["Mui"] != DBNull.Value ? Convert.ToInt32(row["Mui"]) : 0,
                            GiaBan = row["GiaBan"] != DBNull.Value ? Convert.ToDecimal(row["GiaBan"]) : 0,
                            ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0
                        });
                    }
                }
            }

            return danhSachVacXin;
        }
    }
}
