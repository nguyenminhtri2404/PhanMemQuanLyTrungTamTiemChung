using DAL;
using DTO;
using System.Collections.Generic;

namespace BUL
{
    public class NguoiGiamHoBUL
    {
        private NguoiGiamHoDAL nguoiGiamHoDAL;

        public NguoiGiamHoBUL()
        {
            nguoiGiamHoDAL = new NguoiGiamHoDAL();
        }
        // Lấy danh sách tất cả người giám hộ
        public List<NguoiGiamHoDTO> GetAllNguoiGiamHo()
        {
            return nguoiGiamHoDAL.GetAllNguoiGiamHo();
        }

        // Thêm người giám hộ
        public bool ThemNguoiGiamHo(NguoiGiamHoDTO nguoiGiamHo)
        {
            return nguoiGiamHoDAL.ThemNguoiGiamHo(nguoiGiamHo);
        }

        // Lấy mã người giám hộ lớn nhất
        public int GetMaxMaNguoiGiamHo()
        {
            return nguoiGiamHoDAL.GetMaxMaNguoiGiamHo();
        }

        // Kiểm tra người giám hộ có tồn tại hay không
        public bool KiemTraNguoiGiamHoTonTai(string maNguoiGiamHo)
        {
            return nguoiGiamHoDAL.KiemTraNguoiGiamHoTonTai(maNguoiGiamHo);
        }
    }
}
