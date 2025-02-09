using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BUL
{
    public class PhieuKhamSangLocBUL
    {
        private PhieuKhamSangLocDAL phieuKhamDAL;

        public PhieuKhamSangLocBUL()
        {
            phieuKhamDAL = new PhieuKhamSangLocDAL();
        }

        public void LuuPhieuKham(PhieuKhamSangLocDTO phieuKham)
        {
            phieuKhamDAL.LuuPhieuKham(phieuKham);
        }
        public List<PhieuKhamSangLocDTO> GetPhieuKhamTheoMaPhieuDangKy(string maPhieuDangKy)
        {
            return phieuKhamDAL.getPhieuKhamTheoMaPhieuDangKy(maPhieuDangKy);
        }
        public int GetMaxMaPhieuKham()
        {
            return phieuKhamDAL.getMaxMaPhieuKham();
        }

        public List<PhieuKhamDetailsDTO> GetPhieuKhamDetails(string maPhieuKham)
        {
            try
            {
                // Gọi DAL để lấy dữ liệu
                List<PhieuKhamDetailsDTO> result = phieuKhamDAL.GetPhieuKhamDetails(maPhieuKham);

                // Có thể thêm logic xử lý tại đây (như kiểm tra nếu result rỗng)

                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi lấy thông tin phiếu khám: " + ex.Message);
            }
        }
    }
}
