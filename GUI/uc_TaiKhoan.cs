using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class uc_TaiKhoan : UserControl
    {
        public uc_TaiKhoan()
        {
            InitializeComponent();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            //Tạo nút đăng xuất bằng toolstrip

            ToolStripMenuItem item = new ToolStripMenuItem("Đăng xuất");
            item.Click += new EventHandler(item_Click);
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add(item);
            menu.Show(btn_DangXuat, new Point(0, btn_DangXuat.Height));
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frm_DangNhap frm = new frm_DangNhap();
                frm.Show();
                Form frmMain = this.FindForm();
                frmMain.Hide();
            }
        }

        //Load hiển thị
        public void loadThongTinHoTen(NhanVienDTO nhanVienDTO)
        {
            lb_HoTen.Text = nhanVienDTO.hoTen;
        }

        public void loadThongTinChucVu(string chucVu)
        {
            lb_ChucVu.Text = chucVu;
        }



        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frm_DangNhap frm = new frm_DangNhap();
                frm.Show();
                Form frmMain = this.FindForm();
                frmMain.Hide();
            }
        }
    }
}
