using BUL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLNhaCungCap : Form
    {
        NhaCungCapBUL nccBUL;
        int flag = 0;
        string maNCC;
        DataTable dtNCC;
        public frm_QLNhaCungCap()
        {
            InitializeComponent();
            nccBUL = new NhaCungCapBUL();
            loadData();
            clearData();
            txt_MaNhaCungCap.Enabled = false;
        }

        public void loadData()
        {
            dgv_DSNhaCungCap.AutoGenerateColumns = false;
            dtNCC = nccBUL.getNhaCungCap();
            dgv_DSNhaCungCap.DataSource = dtNCC;
        }

        public void clearData()
        {
            txt_MaNhaCungCap.Text = "";
            txt_TenNhaCungCap.Text = "";
            txt_DiaChi.Text = "";
            txt_SDT.Text = "";
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        private void dgv_DSNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txt_MaNhaCungCap.Text = dgv_DSNhaCungCap.Rows[index].Cells["maNhaCungCap"].Value.ToString();
                txt_TenNhaCungCap.Text = dgv_DSNhaCungCap.Rows[index].Cells["tenNhaCungCap"].Value.ToString();
                txt_DiaChi.Text = dgv_DSNhaCungCap.Rows[index].Cells["diaChi"].Value.ToString();
                txt_SDT.Text = dgv_DSNhaCungCap.Rows[index].Cells["sDT"].Value.ToString();
                maNCC = txt_MaNhaCungCap.Text;
            }
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            clearData();
            enbaleButton(false);
            flag = 1;
            txt_MaNhaCungCap.Text = nccBUL.taoMaNhaCungCap();
            dgv_DSNhaCungCap.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.MaNCC = txt_MaNhaCungCap.Text;
                ncc.TenNCC = txt_TenNhaCungCap.Text;
                ncc.DiaChi = txt_DiaChi.Text;
                ncc.SDT = txt_SDT.Text;
                bool kq = nccBUL.themNhaCungCap(ncc);
                if (kq)
                {
                    MessageBox.Show("Thêm thành công");

                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }

            if (flag == 2)
            {
                if (maNCC == "")
                {
                    MessageBox.Show("Chọn nhà cung cấp cần sửa");
                    return;
                }
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.MaNCC = txt_MaNhaCungCap.Text;
                ncc.TenNCC = txt_TenNhaCungCap.Text;
                ncc.DiaChi = txt_DiaChi.Text;
                ncc.SDT = txt_SDT.Text;
                bool kq = nccBUL.suaNhaCungCap(ncc);
                if (kq)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }

            if (flag == 3)
            {
                if (maNCC == "")
                {
                    MessageBox.Show("Chọn nhà cung cấp cần xóa");
                    return;
                }
                if (string.IsNullOrEmpty(maNCC))
                {
                    MessageBox.Show("Chọn nhà cung cấp cần xóa");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool kq = nccBUL.xoaNhaCungCap(maNCC);
                        if (kq)
                        {
                            MessageBox.Show("Xóa thành công");
                            // Add any additional actions like refreshing the data grid or clearing fields
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception if needed
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Đã xảy ra lỗi khi xóa nhà cung cấp. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



            flag = 0;
            loadData();
            clearData();
            enbaleButton(true);
            dgv_DSNhaCungCap.Enabled = true;
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            flag = 2;
            enbaleButton(false);
            dgv_DSNhaCungCap.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSNhaCungCap.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            flag = 3;
            enbaleButton(false);
            dgv_DSNhaCungCap.Enabled = false;

        }

        private void btn_BackHome_Click(object sender, System.EventArgs e)
        {
            //Trờ về form chính
            this.Close();
        }

        private void txt_TimKiem_TextChanged(object sender, System.EventArgs e)
        {
            string filterExpression = string.Format("maNhaCungCap like '%{0}%' or tenNhaCungCap like '%{0}%' or diaChi like '%{0}%' or sDT like '%{0}%'", txt_TimKiem.Text);
            (dgv_DSNhaCungCap.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }
    }
}
