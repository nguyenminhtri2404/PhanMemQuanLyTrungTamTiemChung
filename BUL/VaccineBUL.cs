using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUL
{
    public class VaccineBUL
    {
        VaccineDAL vaccineDAL;

        public VaccineBUL()
        {
            vaccineDAL = new VaccineDAL();
        }
        public DataTable LayTatCaVaccine()
        {
            return vaccineDAL.LayTatCaVaccine();
        }
        public bool UpdateSoLuongTon(string maVaccine, string maLo, int soLuongThayDoi)
        {
            // Kiểm tra các tham số hợp lệ
            if (string.IsNullOrEmpty(maVaccine) || string.IsNullOrEmpty(maLo) || soLuongThayDoi == 0)
                return false;

            // Gọi phương thức DAL để cập nhật số lượng tồn
            return vaccineDAL.UpdateSoLuongTon(maVaccine, soLuongThayDoi, maLo);
        }

        public List<VaccineDTO> GetVaccineCombo()
        {
            return vaccineDAL.getVaccineCombo();
        }

        public string taoMaVaccine()
        {
            return vaccineDAL.taoMaVaccine();
        }

        public bool themVaccine(VaccineDTO vaccine)
        {
            return vaccineDAL.ThemVaccine(vaccine);
        }

        public bool suaVaccine(VaccineDTO vaccine)
        {
            return vaccineDAL.suaVaccine(vaccine);
        }

        public bool xoaVaccine(string maVaccine)
        {
            return vaccineDAL.xoaVaccine(maVaccine);
        }

        public DataTable timKiemVaccine(string seacrchText)
        {
            return vaccineDAL.timKiemVaccine(seacrchText);
        }
        public VaccineDTO GetVaccineInfo(string maVaccine)
        {
            return vaccineDAL.GetVaccineInfo(maVaccine);
        }
        public List<VaccineDTO> GetVaccinesByPhongBenh(string maPhongNgua)
        {
            // Gọi phương thức GetVaccinesByMaPhongNgua từ DAL
            List<VaccineDTO> vaccines = vaccineDAL.GetVaccinesByMaPhongNgua(maPhongNgua)
                .Select(v => new VaccineDTO
                {
                    MaVaccine = v.maVaccine,
                    TenVaccine = v.tenVaccine
                })
                .ToList();

            return vaccines;
        }

    }
}
