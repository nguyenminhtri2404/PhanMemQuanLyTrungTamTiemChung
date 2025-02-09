using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_SuaKhuyenMai : Form
    {
        private KhuyenMaiBUL khuyenMaiBUL;
        private KhuyenMaiDTO khuyenMai;
        public frm_SuaKhuyenMai(KhuyenMaiDTO khuyenMai)
        {
            InitializeComponent();
            khuyenMaiBUL = new KhuyenMaiBUL();
            this.khuyenMai = khuyenMai;
            txt_MaKM.Text = khuyenMai.MaKhuyenMai;
            txt_MaKM.Enabled = false;
            txt_TenKM.Text = khuyenMai.TenKhuyenMai;
            txt_PhanTramKM.Text = khuyenMai.PhanTramKhuyenMai.ToString();
        }

        private void frm_SuaKhuyenMai_Load(object sender, EventArgs e)
        {

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsValidPhanTramKhuyenMai(decimal phanTramKhuyenMai)
        {
            return phanTramKhuyenMai >= 0;
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

                khuyenMai.TenKhuyenMai = tenKM;
                khuyenMai.PhanTramKhuyenMai = phanTram;
            }
            else
            {
                MessageBox.Show("Phần trăm khuyến mãi không hợp lệ!");
                return;
            }

            // Tạo đối tượng BUL để xử lý logic nghiệp vụ
            KhuyenMaiBUL khuyenMaiBUL = new KhuyenMaiBUL();

            // Thực hiện sửa khuyến mãi
            bool isUpdated = khuyenMaiBUL.SuaKhuyenMai(khuyenMai);

            if (isUpdated)
            {
                MessageBox.Show("Sửa khuyến mãi thành công!");
                this.DialogResult = DialogResult.OK; // Đóng form và trả về DialogResult.OK
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa khuyến mãi.");
            }
        }

    }
}
