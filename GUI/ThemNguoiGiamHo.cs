using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemNguoiGiamHo : Form
    {
        private NguoiGiamHoBUL nguoiGiamHoBUL;

        private List<NguoiGiamHoDTO> danhSachNguoiGiamHo;
        public ThemNguoiGiamHo()
        {
            InitializeComponent();
            nguoiGiamHoBUL = new NguoiGiamHoBUL();
            txt_magiamho.Enabled = false;
            txt_magiamho.Text = GenerateMaNguoiGiamHo();
            loadthemnguoigiamho();
        }
        public void loadthemnguoigiamho()
        {
            danhSachNguoiGiamHo = nguoiGiamHoBUL.GetAllNguoiGiamHo();
            dgv_nguoigiamho.DataSource = danhSachNguoiGiamHo;
        }
        private string GenerateMaNguoiGiamHo()
        {
            int maxMaNGH = nguoiGiamHoBUL.GetMaxMaNguoiGiamHo();
            int newMaNGH = maxMaNGH + 1;
            return "NGH" + newMaNGH.ToString().PadLeft(3, '0');
        }
        private void ThemNguoiGiamHo_Load(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                string maNguoiGiamHo = GenerateMaNguoiGiamHo();
                string hoTen = txt_Ten.Text.Trim();
                string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                DateTime ngaySinh = dpk_ngaysinh.Value;
                string diaChi = txtdiachi.Text.Trim();
                string sdt = txtsdt.Text.Trim();
                string email = txtemail.Text.Trim();
                string quanhe = txtquanhe.Text.Trim();

                if (string.IsNullOrEmpty(hoTen))
                {
                    MessageBox.Show("Tên người giám hộ không được để trống.");
                    return;
                }

                NguoiGiamHoDTO nguoigiamho = new NguoiGiamHoDTO
                {
                    MaNguoiGiamHo = maNguoiGiamHo,
                    HoTen = hoTen,
                    GioiTinh = gioiTinh,
                    NgaySinh = ngaySinh,
                    DiaChi = diaChi,
                    SDT = sdt,
                    Email = email,
                    QuanHe = quanhe
                };

                bool isSuccess = nguoiGiamHoBUL.ThemNguoiGiamHo(nguoigiamho);

                if (isSuccess)
                {
                    MessageBox.Show("Thêm người giám hộ thành công!");

                    // Gán giá trị tên người giám hộ vào txtNguoiGiamHo nếu form này có TextBox txtNguoiGiamHo
                    if (Owner != null && Owner.Controls["txtNguoiGiamHo"] is TextBox txtNguoiGiamHo)
                    {
                        txtNguoiGiamHo.Text = hoTen;
                    }
                }
                else
                {
                    MessageBox.Show("Thêm người giám hộ thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            loadthemnguoigiamho();
        }

        private void dgv_nguoigiamho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có chọn dòng nào trong DataGridView
            if (e.RowIndex >= 0)
            {

                // Lấy tên người giám hộ và mã người giám hộ từ cột tương ứng
                string hoTen = dgv_nguoigiamho.Rows[e.RowIndex].Cells["hoTen"].Value.ToString();
                string maNguoiGiamHo = dgv_nguoigiamho.Rows[e.RowIndex].Cells["maNguoiGiamHo"].Value.ToString();
                string diaChi = dgv_nguoigiamho.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                string sDT = dgv_nguoigiamho.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                string email = dgv_nguoigiamho.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Gọi phương thức của form chính để cập nhật TextBox với mã người giám hộ
                if (this.Owner != null)
                {
                    if (this.Owner is frm_DSDangKyTiemChung mainForm)
                    {
                        mainForm.SetNguoiGiamHoInfo(maNguoiGiamHo, hoTen, diaChi, sDT, email);
                    }
                }
            }
        }
    }
}
