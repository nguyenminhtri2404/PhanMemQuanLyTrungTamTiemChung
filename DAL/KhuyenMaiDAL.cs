using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class KhuyenMaiDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public KhuyenMaiDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable getKhuyenMai()
        {
            // Querying LoaiPhim using LINQ
            var query = from KhuyenMai in db.KhuyenMais
                        select new
                        {
                            KhuyenMai.maKhuyenMai,
                            KhuyenMai.tenKhuyenMai,
                            KhuyenMai.phanTramKhuyenMai,

                        };

            // Converting the LINQ query results to a DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maKhuyenMai");
            dt.Columns.Add("tenKhuyenMai");
            dt.Columns.Add("phanTramKhuyenMai");

            foreach (var item in query)
            {
                dt.Rows.Add(item.maKhuyenMai, item.tenKhuyenMai, item.phanTramKhuyenMai);
            }

            return dt;
        }
        public DataTable LayTatCaKhuyenMai()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                // Query để lấy dữ liệu khách hàng
                string query = "SELECT MaKhuyenMai, TenKhuyenMai, PhanTramKhuyenMai FROM KhuyenMai";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                return dataTable;
            }
        }
        public string layMaTuDong()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaKhuyenMai FROM KhuyenMai ORDER BY MaKhuyenMai DESC", conn);
                object result = cmd.ExecuteScalar();

                // Nếu chưa có khách hàng nào thì mã bắt đầu từ "KM001"
                if (result == null)
                {
                    return "KM001";
                }

                string lastMaKhuyenMai = result.ToString();

                // Tách phần số từ maKhuyenMai cuối cùng
                string numberPart = lastMaKhuyenMai.Substring(2); // Bỏ đi phần "KH"

                // Tăng số lên 1
                int newNumber = int.Parse(numberPart) + 1;

                return "KM" + newNumber.ToString("D3"); // "D3" để đảm bảo có 3 chữ số
            }
        }
        public bool ThemKhuyenMai(KhuyenMaiDTO khuyenMai)
        {
            try
            {
                KhuyenMai newKhuyenMai = new KhuyenMai
                {
                    maKhuyenMai = khuyenMai.MaKhuyenMai,
                    tenKhuyenMai = khuyenMai.TenKhuyenMai,
                    phanTramKhuyenMai = khuyenMai.PhanTramKhuyenMai,
                };
                db.KhuyenMais.InsertOnSubmit(newKhuyenMai);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool CheckMaKhuyenMai(string maKhuyenMai)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM KhuyenMai WHERE MaKhuyenMai = @MaKhuyenMai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhuyenMai", maKhuyenMai);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool SuaKhachHang(KhuyenMaiDTO khuyenMai)
        {
            try
            {
                KhuyenMai suaKhuyenMai = db.KhuyenMais.SingleOrDefault(lp => lp.maKhuyenMai == khuyenMai.MaKhuyenMai);
                {
                    suaKhuyenMai.maKhuyenMai = khuyenMai.MaKhuyenMai;
                    suaKhuyenMai.tenKhuyenMai = khuyenMai.TenKhuyenMai;
                    suaKhuyenMai.phanTramKhuyenMai = khuyenMai.PhanTramKhuyenMai;
                };
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool XoaKhuyenMai(string maKhuyenMai)
        {
            try
            {
                KhuyenMai xoaKhuyenMai = db.KhuyenMais.SingleOrDefault(lp => lp.maKhuyenMai == maKhuyenMai);
                db.KhuyenMais.DeleteOnSubmit(xoaKhuyenMai);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
