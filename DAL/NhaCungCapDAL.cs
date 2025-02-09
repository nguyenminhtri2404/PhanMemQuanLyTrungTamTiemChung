using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NhaCungCapDAL
    {
        string strConn;
        public NhaCungCapDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable getNhaCungCap()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM NhaCungCap";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string taoMaNhaCungCap()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maNhaCungCap FROM NhaCungCap ORDER BY maNhaCungCap DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "NCC001";
            string maNCC = dt.Rows[0]["maNhaCungCap"].ToString();
            int so = int.Parse(maNCC.Substring(3)) + 1;
            if (so < 10)
                return "NCC00" + so;
            if (so < 100)
                return "NCC0" + so;
            return "NCC" + so;
        }

        public bool themNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO NhaCungCap VALUES('" + nhaCungCap.MaNCC + "','" + nhaCungCap.TenNCC + "','" + nhaCungCap.DiaChi + "','" + nhaCungCap.SDT + "')";
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

        public bool suaNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE NhaCungCap SET tenNhaCungCap = '" + nhaCungCap.TenNCC + "', diaChi = '" + nhaCungCap.DiaChi + "', sDT = '" + nhaCungCap.SDT + "' WHERE maNhaCungCap = '" + nhaCungCap.MaNCC + "'";
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

        public bool xoaNhaCungCap(string maNCC)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string sql = "DELETE FROM NhaCungCap WHERE maNhaCungCap = @maNCC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNCC", maNCC);
                        int kq = cmd.ExecuteNonQuery();

                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }

                        return kq > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception if needed
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
