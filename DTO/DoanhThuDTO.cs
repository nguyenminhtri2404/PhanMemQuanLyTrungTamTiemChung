namespace DTO
{
    public class DoanhThuDTO : HoaDonInfDTO
    {
        public int STT { get; set; }


        public DoanhThuDTO(HoaDonInfDTO hd, int stt)
        {
            this.STT = stt;
            this.MaHD = hd.MaHD;
            this.NgayLap = hd.NgayLap;
            this.TienTra = hd.TienTra;
            this.TienThua = hd.TienThua;
            this.TongTien = hd.TongTien;
            this.PhuongThucThanhToan = hd.PhuongThucThanhToan;
            this.NoiDung = hd.NoiDung;
            this.MaPhieuKham = hd.MaPhieuKham;
        }
    }
}
