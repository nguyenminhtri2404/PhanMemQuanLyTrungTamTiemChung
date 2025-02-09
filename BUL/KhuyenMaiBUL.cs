using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KhuyenMaiBUL
    {
        KhuyenMaiDAL khuyenMaiDAL;

        public KhuyenMaiBUL()
        {
            khuyenMaiDAL = new KhuyenMaiDAL();
        }
        public List<KhuyenMaiDTO> getKhuyenMai()
        {
            List<KhuyenMaiDTO> list = new List<KhuyenMaiDTO>();

            DataTable dt = khuyenMaiDAL.getKhuyenMai();
            foreach (DataRow dr in dt.Rows)
            {
                // Khởi tạo đối tượng KhachHangDTO với tất cả các tham số
                decimal phanTramKhuyenMai = dr["phanTramKhuyenMai"] != DBNull.Value ? Convert.ToDecimal(dr["phanTramKhuyenMai"]) : 0;

                // Initialize KhuyenMaiDTO with all parameters
                KhuyenMaiDTO khuyenMai = new KhuyenMaiDTO(
                    dr["maKhuyenMai"].ToString(),
                    dr["tenKhuyenMai"].ToString(),
                    phanTramKhuyenMai
                );

                list.Add(khuyenMai);
            }
            return list;
        }
        public string layMaTuDong()
        {
            return khuyenMaiDAL.layMaTuDong(); // Gọi phương thức từ DAL để lấy mã tự động
        }
        public DataTable LayTatCaKhachHang()
        {
            return khuyenMaiDAL.LayTatCaKhuyenMai();
        }
        public bool ThemKhuyenMai(string tenKhuyenMai, decimal phanTramKhuyenMai)
        {
            string maKhuyenMai = khuyenMaiDAL.layMaTuDong(); // Lấy mã khách hàng tự động
            KhuyenMaiDTO KhuyenMaiMoi = new KhuyenMaiDTO(maKhuyenMai, tenKhuyenMai, phanTramKhuyenMai);
            return khuyenMaiDAL.ThemKhuyenMai(KhuyenMaiMoi);
        }
        public bool SuaKhuyenMai(KhuyenMaiDTO khuyenMai)
        {
            // Kiểm tra mã khách hàng có tồn tại không
            if (!khuyenMaiDAL.CheckMaKhuyenMai(khuyenMai.MaKhuyenMai))
            {
                throw new Exception("Mã khách hàng không tồn tại");
            }
            return khuyenMaiDAL.SuaKhachHang(khuyenMai);
        }
        public bool XoaKhuyenMai(string maKhuyenMai)
        {
            return khuyenMaiDAL.XoaKhuyenMai(maKhuyenMai);
        }
    }
}
