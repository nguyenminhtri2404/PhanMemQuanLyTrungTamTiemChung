using System;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TienTra { get; set; }
        public decimal TienThua { get; set; }
        public decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string KieuThanhToan { get; set; }
        public int TrangThai { get; set; }
        public string NoiDung { get; set; }
        public string MaPhieuKham { get; set; }
    }
}
