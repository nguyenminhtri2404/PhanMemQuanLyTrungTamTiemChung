using BUL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_TheoDoiSauTiem : Form
    {
        LichSuTiemChungBUL lichSuTiemChungBUL;
        private System.Timers.Timer countdownTimer;
        private DateTime endTime;
        private int selectedRowIndex = -1;
        string tenNhanVien, maNhanVien;

        public frm_TheoDoiSauTiem(string tenNhanVien, string maNhanVien)
        {
            InitializeComponent();
            lichSuTiemChungBUL = new LichSuTiemChungBUL();
            LoadData();
            this.tenNhanVien = tenNhanVien;
            this.maNhanVien = maNhanVien;


        }

        private void btn_ChoTheoDoi_Click(object sender, EventArgs e)
        {
            tab_QLTheoDoiSauTiem.SetPage(0);
        }


        public void LoadData()
        {
            dgv_ChoTheoDoi.DataSource = lichSuTiemChungBUL.layDSThongTinLichSuTiemChung();

            // Thêm cột thời gian chờ còn lại nếu chưa tồn tại
            if (!dgv_ChoTheoDoi.Columns.Contains("ThoiGianChoConLai"))
            {
                DataGridViewTextBoxColumn thoiGianChoConLaiColumn = new DataGridViewTextBoxColumn();
                thoiGianChoConLaiColumn.Name = "ThoiGianChoConLai";
                thoiGianChoConLaiColumn.HeaderText = "Thời gian còn Lại";
                dgv_ChoTheoDoi.Columns.Add(thoiGianChoConLaiColumn);
            }

            // Cập nhật thời gian chờ còn lại cho mỗi hàng
            foreach (DataGridViewRow row in dgv_ChoTheoDoi.Rows)
            {
                string ngayTiemStr = row.Cells["NgayTiemChoTD"].Value.ToString();
                DateTime ngayTiem;
                if (DateTime.TryParse(ngayTiemStr, out ngayTiem))
                {
                    TimeSpan timeElapsed = DateTime.Now - ngayTiem;
                    TimeSpan timeRemaining = TimeSpan.FromMinutes(30) - timeElapsed;
                    if (timeRemaining.TotalSeconds > 0)
                    {
                        row.Cells["ThoiGianChoConLai"].Value = $"{timeRemaining.Minutes} phút {timeRemaining.Seconds} giây";
                    }
                    else
                    {
                        row.Cells["ThoiGianChoConLai"].Value = "Đã đủ thời gian";
                    }
                }
                else
                {
                    row.Cells["ThoiGianChoConLai"].Value = "Không xác định";
                }
            }
        }

        private void btn_LichSuTheoDoi_Click(object sender, EventArgs e)
        {
            tab_QLTheoDoiSauTiem.SetPage(1);
            dgv_LichSuTheoDoi.DataSource = lichSuTiemChungBUL.layLichSuTiemChungTiemChungDaTheoDoi();

        }

        private void dgv_ChoTheoDoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
        }

        private void UpdateThoiGianChoConLai()
        {
            foreach (DataGridViewRow row in dgv_ChoTheoDoi.Rows)
            {
                string ngayTiemStr = row.Cells["NgayTiemChoTD"].Value.ToString();
                DateTime ngayTiem;
                if (DateTime.TryParse(ngayTiemStr, out ngayTiem))
                {
                    TimeSpan timeElapsed = DateTime.Now - ngayTiem;
                    TimeSpan timeRemaining = TimeSpan.FromMinutes(30) - timeElapsed;
                    if (timeRemaining.TotalSeconds > 0)
                    {
                        row.Cells["ThoiGianChoConLai"].Value = $"{timeRemaining.Minutes} phút {timeRemaining.Seconds} giây";
                    }
                    else
                    {
                        row.Cells["ThoiGianChoConLai"].Value = "Đã đủ thời gian";
                    }
                }
                else
                {
                    row.Cells["ThoiGianChoConLai"].Value = "Không xác định";
                }
            }
        }

        private void frm_TheoDoiSauTiem_Load(object sender, EventArgs e)
        {
            // Tạo timer để cập nhật thời gian chờ còn lại mỗi giây
            countdownTimer = new System.Timers.Timer(1000);
            countdownTimer.Elapsed += (s, args) =>
            {
                UpdateThoiGianChoConLai();
            };
            countdownTimer.Start();
        }

        private void btn_CapNhatTheoDoi_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_ChoTheoDoi.Rows[selectedRowIndex];
                string hoTen = selectedRow.Cells["HoTenChoTD"].Value.ToString();
                string ngaySinh = selectedRow.Cells["NgaySinhChoTD"].Value.ToString();
                string soDienThoai = selectedRow.Cells["SoDienThoaiChoTD"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChiChoTD"].Value.ToString();
                string ngayTiemStr = selectedRow.Cells["NgayTiemChoTD"].Value.ToString();
                string tenVaccine = selectedRow.Cells["TenVaccineChoTD"].Value.ToString();
                string maHoaDon = selectedRow.Cells["MaHDChoTD"].Value.ToString();
                int soLanTiem = int.Parse(selectedRow.Cells["SoLanTiemChoTD"].Value.ToString());

                DateTime ngayTiem;
                if (DateTime.TryParse(ngayTiemStr, out ngayTiem))
                {
                    TimeSpan timeElapsed = DateTime.Now - ngayTiem;
                    if (timeElapsed.TotalMinutes < 30)
                    {
                        TimeSpan timeRemaining = TimeSpan.FromMinutes(30) - timeElapsed;
                        MessageBox.Show($"Chưa đủ thời gian để cập nhật. Thời gian còn lại: {timeRemaining.Minutes} phút {timeRemaining.Seconds} giây.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin thời gian tiêm.");
                    return;
                }

                frm_CapNhatTheoDoi frmCapNhat = new frm_CapNhatTheoDoi(hoTen, ngaySinh, maHoaDon, soLanTiem, tenNhanVien, maNhanVien);
                frmCapNhat.Show();

                //Nếu form cập nhật được đóng thì load lại dữ liệu
                frmCapNhat.FormClosed += (s, args) =>
                {
                    LoadData();
                    UpdateThoiGianChoConLai();
                };
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi cập nhật thông tin.");
            }
        }
    }
}