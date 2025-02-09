using BUL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_DoiMatKhau : Form
    {
        TaiKhoanBUL taiKhoanBUL;
        public Form Pre;
        public frm_DoiMatKhau()
        {
            InitializeComponent();
            taiKhoanBUL = new TaiKhoanBUL();
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            //Kiểm tra nhập đầy đủ thông tin
            if (txt_TenDangNhap.Text == "" || txt_MatKhauCu.Text == "" || txt_MatKhauMoi.Text == "" || txt_XacNhanMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra tên đăng nhập và mật khẩu cũ có đúng không
            if (!taiKhoanBUL.KiemTraMatKhauCu(txt_TenDangNhap.Text, txt_MatKhauCu.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra mật khẩu mới và xác nhận mật khẩu có trùng nhau không
            if (txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Đổi mật khẩu
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (taiKhoanBUL.DoiMatKhau(txt_TenDangNhap.Text, txt_MatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Pre.Show(); // Show the previous form (frm_DangNhap)
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_NhapLai_Click(object sender, EventArgs e)
        {
            txt_TenDangNhap.Text = "";
            txt_MatKhauCu.Text = "";
            txt_MatKhauMoi.Text = "";
            txt_XacNhanMatKhau.Text = "";
        }

        private void cb_HienThiMK_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cb_HienThiMK.Checked)
            {
                txt_MatKhauCu.PasswordChar = '\0';
                txt_MatKhauMoi.PasswordChar = '\0';
                txt_XacNhanMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhauCu.PasswordChar = '*';
                txt_MatKhauMoi.PasswordChar = '*';
                txt_XacNhanMatKhau.PasswordChar = '*';
            }
        }

        private void lb_TroLaiDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
            Pre.Show(); // Show the previous form (frm_DangNhap)
        }

        private void frm_DoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Pre.Show();
            }
        }
    }
}
