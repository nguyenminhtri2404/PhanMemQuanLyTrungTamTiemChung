using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DanhMucManHinhDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public DanhMucManHinhDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable getDanhMucManHinh()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT * FROM DanhMucManHinh";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public string taoMaManHinh()
        {
            string maManHinh = "";
            string query = (from dm in db.DanhMucManHinhs
                            orderby dm.maManHinh descending
                            select dm.maManHinh).FirstOrDefault();
            if (query != null)
            {
                int so = int.Parse(query.Substring(2)) + 1;
                if (so < 10)
                {
                    maManHinh = "MH00" + so;
                }
                else
                {
                    maManHinh = "MH0" + so;
                }
            }
            else
            {
                maManHinh = "MH001";
            }
            return maManHinh;
        }

        public bool themManHinh(DanhMucManHinhDTO danhMucManHinhDTO)
        {
            try
            {
                DanhMucManHinh dm = new DanhMucManHinh();
                dm.maManHinh = danhMucManHinhDTO.MaManHinh;
                dm.tenManHinh = danhMucManHinhDTO.TenManHinh;
                db.DanhMucManHinhs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaManHinh(DanhMucManHinhDTO danhMucManHinhDTO)
        {
            try
            {
                DanhMucManHinh dm = db.DanhMucManHinhs.Where(x => x.maManHinh == danhMucManHinhDTO.MaManHinh).FirstOrDefault();
                dm.tenManHinh = danhMucManHinhDTO.TenManHinh;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaManHinh(string maManHinh)
        {
            try
            {
                DanhMucManHinh dm = db.DanhMucManHinhs.Where(x => x.maManHinh == maManHinh).FirstOrDefault();
                db.DanhMucManHinhs.DeleteOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
