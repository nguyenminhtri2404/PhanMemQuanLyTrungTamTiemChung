using DAL;
using DTO;
using System.Collections.Generic;

namespace BUL
{
    public class CauHoiSangLocBUL
    {
        private CauHoiSangLocDAL cauHoiSangLocDAL;

        public CauHoiSangLocBUL()
        {
            cauHoiSangLocDAL = new CauHoiSangLocDAL();
        }
        public List<CauHoiSangLocDTO> GetDanhSachCauHoi()
        {
            return cauHoiSangLocDAL.GetDanhSachCauHoi();
        }
    }
}
