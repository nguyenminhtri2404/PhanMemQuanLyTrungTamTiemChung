using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class LoVaccineBUL
    {
        LoVaccineDAL loVaccineDAL;

        public LoVaccineBUL()
        {
            loVaccineDAL = new LoVaccineDAL();
        }

        public DataTable layTatCaLoVaccine()
        {
            return loVaccineDAL.layTatCaLoVaccine();
        }

        public string taoMaLoVaccine()
        {
            return loVaccineDAL.taoMaLoVaccine();
        }

        public DataTable layLoVaccineTheoMa(string maLo)
        {
            return loVaccineDAL.layLoVaccineTheoMaLo(maLo);
        }

        //public bool themLoVaccine(LoVaccineDTO loVaccineDTO)
        //{
        //    return loVaccineDAL.themLoVaccine(loVaccineDTO);
        //}

        public (bool isSuccess, string message) themLoVaccine(LoVaccineDTO loVaccineDTO)
        {
            return loVaccineDAL.themLoVaccine(loVaccineDTO);
        }


        public bool suaLoVaccine(LoVaccineDTO loVaccineDTO)
        {
            return loVaccineDAL.suaLoVaccine(loVaccineDTO);
        }

        public bool xoaLoVaccine(string maLo)
        {
            return loVaccineDAL.xoaLoVaccine(maLo);
        }

        public List<string> layTatCaMaLo()
        {
            return loVaccineDAL.layTatCaMaLo();
        }

        public DataTable layLoVaccineTheoMaVaccine(string maVaccine, string maLo)
        {
            return loVaccineDAL.layLoVaccineTheoMaVaccine(maVaccine, maLo);
        }

        public List<LoVaccineDTO> layDanhSachLoVacineTheoMaVaccine(string maVaccine)
        {
            return loVaccineDAL.layDanhSachLoVacineTheoMaVaccine(maVaccine);
        }
    }
}
