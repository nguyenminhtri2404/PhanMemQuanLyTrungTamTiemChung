using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NguoiGiamHoDAL
    {
        private QL_TiemChungDataContext db = new QL_TiemChungDataContext();

        public List<NguoiGiamHoDTO> GetAllNguoiGiamHo()
        {
            return db.NguoiGiamHos
                .Select(nv => new NguoiGiamHoDTO
                {
                    MaNguoiGiamHo = nv.maNguoiGiamHo,
                    HoTen = nv.hoTen,
                    GioiTinh = nv.gioiTinh,
                    NgaySinh = nv.ngaySinh,
                    DiaChi = nv.diaChi,
                    SDT = nv.sDT,
                    Email = nv.email,
                    QuanHe = nv.quanHe
                })
                .ToList();
        }

        // Phương thức kiểm tra mã người giám hộ tồn tại
        public bool KiemTraNguoiGiamHoTonTai(string maNguoiGiamHo)
        {
            return db.NguoiGiamHos
                .Any(ngh => ngh.maNguoiGiamHo == maNguoiGiamHo);
        }

        // Phương thức thêm người giám hộ
        public bool ThemNguoiGiamHo(NguoiGiamHoDTO nguoiGiamHo)
        {
            try
            {
                NguoiGiamHo newNguoiGiamHo = new NguoiGiamHo
                {
                    maNguoiGiamHo = nguoiGiamHo.MaNguoiGiamHo,
                    hoTen = nguoiGiamHo.HoTen,
                    gioiTinh = nguoiGiamHo.GioiTinh,
                    ngaySinh = nguoiGiamHo.NgaySinh,
                    diaChi = nguoiGiamHo.DiaChi,
                    sDT = nguoiGiamHo.SDT,
                    email = nguoiGiamHo.Email,
                    quanHe = nguoiGiamHo.QuanHe
                };
                db.NguoiGiamHos.InsertOnSubmit(newNguoiGiamHo);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm người giám hộ: " + ex.Message);
                return false;
            }
        }

        // Lấy mã người giám hộ lớn nhất để sinh mã mới
        public int GetMaxMaNguoiGiamHo()
        {
            List<string> maNguoiGiamHos = db.NguoiGiamHos
                .Select(nv => nv.maNguoiGiamHo)
                .ToList();

            int maxMaNguoiGiamHo = maNguoiGiamHos
                .Where(mngh => !string.IsNullOrEmpty(mngh) && mngh.Length > 2)
                .Select(mngh => int.Parse(mngh.Substring(3)))
                .DefaultIfEmpty(0)
                .Max();

            return maxMaNguoiGiamHo;
        }
    }
}
