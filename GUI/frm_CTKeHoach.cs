using BUL;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_CTKeHoach : Form
    {
        private KeHoachTiemChungBUL keHoachTiemChungBUL = new KeHoachTiemChungBUL();
        public frm_CTKeHoach()
        {
            InitializeComponent();
        }
        public void LoadData(List<KeHoachTiemChungDTO> dsKeHoach)
        {
            if (dsKeHoach != null && dsKeHoach.Any())
            {
                dgv_kehoachtiemchung.DataSource = dsKeHoach;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_kehoachtiemchung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
            {
                // Lấy mã kế hoạch từ ô maKeHoach của hàng được chọn
                string maKeHoach = dgv_kehoachtiemchung.Rows[e.RowIndex].Cells["maKeHoach"].Value.ToString();

                // Lấy thông tin kế hoạch theo mã kế hoạch
                List<KeHoachTiemChungDTO> dsKeHoach = keHoachTiemChungBUL.GetKeHoachByMa(maKeHoach);

                // Tạo form chi tiết và truyền dữ liệu kế hoạch vào form
                frm_CTKeHoach frmChiTiet = new frm_CTKeHoach();
                frmChiTiet.LoadData(dsKeHoach); // Truyền danh sách kế hoạch vào form chi tiết
                frmChiTiet.Show();
            }
        }
    }
}
