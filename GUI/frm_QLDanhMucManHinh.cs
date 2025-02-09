using BUL;
using DTO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLDanhMucManHinh : Form
    {
        DanhMucManHinhBUL danhMucManHinhBUL;
        string maMH;
        int flag = 0;
        public frm_QLDanhMucManHinh()
        {
            InitializeComponent();
            danhMucManHinhBUL = new DanhMucManHinhBUL();
            loadData();
            enbaleButton(true);
            clearData();
        }

        public void loadData()
        {
            dgv_DSManHinh.DataSource = danhMucManHinhBUL.getDanhMucManHinh();
        }

        public void clearData()
        {
            txt_MaManHinh.Text = "";
            txt_TenManHinh.Text = "";
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            enbaleButton(false);
            txt_MaManHinh.Text = danhMucManHinhBUL.taoMaManHinh();
            dgv_DSManHinh.Enabled = false;
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (maMH == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 2;
            enbaleButton(false);
            dgv_DSManHinh.Enabled = false;

        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (maMH == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            flag = 3;
            enbaleButton(false);
            dgv_DSManHinh.Enabled = false;
        }

        private void dgv_DSManHinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                maMH = dgv_DSManHinh.Rows[i].Cells[0].Value.ToString();
                txt_MaManHinh.Text = dgv_DSManHinh.Rows[i].Cells[0].Value.ToString();
                txt_TenManHinh.Text = dgv_DSManHinh.Rows[i].Cells[1].Value.ToString();
            }
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            DanhMucManHinhDTO danhMucManHinhDTO = new DanhMucManHinhDTO
            {
                MaManHinh = txt_MaManHinh.Text,
                TenManHinh = txt_TenManHinh.Text
            };

            if (flag == 1)
            {
                if (txt_TenManHinh.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (danhMucManHinhBUL.themDanhMucManHinh(danhMucManHinhDTO))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSManHinh.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (flag == 2)
            {
                if (txt_TenManHinh.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (danhMucManHinhBUL.suaDanhMucManHinh(danhMucManHinhDTO))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSManHinh.Enabled = true;
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
                    if (danhMucManHinhBUL.xoaDanhMucManHinh(maMH))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        clearData();
                        enbaleButton(true);
                        dgv_DSManHinh.Enabled = true;
                        flag = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            enbaleButton(true);
            dgv_DSManHinh.Enabled = true;
            clearData();
        }
    }
}
