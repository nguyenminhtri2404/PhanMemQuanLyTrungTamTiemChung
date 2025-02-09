using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
namespace BUL
{
    public class KhachHangBUL
    {
        private KhachHangDAL khachhangDAL;

        public KhachHangBUL()
        {
            khachhangDAL = new KhachHangDAL();
        }
        public List<KhachHangDTO> GetKhachHang()
        {
            List<KhachHangDTO> listkhachhang = new List<KhachHangDTO>();
            DataTable dt = khachhangDAL.getKhachHang();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO
                {
                    maKH = dr["maKhachHang"].ToString(),
                    hoTen = dr["hoTen"].ToString(),
                    gioiTinh = dr["gioiTinh"].ToString(),
                    ngaySinh = DateTime.Parse(dr["ngaySinh"].ToString()),
                    diaChi = dr["diaChi"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    email = dr["email"].ToString(),
                    MaNguoiGiamHo = dr["maNguoiGiamHo"]?.ToString()
                };
                listkhachhang.Add(kh);
            }
            return listkhachhang;
        }
        public int GetMaxMaKhachHang()
        {
            return khachhangDAL.getMaxMaKhachHang();
        }

        //public bool ThemKhachHang(KhachHangDTO khachhang)
        //{
        //    return khachhangDAL.ThemKhachHang(khachhang);
        //}

        public (bool isSuccess, string message) ThemKhachHang(KhachHangDTO khachhang)
        {
            (bool isSuccess, string message) result = khachhangDAL.ThemKhachHang(khachhang); // Gọi đến DAL
            return result; // Trả về kết quả từ DAL
        }


        public bool SuaKhachHang(KhachHangDTO khachhang)
        {
            return khachhangDAL.suaKhachHang(khachhang);
        }
    }
}
