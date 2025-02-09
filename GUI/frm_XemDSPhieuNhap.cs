//using BUL;
//using System.Data;
//using System.Windows.Forms;

//namespace GUI
//{
//    public partial class frm_XemDSPhieuNhap : Form
//    {
//        PhieuNhapBUL phieuNhapBUL;
//        DataTable dtPhieuNhap;
//        public frm_XemDSPhieuNhap()
//        {
//            InitializeComponent();
//            phieuNhapBUL = new PhieuNhapBUL();
//            loadData();
//            this.MaximizeBox = false;
//            dgv_DSPhieuNhap.Columns["GiaNhap"].DefaultCellStyle.Format = "C0";
//            dgv_DSPhieuNhap.Columns["GiaNhap"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

//        }


//        public void loadData()
//        {
//            dgv_DSPhieuNhap.AutoGenerateColumns = false;
//            dtPhieuNhap = phieuNhapBUL.layDSChiTietPhieuNhap();
//            dgv_DSPhieuNhap.DataSource = dtPhieuNhap;
//        }

//        private void btn_Loc_Click(object sender, System.EventArgs e)
//        {
//            //Nếu 2 datetimepicker không có giá trị thì load lại dữ liệu
//            dtp_TuNgay.CustomFormat = " ";
//            dtp_TuNgay.Format = DateTimePickerFormat.Custom;
//            dtp_DenNgay.CustomFormat = " ";
//            dtp_DenNgay.Format = DateTimePickerFormat.Custom;
//            if (dtp_TuNgay.Text == " " && dtp_DenNgay.Text == " ")
//            {
//                loadData();
//            }
//            else
//            {

//            }
//        }

//        private void txt_TimKiem_TextChanged(object sender, System.EventArgs e)
//        {

//        }
//    }
//}



using BUL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_XemDSPhieuNhap : Form
    {
        PhieuNhapBUL phieuNhapBUL;
        DataTable dtPhieuNhap;
        DataView dvPhieuNhap;

        public frm_XemDSPhieuNhap()
        {
            InitializeComponent();
            phieuNhapBUL = new PhieuNhapBUL();
            loadData();
            this.MaximizeBox = false;
        }

        public void loadData()
        {
            dgv_DSPhieuNhap.AutoGenerateColumns = false;
            dtPhieuNhap = phieuNhapBUL.layDSChiTietPhieuNhap();
            dvPhieuNhap = new DataView(dtPhieuNhap);
            dgv_DSPhieuNhap.DataSource = dvPhieuNhap;
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            DateTime? tuNgay = dtp_TuNgay.Value.Date;
            DateTime? denNgay = dtp_DenNgay.Value.Date;

            if (dtp_TuNgay.CustomFormat == " " && dtp_DenNgay.CustomFormat == " ")
            {
                dvPhieuNhap.RowFilter = string.Empty;
            }
            else
            {
                string filter = string.Empty;

                if (dtp_TuNgay.CustomFormat != " ")
                {
                    filter += $"NgayLap >= #{tuNgay.Value.ToString("MM/dd/yyyy")}#";
                }

                if (dtp_DenNgay.CustomFormat != " ")
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filter += " AND ";
                    }
                    filter += $"NgayLap <= #{denNgay.Value.ToString("MM/dd/yyyy")}#";
                }

                dvPhieuNhap.RowFilter = filter;
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;

            if (!string.IsNullOrEmpty(txt_TimKiem.Text))
            {
                filter = $"MaPhieu LIKE '%{txt_TimKiem.Text}%' OR MaLo LIKE '%{txt_TimKiem.Text}%'";
            }

            dvPhieuNhap.RowFilter = filter;
        }

        private void dtp_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtp_TuNgay.CustomFormat = "dd/MM/yyyy";
        }

        private void dtp_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
        }

        private void dgv_DSPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DSPhieuNhap.Rows[e.RowIndex];
                string maPhieu = row.Cells["MaPhieu"].Value.ToString();
            }
        }

        //private void btn_InPhieu_Click(object sender, EventArgs e)
        //{
        //    // Kiểm tra xem có dòng nào được chọn không
        //    if (dgv_DSPhieuNhap.SelectedRows.Count > 0)
        //    {
        //        // Lấy mã phiếu nhập từ dòng được chọn
        //        string maPhieu = dgv_DSPhieuNhap.SelectedRows[0].Cells["MaPhieu"].Value.ToString();

        //        // Lấy dữ liệu chi tiết phiếu nhập
        //        DataTable dtChiTiet = phieuNhapBUL.layDSChiTietPhieuNhapTheoMaPhieuNhap(maPhieu);

        //        if (dtChiTiet.Rows.Count > 0)
        //        {
        //            // Tạo đối tượng ExcelExport để xuất dữ liệu
        //            ExcelExportPhieuNhap exporter = new ExcelExportPhieuNhap();

        //            // Gọi hàm xuất Excel
        //            string fileName = "";

        //            if (exporter.ExportPhieuNhap(dtChiTiet, ref fileName))
        //            {
        //                // Hỏi người dùng có muốn mở file Excel không
        //                if (MessageBox.Show("Xuất phiếu nhập thành công! Bạn có muốn mở file Excel?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {
        //                    // Mở file Excel
        //                    System.Diagnostics.Process.Start(fileName);
        //                }
        //            }
        //            else
        //            {
        //                // Hiển thị thông báo lỗi khi không tìm thấy file template
        //                MessageBox.Show("Không tìm thấy file template PhieuNhapVaccine.xlsx trong thư mục Template!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không có dữ liệu chi tiết phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn một phiếu nhập để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        private void btn_InPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgv_DSPhieuNhap.SelectedRows.Count > 0)
            {
                // Lấy mã phiếu nhập từ dòng được chọn
                string maPhieu = dgv_DSPhieuNhap.SelectedRows[0].Cells["MaPhieu"].Value.ToString();

                // Lấy dữ liệu chi tiết phiếu nhập
                DataTable dtChiTiet = phieuNhapBUL.layDSChiTietPhieuNhapTheoMaPhieuNhap(maPhieu);

                if (dtChiTiet.Rows.Count > 0)
                {
                    // Tạo đối tượng ExcelExport để xuất dữ liệu
                    ExcelExportPhieuNhap exporter = new ExcelExportPhieuNhap();

                    // Gọi hàm xuất Excel
                    string fileName = "";

                    if (exporter.ExportPhieuNhap(dtChiTiet, ref fileName))
                    {
                        // Kiểm tra giá trị của fileName
                        MessageBox.Show("File đã được lưu tại: " + fileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hỏi người dùng có muốn mở file Excel không
                        if (MessageBox.Show("Xuất phiếu nhập thành công! Bạn có muốn mở file Excel?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                // Mở file Excel
                                System.Diagnostics.Process.Start(fileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Không thể mở file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi khi không tìm thấy file template
                        MessageBox.Show("Không tìm thấy file template PhieuNhapVaccine.xlsx trong thư mục Template!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu chi tiết phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}