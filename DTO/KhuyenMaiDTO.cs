namespace DTO
{
    public class KhuyenMaiDTO
    {
        public string MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public decimal PhanTramKhuyenMai { get; set; }


        public KhuyenMaiDTO(string maKhuyenMai, string tenKhuyenMai, decimal phanTramKhuyenMai)
        {
            MaKhuyenMai = maKhuyenMai;
            TenKhuyenMai = tenKhuyenMai;
            PhanTramKhuyenMai = phanTramKhuyenMai;
        }
    }
}
