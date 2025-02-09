using BUL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLLoaiVaccine : Form
    {
        LoaiVaccineBUL loaiVaccineBUL;
        int flag = 0;
        string maLoaiVaccine;
        DataTable dtLoaiVaccine;
        public frm_QLLoaiVaccine()
        {
            InitializeComponent();
            loaiVaccineBUL = new LoaiVaccineBUL();
            loadData();
            enbaleButton(true);
        }

        public void loadData()
        {
            dgv_DSLoaiVaccine.AutoGenerateColumns = false;
            dtLoaiVaccine = loaiVaccineBUL.layTatCaLoaiVaccine();
            dgv_DSLoaiVaccine.DataSource = dtLoaiVaccine;
        }

        public void clearData()
        {
            txt_MaLoai.Text = "";
            txt_TenLoai.Text = "";
            txt_MoTa.Text = "";

        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        private void dgv_DSLoaiVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                maLoaiVaccine = dgv_DSLoaiVaccine.Rows[index].Cells["maLoai"].Value.ToString();
                txt_MaLoai.Text = dgv_DSLoaiVaccine.Rows[index].Cells["maLoai"].Value.ToString();
                txt_TenLoai.Text = dgv_DSLoaiVaccine.Rows[index].Cells["tenLoai"].Value.ToString();
                txt_MoTa.Text = dgv_DSLoaiVaccine.Rows[index].Cells["moTa"].Value.ToString();
            }
        }



        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            flag = 1;
            clearData();
            enbaleButton(false);
            txt_MaLoai.Text = loaiVaccineBUL.taoMaLoaiVaccine();
            dgv_DSLoaiVaccine.Enabled = false;
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                if (txt_TenLoai.Text == "" || txt_MoTa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                LoaiVaccineDTO loaiVaccineDTO = new LoaiVaccineDTO(txt_MaLoai.Text, txt_TenLoai.Text, txt_MoTa.Text);
                bool kq = loaiVaccineBUL.themLoaiVaccine(loaiVaccineDTO);
                if (kq)
                {
                    MessageBox.Show("Thêm thành công");
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSLoaiVaccine.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            if (flag == 2)
            {
                if (txt_TenLoai.Text == "" || txt_MoTa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                LoaiVaccineDTO loaiVaccineDTO = new LoaiVaccineDTO(txt_MaLoai.Text, txt_TenLoai.Text, txt_MoTa.Text);
                bool kq = loaiVaccineBUL.suaLoaiVaccine(loaiVaccineDTO);
                if (kq)
                {
                    MessageBox.Show("Sửa thành công");
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSLoaiVaccine.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            if (flag == 3)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        bool kq = loaiVaccineBUL.xoaLoaiVaccine(maLoaiVaccine);
                        if (kq)
                        {
                            MessageBox.Show("Xóa thành công");
                            loadData();
                            clearData();
                            enbaleButton(true);
                            dgv_DSLoaiVaccine.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception if needed
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Đã xảy ra lỗi khi xóa loại vaccine. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            flag = 0;
            loadData();
            clearData();
            enbaleButton(true);
            dgv_DSLoaiVaccine.Enabled = true;


        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            flag = 2;
            enbaleButton(false);
            dgv_DSLoaiVaccine.Enabled = false;
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSLoaiVaccine.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            flag = 3;
            enbaleButton(false);
            dgv_DSLoaiVaccine.Enabled = false;
        }

        private void frm_QLLoaiVaccine_Load(object sender, System.EventArgs e)
        {

        }

        private void txt_TimKiem_TextChange(object sender, System.EventArgs e)
        {
            string filterExpression = string.Format("maLoai LIKE '%{0}%' OR tenLoai LIKE '%{0}%' OR moTa Like '%{0}%'", txt_TimKiem.Text);
            (dgv_DSLoaiVaccine.DataSource as DataTable).DefaultView.RowFilter = filterExpression;

        }
    }
}
