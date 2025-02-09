using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class LoaiVaccineBUL
    {
        LoaiVaccineDAL loaiVaccineDAL;

        public LoaiVaccineBUL()
        {
            loaiVaccineDAL = new LoaiVaccineDAL();
        }

        public DataTable layTatCaLoaiVaccine()
        {
            return loaiVaccineDAL.layTatCaLoaiVaccine();
        }

        public string taoMaLoaiVaccine()
        {
            return loaiVaccineDAL.taoMaLoaiVaccine();
        }

        public bool themLoaiVaccine(LoaiVaccineDTO loaiVaccineDTO)
        {
            return loaiVaccineDAL.themLoaiVaccine(loaiVaccineDTO);
        }

        public bool suaLoaiVaccine(LoaiVaccineDTO loaiVaccineDTO)
        {
            return loaiVaccineDAL.suaLoaiVaccine(loaiVaccineDTO);
        }

        public bool xoaLoaiVaccine(string maLoai)
        {
            return loaiVaccineDAL.xoaLoaiVaccine(maLoai);
        }
    }
}
