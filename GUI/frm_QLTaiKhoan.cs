using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLTaiKhoan : Form
    {
        TaiKhoanBUL taiKhoanBUL;
        NhanVienBUL nhanVienBUL;
        int flag = 0;
        string tenDangNhap;
        public frm_QLTaiKhoan()
        {
            InitializeComponent();
            taiKhoanBUL = new TaiKhoanBUL();
            nhanVienBUL = new NhanVienBUL();
            loadData();
            enbaleButton(true);
            clearData();
            loadComboNhanVien();
        }

        public void clearData()
        {
            txt_TenTaiKhoan.Text = "";
            rd_HoatDong.Checked = false;
            cbo_NhanVien.SelectedIndex = -1;
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }


        public void loadData()
        {
            dgv_DSTaiKhoan.DataSource = taiKhoanBUL.layDanhSachTaiKhoan();
            //Ẩn cột mật khẩu
            dgv_DSTaiKhoan.Columns["MatKhau"].Visible = false;
            dgv_DSTaiKhoan.CellFormatting += dgv_DSTaiKhoan_CellFormatting;
        }

        private void dgv_DSTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DSTaiKhoan.Columns[e.ColumnIndex].Name == "HoatDong")
            {
                if (e.Value != null)
                {
                    int hoatDongValue;
                    if (int.TryParse(e.Value.ToString(), out hoatDongValue))
                    {
                        e.Value = hoatDongValue == 1 ? "Đang hoạt động" : "Ngưng hoạt động";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        public bool checkData()
        {
            if (txt_TenTaiKhoan.Text == "" || cbo_NhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool checkHoatDong()
        {
            if (rd_HoatDong.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn trạng thái hoạt động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public void loadComboNhanVien()
        {
            cbo_NhanVien.DataSource = nhanVienBUL.LayTatCaNhanVien();
            cbo_NhanVien.DisplayMember = "hoTen";
            cbo_NhanVien.ValueMember = "maNhanVien";
            cbo_NhanVien.SelectedIndex = -1;
        }

        private void dgv_DSTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txt_TenTaiKhoan.Text = dgv_DSTaiKhoan.Rows[index].Cells["TenDN"].Value.ToString();
                tenDangNhap = txt_TenTaiKhoan.Text;
                cbo_NhanVien.SelectedValue = dgv_DSTaiKhoan.Rows[index].Cells["MaNhanVien"].Value.ToString();
                //Nếu hoatDong = 1 thì check vào checkbox
                if (dgv_DSTaiKhoan.Rows[index].Cells["HoatDong"].Value.ToString() == "1")
                {
                    rd_HoatDong.Checked = true;
                }
                else
                {
                    rd_HoatDong.Checked = false;
                }
            }
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            enbaleButton(false);
            dgv_DSTaiKhoan.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                if (checkData() && checkHoatDong())
                {
                    // Set default password to "1" and hash it
                    string defaultPassword = "1";

                    TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
                    {
                        TenDangNhap = txt_TenTaiKhoan.Text,
                        MatKhau = defaultPassword, // Use default password
                        MaNhanVien = cbo_NhanVien.SelectedValue.ToString(),
                        HoatDong = rd_HoatDong.Checked ? 1 : 0
                    };

                    bool kq = taiKhoanBUL.themTaiKhoan(taiKhoanDTO);
                    if (kq)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSTaiKhoan.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (flag == 2)
            {
                if (checkData() && checkHoatDong())
                {
                    TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
                    {
                        TenDangNhap = txt_TenTaiKhoan.Text,
                        MaNhanVien = cbo_NhanVien.SelectedValue.ToString(),
                        HoatDong = rd_HoatDong.Checked ? 1 : 0
                    };

                    if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa tài khoản này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        bool kq = taiKhoanBUL.suaTaiKhoan(taiKhoanDTO);
                        if (kq)
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                            clearData();
                            enbaleButton(true);
                            dgv_DSTaiKhoan.Enabled = true;
                            flag = 0;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            if (flag == 3)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    bool kq = taiKhoanBUL.xoaTaiKhoan(tenDangNhap);
                    if (kq)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSTaiKhoan.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 2;
            enbaleButton(false);
            dgv_DSTaiKhoan.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            enbaleButton(true);
            dgv_DSTaiKhoan.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSTaiKhoan.Enabled = false;
        }
    }
}
