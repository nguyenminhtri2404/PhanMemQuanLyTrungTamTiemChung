using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CTPhieuNhapDAL
    {
        string strConn;
        public CTPhieuNhapDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public bool themChiTietPhieuNhap(CTPhieuNhapDTO cTPhieuNhapDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sql = "INSERT INTO CT_PhieuNhap(maPhieu, maLo, soLuongNhap) VALUES('" + cTPhieuNhapDTO.MaPhieuNhap + "', '" + cTPhieuNhapDTO.MaLo + "', " + cTPhieuNhapDTO.SoLuongNhap + ")";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
            if (kq > 0)
                return true;
            return false;
        }
    }
}
