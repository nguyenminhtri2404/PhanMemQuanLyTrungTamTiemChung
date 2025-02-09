using BUL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_ThemKhuyenMai : Form
    {
        private KhuyenMaiBUL khuyenMaiBUL;
        public frm_ThemKhuyenMai()
        {
            InitializeComponent();
            khuyenMaiBUL = new KhuyenMaiBUL();
        }
        private bool IsValidPhanTramKhuyenMai(decimal phanTramKhuyenMai)
        {
            return phanTramKhuyenMai >= 0;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string tenKM = txt_TenKM.Text.Trim();
            string phanTramKhuyenMai = txt_PhanTramKM.Text.Trim();

            // Kiểm tra và chuyển đổi phanTramKhuyenMai sang kiểu decimal
            if (decimal.TryParse(phanTramKhuyenMai, out decimal phanTram))
            {
                if (!IsValidPhanTramKhuyenMai(phanTram))
                {
                    MessageBox.Show("Phần trăm khuyến mãi phải lớn hơn hoặc bằng 0!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Phần trăm khuyến mãi không hợp lệ!");
                return;
            }

            KhuyenMaiBUL khuyenMaiBUL = new KhuyenMaiBUL();

            // Thêm khách hàng mới
            bool isAdded = khuyenMaiBUL.ThemKhuyenMai(tenKM, phanTram);


            // Kiểm tra kết quả và hiển thị thông báo
            if (isAdded)
            {
                MessageBox.Show("Thêm khuyến mãi thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khuyến mãi.");
            }
        }

        private void frm_ThemKhuyenMai_Load(object sender, EventArgs e)
        {
            string maKM = khuyenMaiBUL.layMaTuDong();
            txt_MaKM.Text = maKM;
        }
    }
}
