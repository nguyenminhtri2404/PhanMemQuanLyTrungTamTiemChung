using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class DapAnDAL
    {
        private string strConn;

        public DapAnDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public void LuuDapAn(DapAnDTO dapAn)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "INSERT INTO DapAn (MaDapAn, LuaChon, MaPhieuKham, MaCauHoi) " +
                               "VALUES (@MaDapAn, @LuaChon, @MaPhieuKham, @MaCauHoi)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDapAn", dapAn.MaDapAn);
                cmd.Parameters.AddWithValue("@LuaChon", dapAn.LuaChon);
                cmd.Parameters.AddWithValue("@MaPhieuKham", dapAn.MaPhieuKham);
                cmd.Parameters.AddWithValue("@MaCauHoi", dapAn.MaCauHoi);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
