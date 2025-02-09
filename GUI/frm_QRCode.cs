using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QRCode : Form
    {
        public frm_QRCode(Image qrImage, decimal soTien)
        {
            InitializeComponent();
            pictureBox_QR.Image = qrImage;
            lb_SoTien.Text = soTien.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
            //pnl_ThanhToan.Controls.Add(pictureBox_QR);
        }
    }
}
