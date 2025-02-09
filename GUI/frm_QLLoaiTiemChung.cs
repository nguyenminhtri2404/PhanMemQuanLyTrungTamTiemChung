using BUL;
using DTO;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLLoaiTiemChung : Form
    {
        LoaiTiemChungBUL loaiTiemChungBUL;
        int flag = 0;
        string maLoaiTiemChung;
        DataTable dtLoaiTiemChung;
        public frm_QLLoaiTiemChung()
        {
            InitializeComponent();
            loaiTiemChungBUL = new LoaiTiemChungBUL();
            loadData();
        }

        public void loadData()
        {
            dgv_DSLoaiTiemChung.AutoGenerateColumns = false;
            dtLoaiTiemChung = loaiTiemChungBUL.layTatCaLoaiTiemChung();
            dgv_DSLoaiTiemChung.DataSource = dtLoaiTiemChung;
        }

        public void clearData()
        {
            txt_MaLoai.Text = "";
            txt_TenLoai.Text = "";
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        private void dgv_DSLoaiTiemChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                maLoaiTiemChung = dgv_DSLoaiTiemChung.Rows[index].Cells["maLoaiTiem"].Value.ToString();
                txt_MaLoai.Text = dgv_DSLoaiTiemChung.Rows[index].Cells["maLoaiTiem"].Value.ToString();
                txt_TenLoai.Text = dgv_DSLoaiTiemChung.Rows[index].Cells["tenLoaiTiemChung"].Value.ToString();
            }
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            clearData();
            enbaleButton(false);
            dgv_DSLoaiTiemChung.Enabled = false;
            txt_MaLoai.Text = loaiTiemChungBUL.taoMaLoaiTiemChung();
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                LoaiTiemChungDTO loaiTiemChungDTO = new LoaiTiemChungDTO();
                loaiTiemChungDTO.MaLoaiTiemChung = loaiTiemChungBUL.taoMaLoaiTiemChung();
                loaiTiemChungDTO.TenLoaiTiemChung = txt_TenLoai.Text;
                bool kq = loaiTiemChungBUL.themLoaiTiemChung(loaiTiemChungDTO);
                if (kq == true)
                {
                    MessageBox.Show("Thêm thành công");
                    loadData();
                    enbaleButton(true);
                    dgv_DSLoaiTiemChung.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            if (flag == 2)
            {
                LoaiTiemChungDTO loaiTiemChungDTO = new LoaiTiemChungDTO();
                loaiTiemChungDTO.MaLoaiTiemChung = txt_MaLoai.Text;
                loaiTiemChungDTO.MaLoaiTiemChung = txt_TenLoai.Text;
                bool kq = loaiTiemChungBUL.suaLoaiTiemChung(loaiTiemChungDTO);
                if (kq == true)
                {
                    MessageBox.Show("Sửa thành công");
                    loadData();
                    enbaleButton(true);
                    dgv_DSLoaiTiemChung.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            if (flag == 3)
            {
                bool kq = loaiTiemChungBUL.xoaLoaiTiemChung(maLoaiTiemChung);
                if (kq == true)
                {
                    MessageBox.Show("Xóa thành công");
                    loadData();
                    enbaleButton(true);
                    dgv_DSLoaiTiemChung.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            flag = 0;
            loadData();
            clearData();
            enbaleButton(true);
            dgv_DSLoaiTiemChung.Enabled = true;

        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            flag = 2;
            enbaleButton(false);
            dgv_DSLoaiTiemChung.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            enbaleButton(true);
            dgv_DSLoaiTiemChung.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            flag = 3;
            enbaleButton(false);
            dgv_DSLoaiTiemChung.Enabled = false;
        }

        private void btn_BackHome_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txt_TimKiem_TextChanged(object sender, System.EventArgs e)
        {
            string filterExpression = string.Format("maLoaiTiemChung like '%{0}%' or tenLoaiTiemChung like '%{0}%'", txt_TimKiem.Text);
            (dgv_DSLoaiTiemChung.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }
    }
}
