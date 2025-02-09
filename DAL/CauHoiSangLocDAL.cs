using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CauHoiSangLocDAL
    {
        private string strConn;

        public CauHoiSangLocDAL()
        {
            strConn = Settings.Default.strConn; // Lấy chuỗi kết nối từ file cấu hình
        }

        // Lấy danh sách câu hỏi cùng đáp án
        public List<CauHoiSangLocDTO> GetDanhSachCauHoi()
        {
            List<CauHoiSangLocDTO> danhSachCauHoi = new List<CauHoiSangLocDTO>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string query = @"
                    SELECT ch.maCauHoi, ch.noiDung
                    FROM CauHoiSangLoc ch";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                IEnumerable<CauHoiSangLocDTO> groupData = from row in dataTable.AsEnumerable()
                                                          group row by row["maCauHoi"] into g
                                                          select new CauHoiSangLocDTO
                                                          {
                                                              MaCauHoi = g.Key.ToString(),
                                                              NoiDung = g.FirstOrDefault()["noiDung"].ToString()
                                                          };

                danhSachCauHoi = groupData.ToList();
            }

            return danhSachCauHoi;
        }
    }
}
