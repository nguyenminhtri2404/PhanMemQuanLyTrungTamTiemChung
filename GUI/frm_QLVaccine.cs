using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLVaccine : Form
    {
        VaccineBUL vaccineBUL;
        PhongBenhBUL phongBenhBUL;
        LoaiVaccineBUL loaiVaccineBUL;
        LoaiTiemChungBUL loaiTiemChungBUL;
        int flag = 0;
        string maVC;
        public frm_QLVaccine()
        {
            InitializeComponent();
            phongBenhBUL = new PhongBenhBUL();
            vaccineBUL = new VaccineBUL();
            loaiVaccineBUL = new LoaiVaccineBUL();
            loaiTiemChungBUL = new LoaiTiemChungBUL();
            loadData();
            loadDataPhongNgua();
            loadLoaiVaccine();
            loadLoaiTiemChung();
            clearData();
            txt_MaVaccine.Enabled = false;
        }
        public void loadDataPhongNgua()
        {
            // Giả sử bạn có phương thức trong BLL để lấy danh sách phòng bệnh
            List<PhongBenhDTO> phongBenhList = phongBenhBUL.GetPhongBenhList();

            cboPhongBenh.DisplayMember = "tenBenh";
            cboPhongBenh.ValueMember = "maPhongNgua";
            cboPhongBenh.DataSource = phongBenhList;
        }
        public void loadData()
        {
            dgv_DSVaccine.DataSource = vaccineBUL.LayTatCaVaccine();
            dgv_DSVaccine.AutoGenerateColumns = false;
            dgv_DSVaccine.Columns["tinhTrang"].Visible = false;
            dgv_DSVaccine.Columns["maLoai"].Visible = false;
            dgv_DSVaccine.Columns["maLoaiTiemChung"].Visible = false;
            dgv_DSVaccine.Columns["maPhongNgua"].Visible = false;
        }

        public void loadLoaiVaccine()
        {
            cbo_LoaiVaccine.DataSource = loaiVaccineBUL.layTatCaLoaiVaccine();
            cbo_LoaiVaccine.DisplayMember = "tenLoai";
            cbo_LoaiVaccine.ValueMember = "maLoai";
        }

        public void loadLoaiTiemChung()
        {
            cbo_LoaiTiemChung.DataSource = loaiTiemChungBUL.layTatCaLoaiTiemChung();
            cbo_LoaiTiemChung.DisplayMember = "tenLoaiTiemChung";
            cbo_LoaiTiemChung.ValueMember = "maLoaiTiemChung";
        }

        public void clearData()
        {
            txt_MaVaccine.Text = "";
            txt_TenVaccine.Text = "";
            txt_NguonGoc.Text = "";
            txt_LieuLuong.Text = "";
            cbo_LoaiVaccine.SelectedIndex = -1;
            cbo_LoaiTiemChung.SelectedIndex = -1;

        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }


        private void btn_Them_Click(object sender, EventArgs e)
        {
            clearData();
            enbaleButton(false);
            flag = 1;
            txt_MaVaccine.Text = vaccineBUL.taoMaVaccine();
            dgv_DSVaccine.Enabled = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (txt_TenVaccine.Text == "" || txt_NguonGoc.Text == "" || txt_LieuLuong.Text == "" || cbo_LoaiVaccine.SelectedIndex == -1 || cbo_LoaiTiemChung.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                VaccineDTO vaccine = new VaccineDTO(txt_MaVaccine.Text, txt_TenVaccine.Text, txt_NguonGoc.Text, txt_LieuLuong.Text, 1, cbo_LoaiVaccine.SelectedValue.ToString(), cbo_LoaiTiemChung.SelectedValue.ToString(), cboPhongBenh.SelectedValue.ToString());
                if (vaccineBUL.themVaccine(vaccine))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            flag = 0;
            loadData();
            clearData();
            enbaleButton(true);
            dgv_DSVaccine.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            flag = 2;
            enbaleButton(false);

            if (txt_TenVaccine.Text == "" || txt_NguonGoc.Text == "" || txt_LieuLuong.Text == "" || cbo_LoaiVaccine.SelectedIndex == -1 || cbo_LoaiTiemChung.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VaccineDTO vaccine = new VaccineDTO(txt_MaVaccine.Text, txt_TenVaccine.Text, txt_NguonGoc.Text, txt_LieuLuong.Text, 1, cbo_LoaiVaccine.SelectedValue.ToString(), cbo_LoaiTiemChung.SelectedValue.ToString(), cboPhongBenh.SelectedValue.ToString());
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (vaccineBUL.suaVaccine(vaccine))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    enbaleButton(true);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSVaccine.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            flag = 3;
            enbaleButton(false);
            dgv_DSVaccine.Enabled = false;
            if (maVC == "")
            {
                MessageBox.Show("Chọn vaccine cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (vaccineBUL.xoaVaccine(maVC))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    clearData();
                    enbaleButton(true);
                    dgv_DSVaccine.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgv_DSVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txt_MaVaccine.Text = dgv_DSVaccine.Rows[index].Cells["maVaccine1"].Value.ToString();
                txt_TenVaccine.Text = dgv_DSVaccine.Rows[index].Cells["tenVaccine"].Value.ToString();
                txt_NguonGoc.Text = dgv_DSVaccine.Rows[index].Cells["nguonGoc"].Value.ToString();
                txt_LieuLuong.Text = dgv_DSVaccine.Rows[index].Cells["lieuLuong"].Value.ToString();
                cbo_LoaiVaccine.SelectedValue = dgv_DSVaccine.Rows[index].Cells["maLoai"].Value.ToString();
                cbo_LoaiTiemChung.SelectedValue = dgv_DSVaccine.Rows[index].Cells["maLoaiTiemChung"].Value.ToString();
                cboPhongBenh.SelectedValue = dgv_DSVaccine.Rows[index].Cells["maPhongNgua"].Value.ToString();
                maVC = txt_MaVaccine.Text;
            }
        }

        private void txt_TimKiem_TextChange(object sender, EventArgs e)
        {
            dgv_DSVaccine.DataSource = vaccineBUL.timKiemVaccine(txt_TimKiem.Text);
        }

        private void txt_LieuLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MaVaccine_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txt_TenVaccine_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void frm_QLVaccine_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void txt_NguonGoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_themphongngua_Click(object sender, EventArgs e)
        {
            frm_QLPhongNgua frm = new frm_QLPhongNgua();
            frm.Owner = this;
            frm.Show();
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
