using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
namespace BUL
{
    public class TiemChungBUL
    {
        TiemChungDAL tiemchungDAL;
        public TiemChungBUL()
        {
            tiemchungDAL = new TiemChungDAL();
        }
        public List<TiemChungDTO> getTiemChung()
        {
            List<TiemChungDTO> list = new List<TiemChungDTO>();

            DataTable dt = tiemchungDAL.getTiemChung();
            foreach (DataRow dr in dt.Rows)
            {
                TiemChungDTO tiemchung = new TiemChungDTO
                {
                    maPhieuDangKy = dr["maPhieuDangKy"].ToString(),
                    hinhThucTiem = dr["hinhThucTiem"].ToString(),
                    hoTen = dr["hoTen"].ToString(),
                    gioiTinh = dr["gioiTinh"].ToString(),
                    ngaySinh = DateTime.Parse(dr["ngaySinh"].ToString()),
                    diaChi = dr["diaChi"].ToString(),
                    ngayDangKy = DateTime.Parse(dr["ngayDangKy"].ToString()),

                };
                list.Add(tiemchung);
            }
            return list;
        }
        public List<TiemChungDTO> getTiemChungDangCho()
        {
            List<TiemChungDTO> list = new List<TiemChungDTO>();

            DataTable dt = tiemchungDAL.getTiemChungDangCho();
            foreach (DataRow dr in dt.Rows)
            {
                TiemChungDTO tiemchung = new TiemChungDTO
                {
                    maPhieuDangKy = dr["maPhieuDangKy"].ToString(),
                    hinhThucTiem = dr["hinhThucTiem"].ToString(),
                    hoTen = dr["hoTen"].ToString(),
                    gioiTinh = dr["gioiTinh"].ToString(),
                    ngaySinh = DateTime.Parse(dr["ngaySinh"].ToString()),
                    diaChi = dr["diaChi"].ToString(),
                    maKhachHang = dr["maKhachHang"].ToString(),
                    ngayDangKy = DateTime.Parse(dr["ngayDangKy"].ToString()),
                    trangThai = dr["trangThai"] != DBNull.Value ? int.Parse(dr["trangThai"].ToString()) : 0
                };
                list.Add(tiemchung);
            }
            return list;
        }

        public void SaveTiemChung(TiemChungDTO tiemChung)
        {
            if (string.IsNullOrWhiteSpace(tiemChung.hinhThucTiem))
                throw new ArgumentException("Hình thức tiêm không được để trống.");

            ThongTinDangKy thongTinDangKy = new ThongTinDangKy
            {
                maPhieuDangKy = GenerateMaPhieuDangKy(),
                hinhThucTiem = tiemChung.hinhThucTiem,
                ngayDangKy = tiemChung.ngayDangKy,
                ghiChu = tiemChung.GhiChu,
                maNhanVien = tiemChung.MaNhanVien,
                maKhachHang = tiemChung.maKhachHang,
                trangThai = tiemChung.trangThai
            };

            tiemchungDAL.SaveTiemChung(thongTinDangKy);
        }

        private string GenerateMaPhieuDangKy()
        {
            int maxMaDK = tiemchungDAL.GetMaxMaPhieuDangKy();
            int newMaDk = maxMaDK + 1;
            return "PDK" + newMaDk.ToString().PadLeft(3, '0');
        }
        public string GetMaPhieuByTenKhachHang(string tenKhachHang)
        {
            return tiemchungDAL.GetMaPhieuByTenKhachHang(tenKhachHang);
        }

        public int GetMaxMaPhieuDangKy()
        {
            return tiemchungDAL.GetMaxMaPhieuDangKy();
        }

    }
}
