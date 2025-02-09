using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_DangNhap : Form
    {
        TaiKhoanBUL bul = new TaiKhoanBUL();
        public frm_DangNhap()
        {
            InitializeComponent();
            //Không cho phép thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Không cho phép phóng to, thu nhỏ form
            this.MaximizeBox = false;
            cb_HienThiMK.Checked = false;
            txt_TenDangNhap.Focus();
            txt_TenDangNhap.Text = "admin";
            txt_MatKhau.Text = "1";
            this.AcceptButton = btn_DangNhap;
        }

        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btn_CauHinh_Click(object sender, System.EventArgs e)
        {
            frm_CauHinh frm = new frm_CauHinh();
            frm.Pre = this;
            frm.Show();
            this.Hide();
        }

        private void btn_DangNhap_Click(object sender, System.EventArgs e)
        {
            if (txt_TenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập " + lb_TenDangNhap.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenDangNhap.Focus();
                return;
            }

            if (txt_MatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập " + lb_MatKhau.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhau.Focus();
                return;
            }

            // Kiểm tra tài khoản và mật khẩu
            string username = txt_TenDangNhap.Text;
            string password = txt_MatKhau.Text;
            TaiKhoanDTO user = new TaiKhoanDTO(username, password, 1);
            string maNhanVien = bul.kiemTraDangNhap(user);

            if (maNhanVien == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenDangNhap.Focus();
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_Main2 frm = new frm_Main2(username, maNhanVien);
                frm.Show();
                this.Hide();

                // Hủy đăng ký sự kiện FormClosing của frm_DangNhap
                this.FormClosing -= frm_DangNhap_FormClosing;

                //Nếu frm_Main2 đóng thì frm_DangNhap cũng đóng
                frm.FormClosed += (s, args) => this.Close();
            }
        }

        private void cb_HienThiMK_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cb_HienThiMK.Checked)
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void btn_NhapLai_Click(object sender, System.EventArgs e)
        {
            txt_TenDangNhap.Text = "";
            txt_MatKhau.Text = "";
            txt_TenDangNhap.Focus();
        }

        private void lb_DoiMatKhau_Click(object sender, System.EventArgs e)
        {
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.Pre = this;
            frm.Show();
            this.Hide();
        }
    }
}
