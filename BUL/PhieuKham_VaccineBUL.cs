using DAL;

namespace BUL
{
    public class PhieuKham_VaccineBUL
    {
        private readonly PhieuKham_VaccineDAL vaccineDAL;

        public PhieuKham_VaccineBUL()
        {
            vaccineDAL = new PhieuKham_VaccineDAL();
        }
        public void AddVaccineToPhieuKham(string maVaccine, string maPhieuKham, string ghiChu, string ketLuan, int mui, decimal giaBan)
        {
            vaccineDAL.AddVaccineToPhieuKham(maVaccine, maPhieuKham, ghiChu, ketLuan, mui, giaBan);
        }

    }
}
