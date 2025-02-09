using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class LoaiTiemChungBUL
    {
        LoaiTiemChungDAL loaiTiemChungDAL;

        public LoaiTiemChungBUL()
        {
            loaiTiemChungDAL = new LoaiTiemChungDAL();
        }

        public DataTable layTatCaLoaiTiemChung()
        {
            return loaiTiemChungDAL.layTatCaLoaiTiemChung();
        }

        public string taoMaLoaiTiemChung()
        {
            return loaiTiemChungDAL.taoMaLoaiTiemChung();
        }

        public bool themLoaiTiemChung(LoaiTiemChungDTO loaiTiemChungDTO)
        {
            return loaiTiemChungDAL.themLoaiTiemChung(loaiTiemChungDTO);
        }

        public bool suaLoaiTiemChung(LoaiTiemChungDTO loaiTiemChungDTO)
        {
            return loaiTiemChungDAL.suaLoaiTiemChung(loaiTiemChungDTO);
        }

        public bool xoaLoaiTiemChung(string maLoai)
        {
            return loaiTiemChungDAL.xoaLoaiTiemChung(maLoai);
        }
    }
}
