using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DAL
{
    public class DoanhThuDAL
    {
        private QL_TiemChungDataContext _context;
        private string _connectionString;
        public DoanhThuDAL(QL_TiemChungDataContext context)
        {
            _context = context;
            _connectionString = _context.Connection.ConnectionString;
        }

        public List<HoaDonInfDTO> GetHoaDonByMonth(int month, int year)
        {
            IQueryable<HoaDonInfDTO> query = from hd in _context.HoaDons
                                             where hd.ngayLap.HasValue
                                             && hd.ngayLap.Value.Month == month
                                             && hd.ngayLap.Value.Year == year
                                             select new HoaDonInfDTO
                                             {
                                                 MaHD = hd.maHoaDon,
                                                 NgayLap = hd.ngayLap,
                                                 TienTra = hd.tienTra,
                                                 TienThua = hd.tienThua,
                                                 TongTien = hd.tongTien,
                                                 PhuongThucThanhToan = hd.phuongThucThanhToan,
                                                 NoiDung = hd.noiDung,
                                                 MaPhieuKham = hd.maPhieuKham
                                             };


            return query.ToList() ?? new List<HoaDonInfDTO>();
        }
        public DataTable GetHoaDonDataTable(int month, int year)
        {
            // Khởi tạo DataTable để lưu kết quả
            DataTable dataTable = new DataTable();

            // Câu lệnh SQL
            string sql = @"
                    SELECT 
                    MONTH(ngayLap) AS Thang,
	                YEAR(ngayLap) AS Nam,
                    maHoaDon AS MaHoaDon,
                    ngayLap AS NgayLap,
                    tienTra AS TienTra,
                    tienThua AS TienThua,
                    tongTien AS TongTien,
                    phuongThucThanhToan AS PhuongThuc
                FROM HoaDon
                WHERE ngayLap IS NOT NULL
                AND MONTH(ngayLap) = @Month
                AND YEAR(ngayLap) = @Year";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    // Thêm tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);


                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
