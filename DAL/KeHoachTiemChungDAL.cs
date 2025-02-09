using DTO;
using System.Collections.Generic;
using System.Linq;
namespace DAL
{
    public class KeHoachTiemChungDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public KeHoachTiemChungDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public KeHoachTiemChungDTO GetKeHoachTiemChung(string maVaccine)
        {
            return db.KeHoachTiemChungs
                    .Where(k => k.maVaccine == maVaccine)
                    .Select(k => new KeHoachTiemChungDTO
                    {
                        MaKeHoach = k.maKeHoach,
                        MaVaccine = k.maVaccine,
                        SoMui = k.soMui
                    })
                    .FirstOrDefault();
        }
        public List<KeHoachTiemChungDTO> GetKeHoachByMa(string maKeHoach)
        {
            // Lấy danh sách kế hoạch tiêm chủng từ cơ sở dữ liệu dựa trên mã kế hoạch
            List<KeHoachTiemChungDTO> dskh = (from kh in db.KeHoachTiemChungs
                                              where kh.maKeHoach == maKeHoach
                                              select new KeHoachTiemChungDTO
                                              {
                                                  MaKeHoach = kh.maKeHoach,
                                                  MaVaccine = kh.maVaccine,
                                                  SoMui = kh.soMui,
                                                  TenKeHoach = kh.tenKeHoach,
                                                  ThoiGianGiuaMui = kh.thoiGianGiuaMui
                                              }).ToList();
            return dskh;
        }
        public List<KeHoachTiemChungDTO> GetKeHoachCombo()
        {
            return (from kh in db.KeHoachTiemChungs
                    select new KeHoachTiemChungDTO
                    {
                        MaKeHoach = kh.maKeHoach,
                        TenKeHoach = kh.tenKeHoach
                    }).ToList();
        }
    }
}
