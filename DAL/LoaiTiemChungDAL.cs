using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoaiTiemChungDAL
    {

        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public LoaiTiemChungDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layTatCaLoaiTiemChung()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM LoaiTiemChung where trangThai = 1";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string taoMaLoaiTiemChung()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maLoaiTiemChung FROM LoaiTiemChung ORDER BY maLoaiTiemChung DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "LTC01";
            string maLT = dt.Rows[0]["maLoaiTiemChung"].ToString();
            int so = int.Parse(maLT.Substring(3)) + 1;
            if (so < 10)
                return "LTC0" + so;
            if (so < 100)
                return "LTC" + so;
            return "LTC" + so;
        }

        public bool themLoaiTiemChung(LoaiTiemChungDTO loaiTiemChungDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO LoaiTiemChung (maLoaiTiemChung, tenLoaiTiemChung, trangThai) VALUES ('" + loaiTiemChungDTO.MaLoaiTiemChung + "', N'" + loaiTiemChungDTO.TenLoaiTiemChung + "', 1)";
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

        public bool suaLoaiTiemChung(LoaiTiemChungDTO loaiTiemChungDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE LoaiTiemChung SET tenLoaiTiemChung = N'" + loaiTiemChungDTO.TenLoaiTiemChung + "' WHERE maLoaiTiemChung = '" + loaiTiemChungDTO.MaLoaiTiemChung + "'";
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

        public bool xoaLoaiTiemChung(string maLoaiTiemChung)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE LoaiTiemChung SET trangThai = 0 WHERE maLoaiTiemChung = '" + maLoaiTiemChung + "'";
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

    }
}
