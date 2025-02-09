using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLNhanVienChucVu : Form
    {
        TaiKhoanBUL taiKhoanBUL;
        ChucVuBUL chucVuBUL;
        NhanVien_ChucVuBUL nhanVien_ChucVuBUL;
        int flag = 0;
        string tenDangNhap;
        public frm_QLNhanVienChucVu()
        {
            InitializeComponent();
            taiKhoanBUL = new TaiKhoanBUL();
            chucVuBUL = new ChucVuBUL();
            nhanVien_ChucVuBUL = new NhanVien_ChucVuBUL();
            loadData();
            loadCombobox();
            enbaleButton(true);
        }


        public void clearData()
        {
            cbo_TenChucVu.SelectedIndex = -1;
            cbo_TenDangNhap.SelectedIndex = -1;
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
            dgv_DSNV_CV.DataSource = nhanVien_ChucVuBUL.layDanhSachNhanVienChucVu();
        }

        public void loadCombobox()
        {
            cbo_TenChucVu.DataSource = chucVuBUL.getChucVu();
            cbo_TenChucVu.DisplayMember = "TenChucVu";
            cbo_TenChucVu.ValueMember = "MaChucVu";
            cbo_TenChucVu.SelectedIndex = -1;

            cbo_TenDangNhap.DataSource = taiKhoanBUL.layDanhSachTaiKhoan();
            cbo_TenDangNhap.DisplayMember = "TenDangNhap";
            cbo_TenDangNhap.ValueMember = "TenDangNhap";
            cbo_TenDangNhap.SelectedIndex = -1;
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            enbaleButton(false);
            dgv_DSNV_CV.Enabled = false;
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (tenDangNhap == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 2;
            enbaleButton(false);
            dgv_DSNV_CV.Enabled = false;
        }

        private void dgv_DSNV_CV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                tenDangNhap = dgv_DSNV_CV.Rows[i].Cells[0].Value.ToString();
                cbo_TenDangNhap.Text = dgv_DSNV_CV.Rows[i].Cells[0].Value.ToString();

                // Tìm giá trị của maChucVu từ DataGridView và gán nó cho SelectedValue của cbo_TenChucVu
                string maChucVu = dgv_DSNV_CV.Rows[i].Cells[1].Value.ToString();
                cbo_TenChucVu.SelectedValue = maChucVu;
            }
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            dgv_DSNV_CV.Enabled = true;
            enbaleButton(true);
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            NhanVien_ChucVuDTO nhanVien_ChucVuDTO = new NhanVien_ChucVuDTO();
            nhanVien_ChucVuDTO.TenDangNhap = cbo_TenDangNhap.Text;
            nhanVien_ChucVuDTO.MaChucVu = cbo_TenChucVu.SelectedValue.ToString();

            if (flag == 1)
            {
                if (cbo_TenChucVu.SelectedIndex == -1 || cbo_TenDangNhap.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nhanVien_ChucVuBUL.themNhanVienChucVu(nhanVien_ChucVuDTO))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSNV_CV.Enabled = true;
                    flag = 0;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (flag == 2)
            {
                if (cbo_TenChucVu.SelectedIndex == -1 || cbo_TenDangNhap.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (nhanVien_ChucVuBUL.suaNhanVienChucVu(nhanVien_ChucVuDTO))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSNV_CV.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (flag == 3)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (nhanVien_ChucVuBUL.xoaNhanVienChucVu(nhanVien_ChucVuDTO.TenDangNhap, nhanVien_ChucVuDTO.MaChucVu))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSNV_CV.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (tenDangNhap == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSNV_CV.Enabled = false;
        }
    }
}
