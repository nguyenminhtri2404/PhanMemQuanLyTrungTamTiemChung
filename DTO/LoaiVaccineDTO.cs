namespace DTO
{
    public class LoaiVaccineDTO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public LoaiVaccineDTO() { }
        public LoaiVaccineDTO(string maLoai, string tenLoai, string moTa)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            MoTa = moTa;
        }
    }
}
