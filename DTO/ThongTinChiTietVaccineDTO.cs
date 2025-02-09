namespace DTO
{
    public class ThongTinChiTietVaccineDTO
    {
        public string MaVaccine { get; set; }
        public string MaLo { get; set; }
        public string TenVaccine { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? GiaBan { get; set; }
        public string DonViTinh { get; set; }
        public string DisplayText
        {
            get
            {
                return string.Format("{0} - {1}", TenVaccine, SoLuongTon);
            }
        }

    }
}
