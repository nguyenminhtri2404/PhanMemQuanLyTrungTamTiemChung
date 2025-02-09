using BUL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_CapNhatTiemChung : Form
    {
        private LichSuTiemChungBUL lichSuTiemChungBUL;
        private LichTiemChungBUL lichTiemChungBUL;
        private NhanVienBUL nhanVienBUL;
        private ThongTinChiTietVaccineBUL ttctVaccineBUL;
        //List<LichTiemChungDTO> danhSachLichTiemChung;
        string maLichTiemChung;
        string maKH;
        string maVaccine;
        string tenNhanVien;
        string maNV;
        private DataTable originalDataTable;
        public frm_CapNhatTiemChung(string tenNhanVien, string maNV)
        {
            InitializeComponent();
            lichTiemChungBUL = new LichTiemChungBUL();
            lichSuTiemChungBUL = new LichSuTiemChungBUL();
            nhanVienBUL = new NhanVienBUL();
            ttctVaccineBUL = new ThongTinChiTietVaccineBUL();
            //LoadLichTiemChung();
            loadcboNhanVien();
            dgv_LichTiemChung.CellClick += dgv_LichTiemChung_CellClick; // Di chuyển sự kiện CellClick ở đây
            this.tenNhanVien = tenNhanVien;
            this.maNV = maNV;
        }

        private void LoadLichSuTiemChung(string maKhachHang)
        {
            // Tải dữ liệu lịch sử tiêm chủng vào dgv_LichSu
            dgv_LichSu.AutoGenerateColumns = false;
            dgv_LichSu.DataSource = lichSuTiemChungBUL.GetLichSuTiemChungByKhachHang(maKhachHang);
            //dgv_LichSu.Columns["maLichTC"].Visible = true;
            //dgv_LichSu.Columns["maVaccine"].Visible = true;
            //dgv_LichSu.Columns["maKhachHang"].Visible = true;
        }

        private void LoadLichTiemChung()
        {
            originalDataTable = lichTiemChungBUL.LayTatCaLichTiem();
            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BindingSource bindingSource = new BindingSource
            {
                DataSource = originalDataTable
            };
            dgv_LichTiemChung.DataSource = bindingSource;
        }

        void loadcboNhanVien()
        {
            DataTable dtNhanVien = nhanVienBUL.getBacSi();

            // Add an "All" row at the top of the DataTable
            DataRow allRow = dtNhanVien.NewRow();
            allRow["hoTen"] = "Tất cả";
            dtNhanVien.Rows.InsertAt(allRow, 0); // Insert at the first position

            cbo_NhanVien.DataSource = dtNhanVien;
            cbo_NhanVien.DisplayMember = "hoTen";
            cbo_NhanVien.ValueMember = "hoTen";
            cbo_NhanVien.SelectedIndex = 0; // Set "All" as the default selection
            cbo_NhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_NhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void LoadTTCTTheoMaVaccine(string maVaccine)
        {
            dgv_TTCTVaccine.AutoGenerateColumns = false;
            dgv_TTCTVaccine.DataSource = ttctVaccineBUL.GetCTVaccineTheoMaVaccine(maVaccine); // Store the original data
        }
        private void dgv_LichTiemChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Check if the column name is correct
                maKH = dgv_LichTiemChung.SelectedRows[0].Cells["maKhachHang"].Value.ToString();
                maLichTiemChung = dgv_LichTiemChung.SelectedRows[0].Cells["maLichTiemChung1"].Value.ToString();
                maVaccine = dgv_LichTiemChung.SelectedRows[0].Cells["maVaccine2"].Value.ToString();
                LoadLichSuTiemChung(maKH);
                LoadTTCTTheoMaVaccine(maVaccine);
            }
        }

        private void btn_ThemLSTC_Click(object sender, EventArgs e)
        {
            if (maLichTiemChung != null && maVaccine != null)
            {
                frm_ThemLichSuTiemChung form = new frm_ThemLichSuTiemChung(maLichTiemChung, maVaccine, tenNhanVien, maNV);

                form.FormClosed += (s, ev) =>
                {
                    LoadLichSuTiemChung(maKH);
                    LoadTTCTTheoMaVaccine(maVaccine);
                    LoadLichTiemChung();
                };

                form.Show();
            }
            else
            {
                MessageBox.Show("Không thể lấy dữ liệu lịch tiêm chủng từ dòng đã chọn.");
            }
        }

        private void txt_TimKiem_TextChange(object sender, EventArgs e)
        {
            string searchText = txt_TimKiem.Text.Trim().ToLower();

            if (originalDataTable != null)
            {
                DataView dataView = originalDataTable.DefaultView;

                // Apply filter to display only matching records
                if (!string.IsNullOrEmpty(searchText))
                {
                    dataView.RowFilter = string.Format("hoTenKhachHang LIKE '%{0}%'", searchText);
                }
                else
                {
                    dataView.RowFilter = string.Empty; // Clear the filter
                }

                // No need to reset the DataSource, just refresh the DataGridView
                dgv_LichTiemChung.DataSource = dataView;
            }
        }
        private void cbo_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã nhân viên được chọn từ ComboBox
            string selectedNhanVienID = cbo_NhanVien.SelectedValue?.ToString();

            if (originalDataTable != null)
            {
                DataView dataView = originalDataTable.DefaultView;

                // Check if the "hoTenNhanVien" column exists in the DataTable
                if (originalDataTable.Columns.Contains("hoTenNhanVien"))
                {
                    // Check if "Tất cả" is selected
                    if (selectedNhanVienID == "Tất cả")
                    {
                        // Reset to show all data
                        dataView.RowFilter = string.Empty;
                    }
                    else if (!string.IsNullOrEmpty(selectedNhanVienID))
                    {
                        // Apply filter based on the selected hoTenNhanVien
                        dataView.RowFilter = String.Format("hoTenNhanVien = '{0}'", selectedNhanVienID);
                    }

                    // Re-assign the filtered view to the DataGridView
                    dgv_LichTiemChung.DataSource = dataView;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cột 'hoTenNhanVien' trong dữ liệu.");
                }
            }
        }

        private void frm_CapNhatTiemChung_Load(object sender, EventArgs e)
        {
            LoadLichTiemChung();
        }
    }
}
