using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class TaiKhoanDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public TaiKhoanDAL()
        {
            strConn = Settings.Default.strConn;
        }

        //public bool kiemTraDangNhap(TaiKhoanDTO taiKhoanDTO)
        //{
        //    SqlConnection conn = new SqlConnection(strConn);
        //    if (conn.State == ConnectionState.Closed)
        //        conn.Open();

        //    string sql = "Select count(*) from TaiKhoan where tenDangNhap ='" + taiKhoanDTO.TenDangNhap + "' and matKhau = '" + taiKhoanDTO.MatKhau + "' and hoatDong = 1";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    int so = (int)cmd.ExecuteScalar();
        //    if (conn.State == ConnectionState.Open)
        //        conn.Close();
        //    if (so == 0)
        //        return false;
        //    return true;
        //}

        public string kiemTraDangNhap(TaiKhoanDTO taiKhoanDTO)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT maNhanVien FROM TaiKhoan WHERE tenDangNhap = @tenDangNhap AND matKhau = @matKhau AND hoatDong = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", taiKhoanDTO.TenDangNhap);
                cmd.Parameters.AddWithValue("@matKhau", taiKhoanDTO.MatKhau);

                object result = cmd.ExecuteScalar();
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                return result != null ? result.ToString() : null;
            }
        }

        public DataTable layDanhSachTaiKhoan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT * FROM TaiKhoan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        public bool themTaiKhoan(TaiKhoanDTO taiKhoanDTO)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "INSERT INTO TaiKhoan(tenDangNhap, matKhau, maNhanVien, hoatDong) VALUES(@tenDangNhap, @matKhau, @maNhanVien, @hoatDong)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tenDangNhap", taiKhoanDTO.TenDangNhap);
                    cmd.Parameters.AddWithValue("@matKhau", taiKhoanDTO.MatKhau);
                    cmd.Parameters.AddWithValue("@maNhanVien", taiKhoanDTO.MaNhanVien);
                    cmd.Parameters.AddWithValue("@hoatDong", taiKhoanDTO.HoatDong);

                    int result = cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    return result > 0;
                }
            }
        }

        public bool suaTaiKhoan(TaiKhoanDTO taiKhoanDTO)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "UPDATE TaiKhoan SET matKhau = @matKhau, maNhanVien = @maNhanVien, hoatDong = @hoatDong WHERE tenDangNhap = @tenDangNhap";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@matKhau", taiKhoanDTO.MatKhau);
                    cmd.Parameters.AddWithValue("@maNhanVien", taiKhoanDTO.MaNhanVien);
                    cmd.Parameters.AddWithValue("@hoatDong", taiKhoanDTO.HoatDong);
                    cmd.Parameters.AddWithValue("@tenDangNhap", taiKhoanDTO.TenDangNhap);

                    int result = cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    return result > 0;
                }
            }
        }

        public bool xoaTaiKhoan(string tenDangNhap)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "DELETE FROM TaiKhoan WHERE tenDangNhap = '" + tenDangNhap + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                if (result > 0)
                    return true;
                return false;
            }
        }


        public bool KiemTraMatKhauCu(string tenDangNhap, string matKhau)
        {
            IQueryable<TaiKhoan> query = from tk in db.TaiKhoans
                                         where tk.tenDangNhap == tenDangNhap &&
                                               tk.matKhau == matKhau
                                         select tk;

            return query.Count() > 0;
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.tenDangNhap == tenDangNhap);
            tk.matKhau = matKhauMoi;
            db.SubmitChanges();
            return true;
        }
    }
}
