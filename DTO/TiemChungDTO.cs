using System;

namespace DTO
{
    public class TiemChungDTO
    {
        public string maPhieuDangKy { get; set; }
        public string hinhThucTiem { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayDangKy { get; set; }
        public string GhiChu { get; set; }
        public string MaNhanVien { get; set; }
        public string maKhachHang { get; set; }
        public int trangThai { get; set; }
        public string TrangThaiText
        {
            get
            {
                if (trangThai == 0)
                    return "Chưa tiêm";
                else if (trangThai == 1)
                    return "Đã tiêm";
                else
                    return "Không xác định";
            }
        }
    }
}
