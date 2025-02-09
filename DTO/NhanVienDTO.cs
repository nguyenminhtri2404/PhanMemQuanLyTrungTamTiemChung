using System;

namespace DTO
{
    public class NhanVienDTO
    {
        public string maNhanVien { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string sDT { get; set; }
        public string email { get; set; }
        public NhanVienDTO()
        {
            maNhanVien = string.Empty;
            hoTen = string.Empty;
            gioiTinh = string.Empty;
            ngaySinh = DateTime.MinValue;
            diaChi = string.Empty;
            sDT = string.Empty;
            email = string.Empty;
        }

        public NhanVienDTO(string maNhanVien, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string sDT, string email)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
        }
    }

}
