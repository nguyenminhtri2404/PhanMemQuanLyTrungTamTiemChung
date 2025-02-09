using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ChucVuDAL
    {
        string strConn;

        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public ChucVuDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public List<string> layMaChucVuTheoTenDangNhap(string tenDangNhap)
        {
            List<string> maChucVu = (from tk in db.TaiKhoans
                                     join nvcv in db.NhanVien_ChucVus on tk.tenDangNhap equals nvcv.tenDangNhap
                                     where tk.tenDangNhap == tenDangNhap
                                     select nvcv.maChucVu).ToList();
            return maChucVu;
        }


        public DataTable getChucVu()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM ChucVu";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string getChucVuByTenDangNhap(string tenDangNhap)
        {
            string chucVu = (from tk in db.TaiKhoans
                             join nvcv in db.NhanVien_ChucVus on tk.tenDangNhap equals nvcv.tenDangNhap
                             join cv in db.ChucVus on nvcv.maChucVu equals cv.maChucVu
                             where tk.tenDangNhap == tenDangNhap
                             select cv.tenChucVu).FirstOrDefault();

            return chucVu;
        }

        public string taoMaChucVu()
        {
            string maChucVu = "";
            string query = (from cv in db.ChucVus
                            orderby cv.maChucVu descending
                            select cv.maChucVu).FirstOrDefault();
            if (query == null)
            {
                maChucVu = "CV001";
            }
            else
            {
                int so = int.Parse(query.Substring(2)) + 1;
                if (so < 10)
                {
                    maChucVu = "CV00" + so;
                }
                else if (so < 100)
                {
                    maChucVu = "CV0" + so;
                }
                else
                {
                    maChucVu = "CV" + so;
                }
            }
            return maChucVu;
        }

        public bool themChucVu(ChucVuDTO chucVuDTO)
        {
            ChucVu cv = new ChucVu();
            cv.maChucVu = chucVuDTO.MaChucVu;
            cv.tenChucVu = chucVuDTO.TenChucVu;

            db.ChucVus.InsertOnSubmit(cv);
            db.SubmitChanges();
            return true;
        }

        public bool suaChucVu(ChucVuDTO chucVuDTO)
        {
            ChucVu cv = db.ChucVus.Where(t => t.maChucVu == chucVuDTO.MaChucVu).FirstOrDefault();
            cv.tenChucVu = chucVuDTO.TenChucVu;

            db.SubmitChanges();
            return true;
        }

        public bool xoaChucVu(string maChucVu)
        {
            ChucVu cv = db.ChucVus.Where(t => t.maChucVu == maChucVu).FirstOrDefault();
            db.ChucVus.DeleteOnSubmit(cv);
            db.SubmitChanges();
            return true;
        }

    }
}
