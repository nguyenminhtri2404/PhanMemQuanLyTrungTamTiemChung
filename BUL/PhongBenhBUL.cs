using DAL;
using DTO;
using System.Collections.Generic;

namespace BUL
{
    public class PhongBenhBUL
    {
        private PhongBenhDAL phongBenhDAL;

        public PhongBenhBUL()
        {
            phongBenhDAL = new PhongBenhDAL();
        }
        // Phương thức lấy danh sách phòng bệnh
        public List<PhongBenhDTO> GetPhongBenhList()
        {
            return phongBenhDAL.GetPhongBenhList();
        }
        public bool ThemPhongBenh(PhongBenhDTO phongBenh)
        {
            return phongBenhDAL.ThemPhongBenh(phongBenh);
        }

        // Lấy mã phòng bệnh
        public int GetMaxMaPhongBenh()
        {
            return phongBenhDAL.GetMaxMaPhongBenh();
        }
    }
}
