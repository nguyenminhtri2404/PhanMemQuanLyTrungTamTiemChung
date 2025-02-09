namespace DTO
{
    public class VaccineDTO
    {
        public string MaVaccine { get; set; }
        public string TenVaccine { get; set; }
        public string NguonGoc { get; set; }
        public string LieuLuong { get; set; }
        public int? TinhTrang { get; set; }
        public string MaLoai { get; set; }
        public string MaLoaiTiemChung { get; set; }
        public string MaPhongNgua { get; set; }
        public VaccineDTO()
        {
            MaVaccine = string.Empty;
            TenVaccine = string.Empty;
            NguonGoc = string.Empty;
            LieuLuong = string.Empty;
            TinhTrang = 0;
            MaLoai = string.Empty;
            MaLoaiTiemChung = string.Empty;
            MaPhongNgua = string.Empty;
        }

        public VaccineDTO(string maVaccine, string tenVaccine, string nguonGoc, string lieuLuong, int tinhTrang, string maLoai, string maLoaiTiemChung, string maPhongNgua)
        {
            this.MaVaccine = maVaccine;
            this.TenVaccine = tenVaccine;
            this.NguonGoc = nguonGoc;
            this.LieuLuong = lieuLuong;
            this.TinhTrang = tinhTrang;
            this.MaLoai = maLoai;
            this.MaLoaiTiemChung = maLoaiTiemChung;
            this.MaPhongNgua = maPhongNgua;
        }
    }
}
