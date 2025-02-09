using DAL;
using DTO;

namespace BUL
{
    public class CTPhieuNhapBUL
    {
        CTPhieuNhapDAL cTPhieuNhapDAL;
        public CTPhieuNhapBUL()
        {
            cTPhieuNhapDAL = new CTPhieuNhapDAL();
        }

        public bool themCTPhieuNhap(CTPhieuNhapDTO cTPhieuNhapDTO)
        {
            return cTPhieuNhapDAL.themChiTietPhieuNhap(cTPhieuNhapDTO);
        }
    }
}
