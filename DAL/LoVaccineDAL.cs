using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoVaccineDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public LoVaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layTatCaLoVaccine()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT Vaccine.maVaccine, Vaccine.tenVaccine, TT_CTVaccine.maLo, TT_CTVaccine.giaBan, TT_CTVaccine.soLuongTon, TT_CTVaccine.donViTinh,LoVaccine.ngaySanXuat, LoVaccine.hanSuDung, LoVaccine.giaNhap, LoVaccine.soLuongVaccine FROM Vaccine JOIN TT_CTVaccine ON Vaccine.maVaccine = TT_CTVaccine.maVaccine JOIN LoVaccine ON TT_CTVaccine.maLo = LoVaccine.maLo";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable layLoVaccineTheoMaLo(string maLo)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT Vaccine.maVaccine, Vaccine.tenVaccine, TT_CTVaccine.maLo, TT_CTVaccine.giaBan, TT_CTVaccine.soLuongTon, TT_CTVaccine.donViTinh, LoVaccine.ngaySanXuat, LoVaccine.hanSuDung, LoVaccine.giaNhap, LoVaccine.soLuongVaccine " +
                             "FROM Vaccine " +
                             "JOIN TT_CTVaccine ON Vaccine.maVaccine = TT_CTVaccine.maVaccine " +
                             "JOIN LoVaccine ON TT_CTVaccine.maLo = LoVaccine.maLo " +
                             "WHERE TT_CTVaccine.maLo = @maLo";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@maLo", maLo);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                return dt;
            }
        }


        public DataTable layLoVaccineTheoMaVaccine(string maVaccine, string maLo)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT Vaccine.maVaccine, Vaccine.tenVaccine, TT_CTVaccine.maLo, TT_CTVaccine.giaBan, TT_CTVaccine.soLuongTon, TT_CTVaccine.donViTinh, LoVaccine.ngaySanXuat, LoVaccine.hanSuDung, LoVaccine.giaNhap, LoVaccine.soLuongVaccine " +
                             "FROM Vaccine " +
                             "JOIN TT_CTVaccine ON Vaccine.maVaccine = TT_CTVaccine.maVaccine " +
                             "JOIN LoVaccine ON TT_CTVaccine.maLo = LoVaccine.maLo " +
                             "WHERE Vaccine.maVaccine = @maVaccine AND TT_CTVaccine.maLo = @maLo";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@maVaccine", maVaccine);
                da.SelectCommand.Parameters.AddWithValue("@maLo", maLo);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                return dt;
            }
        }

        public string taoMaLoVaccine()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maLo FROM LoVaccine ORDER BY maLo DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "L01";
            string maLT = dt.Rows[0]["maLo"].ToString();
            int so = int.Parse(maLT.Substring(1)) + 1;
            if (so < 10)
                return "L0" + so;
            if (so < 100)
                return "L" + so;
            return "L" + so;
        }

        //public bool themLoVaccine(LoVaccineDTO loVaccineDTO)
        //{
        //    SqlConnection conn = new SqlConnection(strConn);
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    string sql = "INSERT INTO LoVaccine (maLo, ngaySanXuat, hanSuDung, giaNhap, soLuongVaccine) VALUES ('" + loVaccineDTO.MaLo + "', '" + loVaccineDTO.NgaySanXuat + "', '" + loVaccineDTO.HanSuDung + "', " + loVaccineDTO.GiaNhap + ", " + loVaccineDTO.SoLuongVaccine + ")";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    int kq = cmd.ExecuteNonQuery();
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    if (kq > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public (bool isSuccess, string message) themLoVaccine(LoVaccineDTO loVaccineDTO)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string sql = "INSERT INTO LoVaccine (maLo, ngaySanXuat, hanSuDung, giaNhap, soLuongVaccine) VALUES (@MaLo, @NgaySanXuat, @HanSuDung, @GiaNhap, @SoLuongVaccine)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaLo", loVaccineDTO.MaLo);
                    cmd.Parameters.AddWithValue("@NgaySanXuat", loVaccineDTO.NgaySanXuat);
                    cmd.Parameters.AddWithValue("@HanSuDung", loVaccineDTO.HanSuDung);
                    cmd.Parameters.AddWithValue("@GiaNhap", loVaccineDTO.GiaNhap);
                    cmd.Parameters.AddWithValue("@SoLuongVaccine", loVaccineDTO.SoLuongVaccine);

                    int kq = cmd.ExecuteNonQuery();
                    return kq > 0
                        ? (true, "Thêm lô vaccine thành công.")
                        : (false, "Không thể thêm lô vaccine.");
                }
                catch (SqlException ex)
                {
                    // Kiểm tra lỗi cụ thể, ví dụ lỗi vi phạm ràng buộc CHECK
                    if (ex.Number == 547) // Vi phạm CHECK CONSTRAINT
                    {
                        return (false, "Giá nhập phải lớn hơn 0.");
                    }
                    return (false, "Lỗi cơ sở dữ liệu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    return (false, "Lỗi không xác định: " + ex.Message);
                }
            }
        }


        public bool suaLoVaccine(LoVaccineDTO loVaccineDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "UPDATE LoVaccine SET ngaySanXuat = '" + loVaccineDTO.NgaySanXuat + "', hanSuDung = '" + loVaccineDTO.HanSuDung + "', giaNhap = " + loVaccineDTO.GiaNhap + ", soLuongVaccine = " + loVaccineDTO.SoLuongVaccine + " WHERE maLo = '" + loVaccineDTO.MaLo + "'";
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

        public bool xoaLoVaccine(string maLo)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "DELETE FROM LoVaccine WHERE maLo = '" + maLo + "'";
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

        public List<string> layTatCaMaLo()
        {
            List<string> maLoList = new List<string>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT maLo FROM LoVaccine";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    maLoList.Add(reader["maLo"].ToString());
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return maLoList;
        }

        public List<LoVaccineDTO> layDanhSachLoVacineTheoMaVaccine(string maVaccine)
        {
            List<LoVaccineDTO> loVaccineList = new List<LoVaccineDTO>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT LoVaccine.maLo, LoVaccine.ngaySanXuat, LoVaccine.hanSuDung, LoVaccine.giaNhap, LoVaccine.soLuongVaccine " +
                             "FROM LoVaccine " +
                             "JOIN TT_CTVaccine ON LoVaccine.maLo = TT_CTVaccine.maLo " +
                             "WHERE TT_CTVaccine.maVaccine = @maVaccine";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maVaccine", maVaccine);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoVaccineDTO loVaccine = new LoVaccineDTO
                            {
                                MaLo = reader["maLo"].ToString(),
                                NgaySanXuat = (DateTime)reader["ngaySanXuat"],
                                HanSuDung = (DateTime)reader["hanSuDung"],
                                GiaNhap = (decimal)reader["giaNhap"],
                                SoLuongVaccine = (int)reader["soLuongVaccine"]
                            };

                            loVaccineList.Add(loVaccine);
                        }
                    }
                }
                conn.Close();
            }
            return loVaccineList;
        }
    }
}
