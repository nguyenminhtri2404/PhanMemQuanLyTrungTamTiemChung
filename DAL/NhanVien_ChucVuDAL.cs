using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NhanVien_ChucVuDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public NhanVien_ChucVuDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layDanhSachNhanVienChucVu()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM NhanVien_ChucVu";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public bool themNhanVienChucVu(NhanVien_ChucVuDTO nhanVien_ChucVuDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO NhanVien_ChucVu VALUES('" + nhanVien_ChucVuDTO.TenDangNhap + "', '" + nhanVien_ChucVuDTO.MaChucVu + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (kq > 0)
            {
                return true;
            }
            return false;
        }

        public bool xoaNhanVienChucVu(string tenDangNhap, string maChucVu)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "DELETE FROM NhanVien_ChucVu WHERE tenDangNhap = '" + tenDangNhap + "' AND maChucVu = '" + maChucVu + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (kq > 0)
            {
                return true;
            }
            return false;
        }

        public bool suaNhanVienChucVu(NhanVien_ChucVuDTO nhanVien_ChucVuDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE NhanVien_ChucVu SET maChucVu = '" + nhanVien_ChucVuDTO.MaChucVu + "' WHERE tenDangNhap = '" + nhanVien_ChucVuDTO.TenDangNhap + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (kq > 0)
            {
                return true;
            }
            return false;
        }
    }
}
