using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuNhapDAL
    {
        string strConn;
        public PhieuNhapDAL()
        {
            strConn = Settings.Default.strConn;
        }

        public DataTable layTatCaPhieuNhap()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT PhieuNhap.maPhieu, ngayLap, maNhanVien, maNhaCungCap, maLo, soLuongNhap FROM PhieuNhap, CT_PhieuNhap WHERE PhieuNhap.maPhieu = CT_PhieuNhap.maPhieu";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        //Mã phiếu nhập nhâp PN001
        public string taoMaPhieuNhap()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT top 1 maPhieu FROM PhieuNhap ORDER BY maPhieu DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            if (dt.Rows.Count == 0)
                return "PN001";
            string maPN = dt.Rows[0]["maPhieu"].ToString();
            int so = int.Parse(maPN.Substring(2)) + 1;
            if (so < 10)
                return "PN00" + so;
            if (so < 100)
                return "PN0" + so;
            return "PN" + so;
        }

        public bool themPhieuNhap(PhieuNhapDTO phieuNhapDTO)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "INSERT INTO PhieuNhap(maPhieu, ngayLap, maNhanVien, maNhaCungCap) VALUES ('" + phieuNhapDTO.MaPhieuNhap + "', '" + phieuNhapDTO.NgayLap + "', '" + phieuNhapDTO.MaNhanVien + "', '" + phieuNhapDTO.MaNhaCungCap + "')";
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

        public DataTable layDSChiTietPhieuNhap()
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //string sql = "SELECT pn.maPhieu,pn.ngayLap,ncc.tenNhaCungCap,nv.hoTen, ct.maLo,ct.soLuongNhap, lv.ngaySanXuat,lv.hanSuDung,lv.giaNhap,lv.soLuongVaccine, v.tenVaccine FROM PhieuNhap pn JOIN CT_PhieuNhap ct ON pn.maPhieu = ct.maPhieu JOIN LoVaccine lv ON ct.maLo = lv.maLo JOIN TT_CTVaccine ttc ON lv.maLo = ttc.maLo JOIN Vaccine v ON ttc.maVaccine = v.maVaccine JOIN NhaCungCap ncc ON pn.maNhaCungCap = ncc.maNhaCungCap JOIN NhanVien nv ON pn.maNhanVien = nv.maNhanVien ORDER BY pn.ngayLap DESC ";
            string sql = "SELECT pn.maPhieu,pn.ngayLap,ncc.tenNhaCungCap,nv.hoTen FROM PhieuNhap pn JOIN NhaCungCap ncc ON pn.maNhaCungCap = ncc.maNhaCungCap JOIN NhanVien nv ON pn.maNhanVien = nv.maNhanVien ORDER BY pn.ngayLap DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }


        public DataTable layDSChiTietPhieuNhapTheoMaPhieuNhap(string maPhieuNhap)
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT pn.maPhieu, pn.ngayLap,ncc.tenNhaCungCap, ncc.diaChi,ncc.sDT,nv.hoTen,ct.maLo,ct.soLuongNhap,lv.ngaySanXuat,lv.hanSuDung,lv.giaNhap,lv.soLuongVaccine,v.tenVaccine, v.maVaccine FROM PhieuNhap pn JOIN CT_PhieuNhap ct ON pn.maPhieu = ct.maPhieu JOIN LoVaccine lv ON ct.maLo = lv.maLo JOIN TT_CTVaccine ttc ON lv.maLo = ttc.maLo JOIN Vaccine v ON ttc.maVaccine = v.maVaccine JOIN NhaCungCap ncc ON pn.maNhaCungCap = ncc.maNhaCungCap JOIN NhanVien nv ON pn.maNhanVien = nv.maNhanVien WHERE pn.maPhieu = '" + maPhieuNhap + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }
    }
}
