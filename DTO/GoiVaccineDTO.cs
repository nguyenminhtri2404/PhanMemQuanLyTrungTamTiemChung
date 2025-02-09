using System;
using System.Collections.Generic;

namespace DTO
{
    public class GoiVaccineDTO
    {
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public DateTime? ThoiHanSuDung { get; set; }
        public int? trangThai { get; set; }
        public string MaKhuyenMai { get; set; }
        public decimal? TongTienGoi { get; set; }
        public List<VaccineGoiVaccineDTO> Vaccines { get; set; }
        public string TrangThaiText
        {
            get
            {
                if (trangThai == 0)
                    return "Chưa có hàng";
                else if (trangThai == 1)
                    return "Còn hàng";
                else
                    return "Không xác định";
            }
        }
    }
}
