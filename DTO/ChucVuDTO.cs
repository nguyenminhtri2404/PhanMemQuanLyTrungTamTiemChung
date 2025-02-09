namespace DTO
{
    public class ChucVuDTO
    {
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }


        public ChucVuDTO() { }

        public ChucVuDTO(string maChucVu, string tenChucVu)
        {
            MaChucVu = maChucVu;
            TenChucVu = tenChucVu;
        }
    }
}
