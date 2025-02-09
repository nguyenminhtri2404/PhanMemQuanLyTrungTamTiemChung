using BUL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_Main2 : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentSelectedButton;
        private Form activeForm = null;
        string username;
        string maNhanVien;
        string hoTen;
        NhanVienBUL nhanVienBUL;
        ChucVuBUL chucVuBUL;
        PhanQuyenBUL phanQuyenBUL;

        public frm_Main2(string username, string maNhanVien)
        {
            InitializeComponent();
            mnu_TaiNguyen.IsMainMenu = true;
            mnu_TaiNguyen.PrimaryColor = Color.FromArgb(42, 56, 145);
            mnu_TaiNguyen.MenuItemTextColor = Color.Black;
            mnu_TaiNguyen.MenuItemHeight = 40;

            mnu_Kho.IsMainMenu = true;
            mnu_Kho.PrimaryColor = Color.FromArgb(42, 56, 145);
            mnu_Kho.MenuItemTextColor = Color.Black;
            mnu_Kho.MenuItemHeight = 40;

            mnu_QLHeThong.IsMainMenu = true;
            mnu_QLHeThong.PrimaryColor = Color.FromArgb(42, 56, 145);
            mnu_QLHeThong.MenuItemTextColor = Color.Black;
            mnu_QLHeThong.MenuItemHeight = 40;

            mnu_TaiNguyen.Closed += Menu_Closed;
            mnu_Kho.Closed += Menu_Closed;
            mnu_QLHeThong.Closed += Menu_Closed;
            this.username = username;

            nhanVienBUL = new NhanVienBUL();
            chucVuBUL = new ChucVuBUL();
            phanQuyenBUL = new PhanQuyenBUL();
            uc_TaiKhoan1.loadThongTinHoTen(nhanVienBUL.getNhanVienByTenDangNhap(username));
            hoTen = nhanVienBUL.getNhanVienByTenDangNhap(username).hoTen;
            uc_TaiKhoan1.loadThongTinChucVu(chucVuBUL.getChucVuByTenDangNhap(username));
            this.maNhanVien = maNhanVien;

            // Phân quyền
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            List<string> nhomChucVu = new ChucVuBUL().layMaChucVuTheoTenDangNhap(username);
            foreach (string item in nhomChucVu)
            {
                DataTable dsQuyen = phanQuyenBUL.layDanhSachQuyen(item);
                //Lưu danh sách mã màn hình vào List

                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(mnu_TaiNguyen.Items, mh[1].ToString(), Convert.ToBoolean(mh[2]));
                    FindButtonPhanQuyen(mh[1].ToString(), Convert.ToBoolean(mh[2]));
                }
            }
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection menuItems, string pScreeName, bool pEnable)
        {
            foreach (ToolStripMenuItem menu in menuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, pScreeName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(pScreeName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
        }

        private void FindButtonPhanQuyen(string pScreeName, bool pEnable)
        {
            // Dò trên pnl_Left (Menu) để tìm button
            foreach (Control control in pnL_Button.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button && string.Equals(pScreeName, button.Tag))
                {
                    button.Enabled = pEnable;
                    button.Visible = pEnable;
                }
            }

        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection menuItems)
        {
            foreach (ToolStripMenuItem menuItem in menuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;
                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }

            return false;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnl_Right.Controls.Add(childForm);
            pnl_Right.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_Nav_Click(object sender, System.EventArgs e)
        {
            if (pnl_Left.Width == 60)
            {
                pnl_Left.Visible = false;
                pnl_Left.Width = 260;
                foreach (Control control in pnL_Button.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2Button button)
                    {
                        button.Text = button.Tag.ToString(); // Restore the text from the Tag property
                    }
                }
                // Restore the text of btn_Thoat
                btn_Thoat.Text = btn_Thoat.Tag.ToString();
                animationPanel.ShowSync(pnl_Left);
            }
            else
            {
                pnl_Left.Visible = false;
                pnl_Left.Width = 60;
                foreach (Control control in pnL_Button.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2Button button)
                    {
                        button.Tag = button.Text; // Save the text to the Tag property
                        button.Text = ""; // Hide the text
                    }
                }
                // Save the text of btn_Thoat and hide it
                btn_Thoat.Tag = btn_Thoat.Text;
                btn_Thoat.Text = "";
                animationPanel.ShowSync(pnl_Left);
            }
        }

        private void btn_QLTaiNguyen_Click(object sender, System.EventArgs e)
        {
            mnu_TaiNguyen.Show(btn_QLTaiNguyen, btn_QLTaiNguyen.Width, 0);
            SetButtonSelected(btn_QLTaiNguyen);
        }

        private void btn_QL_Kho_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_QLKho);
            openChildForm(new frm_NhapVaccine(hoTen, maNhanVien));
        }

        private void SetButtonSelected(Guna.UI2.WinForms.Guna2Button button)
        {
            if (currentSelectedButton != null && currentSelectedButton != button)
            {
                currentSelectedButton.BackColor = Color.Transparent;
            }

            button.BackColor = Color.FromArgb(42, 56, 145); // Set selected color
            currentSelectedButton = button;
        }

        private void Menu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.Transparent;
                currentSelectedButton = null;
            }
        }

        private void btn_DangKyTiemChung_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_DangKyTiemChung);
            openChildForm(new frm_DSDangKyTiemChung(hoTen, maNhanVien));
        }

        private void btn_ThucHienTiemChung_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_ThucHienTiemChung);
            openChildForm(new frm_CapNhatTiemChung(hoTen, maNhanVien));
        }

        private void btn_HenTiem_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_NhacHen);
            openChildForm(new frm_NhacHen());
        }

        private void btn_TheoDoiSauTiem_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_TheoDoiSauTiem);
            openChildForm(new frm_TheoDoiSauTiem(hoTen, maNhanVien));
        }

        private void btn_QLNhanVien_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_QLNhanVien);
            openChildForm(new frm_QLNhanVien());
        }

        private void btn_QLTaiKhoan_Click(object sender, System.EventArgs e)
        {
            mnu_QLHeThong.Show(btn_QLTaiKhoan, btn_QLTaiKhoan.Width, 0);
            SetButtonSelected(btn_QLTaiKhoan);
        }

        private void btn_ThongKe_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_ThongKe);
            openChildForm(new frm_ThongKeDoanhThu());
        }

        private void btn_Thoat_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_Thoat);
            this.Close();
        }

        private void vaccineToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openChildForm(new frm_QLVaccine());
        }

        private void loaiVaccineToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openChildForm(new frm_QLLoaiVaccine());
        }


        private void loaiTiemChungToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openChildForm(new frm_QLLoaiTiemChung());
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openChildForm(new frm_QLNhaCungCap());
        }

        private void khuyenMaiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openChildForm(new frm_KhuyenMai());
        }

        private void frm_Main2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        private void btn_KhamSangLoc_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_KhamSangLoc);
            openChildForm(new frm_DSKhamSangLoc(hoTen, maNhanVien));
        }

        private void btn_ThanhToan_Click(object sender, System.EventArgs e)
        {
            SetButtonSelected(btn_ThanhToan);
            openChildForm(new frm_ThanhToan());
        }

        private void qLPhanQuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_QLPhanQuyen());
        }

        private void qLDanhMucManHinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_QLDanhMucManHinh());
        }

        private void qLChucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_QLChucVu());
        }

        private void qLNhanVienChucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_QLNhanVienChucVu());
        }

        private void qLTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_QLTaiKhoan());
        }
    }
}