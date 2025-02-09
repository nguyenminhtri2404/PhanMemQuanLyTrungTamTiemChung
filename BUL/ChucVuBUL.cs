using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class ChucVuBUL
    {
        ChucVuDAL chucVuDAL;

        public ChucVuBUL()
        {
            chucVuDAL = new ChucVuDAL();
        }
        public List<string> layMaChucVuTheoTenDangNhap(string tenDangNhap)
        {
            return chucVuDAL.layMaChucVuTheoTenDangNhap(tenDangNhap);
        }


        public DataTable getChucVu()
        {
            return chucVuDAL.getChucVu();
        }

        public string getChucVuByTenDangNhap(string tenDangNhap)
        {
            return chucVuDAL.getChucVuByTenDangNhap(tenDangNhap);
        }

        public string taoMaChucVu()
        {
            return chucVuDAL.taoMaChucVu();
        }

        public bool themChucVu(ChucVuDTO chucVuDTO)
        {
            return chucVuDAL.themChucVu(chucVuDTO);
        }

        public bool suaChucVu(ChucVuDTO chucVuDTO)
        {
            return chucVuDAL.suaChucVu(chucVuDTO);
        }

        public bool xoaChucVu(string maChucVu)
        {
            return chucVuDAL.xoaChucVu(maChucVu);
        }


    }
}
