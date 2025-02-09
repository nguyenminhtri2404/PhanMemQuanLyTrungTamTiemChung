using DAL;
using DTO;

namespace BUL
{
    public class PhieuTheoDoiBUL
    {
        PhieuTheoDoiDAL phieuTheoDoiDAL;

        public PhieuTheoDoiBUL()
        {
            phieuTheoDoiDAL = new PhieuTheoDoiDAL();
        }

        public string taoMaPhieuTheoDoi()
        {
            return phieuTheoDoiDAL.taoMaPhieuTheoDoi();
        }

        public bool themPhieuTheoDoi(PhieuTheoDoiDTO phieuTheoDoi)
        {
            return phieuTheoDoiDAL.themPhieuTheoDoi(phieuTheoDoi);
        }
    }
}
