using BUL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_NhacHen : Form
    {
        private LichTiemChungBUL lichTiemChungBUL;

        public frm_NhacHen()
        {
            InitializeComponent();
            lichTiemChungBUL = new LichTiemChungBUL();
            LoadLichTiemChung();
        }
        private void LoadLichTiemChung()
        {
            // Tải dữ liệu lịch sử tiêm chủng vào dgv_LichSu
            dgv_LichTiemChung.AutoGenerateColumns = false;
            dgv_LichTiemChung.DataSource = lichTiemChungBUL.LayTatCaLichHen();
            //dgv_LichSu.Columns["maLichTC"].Visible = true;
            //dgv_LichSu.Columns["maVaccine"].Visible = true;
            //dgv_LichSu.Columns["maKhachHang"].Visible = true;
        }

        private void txt_TimKiem_TextChange(object sender, EventArgs e)
        {
            string tenKhachHang = txt_TimKiem.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(tenKhachHang))
                {
                    // Load lại danh sách ban đầu
                    DataTable dt = lichTiemChungBUL.LayTatCaLichHen();
                    dgv_LichTiemChung.DataSource = dt;
                }
                else
                {
                    // Lọc danh sách theo tên khách hàng
                    DataTable dt = lichTiemChungBUL.LayTatCaLichHenTheoTenKhachHang(tenKhachHang);
                    dgv_LichTiemChung.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi hoặc log lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void dt_NgayHen_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayHen = dt_NgayHen.Value;

            try
            {
                // Gọi BUL để lấy dữ liệu
                DataTable lichHen = lichTiemChungBUL.LayTatCaLichHenTheoNgayHen(ngayHen);

                // Hiển thị dữ liệu lên DataGridView
                dgv_LichTiemChung.DataSource = lichHen;
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi (hoặc xử lý theo yêu cầu)
                MessageBox.Show("Lỗi khi tìm kiếm lịch hẹn: " + ex.Message);
            }
        }

        private void btn_NhacHen_Click(object sender, EventArgs e)
        {
            bool hasCheckedRows = false;

            foreach (DataGridViewRow row in dgv_LichTiemChung.Rows)
            {
                // Kiểm tra nếu ô thaoTac được tích
                if (row.Cells["thaoTac"] is DataGridViewCheckBoxCell checkBoxCell &&
                    checkBoxCell.Value is bool isChecked && isChecked)
                {
                    hasCheckedRows = true;

                    // Lấy dữ liệu từ dòng được chọn
                    string maKhachHang = row.Cells["MaKhachHang"].Value?.ToString();
                    string hoTen = row.Cells["hoTenKhachHang"].Value?.ToString();
                    DateTime ngayHen = Convert.ToDateTime(row.Cells["NgayHen"].Value);

                    // Lấy email từ cơ sở dữ liệu
                    string email = lichTiemChungBUL.LayEmailTheoMaKhachHang(maKhachHang);

                    string maLichTiemChung = row.Cells["MaLichTiemChung"].Value?.ToString(); // Giả sử bạn có một cột ẩn chứa "MaLichTiemChung"

                    // Nếu không có thông tin "MaLichTiemChung", bỏ qua dòng này
                    if (string.IsNullOrEmpty(maLichTiemChung))
                    {
                        MessageBox.Show(string.Format("Không có mã lịch tiêm cho khách hàng {0}!", hoTen),
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    // Lấy tên vaccine và số mũi từ cơ sở dữ liệu
                    string tenVaccine = lichTiemChungBUL.LayTenVaccineTheoMaLich(maLichTiemChung);
                    int soMui = lichTiemChungBUL.LaySoMuiTheoMaLich(maLichTiemChung);

                    // Kiểm tra email hợp lệ
                    if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                    {
                        MessageBox.Show(string.Format("Khách hàng {0} có email không hợp lệ hoặc chưa được cung cấp!", hoTen),
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    // Tính ngày nhắc hẹn
                    DateTime ngayNhacHen = ngayHen.AddMonths(1);
                    DateTime ngayGuiEmail = DateTime.Now;

                    //DateTime ngayNhacHen = ngayHen.AddMonths(1);
                    //string ngayNhacHenFormatted = ngayNhacHen.ToString("dd/MM/yyyy");
                    //DateTime ngayGuiEmail = ngayNhacHen.AddDays(-7);
                    //string ngayGuiEmailFormatted = ngayGuiEmail.ToString("dd/MM/yyyy");


                    // Kiểm tra nếu ngày gửi email là hôm nay
                    if (DateTime.Now.Date == ngayGuiEmail.Date)
                    {
                        // Gửi email
                        try
                        {
                            lichTiemChungBUL.GuiEmail(hoTen, email, ngayNhacHen, tenVaccine, soMui);
                            MessageBox.Show(string.Format("Email nhắc hẹn cho khách hàng {0} đã được gửi thành công!", hoTen),
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Lỗi khi gửi email cho khách hàng {0}: {1}", hoTen, ex.Message),
                            "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Hôm nay không phải ngày gửi nhắc hẹn cho khách hàng {0}!", hoTen),
                         "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (!hasCheckedRows)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một khách hàng từ danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_LichTiemChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu dòng được click không phải tiêu đề và cột là thaoTac
            if (e.RowIndex >= 0 && dgv_LichTiemChung.Columns["thaoTac"] != null)
            {
                DataGridViewRow currentRow = dgv_LichTiemChung.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cell = currentRow.Cells["thaoTac"] as DataGridViewCheckBoxCell;

                if (cell != null)
                {
                    // Đảo trạng thái giữa True (tích) và False (không tích)
                    bool isChecked = cell.Value as bool? ?? false;
                    cell.Value = !isChecked;
                }
            }
        }

        private void cb_ChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_LichTiemChung.Columns["thaoTac"] != null && dgv_LichTiemChung.Rows.Count > 0)
            {
                bool checkAll = cb_ChonTatCa.Checked; // Trạng thái của CheckBox

                // Duyệt qua tất cả các dòng trong `DataGridView`
                foreach (DataGridViewRow row in dgv_LichTiemChung.Rows)
                {
                    // Đặt giá trị cột thaoTac thành trạng thái của CheckBox
                    DataGridViewCheckBoxCell cell = row.Cells["thaoTac"] as DataGridViewCheckBoxCell;
                    if (cell != null)
                    {
                        cell.Value = checkAll; // Chọn hoặc bỏ chọn
                    }
                }
            }
        }
    }
}
