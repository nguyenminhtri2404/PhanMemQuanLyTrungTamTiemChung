using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLChucVu : Form
    {
        ChucVuBUL chucVuBUL;
        string maCV;
        int flag = 0;
        public frm_QLChucVu()
        {
            InitializeComponent();
            chucVuBUL = new ChucVuBUL();
            loadData();
            enbaleButton(true);
            clearData();
        }

        public void clearData()
        {
            txt_MaChucVu.Text = "";
            txt_TenChucVu.Text = "";
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
            dgv_DSChucVu.DataSource = chucVuBUL.getChucVu();
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            enbaleButton(false);
            txt_MaChucVu.Text = chucVuBUL.taoMaChucVu();
            dgv_DSChucVu.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                if (txt_TenChucVu.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ChucVuDTO chucVuDTO = new ChucVuDTO(txt_MaChucVu.Text, txt_TenChucVu.Text);
                if (chucVuBUL.themChucVu(chucVuDTO))
                {
                    MessageBox.Show("Thêm chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    dgv_DSChucVu.Enabled = true;
                    enbaleButton(true);
                    flag = 0;
                }
                else
                {
                    MessageBox.Show("Thêm chức vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (flag == 2)
            {
                if (txt_TenChucVu.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ChucVuDTO chucVuDTO = new ChucVuDTO(txt_MaChucVu.Text, txt_TenChucVu.Text);
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa chức vụ này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (chucVuBUL.suaChucVu(chucVuDTO))
                    {
                        MessageBox.Show("Sửa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        dgv_DSChucVu.Enabled = true;
                        enbaleButton(true);
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Sửa chức vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (flag == 3)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (chucVuBUL.xoaChucVu(maCV))
                    {
                        MessageBox.Show("Xóa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        dgv_DSChucVu.Enabled = true;
                        enbaleButton(true);
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa chức vụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (maCV == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 2;
            enbaleButton(false);
            dgv_DSChucVu.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            dgv_DSChucVu.Enabled = true;
            enbaleButton(true);
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (maCV == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSChucVu.Enabled = false;
        }

        private void dgv_DSChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                maCV = dgv_DSChucVu.Rows[index].Cells["maChucVu"].Value.ToString();
                txt_MaChucVu.Text = dgv_DSChucVu.Rows[index].Cells["maChucVu"].Value.ToString();
                txt_TenChucVu.Text = dgv_DSChucVu.Rows[index].Cells["tenChucVu"].Value.ToString();
            }
        }
    }
}
