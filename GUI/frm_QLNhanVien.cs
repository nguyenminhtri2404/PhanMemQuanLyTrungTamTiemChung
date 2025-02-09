using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLNhanVien : Form
    {
        NhanVienBUL nhanVienBUL;
        int flag = 0;
        string maNV;
        public frm_QLNhanVien()
        {
            InitializeComponent();
            nhanVienBUL = new NhanVienBUL();
            loadData();
            enbaleButton(true);
            clearData();

        }

        public void clearData()
        {
            txt_MaNhanVien.Text = "";
            txt_SDT.Text = "";
            txt_Email.Text = "";
            txt_DiaChi.Text = "";
            txt_HoTenNV.Text = "";
            rd_GTNam.Checked = false;
            rd_GTNu.Checked = false;
            dtp_NgaySinh.Value = System.DateTime.Now;
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        public bool checkData()
        {
            if (txt_HoTenNV.Text == "" || txt_SDT.Text == "" || txt_Email.Text == "" || txt_DiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool checkGT()
        {
            if (rd_GTNam.Checked == false && rd_GTNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool checkNgaySinh()
        {
            DateTime ngaySinh = dtp_NgaySinh.Value;
            DateTime now = DateTime.Now;

            if (ngaySinh > now || ngaySinh.Year < 1900)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Kiểm tra tuổi nhân viên phải đủ 18 tuổi trở lên
            int age = now.Year - ngaySinh.Year;
            if (ngaySinh > now.AddYears(-age)) age--;

            if (age < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //Kiểm tra số điện thoại phải đủ 10 số
        public bool checkSDT()
        {
            if (txt_SDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //Kiểm tra email phải đúng định dạng sử dụng Regex
        public bool checkEmail()
        {
            string email = txt_Email.Text;
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        public void loadData()
        {
            dgv_DSNhanVien.DataSource = nhanVienBUL.LayTatCaNhanVien();
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            clearData();
            enbaleButton(false);
            txt_MaNhanVien.Text = nhanVienBUL.taoMaNhanVien();
            dgv_DSNhanVien.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            NhanVienDTO nhanVienDTO = new NhanVienDTO();
            nhanVienDTO.maNhanVien = txt_MaNhanVien.Text;
            nhanVienDTO.hoTen = txt_HoTenNV.Text;
            nhanVienDTO.sDT = txt_SDT.Text;
            nhanVienDTO.email = txt_Email.Text;
            nhanVienDTO.diaChi = txt_DiaChi.Text;
            nhanVienDTO.ngaySinh = dtp_NgaySinh.Value;
            nhanVienDTO.gioiTinh = rd_GTNam.Checked ? "Nam" : "Nữ";

            if (flag == 1)
            {
                if (checkData() && checkGT() && checkNgaySinh() && checkSDT() && checkEmail())
                {
                    bool kq = nhanVienBUL.themNhanVien(nhanVienDTO);
                    if (kq)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSNhanVien.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (flag == 2)
            {
                if (checkData() && checkGT() && checkNgaySinh() && checkSDT() && checkEmail())
                {
                    bool kq = nhanVienBUL.suaNhanVien(nhanVienDTO);
                    if (kq)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSNhanVien.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (flag == 3)
            {
                bool kq = nhanVienBUL.xoaNhanVien(maNV);
                if (kq)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSNhanVien.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (maNV == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 2;
            enbaleButton(false);
            dgv_DSNhanVien.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSNhanVien.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (maNV == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSNhanVien.Enabled = false;
        }

        private void dgv_DSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txt_MaNhanVien.Text = dgv_DSNhanVien.Rows[index].Cells["maNhanVien"].Value.ToString();
                maNV = txt_MaNhanVien.Text;
                txt_HoTenNV.Text = dgv_DSNhanVien.Rows[index].Cells["hoTen"].Value.ToString();
                txt_SDT.Text = dgv_DSNhanVien.Rows[index].Cells["sDT"].Value.ToString();
                txt_Email.Text = dgv_DSNhanVien.Rows[index].Cells["email"].Value.ToString();
                txt_DiaChi.Text = dgv_DSNhanVien.Rows[index].Cells["diaChi"].Value.ToString();
                dtp_NgaySinh.Value = (System.DateTime)dgv_DSNhanVien.Rows[index].Cells["ngaySinh"].Value;
                if (dgv_DSNhanVien.Rows[index].Cells["gioiTinh"].Value.ToString() == "Nam")
                {
                    rd_GTNam.Checked = true;
                    rd_GTNu.Checked = false;
                }
                else
                {
                    rd_GTNu.Checked = true;
                    rd_GTNam.Checked = false;
                }
            }
        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Thông báo bằng errorProvider
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txt_SDT, "Vui lòng nhập số");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}