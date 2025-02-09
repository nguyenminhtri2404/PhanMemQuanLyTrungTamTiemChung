using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_CapNhatTheoDoi : Form
    {
        string hoTen, ngaySinh, maHoaDon, tenNhanVien, maNhanVien;
        int soLanTiem;
        PhieuTheoDoiBUL phieuTheoDoiBUL;

        public frm_CapNhatTheoDoi(string hoTen, string ngaySinh, string maHoaDon, int soLanTiem, string tenNhanVien, string maNhanVien)
        {
            InitializeComponent();
            phieuTheoDoiBUL = new PhieuTheoDoiBUL();
            txt_TenKH.Text = hoTen;
            txt_LanTiem.Text = soLanTiem.ToString();
            dtp_NgaySinh.Value = DateTime.Parse(ngaySinh);
            this.maHoaDon = maHoaDon;
            this.tenNhanVien = tenNhanVien;
            this.maNhanVien = maNhanVien;

            txt_TenNV.Text = tenNhanVien;
            phanUng();

            dtp_ThoiGianTheoDoi.Value = DateTime.Now;
        }

        public void phanUng()
        {
            string[] dsPhanUng = { "Bình thường", "Có phản ứng nhẹ", "Tai biến nặng" };
            foreach (string phanUng in dsPhanUng)
            {
                cbo_PhanUng.Items.Add(phanUng);
            }

            cbo_PhanUng.SelectedIndex = 0;
            cbo_PhanUng.DisplayMember = dsPhanUng.ToString();
            cbo_PhanUng.ValueMember = dsPhanUng.ToString();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            PhieuTheoDoiDTO phieuTheoDoi = new PhieuTheoDoiDTO();
            phieuTheoDoi.MaPhieuTheoDoi = phieuTheoDoiBUL.taoMaPhieuTheoDoi();
            phieuTheoDoi.MaHoaDon = maHoaDon;
            phieuTheoDoi.TinhTrangSauTiem = cbo_PhanUng.SelectedItem.ToString();
            phieuTheoDoi.Lan = int.Parse(txt_LanTiem.Text);
            phieuTheoDoi.GhiChu = txt_GhiChu.Text;
            phieuTheoDoi.MaNhanVien = maNhanVien;
            phieuTheoDoi.ThoiGianTiem = dtp_ThoiGianTheoDoi.Value;

            if (phieuTheoDoiBUL.themPhieuTheoDoi(phieuTheoDoi))
            {
                MessageBox.Show("Thêm phiếu theo dõi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Thêm phiếu theo dõi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
