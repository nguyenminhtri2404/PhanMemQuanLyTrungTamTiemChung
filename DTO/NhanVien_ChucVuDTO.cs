namespace DTO
{
    public class NhanVien_ChucVuDTO
    {
        public string TenDangNhap { get; set; }
        public string MaChucVu { get; set; }

        public NhanVien_ChucVuDTO() { }
        public NhanVien_ChucVuDTO(string tenDangNhap, string maChucVu)
        {
            TenDangNhap = tenDangNhap;
            MaChucVu = maChucVu;
        }
    }
}
