using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class PhieuNhapBUL
    {
        PhieuNhapDAL phieuNhapDAL;
        public PhieuNhapBUL()
        {
            phieuNhapDAL = new PhieuNhapDAL();
        }

        public DataTable layTatCaPhieuNhap()
        {
            return phieuNhapDAL.layTatCaPhieuNhap();
        }

        public string taoMaPhieuNhap()
        {
            return phieuNhapDAL.taoMaPhieuNhap();
        }

        public bool themPhieuNhap(PhieuNhapDTO phieuNhapDTO)
        {
            return phieuNhapDAL.themPhieuNhap(phieuNhapDTO);
        }


        public DataTable layDSChiTietPhieuNhap()
        {
            return phieuNhapDAL.layDSChiTietPhieuNhap();
        }

        public DataTable layDSChiTietPhieuNhapTheoMaPhieuNhap(string maPhieuNhap)
        {
            return phieuNhapDAL.layDSChiTietPhieuNhapTheoMaPhieuNhap(maPhieuNhap);
        }
    }
}
