using DAL;
using System.Data;

namespace BUL
{
    public class DanhMucManHinhBUL
    {
        DanhMucManHinhDAL danhMucManHinhDAL;

        public DanhMucManHinhBUL()
        {
            danhMucManHinhDAL = new DanhMucManHinhDAL();
        }

        public DataTable getDanhMucManHinh()
        {
            return danhMucManHinhDAL.getDanhMucManHinh();
        }

        public string taoMaManHinh()
        {
            return danhMucManHinhDAL.taoMaManHinh();
        }

        public bool themDanhMucManHinh(DTO.DanhMucManHinhDTO danhMucManHinhDTO)
        {
            return danhMucManHinhDAL.themManHinh(danhMucManHinhDTO);
        }

        public bool suaDanhMucManHinh(DTO.DanhMucManHinhDTO danhMucManHinhDTO)
        {
            return danhMucManHinhDAL.suaManHinh(danhMucManHinhDTO);
        }

        public bool xoaDanhMucManHinh(string maManHinh)
        {
            return danhMucManHinhDAL.xoaManHinh(maManHinh);
        }
    }
}
