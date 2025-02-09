using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DAL
{
    public class KhachHangDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public KhachHangDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public DataTable getKhachHang()
        {
            var query = from khachhang in db.KhachHangs
                        join nguoigiamho in db.NguoiGiamHos
                        on khachhang.maNguoiGiamHo equals nguoigiamho.maNguoiGiamHo into gj
                        from subNgGiamHo in gj.DefaultIfEmpty()
                        select new
                        {
                            khachhang.maKhachHang,
                            khachhang.hoTen,
                            khachhang.gioiTinh,
                            khachhang.ngaySinh,
                            khachhang.diaChi,
                            khachhang.sDT,
                            khachhang.email,
                            tenNguoiGiamHo = subNgGiamHo != null ? subNgGiamHo.hoTen : " "
                        };

            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maKhachHang");
            dt.Columns.Add("hoTen");
            dt.Columns.Add("gioiTinh");
            dt.Columns.Add("ngaySinh");
            dt.Columns.Add("diaChi");
            dt.Columns.Add("SDT");
            dt.Columns.Add("email");
            dt.Columns.Add("maNguoiGiamHo");

            foreach (var item in query)
            {
                dt.Rows.Add(item.maKhachHang, item.hoTen, item.gioiTinh, item.ngaySinh, item.diaChi, item.sDT, item.email, item.tenNguoiGiamHo);
            }

            return dt;
        }


        public int getMaxMaKhachHang()
        {
            List<string> maKhachHangs = db.KhachHangs
                .Select(nv => nv.maKhachHang)
                .ToList();
            int maxMaKhachHang = maKhachHangs
                .Where(mkh => !string.IsNullOrEmpty(mkh) && mkh.Length > 2)
                .Select(mkh => int.Parse(mkh.Substring(2)))
                .DefaultIfEmpty(0)
                .Max();
            return maxMaKhachHang;
        }

        //public bool ThemKhachHang(KhachHangDTO khachhang)
        //{
        //    KhachHang newkhachhang = new KhachHang
        //    {
        //        maKhachHang = khachhang.maKH,
        //        hoTen = khachhang.hoTen,
        //        gioiTinh = khachhang.gioiTinh,
        //        ngaySinh = khachhang.ngaySinh,
        //        diaChi = khachhang.diaChi,
        //        sDT = khachhang.SDT,
        //        email = khachhang.email,
        //        maNguoiGiamHo = khachhang.MaNguoiGiamHo
        //    };
        //    db.KhachHangs.InsertOnSubmit(newkhachhang);
        //    try
        //    {
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.Number);
        //        return false;
        //    }
        //}
        public (bool isSuccess, string message) ThemKhachHang(KhachHangDTO khachhang)
        {
            KhachHang newkhachhang = new KhachHang
            {
                maKhachHang = khachhang.maKH,
                hoTen = khachhang.hoTen,
                gioiTinh = khachhang.gioiTinh,
                ngaySinh = khachhang.ngaySinh,
                diaChi = khachhang.diaChi,
                sDT = khachhang.SDT,
                email = khachhang.email,
                maNguoiGiamHo = khachhang.MaNguoiGiamHo
            };
            db.KhachHangs.InsertOnSubmit(newkhachhang);
            try
            {
                db.SubmitChanges();
                return (true, "Thêm khách hàng thành công.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Lỗi trùng UNIQUE
                {
                    return (false, "Số điện thoại hoặc email đã tồn tại.");
                }
                return (false, "Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi không xác định: " + ex.Message);
            }
        }


        public bool suaKhachHang(KhachHangDTO khachhang)
        {
            try
            {
                KhachHang suakh = db.KhachHangs.SingleOrDefault(lp => lp.maKhachHang == khachhang.maKH);
                {
                    suakh.maKhachHang = khachhang.maKH;
                    suakh.hoTen = khachhang.hoTen;
                    suakh.gioiTinh = khachhang.gioiTinh;
                    suakh.ngaySinh = khachhang.ngaySinh;
                    suakh.diaChi = khachhang.diaChi;
                    suakh.sDT = khachhang.SDT;
                    suakh.email = khachhang.email;
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
    }
}
