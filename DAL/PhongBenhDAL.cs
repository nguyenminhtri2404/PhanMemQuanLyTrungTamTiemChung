using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DAL
{
    public class PhongBenhDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public PhongBenhDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public List<PhongBenhDTO> GetPhongBenhList()
        {
            // Truy vấn danh sách phòng bệnh từ cơ sở dữ liệu
            return db.PhongNguas
                     .Select(p => new PhongBenhDTO
                     {
                         MaPhongNgua = p.maPhongNgua,
                         TenBenh = p.tenBenh,
                         MoTa = p.moTa
                     }).ToList();
        }
        public bool ThemPhongBenh(PhongBenhDTO phongBenh)
        {
            try
            {
                PhongNgua newphongbenh = new PhongNgua
                {
                    maPhongNgua = phongBenh.MaPhongNgua,
                    tenBenh = phongBenh.TenBenh,
                    moTa = phongBenh.MoTa,

                };
                db.PhongNguas.InsertOnSubmit(newphongbenh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phòng bệnh: " + ex.Message);
                return false;
            }
        }

        // Lấy mã người giám hộ lớn nhất để sinh mã mới
        public int GetMaxMaPhongBenh()
        {
            List<string> maPhongbenhs = db.PhongNguas
                .Select(nv => nv.maPhongNgua)
                .ToList();

            int maxMaPhongNgua = maPhongbenhs
                .Where(mpn => !string.IsNullOrEmpty(mpn) && mpn.Length > 2)
                .Select(mpn => int.Parse(mpn.Substring(2)))
                .DefaultIfEmpty(0)
                .Max();

            return maxMaPhongNgua;
        }
    }
}
