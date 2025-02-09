using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DAL
{
    public class ThongTinChiTietVaccineDAL
    {
        private QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        string strConn;

        public ThongTinChiTietVaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public List<ThongTinChiTietVaccineDTO> GetVaccineList()
        {
            List<ThongTinChiTietVaccineDTO> vaccineList = (from v in db.Vaccines
                                                           join t in db.TT_CTVaccines on v.maVaccine equals t.maVaccine
                                                           select new ThongTinChiTietVaccineDTO
                                                           {
                                                               MaVaccine = v.maVaccine,
                                                               TenVaccine = v.tenVaccine,
                                                               SoLuongTon = t.soLuongTon ?? 0
                                                           }).ToList();

            return vaccineList;
        }

        public ThongTinChiTietVaccineDTO GetCTVaccineInfo(string maVaccine)
        {
            return db.TT_CTVaccines
                    .Where(tv => tv.maVaccine == maVaccine)
                    .Join(db.Vaccines,
                          tt => tt.maVaccine,
                          v => v.maVaccine,
                          (tt, v) => new { TT_CTVaccine = tt, Vaccine = v })
                    .Select(t => new ThongTinChiTietVaccineDTO
                    {
                        MaVaccine = t.TT_CTVaccine.maVaccine,
                        MaLo = t.TT_CTVaccine.maLo,
                        GiaBan = t.TT_CTVaccine.giaBan,
                        SoLuongTon = t.TT_CTVaccine.soLuongTon,
                        DonViTinh = t.TT_CTVaccine.donViTinh,
                        TenVaccine = t.Vaccine.tenVaccine, // Lấy tên vaccine từ bảng Vaccine
                    })
                    .FirstOrDefault();
        }


        public DataTable getTTCTVaccineInfo()
        {
            // Define the SQL query
            string query = @"
                    SELECT 
                        v.tenVaccine,
                        v.lieuLuong,
                        v.nguonGoc,
                        tt.soLuongTon,
                        l.tenLoai
                    FROM 
                        TT_CTVaccine tt
                    JOIN 
                        Vaccine v ON tt.maVaccine = v.maVaccine
                    JOIN 
                        LoaiVaccine l ON v.maLoai = l.maLoai;";

            // Initialize the DataTable to hold the result set
            DataTable dt = new DataTable();
            dt.Columns.Add("tenVaccine");
            dt.Columns.Add("lieuLuong");
            dt.Columns.Add("nguonGoc");
            dt.Columns.Add("soLuongTon");
            dt.Columns.Add("tenLoai");

            // Execute the SQL query and populate the DataTable
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each row to the DataTable
                            dt.Rows.Add(
                                reader["tenVaccine"],
                                reader["lieuLuong"],
                                reader["nguonGoc"],
                                reader["soLuongTon"],
                                reader["tenLoai"]
                            );
                        }
                    }
                }
            }

            return dt;
        }

        public List<LoaiVaccineDTO> GetLoaiVaccine()
        {
            string query = @"
                SELECT maLoai, tenLoai
                FROM LoaiVaccine";  // Không cần INNER JOIN với bảng Vaccine

            // Tạo danh sách để chứa dữ liệu
            List<LoaiVaccineDTO> loaiVaccines = new List<LoaiVaccineDTO>();

            // Sử dụng SqlConnection và SqlCommand để thực thi câu truy vấn
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoaiVaccineDTO loaiVaccine = new LoaiVaccineDTO
                            {
                                MaLoai = reader["maLoai"].ToString(),
                                TenLoai = reader["tenLoai"].ToString()
                            };

                            loaiVaccines.Add(loaiVaccine);
                        }
                    }
                }
            }

            return loaiVaccines;
        }

        public bool themThongTinCTVaccine(ThongTinChiTietVaccineDTO chiTietVaccineDTO)
        {
            SqlConnection connection = new SqlConnection(strConn);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "INSERT INTO TT_CTVaccine VALUES('" + chiTietVaccineDTO.MaVaccine + "', '" + chiTietVaccineDTO.MaLo + "', '" + chiTietVaccineDTO.GiaBan + "', '" + chiTietVaccineDTO.SoLuongTon + "', N'" + chiTietVaccineDTO.DonViTinh + "')";
            SqlCommand command = new SqlCommand(sql, connection);
            int kq = command.ExecuteNonQuery();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            if (kq > 0)
                return true;
            return false;

        }

        public DataTable getTTCTVaccinetheoMaVaccine(string maVaccine)
        {
            // Kiểm tra nếu maVaccine là null hoặc rỗng
            if (string.IsNullOrEmpty(maVaccine))
            {
                throw new ArgumentException("Mã vaccine không được để trống.", nameof(maVaccine));
            }

            // Define the SQL query with a parameter for maVaccine
            string query = @"
                        SELECT 
                            v.tenVaccine,
                            v.lieuLuong,
                            v.nguonGoc,
                            tt.soLuongTon,
                            l.tenLoai
                        FROM 
                            TT_CTVaccine tt
                        JOIN 
                            Vaccine v ON tt.maVaccine = v.maVaccine
                        JOIN 
                            LoaiVaccine l ON v.maLoai = l.maLoai
                        WHERE 
                            v.maVaccine = @maVaccine;";

            // Initialize the DataTable to hold the result set
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @maVaccine vào câu lệnh SQL
                    command.Parameters.AddWithValue("@maVaccine", maVaccine);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader); // Tự động nạp dữ liệu vào DataTable
                    }
                }
            }

            return dt;
        }


    }
}
