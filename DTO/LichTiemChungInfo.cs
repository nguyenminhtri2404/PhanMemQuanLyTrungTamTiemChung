namespace DTO
{
    public class LichTiemChungInfo
    {
        public string MaLichTiemChung { get; set; }
        public string HoTen { get; set; }
        public string TenVaccine { get; set; }
        public int Mui { get; set; }

        public LichTiemChungInfo(string maLichTiemChung, string hoTen, string tenVaccine, int mui)
        {
            MaLichTiemChung = maLichTiemChung;
            TenVaccine = tenVaccine;
            HoTen = hoTen;
            Mui = mui;
        }
    }
}
