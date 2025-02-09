namespace DTO
{
    public class TaiKhoanDTO
    {
        //public string MaNhanVien { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int HoatDong { get; set; }
        public string MaNhanVien { get; set; }

        public TaiKhoanDTO()
        {
            //MaNhanVien = string.Empty;
            TenDangNhap = string.Empty;
            MatKhau = string.Empty;
            HoatDong = 0;
        }

        public TaiKhoanDTO(string tenDangNhap, string matKhau, int hoatDong)
        {
            //this.MaNhanVien = maNhanVien;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.HoatDong = hoatDong;
        }

    }
}
