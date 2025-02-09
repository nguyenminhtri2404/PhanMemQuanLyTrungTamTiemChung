namespace DTO
{
    public class LoaiTiemChungDTO
    {
        public string MaLoaiTiemChung { get; set; }
        public string TenLoaiTiemChung { get; set; }
        public int TrangThai { get; set; }

        public LoaiTiemChungDTO()
        {
            MaLoaiTiemChung = string.Empty;
            TenLoaiTiemChung = string.Empty;
            TrangThai = 0;
        }

        public LoaiTiemChungDTO(string maLoaiTiemChung, string tenLoaiTiemChung, int trangThai)
        {
            MaLoaiTiemChung = maLoaiTiemChung;
            TenLoaiTiemChung = tenLoaiTiemChung;
            TrangThai = trangThai;
        }
    }
}
