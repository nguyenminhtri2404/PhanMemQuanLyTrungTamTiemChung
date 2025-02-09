using System;

namespace DTO
{
    public class LichSuTiemChungDTO
    {
        public string MaLichSuTiemChung { get; set; }
        public DateTime NgayTiem { get; set; }
        public string MaLichTiemChung { get; set; }
        public string MaNhanVien { get; set; }
        public int Mui { get; set; }
        public string MaVaccine { get; set; }
        public string TenVaccine { get; set; }

        public LichSuTiemChungDTO()
        {

        }

        public LichSuTiemChungDTO(string maLichSuTiemChung, DateTime ngayTiem, string maLichTiemChung, string maVaccine, string maNhanVien, string tenVaccine, int mui)
        {
            this.MaLichSuTiemChung = maLichSuTiemChung;
            this.NgayTiem = ngayTiem;
            this.MaLichTiemChung = maLichTiemChung;
            this.MaNhanVien = maNhanVien;
            this.MaVaccine = maVaccine;
            this.TenVaccine = tenVaccine;
            this.Mui = mui;
        }

    }
}
