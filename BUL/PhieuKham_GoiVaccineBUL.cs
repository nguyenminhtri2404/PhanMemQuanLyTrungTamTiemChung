using DAL;
using DTO;
using System;

namespace BUL
{
    public class PhieuKham_GoiVaccineBUL
    {
        private readonly PhieuKham_GoiVacXinDAL goivaccineDAL;

        public PhieuKham_GoiVaccineBUL()
        {
            goivaccineDAL = new PhieuKham_GoiVacXinDAL();
        }
        public bool AddVaccineToPhieuKham(PhieuKham_GoiVacXinDTO phieuDTO)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(phieuDTO.MaGoi) || string.IsNullOrEmpty(phieuDTO.MaPhieuKham) || phieuDTO.Mui <= 0 || phieuDTO.GiaBan <= 0 || phieuDTO.ThanhTien <= 0)
            {
                // Nếu dữ liệu không hợp lệ, trả về false và thông báo lỗi
                Console.WriteLine("Dữ liệu không hợp lệ.");
                return false;
            }

            // Gọi DAL để thêm dữ liệu vào cơ sở dữ liệu
            return goivaccineDAL.InsertPhieuKhamGoiVacXin(
                phieuDTO.MaGoi,
                phieuDTO.MaPhieuKham,
                phieuDTO.GhiChu,
                phieuDTO.MoTa,
                phieuDTO.Mui,
                phieuDTO.GiaBan,
                phieuDTO.ThanhTien
            );
        }
    }
}
