using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class VaccineDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public VaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable LayTatCaVaccine()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT * from Vaccine WHERE tinhTrang = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }
        public bool UpdateSoLuongTon(string maVaccine, int soLuongThayDoi, string maLo)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "UPDATE TT_CTVaccine SET soLuongTon = soLuongTon - @soLuongThayDoi WHERE maVaccine = @maVaccine and maLo = @maLo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@soLuongThayDoi", soLuongThayDoi);
                cmd.Parameters.AddWithValue("@maVaccine", maVaccine);
                cmd.Parameters.AddWithValue("@maLo", maLo);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        public List<VaccineDTO> getVaccineCombo()
        {
            List<VaccineDTO> dsvx = (from lp in db.Vaccines
                                     select new VaccineDTO
                                     {
                                         MaVaccine = lp.maVaccine,
                                         TenVaccine = lp.tenVaccine
                                     }).ToList();
            return dsvx;
        }

        //public string taoMaVaccine()
        //{
        //    SqlConnection sqlConnection = new SqlConnection(strConn);
        //    if (sqlConnection.State == ConnectionState.Closed)
        //    {
        //        sqlConnection.Open();
        //    }
        //    string sql = "SELECT top 1 maVaccine FROM Vaccine ORDER BY maVaccine DESC";
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    if (sqlConnection.State == ConnectionState.Open)
        //    {
        //        sqlConnection.Close();
        //    }
        //    if (dataTable.Rows.Count == 0)
        //        return "VAC01";
        //    string maVC = dataTable.Rows[0]["maVaccine"].ToString();
        //    int so = int.Parse(maVC.Substring(3)) + 1;
        //    if (so < 10)
        //        return "VAC" + so;
        //    if (so < 100)
        //        return "VAC0" + so;
        //    return "VAC" + so;
        //}

        public string taoMaVaccine()
        {
            SqlConnection sqlConnection = new SqlConnection(strConn);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string sql = "SELECT top 1 maVaccine FROM Vaccine ORDER BY CAST(SUBSTRING(maVaccine, 4, LEN(maVaccine) - 3) AS INT) DESC";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            if (dataTable.Rows.Count == 0)
                return "VAC01";
            string maVC = dataTable.Rows[0]["maVaccine"].ToString();
            int so = int.Parse(maVC.Substring(3)) + 1;
            return "VAC" + so.ToString("D2");
        }

        public bool ThemVaccine(VaccineDTO vaccineDTO)
        {
            SqlConnection sqlConnection = new SqlConnection(strConn);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string sql = "INSERT INTO Vaccine (MaVaccine, TenVaccine, NguonGoc, LieuLuong, TinhTrang, MaLoai, MaLoaiTiemChung, MaPhongNgua) VALUES (@MaVaccine, @TenVaccine, @NguonGoc, @LieuLuong, @TinhTrang, @MaLoai, @MaLoaiTiemChung, @MaPhongNgua)";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@MaVaccine", vaccineDTO.MaVaccine);
            cmd.Parameters.AddWithValue("@TenVaccine", vaccineDTO.TenVaccine);
            cmd.Parameters.AddWithValue("@NguonGoc", vaccineDTO.NguonGoc);
            cmd.Parameters.AddWithValue("@LieuLuong", vaccineDTO.LieuLuong);
            cmd.Parameters.AddWithValue("@TinhTrang", vaccineDTO.TinhTrang);
            cmd.Parameters.AddWithValue("@MaLoai", vaccineDTO.MaLoai);
            cmd.Parameters.AddWithValue("@MaLoaiTiemChung", vaccineDTO.MaLoaiTiemChung);
            cmd.Parameters.AddWithValue("@MaPhongNgua", vaccineDTO.MaPhongNgua);

            return cmd.ExecuteNonQuery() > 0;
        }


        public bool suaVaccine(VaccineDTO vaccineDTO)
        {
            SqlConnection sqlConnection = new SqlConnection(strConn);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string sql = "UPDATE Vaccine SET tenVaccine = N'" + vaccineDTO.TenVaccine + "', nguonGoc = N'" + vaccineDTO.NguonGoc + "', lieuLuong = '" + vaccineDTO.LieuLuong + "', maLoai = '" + vaccineDTO.MaLoai + "', maLoaiTiemChung = '" + vaccineDTO.MaLoaiTiemChung + "' WHERE maVaccine = '" + vaccineDTO.MaVaccine + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            int kq = sqlCommand.ExecuteNonQuery();
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            if (kq > 0)
                return true;
            return false;
        }

        public bool xoaVaccine(string maVaccine)
        {
            SqlConnection sqlConnection = new SqlConnection(strConn);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string sql = "UPDATE Vaccine SET tinhTrang = 0 WHERE maVaccine = '" + maVaccine + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            int kq = sqlCommand.ExecuteNonQuery();
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            if (kq > 0)
                return true;
            return false;
        }

        //Tìm kiếm vaccine với nhiều điều kiện
        public DataTable timKiemVaccine(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = "SELECT * FROM Vaccine WHERE tinhTrang = 1 AND (maVaccine LIKE @searchText OR tenVaccine LIKE @searchText OR nguonGoc LIKE @searchText OR lieuLuong LIKE @searchText)";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }

        }
        public List<VaccineDTO> GetVaccines()
        {
            return db.Vaccines
                .Select(v => new VaccineDTO
                {
                    MaVaccine = v.maVaccine,
                    TenVaccine = v.tenVaccine,
                    NguonGoc = v.nguonGoc,
                    LieuLuong = v.lieuLuong,
                })
                .ToList();
        }
        public VaccineDTO GetVaccineInfo(string maVaccine)
        {
            return db.Vaccines
                    .Where(v => v.maVaccine == maVaccine)
                    .Select(v => new VaccineDTO
                    {
                        MaVaccine = v.maVaccine,
                        TenVaccine = v.tenVaccine,
                        LieuLuong = v.lieuLuong,
                        TinhTrang = v.tinhTrang
                    })
                    .FirstOrDefault();
        }
        public List<Vaccine> GetVaccinesByMaPhongNgua(string maPhongNgua)
        {
            // Truy vấn danh sách vắc xin theo mã phòng ngừa
            return db.Vaccines
                .Where(v => v.maPhongNgua == maPhongNgua)
                .ToList();
        }
    }
}
