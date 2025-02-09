using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class ThongTinChiTietVaccineBUL
    {
        private ThongTinChiTietVaccineDAL thongtinchitietvacxinDAL;

        public ThongTinChiTietVaccineBUL()
        {
            thongtinchitietvacxinDAL = new ThongTinChiTietVaccineDAL();
        }
        public List<ThongTinChiTietVaccineDTO> GetVaccineList()
        {
            return thongtinchitietvacxinDAL.GetVaccineList();
        }
        public ThongTinChiTietVaccineDTO GetCTVaccineInfo(string maVaccine)
        {
            return thongtinchitietvacxinDAL.GetCTVaccineInfo(maVaccine);
        }

        public DataTable LayTatCaTTCTVaccine()
        {
            return thongtinchitietvacxinDAL.getTTCTVaccineInfo();
        }
        public List<LoaiVaccineDTO> GetLoaiVaccine()
        {
            return thongtinchitietvacxinDAL.GetLoaiVaccine();
        }

        public bool ThemCTVaccine(ThongTinChiTietVaccineDTO ttctVaccine)
        {
            return thongtinchitietvacxinDAL.themThongTinCTVaccine(ttctVaccine);
        }

        public DataTable GetCTVaccineTheoMaVaccine(string maVaccine)
        {
            return thongtinchitietvacxinDAL.getTTCTVaccinetheoMaVaccine(maVaccine);
        }
    }
}
