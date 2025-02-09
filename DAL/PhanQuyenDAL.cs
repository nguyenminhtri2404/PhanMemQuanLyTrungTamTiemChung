using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhanQuyenDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public PhanQuyenDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layDanhSachQuyen(string maChucVu)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Select DanhMucManHinh.maManHinh, tenManHinh, coQuyen from PhanQuyen, DanhMucManHinh where PhanQuyen.maManHinh = DanhMucManHinh.maManHinh and PhanQuyen.maChucVu = '" + maChucVu + "' ORDER BY DanhMucManHinh.maManHinh ASC";
            //string sql = "Select tenManHinh, coQuyen from PhanQuyen, DanhMucManHinh where PhanQuyen.maManHinh = DanhMucManHinh.maManHinh and PhanQuyen.maChucVu = '" + maChucVu + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable getDSQuyen()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Select * from PhanQuyen";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public bool themPhanQuyen(PhanQuyenDTO phanQuyenDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Insert into PhanQuyen values('" + phanQuyenDTO.MaManHinh + "', '" + phanQuyenDTO.MaChucVu + "', " + phanQuyenDTO.CoQuyen + ")";
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

        public bool xoaPhanQuyen(string maManHinh, string maChucVu)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Delete from PhanQuyen where maManHinh = '" + maManHinh + "' and maChucVu = '" + maChucVu + "'";
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

        public bool suaPhanQuyen(PhanQuyenDTO phanQuyenDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "Update PhanQuyen set coQuyen = " + phanQuyenDTO.CoQuyen + " where maManHinh = '" + phanQuyenDTO.MaManHinh + "' and maChucVu = '" + phanQuyenDTO.MaChucVu + "'";
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
    }
}
