using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class HoaDonBUL
    {
        HoaDonDAL thanhToanDAL;
        public HoaDonBUL()
        {
            thanhToanDAL = new HoaDonDAL();
        }
        public DataTable LayThongTinPhieuKhamVaccine(string maPhieuKham)
        {
            if (string.IsNullOrWhiteSpace(maPhieuKham))
            {
                throw new ArgumentException("Mã phiếu khám không được để trống.");
            }

            try
            {
                return thanhToanDAL.LayThongTinPhieuKhamVaccine(maPhieuKham);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi từ tầng DAL
                throw new Exception("Lỗi khi lấy thông tin phiếu khám vaccine: " + ex.Message);
            }
        }
        public DataTable LayThongTinPhieuKhamGoiVaccine(string maPhieuKham)
        {
            if (string.IsNullOrWhiteSpace(maPhieuKham))
            {
                throw new ArgumentException("Mã phiếu khám không được để trống.");
            }

            try
            {
                return thanhToanDAL.LayThongTinPhieuKhamGoiVaccine(maPhieuKham);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi từ tầng DAL
                throw new Exception("Lỗi khi lấy thông tin phiếu khám gói vaccine: " + ex.Message);
            }
        }
        public DataTable LayDSChoThanhToan()
        {
            try
            {
                return thanhToanDAL.LayDSChoThanhToan();
            }
            catch (Exception ex)
            {
                // Xử lý hoặc log lỗi tùy theo yêu cầu
                throw new Exception("Lỗi khi lấy danh sách chờ thanh toán: " + ex.Message);
            }
        }
        //public bool LuuHoaDon(string maHoaDon, decimal tienTra, decimal tienThua, decimal tongTien, string phuongThucThanhToan, string noiDung, string maPhieuKham)
        //{
        //    // Gọi phương thức của DAL để lưu dữ liệu vào cơ sở dữ liệu
        //    return thanhToanDAL.LayThongTinHoaDon(maHoaDon, tienTra, tienThua, tongTien, phuongThucThanhToan, noiDung, maPhieuKham);
        //}
        public bool LuuHoaDon(HoaDonDTO hoaDon)
        {
            // Gọi phương thức của DAL để lưu dữ liệu vào cơ sở dữ liệu
            return thanhToanDAL.LayThongTinHoaDon(
                hoaDon.MaHD,
                hoaDon.TienTra,
                hoaDon.TienThua,
                hoaDon.TongTien,
                hoaDon.PhuongThucThanhToan,
                hoaDon.NoiDung,
                hoaDon.MaPhieuKham
            );
        }
        public string taoMaHoaDon()
        {
            return thanhToanDAL.taoMaHoaDon();
        }
        public DataTable getLSThanhToan()
        {
            return thanhToanDAL.GetLSThanhToan();
        }


        public DataTable LayDSChoThanhToanTheoTenKhachHang(string tenKhachHang)
        {
            if (string.IsNullOrEmpty(tenKhachHang))
            {
                throw new ArgumentException("Tên khách hàng không được để trống.");
            }

            return thanhToanDAL.LayDSChoThanhToanTheoTenKhachHang(tenKhachHang);
        }

        public DataTable LayTatCaHoaDon()
        {
            return thanhToanDAL.LayTatCaHoaDon();
        }
        public DataTable LayHoaDonTheoPhuongThucTienMat()
        {
            try
            {
                return thanhToanDAL.LayHoaDonTheoPhuongThucTienMat();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Error in BUL: " + ex.Message);
            }
        }
        public DataTable LayHoaDonTheoPhuongThucChuyenKhoan()
        {
            try
            {
                return thanhToanDAL.LayHoaDonTheoPhuongThucChuyenKhoan();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Error in BUL: " + ex.Message);
            }
        }
        public DataTable LayTatCaHoaDonTheoThangNam(int thang, int nam)
        {
            return thanhToanDAL.LayTatCaHoaDonTheoThangNam(thang, nam);
        }

        // Lấy hóa đơn thanh toán bằng tiền mặt theo tháng và năm
        public DataTable LayHoaDonTheoPhuongThucTienMatThangNam(int thang, int nam)
        {
            return thanhToanDAL.LayHoaDonTheoPhuongThucTienMatThangNam(thang, nam);
        }

        // Lấy hóa đơn thanh toán bằng chuyển khoản theo tháng và năm
        public DataTable LayHoaDonTheoPhuongThucChuyenKhoanThangNam(int thang, int nam)
        {
            return thanhToanDAL.LayHoaDonTheoPhuongThucChuyenKhoanThangNam(thang, nam);
        }
        public DataTable LayTongDoanhThuTheoThang(int nam)
        {
            return thanhToanDAL.LayTongDoanhThuTheoThang(nam);
        }
        public DataTable ThongKeSoLuongKhachHang(int nam)
        {
            return thanhToanDAL.ThongKeSoLuongKhachHang(nam);
        }

        public List<DanhSachGoiVaccineDTO> GetPhieuKhamByHoaDonId(string maPhieuKham)
        {
            if (string.IsNullOrEmpty(maPhieuKham))
            {
                throw new ArgumentException("Mã phiếu khám không được để trống.");
            }

            try
            {
                return thanhToanDAL.GetPhieuKhamByHoaDonId(maPhieuKham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách gói vắc xin theo mã phiếu khám: " + ex.Message);
            }
        }
        public List<DanhSachVaccineDTO> GetPhieuKhamByHoaDon(string maPhieuKham)
        {
            if (string.IsNullOrEmpty(maPhieuKham))
            {
                throw new ArgumentException("Mã phiếu khám không được để trống.");
            }

            try
            {
                return thanhToanDAL.GetPhieuKhamByHoaDon(maPhieuKham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vắc xin theo mã phiếu khám: " + ex.Message);
            }
        }
        public HoaDonKhachHangDTO GetHoaDonKhachHangByMaPhieuKham(string maPhieuKham)
        {
            // Gọi phương thức DAL để lấy dữ liệu từ cơ sở dữ liệu
            return thanhToanDAL.GetHoaDonKhachHangByMaPhieuKham(maPhieuKham);
        }

    }
}
