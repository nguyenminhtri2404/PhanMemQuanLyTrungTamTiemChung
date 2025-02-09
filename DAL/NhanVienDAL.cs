using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class NhanVienDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public NhanVienDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable LayTatCaNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                // Query để lấy dữ liệu khách hàng
                string query = "SELECT * FROM NhanVien";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }

        public List<NhanVienDTO> getNhanVienCombo()
        {
            List<NhanVienDTO> dsnv = (from lp in db.NhanViens
                                      select new NhanVienDTO
                                      {
                                          maNhanVien = lp.maNhanVien,
                                          hoTen = lp.hoTen
                                      }).ToList();

            return dsnv;
        }

        //lấy thông tin nhân viên của bảng Nhân viên
        public NhanVienDTO getNhanVienByTenDangNhap(string tenDangNhap)
        {
            NhanVienDTO info = (from tk in db.TaiKhoans
                                join nv in db.NhanViens on tk.maNhanVien equals nv.maNhanVien
                                where tk.tenDangNhap == tenDangNhap
                                select new NhanVienDTO
                                {
                                    maNhanVien = nv.maNhanVien,
                                    hoTen = nv.hoTen,
                                }).FirstOrDefault();

            return info;

        }

        public string taoMaNhanVien()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maNhanVien FROM NhanVien ORDER BY maNhanVien DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "NV01";
            string maNV = dt.Rows[0]["maNhanVien"].ToString();
            int so = int.Parse(maNV.Substring(2)) + 1;
            if (so < 10)
                return "NV00" + so;
            if (so < 100)
                return "NV0" + so;
            return "NV" + so;
        }

        public bool themNhanVien(NhanVienDTO nhanVienDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO NhanVien(maNhanVien, hoTen, ngaySinh, gioiTinh, diaChi, sDT, email) VALUES('" + nhanVienDTO.maNhanVien + "', N'" + nhanVienDTO.hoTen + "', '" + nhanVienDTO.ngaySinh + "', N'" + nhanVienDTO.gioiTinh + "', N'" + nhanVienDTO.diaChi + "', '" + nhanVienDTO.sDT + "', '" + nhanVienDTO.email + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (kq > 0)
                return true;
            return false;
        }

        public bool suaNhanVien(NhanVienDTO nhanVienDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE NhanVien SET hoTen = N'" + nhanVienDTO.hoTen + "', ngaySinh = '" + nhanVienDTO.ngaySinh + "', gioiTinh = N'" + nhanVienDTO.gioiTinh + "', diaChi = N'" + nhanVienDTO.diaChi + "', sDT = '" + nhanVienDTO.sDT + "', email = '" + nhanVienDTO.email + "' WHERE maNhanVien = '" + nhanVienDTO.maNhanVien + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (kq > 0)
                return true;
            return false;
        }

        public bool xoaNhanVien(string maNhanVien)
        {
            //Try catch để bắt lỗi không thể xóa khóa ngoại
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "DELETE FROM NhanVien WHERE maNhanVien = '" + maNhanVien + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                if (kq > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        //Lấy danh sách nhân viên có chức vụ là bác sĩ
        public DataTable getBacSi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT nv.maNhanVien, nv.hoTen FROM NhanVien nv JOIN TaiKhoan tk ON nv.maNhanVien = tk.maNhanVien JOIN NhanVien_ChucVu nvcv ON tk.tenDangNhap = nvcv.tenDangNhap JOIN ChucVu cv ON nvcv.maChucVu = cv.maChucVu WHERE cv.tenChucVu = N'Bác sĩ';";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }

}
