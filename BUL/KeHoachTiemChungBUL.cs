using DAL;
using DTO;
using System.Collections.Generic;

namespace BUL
{
    public class KeHoachTiemChungBUL
    {
        KeHoachTiemChungDAL kehoachTiemChungDAL;

        public KeHoachTiemChungBUL()
        {
            kehoachTiemChungDAL = new KeHoachTiemChungDAL();
        }
        public KeHoachTiemChungDTO GetKeHoachTiemChung(string maVaccine)
        {
            return kehoachTiemChungDAL.GetKeHoachTiemChung(maVaccine);
        }
        public List<KeHoachTiemChungDTO> GetKeHoachByMa(string maKeHoach)
        {
            return kehoachTiemChungDAL.GetKeHoachByMa(maKeHoach);
        }
        public List<KeHoachTiemChungDTO> GetKeHoachCombo()
        {
            return kehoachTiemChungDAL.GetKeHoachCombo();
        }
    }
}
