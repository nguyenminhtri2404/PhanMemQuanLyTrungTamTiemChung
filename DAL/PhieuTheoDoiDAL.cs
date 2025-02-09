using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuTheoDoiDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public PhieuTheoDoiDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layDanhSachPhieuTheoDoi()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Select * from PhieuTheoDoi";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string taoMaPhieuTheoDoi()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maPhieuTheoDoi FROM PhieuTheoDoi ORDER BY maPhieuTheoDoi DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "PTD001";
            string maLT = dt.Rows[0]["maPhieuTheoDoi"].ToString();
            int so = int.Parse(maLT.Substring(3)) + 1;
            if (so < 10)
                return "PTD00" + so;
            if (so < 100)
                return "PTD0" + so;
            return "PTD" + so;
        }

        public bool themPhieuTheoDoi(PhieuTheoDoiDTO phieuTheoDoiDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO PhieuTheoDoi (maPhieuTheoDoi, thoiGianTiem, tinhTrangSauTiem, lan, ghiChu, maNhanVien, maHoaDon) VALUES ('" + phieuTheoDoiDTO.MaPhieuTheoDoi + "', '" + phieuTheoDoiDTO.ThoiGianTiem + "', N'" + phieuTheoDoiDTO.TinhTrangSauTiem + "', " + phieuTheoDoiDTO.Lan + ", N'" + phieuTheoDoiDTO.GhiChu + "', '" + phieuTheoDoiDTO.MaNhanVien + "', '" + phieuTheoDoiDTO.MaHoaDon + "')";
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
