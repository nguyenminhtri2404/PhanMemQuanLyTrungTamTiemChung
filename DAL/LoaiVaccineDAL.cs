using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoaiVaccineDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public LoaiVaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layTatCaLoaiVaccine()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM LoaiVaccine";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string taoMaLoaiVaccine()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maLoai FROM LoaiVaccine ORDER BY maLoai DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "LV01";
            string maLV = dt.Rows[0]["maLoai"].ToString();
            int so = int.Parse(maLV.Substring(2)) + 1;
            if (so < 10)
                return "LV0" + so;
            if (so < 100)
                return "LV" + so;
            return "LV" + so;
        }

        public bool themLoaiVaccine(LoaiVaccineDTO loaiVaccineDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO LoaiVaccine VALUES('" + loaiVaccineDTO.MaLoai + "', N'" + loaiVaccineDTO.TenLoai + "', N'" + loaiVaccineDTO.MoTa + "')";
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

        public bool suaLoaiVaccine(LoaiVaccineDTO loaiVaccineDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE LoaiVaccine SET tenLoai = N'" + loaiVaccineDTO.TenLoai + "', moTa = N'" + loaiVaccineDTO.MoTa + "' WHERE maLoai = '" + loaiVaccineDTO.MaLoai + "'";
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

        public bool xoaLoaiVaccine(string maLoai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string sql = "DELETE FROM LoaiVaccine WHERE maLoai = @maLoai";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);
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
