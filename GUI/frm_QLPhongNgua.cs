using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLPhongNgua : Form
    {
        private PhongBenhBUL phongBenhBUL;

        private List<PhongBenhDTO> danhSachPhongNgua;
        public frm_QLPhongNgua()
        {
            InitializeComponent();
            phongBenhBUL = new PhongBenhBUL();
            txtmapn.Enabled = false;
            txtmapn.Text = GenerateMaPhongNgua();
            loadthemphongngua();
        }
        public void loadthemphongngua()
        {
            danhSachPhongNgua = phongBenhBUL.GetPhongBenhList();
            dgv_phongngua.DataSource = danhSachPhongNgua;
        }
        private string GenerateMaPhongNgua()
        {
            int maxMaPN = phongBenhBUL.GetMaxMaPhongBenh();
            int newMaPN = maxMaPN + 1;
            return "PB" + newMaPN.ToString().PadLeft(2, '0');
        }
        private void lb_magoi_Click(object sender, EventArgs e)
        {

        }

        private void txtmagoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_QLPhongNgua_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhongNgua = GenerateMaPhongNgua();
                string tenPhongNgua = txtTenPN.Text.Trim();
                string mota = txtMoTapn.Text.Trim();


                if (string.IsNullOrEmpty(tenPhongNgua))
                {
                    MessageBox.Show("Tên phòng bệnh không được để trống.");
                    return;
                }

                PhongBenhDTO phongbenh = new PhongBenhDTO
                {
                    MaPhongNgua = maPhongNgua,
                    TenBenh = tenPhongNgua,
                    MoTa = mota,

                };

                bool isSuccess = phongBenhBUL.ThemPhongBenh(phongbenh);

                if (isSuccess)
                {
                    MessageBox.Show("Thêm phòng bệnh thành công!");

                    if (Owner != null && Owner is frm_QLVaccine formCha)
                    {
                        formCha.loadDataPhongNgua();
                    }
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            loadthemphongngua();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            txtmapn.Text = "";
            txtTenPN.Text = "";
            txtMoTapn.Text = "";
        }
    }
}
