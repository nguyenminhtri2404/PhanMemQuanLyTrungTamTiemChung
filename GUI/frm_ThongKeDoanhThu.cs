using BUL;
using DAL;
using DTO;
using GUI.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace GUI
{
    public partial class frm_ThongKeDoanhThu : Form
    {
        private KhachHangBUL khachHangBUL;
        DoanhThuBUL doanhThuBUL;
        private HoaDonBUL hoaDonBUL;
        public frm_ThongKeDoanhThu()
        {
            InitializeComponent();
            //loadComboBoxKhachHang();
            khachHangBUL = new KhachHangBUL();
            hoaDonBUL = new HoaDonBUL();
            QL_TiemChungDataContext context = new QL_TiemChungDataContext();
            doanhThuBUL = new DoanhThuBUL(context);
            loadComboBoxNam();
            loadComboBoxThang();
            loadHoaDon();
            loadcboPhuongThucThanhToan();
        }
        void loadComboBoxThang()
        {
            cbo_Thang.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                cbo_Thang.Items.Add(i.ToString());
            }

            cbo_Thang.SelectedIndex = -1;
        }
        void loadComboBoxNam()
        {
            cbo_Nam.Items.Clear();

            // Thêm các năm từ 2000 đến 2100 vào ComboBox
            for (int i = 2000; i <= 2100; i++)
            {
                cbo_Nam.Items.Add(i.ToString());
            }

            cbo_Nam.SelectedIndex = -1;
        }

        void loadHoaDon()
        {
            dgv_DSHoaDon.AutoGenerateColumns = false;
            dgv_DSHoaDon.DataSource = hoaDonBUL.LayTatCaHoaDon();

        }
        void loadcboPhuongThucThanhToan()
        {
            DataTable dtPhuongThucThanhToan = new DataTable();
            dtPhuongThucThanhToan.Columns.Add("Value", typeof(string));
            dtPhuongThucThanhToan.Columns.Add("Display", typeof(string));
            DataRow rowTatCa = dtPhuongThucThanhToan.NewRow();
            rowTatCa["Value"] = "All";
            rowTatCa["Display"] = "Tất cả";
            dtPhuongThucThanhToan.Rows.Add(rowTatCa);

            DataRow rowTienMat = dtPhuongThucThanhToan.NewRow();
            rowTienMat["Value"] = "TienMat";
            rowTienMat["Display"] = "Tiền mặt";
            dtPhuongThucThanhToan.Rows.Add(rowTienMat);

            DataRow rowChuyenKhoan = dtPhuongThucThanhToan.NewRow();
            rowChuyenKhoan["Value"] = "ChuyenKhoan";
            rowChuyenKhoan["Display"] = "Chuyển khoản";
            dtPhuongThucThanhToan.Rows.Add(rowChuyenKhoan);

            cbo_PhuongThucThanhToan.DataSource = dtPhuongThucThanhToan;
            cbo_PhuongThucThanhToan.DisplayMember = "Display";
            cbo_PhuongThucThanhToan.ValueMember = "Value";
            cbo_PhuongThucThanhToan.SelectedIndex = 0;
        }
        private void CapNhatDanhSachHoaDon()
        {
            // Lấy giá trị từ các ComboBox với kiểm tra null
            string phuongThucThanhToan = cbo_PhuongThucThanhToan.SelectedValue?.ToString();
            int thang = cbo_Thang.SelectedItem != null ? Convert.ToInt32(cbo_Thang.SelectedItem.ToString()) : 0;
            int nam = cbo_Nam.SelectedItem != null ? Convert.ToInt32(cbo_Nam.SelectedItem.ToString()) : 0;

            // Kiểm tra phương thức thanh toán và tháng/năm
            if (phuongThucThanhToan == "All")
            {
                if (thang > 0 && nam > 0)
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayTatCaHoaDonTheoThangNam(thang, nam);
                }
                else
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayTatCaHoaDon();
                }
            }
            else if (phuongThucThanhToan == "TienMat")
            {
                if (thang > 0 && nam > 0)
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucTienMatThangNam(thang, nam);
                }
                else
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucTienMat();
                }
            }
            else if (phuongThucThanhToan == "ChuyenKhoan")
            {
                if (thang > 0 && nam > 0)
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucChuyenKhoanThangNam(thang, nam);
                }
                else
                {
                    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucChuyenKhoan();
                }
            }
            else
            {
                dgv_DSHoaDon.DataSource = null; // Trường hợp không hợp lệ
            }
        }

        private void cbo_PhuongThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Lấy giá trị phương thức thanh toán từ ComboBox
            //string phuongThucThanhToan = cbo_PhuongThucThanhToan.SelectedValue.ToString();

            //// Kiểm tra giá trị của ComboBox và gọi hàm tương ứng để hiển thị trực tiếp lên DataGridView
            //if (phuongThucThanhToan == "All")
            //{
            //    dgv_DSHoaDon.DataSource = hoaDonBUL.LayTatCaHoaDon();
            //}
            //else if (phuongThucThanhToan == "TienMat")
            //{
            //    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucTienMat();
            //}
            //else if (phuongThucThanhToan == "ChuyenKhoan")
            //{
            //    dgv_DSHoaDon.DataSource = hoaDonBUL.LayHoaDonTheoPhuongThucChuyenKhoan();
            //}
            CapNhatDanhSachHoaDon();
        }

        private void cbo_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatDanhSachHoaDon();
        }

        private void cbo_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatDanhSachHoaDon();
            LoadChartData();
            LoadChartDataKhachHang();
        }
        private void LoadChartData()
        {
            int nam = Convert.ToInt32(cbo_Nam.SelectedItem);
            DataTable dt = hoaDonBUL.LayTongDoanhThuTheoThang(nam);

            chartDoanhThu.Series.Clear();
            Series series = new Series
            {
                Name = "Doanh Thu",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };
            chartDoanhThu.Series.Add(series);

            // Đảm bảo chỉ có tối đa 12 cột (ứng với 12 tháng)
            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                if (thang >= 1 && thang <= 12)
                {
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                    series.Points.AddXY(thang, doanhThu);
                }
            }

            // Điều chỉnh sơ đồ bên trong mà không thay đổi kích thước Chart
            chartDoanhThu.ChartAreas[0].InnerPlotPosition.Width = 100;
            chartDoanhThu.ChartAreas[0].InnerPlotPosition.Height = 85;
            chartDoanhThu.ChartAreas[0].InnerPlotPosition.X = 20;
            chartDoanhThu.ChartAreas[0].InnerPlotPosition.Y = 5;

            chartDoanhThu.ChartAreas[0].AxisX.Minimum = 0;
            chartDoanhThu.ChartAreas[0].AxisX.Maximum = 13;
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 0;

            chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh Thu (VND)";
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add(string.Format("Doanh Thu Năm {0}", nam));
        }

        private void LoadChartDataKhachHang()
        {
            int nam = Convert.ToInt32(cbo_Nam.SelectedItem);
            DataTable dt = hoaDonBUL.ThongKeSoLuongKhachHang(nam);

            chartKhachHang.Series.Clear();
            Series series = new Series
            {
                Name = "Số lượng",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };
            chartKhachHang.Series.Add(series);

            // Đảm bảo chỉ có tối đa 12 cột (ứng với 12 tháng)
            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                if (thang >= 1 && thang <= 12)
                {
                    int soLuong = Convert.ToInt32(row["SoLuongKhachHang"]);
                    series.Points.AddXY(thang, soLuong);
                }
            }

            // Điều chỉnh sơ đồ bên trong mà không thay đổi kích thước Chart
            chartKhachHang.ChartAreas[0].InnerPlotPosition.Width = 100;
            chartKhachHang.ChartAreas[0].InnerPlotPosition.Height = 85;
            chartKhachHang.ChartAreas[0].InnerPlotPosition.X = 20;
            chartKhachHang.ChartAreas[0].InnerPlotPosition.Y = 5;

            chartKhachHang.ChartAreas[0].AxisX.Minimum = 0;
            chartKhachHang.ChartAreas[0].AxisX.Maximum = 13;
            chartKhachHang.ChartAreas[0].AxisX.Interval = 0;

            chartKhachHang.ChartAreas[0].AxisX.Title = "Tháng";
            chartKhachHang.ChartAreas[0].AxisY.Title = "Số lượng";
            chartKhachHang.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            chartKhachHang.Titles.Clear();
            chartKhachHang.Titles.Add(string.Format("Số lượng khách hàng Năm {0}", nam));
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tháng và năm từ TextBox
                int month = Convert.ToInt32(cbo_Thang.SelectedItem);
                int year = Convert.ToInt32(cbo_Nam.SelectedItem);

                // Kiểm tra tháng và năm hợp lệ
                if (month < 1 || month > 12)
                {
                    MessageBox.Show("Tháng phải nằm trong khoảng từ 1 đến 12.");
                    return;
                }

                if (year <= 0)
                {
                    MessageBox.Show("Năm không hợp lệ.");
                    return;
                }

                // Lấy dữ liệu doanh thu
                List<DoanhThuDTO> doanhThuList = doanhThuBUL.GetDoanhThuByMonth(month, year);
                if (doanhThuList == null || doanhThuList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cho tháng và năm này.");
                    return;
                }

                // Xuất dữ liệu ra Excel
                string fileName = string.Empty;
                bool isPrintPreview = false;  // Set true nếu bạn muốn hiển thị bản xem trước

                // Giả sử bạn có một lớp ExcelExport để xuất dữ liệu
                ExcelExport excelExport = new ExcelExport(new QL_TiemChungDataContext());
                excelExport.ExportDoanhThu(doanhThuList, ref fileName, isPrintPreview);

                // Hiển thị thông báo thành công
                MessageBox.Show("Dữ liệu đã được xuất thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int month = Convert.ToInt32(cbo_Thang.SelectedItem);
                int year = Convert.ToInt32(cbo_Nam.SelectedItem);

                // Gọi BUL để lấy DataTable
                DataTable dt = doanhThuBUL.GetHoaDonReport(month, year);

                // Kiểm tra nếu DataTable rỗng
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu báo cáo cho tháng và năm đã chọn!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo và thiết lập Crystal Report
                rptThongKe rpt = new rptThongKe();
                rpt.SetDataSource(dt);

                // Hiển thị báo cáo trên form
                frm_Report f = new frm_Report();
                f.crystalReportViewer1.ReportSource = rpt;
                f.crystalReportViewer1.Refresh();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
