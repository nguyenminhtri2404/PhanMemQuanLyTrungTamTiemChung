using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLPhanQuyen : Form
    {
        ChucVuBUL chucVuBUL;
        DanhMucManHinhBUL danhMucManHinh;
        PhanQuyenBUL phanQuyenBUL;
        int flag = 0;
        string tenCV, tenMH;
        public frm_QLPhanQuyen()
        {
            InitializeComponent();
            chucVuBUL = new ChucVuBUL();
            danhMucManHinh = new DanhMucManHinhBUL();
            phanQuyenBUL = new PhanQuyenBUL();
            loadCombobox();
            loadDanhSachChucVu();
            enbaleButton(true);
        }

        public void clearData()
        {
            cbo_TenChucVu.SelectedIndex = -1;
            cbo_TenManHinh.SelectedIndex = -1;
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        public void loadDanhSachChucVu()
        {
            dgv_DSPhanQuyen.DataSource = phanQuyenBUL.getDSQuyen();
            dgv_DSPhanQuyen.CellFormatting += dgv_DSPhanQuyen_CellFormatting;
        }

        private void dgv_DSPhanQuyen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DSPhanQuyen.Columns[e.ColumnIndex].Name == "CoQuyen") // Replace "Quyen" with the actual column name
            {
                if (e.Value != null)
                {
                    int quyenValue;
                    if (int.TryParse(e.Value.ToString(), out quyenValue))
                    {
                        e.Value = quyenValue == 1 ? "Có quyền" : "Không có quyền";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        public void loadCombobox()
        {
            cbo_TenManHinh.DataSource = danhMucManHinh.getDanhMucManHinh();
            cbo_TenManHinh.DisplayMember = "tenManHinh";
            cbo_TenManHinh.ValueMember = "maManHinh";
            cbo_TenManHinh.SelectedIndex = -1;

            cbo_TenChucVu.DataSource = chucVuBUL.getChucVu();
            cbo_TenChucVu.DisplayMember = "tenChucVu";
            cbo_TenChucVu.ValueMember = "maChucVu";
            cbo_TenChucVu.SelectedIndex = -1;
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            enbaleButton(false);
            dgv_DSPhanQuyen.Enabled = false;
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            flag = 2;
            enbaleButton(false);
            dgv_DSPhanQuyen.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSPhanQuyen.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (tenCV == null || tenMH == null)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSPhanQuyen.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                if (cbo_TenChucVu.SelectedIndex == -1 || cbo_TenManHinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhanQuyenDTO phanQuyenDTO = new PhanQuyenDTO();
                phanQuyenDTO.MaChucVu = cbo_TenChucVu.SelectedValue.ToString();
                phanQuyenDTO.MaManHinh = cbo_TenManHinh.SelectedValue.ToString();
                phanQuyenDTO.CoQuyen = cb_CoQuyen.Checked ? 1 : 0;

                if (phanQuyenBUL.themPhanQuyen(phanQuyenDTO))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDanhSachChucVu();
                    enbaleButton(true);
                    dgv_DSPhanQuyen.Enabled = true;
                    flag = 0;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (flag == 2)
            {
                if (cbo_TenChucVu.SelectedIndex == -1 || cbo_TenManHinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhanQuyenDTO phanQuyenDTO = new PhanQuyenDTO();
                phanQuyenDTO.MaChucVu = cbo_TenChucVu.SelectedValue.ToString();
                phanQuyenDTO.MaManHinh = cbo_TenManHinh.SelectedValue.ToString();
                phanQuyenDTO.CoQuyen = cb_CoQuyen.Checked ? 1 : 0;

                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (phanQuyenBUL.suaPhanQuyen(phanQuyenDTO))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDanhSachChucVu();
                        enbaleButton(true);
                        dgv_DSPhanQuyen.Enabled = true;
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
                if (cbo_TenChucVu.SelectedIndex == -1 || cbo_TenManHinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (phanQuyenBUL.xoaPhanQuyen(cbo_TenManHinh.SelectedValue.ToString(), cbo_TenChucVu.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDanhSachChucVu();
                        enbaleButton(true);
                        dgv_DSPhanQuyen.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_DSPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                tenCV = dgv_DSPhanQuyen.Rows[index].Cells["maChucVu"].Value.ToString();
                tenMH = dgv_DSPhanQuyen.Rows[index].Cells["maManHinh"].Value.ToString();
                cbo_TenChucVu.SelectedValue = dgv_DSPhanQuyen.Rows[index].Cells["maChucVu"].Value.ToString();
                cbo_TenManHinh.SelectedValue = dgv_DSPhanQuyen.Rows[index].Cells["maManHinh"].Value.ToString();
                cb_CoQuyen.Checked = dgv_DSPhanQuyen.Rows[index].Cells["coQuyen"].Value.ToString() == "1" ? true : false;
            }
        }
    }
}
