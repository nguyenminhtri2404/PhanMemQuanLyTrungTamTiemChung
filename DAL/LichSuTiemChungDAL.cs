using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class LichSuTiemChungDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        LichTiemChungDAL lichTiemChungDAL;
        public LichSuTiemChungDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layDSThongTinLichSuTiemChung()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
                    SELECT 
                    KH.hoTen AS HoTen,
                    KH.ngaySinh AS NgaySinh,
                    KH.sDT AS SoDienThoai,
                    KH.diaChi AS DiaChi,
                    LSTTC.ngayTiem AS NgayTiem,
                    VC.tenVaccine AS TenVaccine,
                    HD.maHoaDon AS MaHoaDon,
                    COUNT(LSTTC.maLichSuTiemChung) AS SoLanTiem 
                FROM 
                    KhachHang AS KH
                INNER JOIN 
                    ThongTinDangKy AS TTĐK ON KH.maKhachHang = TTĐK.maKhachHang
                INNER JOIN
                    PhieuKhamSangLoc AS PK ON TTĐK.maPhieuDangKy = PK.maPhieuDangKy
                INNER JOIN
                    HoaDon AS HD ON PK.maPhieuKham = HD.maPhieuKham
                INNER JOIN 
                    LichSuTiemChung AS LSTTC ON KH.maKhachHang = (SELECT maKhachHang FROM LichTiemChung WHERE maLichTiemChung = LSTTC.maLichTiemChung)
                LEFT JOIN 
                    LichTiemChung AS LTC ON LSTTC.maLichTiemChung = LTC.maLichTiemChung
                LEFT JOIN 
                    KeHoachTiemChung AS KHTC ON LTC.maKeHoach = KHTC.maKeHoach
                LEFT JOIN
                    Vaccine AS VC ON KHTC.maVaccine = VC.maVaccine
                WHERE 
                    HD.maHoaDon NOT IN (SELECT maHoaDon FROM PhieuTheoDoi WHERE maHoaDon IS NOT NULL)
                GROUP BY KH.maKhachHang, KH.hoTen, KH.ngaySinh, KH.sDT, KH.diaChi, LSTTC.ngayTiem, VC.tenVaccine, HD.maHoaDon 
                ORDER BY KH.hoTen, LSTTC.ngayTiem;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }


        public DataTable layLichSuTiemChungTiemChungDaTheoDoi()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
                SELECT 
                    KH.hoTen AS HoTen,
                    KH.ngaySinh AS NgaySinh,
                    KH.sDT AS SoDienThoai,
                    KH.diaChi AS DiaChi,
                    LSTTC.ngayTiem AS NgayTiem,
                    VC.tenVaccine AS TenVaccine,
                    HD.maHoaDon AS MaHoaDon,
                    PTD.thoiGianTiem AS ThoiGianTheoDoi, -- Thời gian theo dõi
                    COUNT(LSTTC.maLichSuTiemChung) AS SoLanTiem -- Đếm số lần tiêm từ LichSuTiemChung
                FROM 
                    KhachHang AS KH
                INNER JOIN 
                    ThongTinDangKy AS TTĐK ON KH.maKhachHang = TTĐK.maKhachHang
                INNER JOIN
                    PhieuKhamSangLoc AS PK ON TTĐK.maPhieuDangKy = PK.maPhieuDangKy
                INNER JOIN
                    HoaDon AS HD ON PK.maPhieuKham = HD.maPhieuKham
                INNER JOIN 
                    LichSuTiemChung AS LSTTC ON KH.maKhachHang = (SELECT maKhachHang FROM LichTiemChung WHERE maLichTiemChung = LSTTC.maLichTiemChung)
                LEFT JOIN 
                    LichTiemChung AS LTC ON LSTTC.maLichTiemChung = LTC.maLichTiemChung
                LEFT JOIN 
                    KeHoachTiemChung AS KHTC ON LTC.maKeHoach = KHTC.maKeHoach
                LEFT JOIN
                    Vaccine AS VC ON KHTC.maVaccine = VC.maVaccine
                LEFT JOIN
                    PhieuTheoDoi AS PTD ON HD.maHoaDon = PTD.maHoaDon -- Kết nối với PhieuTheoDoi để lấy thời gian theo dõi
                WHERE 
                    HD.maHoaDon IN (SELECT maHoaDon FROM PhieuTheoDoi WHERE maHoaDon IS NOT NULL)
                GROUP BY 
                    KH.maKhachHang, KH.hoTen, KH.ngaySinh, KH.sDT, KH.diaChi, LSTTC.ngayTiem, VC.tenVaccine, HD.maHoaDon, PTD.thoiGianTiem
                ORDER BY 
                    KH.hoTen, LSTTC.ngayTiem;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }



        public DataTable getLichSuTiemChung()
        {
            var query = from l in db.LichSuTiemChungs
                        join lt in db.LichTiemChungs on l.maLichTiemChung equals lt.maLichTiemChung
                        join kh in db.KeHoachTiemChungs on lt.maKeHoach equals kh.maKeHoach // Nối với KeHoachTiemChung
                        join v in db.Vaccines on kh.maVaccine equals v.maVaccine // Nối với Vaccine để lấy tenVaccine
                        select new
                        {
                            l.maLichSuTiemChung,
                            l.ngayTiem,
                            l.maLichTiemChung,
                            lt.mui,
                            tenVaccine = v.tenVaccine // Lấy tenVaccine từ bảng Vaccine
                        };

            DataTable dt = new DataTable();
            dt.Columns.Add("maLichSuTiemChung");
            dt.Columns.Add("ngayTiem");
            dt.Columns.Add("maLichTiemChung");
            dt.Columns.Add("mui");
            dt.Columns.Add("tenVaccine"); // Thêm cột cho tenVaccine từ bảng Vaccine

            // Duyệt qua kết quả và thêm vào DataTable
            foreach (var item in query.ToList())
            {
                dt.Rows.Add(item.maLichSuTiemChung, item.ngayTiem, item.maLichTiemChung, item.mui, item.tenVaccine);
            }

            return dt;
        }
        public DataTable GetLichSuTiemChungByKhachHang(string maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                // Updated SQL query to filter by maKhachHang
                string query = @"
            SELECT LichSuTiemChung.MaLichSuTiemChung, 
                   LichTiemChung.maLichTiemChung, 
                   NhanVien.hoTen, 
                   LichSuTiemChung.NgayTiem, 
                   KeHoachTiemChung.maVaccine, 
                   Vaccine.tenVaccine, 
                   LichTiemChung.mui, 
                   KhachHang.hoTen AS hoTenKhachHang
            FROM LichSuTiemChung 
            INNER JOIN LichTiemChung ON LichSuTiemChung.maLichTiemChung = LichTiemChung.maLichTiemChung
            INNER JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach
            INNER JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine
            INNER JOIN NhanVien ON LichSuTiemChung.maNhanVien = NhanVien.maNhanVien
            INNER JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang
            WHERE KhachHang.maKhachHang = @maKhachHang";

                // Create SqlDataAdapter and add parameter
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }
        public DataTable LayTatCaLichSuTiemChung(string maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
                SELECT 
                    LichSuTiemChung.MaLichSuTiemChung, 
                    LichTiemChung.maLichTiemChung, 
                    KhachHang.maKhachHang, 
                    KhachHang.hoTen AS TenKhachHang,
                    LichSuTiemChung.NgayTiem, 
                    KeHoachTiemChung.maVaccine, 
                    Vaccine.tenVaccine, 
                    LichTiemChung.mui
                FROM 
                    LichSuTiemChung
                INNER JOIN 
                    LichTiemChung ON LichSuTiemChung.maLichTiemChung = LichTiemChung.maLichTiemChung
                INNER JOIN 
                    KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach
                INNER JOIN 
                    Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine
                INNER JOIN 
                    KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang
                WHERE 
                    LichTiemChung.TrangThai = 0
                    AND KhachHang.maKhachHang = @maKhachHang"; // Thêm điều kiện lọc theo mã khách hàng

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }


        public string layMaTuDong()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaLichSuTiemChung FROM LichSuTiemChung ORDER BY MaLichSuTiemChung DESC", conn);
                object result = cmd.ExecuteScalar();

                // Nếu chưa có khách hàng nào thì mã bắt đầu từ "KM001"
                if (result == null)
                {
                    return "LSTC0001";
                }

                string lastMaKhuyenMai = result.ToString();

                string numberPart = lastMaKhuyenMai.Substring(4);

                // Tăng số lên 1
                int newNumber = int.Parse(numberPart) + 1;

                return "LSTC" + newNumber.ToString("D4"); // "D4" để đảm bảo có 4 chữ số
            }
        }

        //public bool ThemLichSuTiemChung(string maLichSuTiemChung, DateTime ngayTiem, string maLichTiemChung, string maNhanVien)
        //{
        //    using (SqlConnection conn = new SqlConnection(strConn))
        //    {
        //        // Insert query cho bảng LichSuTiemChung
        //        string insertQuery = @"
        //    INSERT INTO LichSuTiemChung (MaLichSuTiemChung, NgayTiem, MaLichTiemChung, MaNhanVien)
        //    VALUES (@maLichSuTiemChung, @ngayTiem, @maLichTiemChung, @maNhanVien)";

        //        // Update query cho bảng LichTiemChung
        //        string updateLichTiemChungQuery = @"
        //    UPDATE LichTiemChung
        //    SET TrangThai = 0
        //    WHERE MaLichTiemChung = @maLichTiemChung";

        //        // Update query cho bảng ThongTinDangKy
        //        string updateThongTinDangKyQuery = @"
        //    UPDATE ThongTinDangKy
        //    SET TrangThai = 1 
        //    WHERE MaPhieuDangKy = (
        //        SELECT TOP 1 MaPhieuDangKy
        //        FROM PhieuKhamSangLoc
        //        WHERE MaPhieuKham IN (
        //            SELECT MaPhieuKham
        //            FROM LichTiemChung
        //            WHERE MaLichTiemChung = @maLichTiemChung
        //        )
        //    )";

        //        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
        //        SqlCommand updateLichTiemChungCmd = new SqlCommand(updateLichTiemChungQuery, conn);
        //        SqlCommand updateThongTinDangKyCmd = new SqlCommand(updateThongTinDangKyQuery, conn);

        //        // Thêm tham số cho lệnh insert
        //        insertCmd.Parameters.AddWithValue("@maLichSuTiemChung", maLichSuTiemChung);
        //        insertCmd.Parameters.AddWithValue("@ngayTiem", ngayTiem);
        //        insertCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
        //        insertCmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);

        //        // Thêm tham số cho lệnh update
        //        updateLichTiemChungCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
        //        updateThongTinDangKyCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);

        //        conn.Open();

        //        // Thực hiện lệnh insert
        //        int insertResult = insertCmd.ExecuteNonQuery();

        //        // Nếu insert thành công, thực hiện các lệnh update
        //        if (insertResult > 0)
        //        {
        //            updateLichTiemChungCmd.ExecuteNonQuery();
        //            updateThongTinDangKyCmd.ExecuteNonQuery();
        //            conn.Close();
        //            return true; // Cả insert và update đều thành công
        //        }

        //        conn.Close();
        //        return false; // Insert thất bại
        //    }
        //}


        public bool ThemLichSuTiemChung(string maLichSuTiemChung, DateTime ngayTiem, string maLichTiemChung, string maNhanVien)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                // Insert query for LichSuTiemChung
                string insertQuery = @"
            INSERT INTO LichSuTiemChung (MaLichSuTiemChung, NgayTiem, MaLichTiemChung, MaNhanVien)
            VALUES (@maLichSuTiemChung, @ngayTiem, @maLichTiemChung, @maNhanVien)";

                // Update query for LichTiemChung
                string updateLichTiemChungQuery = @"
            UPDATE LichTiemChung
            SET TrangThai = 0
            WHERE MaLichTiemChung = @maLichTiemChung";

                // Update query for ThongTinDangKy
                string updateThongTinDangKyQuery = @"
            UPDATE ThongTinDangKy
            SET TrangThai = 1
            WHERE MaKhachHang = (SELECT MaKhachHang FROM LichTiemChung WHERE MaLichTiemChung = @maLichTiemChung)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                SqlCommand updateLichTiemChungCmd = new SqlCommand(updateLichTiemChungQuery, conn);
                SqlCommand updateThongTinDangKyCmd = new SqlCommand(updateThongTinDangKyQuery, conn);

                // Add parameters for insert command
                insertCmd.Parameters.AddWithValue("@maLichSuTiemChung", maLichSuTiemChung);
                insertCmd.Parameters.AddWithValue("@ngayTiem", ngayTiem);
                insertCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
                insertCmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);

                // Add parameter for update commands
                updateLichTiemChungCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);
                updateThongTinDangKyCmd.Parameters.AddWithValue("@maLichTiemChung", maLichTiemChung);

                conn.Open();

                // Execute the insert command
                int insertResult = insertCmd.ExecuteNonQuery();

                // If the insert was successful, execute the update commands
                if (insertResult > 0)
                {
                    updateLichTiemChungCmd.ExecuteNonQuery();
                    updateThongTinDangKyCmd.ExecuteNonQuery();
                    conn.Close();
                    return true; // Insert and updates were successful
                }

                conn.Close();
                return false; // Insert failed
            }
        }

        public DataTable LayTatCaLichSuTiem(string maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
            SELECT 
                LichSuTiemChung.MaLichSuTiemChung,
                LichTiemChung.maLichTiemChung,
                KhachHang.maKhachHang,
                KhachHang.hoTen AS hoTenKhachHang,
                Vaccine.maVaccine,
                Vaccine.tenVaccine,
                LichTiemChung.ngayHen,
                LichTiemChung.mui,
                LichTiemChung.ghiChu
            FROM LichSuTiemChung
            JOIN LichTiemChung ON LichSuTiemChung.maLichTiemChung = LichTiemChung.maLichTiemChung
            JOIN KhachHang ON LichTiemChung.maKhachHang = KhachHang.maKhachHang
            JOIN KeHoachTiemChung ON LichTiemChung.maKeHoach = KeHoachTiemChung.maKeHoach
            JOIN Vaccine ON KeHoachTiemChung.maVaccine = Vaccine.maVaccine
            WHERE LichTiemChung.trangThai = 0
                  AND KhachHang.maKhachHang = @maKhachHang";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                    DataTable dataTable = new DataTable();

                    try
                    {
                        conn.Open();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            throw new Exception($"Không tìm thấy dữ liệu cho mã khách hàng '{maKhachHang}' với trạng thái = 0.");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi truy vấn: {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }

                    return dataTable;
                }
            }
        }



    }
}
