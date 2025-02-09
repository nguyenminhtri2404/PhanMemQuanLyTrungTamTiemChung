using BUL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using VietQRHelper;

namespace GUI
{
    public partial class frm_ThanhToan : Form
    {
        private DoanhThuBUL doanhThuBUL;
        HoaDonBUL hoaDonBUL;
        private string phuongThucThanhToan;
        public frm_ThanhToan()
        {
            InitializeComponent();
            QL_TiemChungDataContext context = new QL_TiemChungDataContext();
            doanhThuBUL = new DoanhThuBUL(context);
            hoaDonBUL = new HoaDonBUL();
            LoadDanhSachChoThanhToan();
            dgv_ThanhToan.Columns["mui"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_ThanhToan.Columns["giaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_ThanhToan.Columns["thanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Fomart cột thành tiền
            dgv_ThanhToan.Columns["thanhTien"].DefaultCellStyle.Format = "C0";
            dgv_ThanhToan.Columns["thanhTien"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
            //Fomart cột giá bán
            dgv_ThanhToan.Columns["giaBan"].DefaultCellStyle.Format = "C0";
            dgv_ThanhToan.Columns["giaBan"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
            btn_Luu.Enabled = false;
            btn_inBienLai.Enabled = false;
            btn_LuuGoi.Enabled = false;
            btn_InBienLaiGoi.Enabled = false;

        }

        private void tab_QuanLyThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_ChoThanhToan_Click(object sender, EventArgs e)
        {
            tab_QuanLyThanhToan.SetPage(0);
        }

        private void btn_LichSuThanhToan_Click(object sender, EventArgs e)
        {
            tab_QuanLyThanhToan.SetPage(1);
            loadLSThanhtoan();
        }

        private void btn_ThanhToanVaccine_Click(object sender, EventArgs e)
        {
            tab_QuanLyThanhToan.SetPage(2);
        }

        private void btn_ThanhToanGoi_Click(object sender, EventArgs e)
        {
            tab_QuanLyThanhToan.SetPage(3);
        }

        #region Chờ thanh toán
        private void LoadDanhSachChoThanhToan()
        {
            dgv_ChoThanhToan.DataSource = hoaDonBUL.LayDSChoThanhToan();
        }
        private void dgv_ChoThanhToan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgv_ChoThanhToan.Rows[e.RowIndex];
                string maPhieuKham = row.Cells["maPK"].Value?.ToString();
                string hinhThucTiem = row.Cells["hinhThucTiem"].Value?.ToString();

                // Điều hướng theo hình thức tiêm
                if (!string.IsNullOrEmpty(maPhieuKham))
                {
                    if (hinhThucTiem == "Tiêm lẻ")
                    {
                        tab_QuanLyThanhToan.SetPage(2); // Chuyển sang tab "Thanh toán Vaccine"
                        DataTable dtPhieuKham = hoaDonBUL.LayThongTinPhieuKhamVaccine(maPhieuKham);
                        HienThiThongTinPhieuKham(dtPhieuKham);
                    }
                    else if (hinhThucTiem == "Tiêm gói")
                    {
                        tab_QuanLyThanhToan.SetPage(3); // Chuyển sang tab "Thanh toán Gói Vaccine"
                        DataTable dtPhieuKham = hoaDonBUL.LayThongTinPhieuKhamGoiVaccine(maPhieuKham);
                        HienThiThongTinPhieuKhamGoi(dtPhieuKham);
                    }
                }
            }
        }
        private void HienThiThongTinPhieuKham(DataTable dtPhieuKham)
        {
            if (dtPhieuKham.Rows.Count > 0)
            {
                // Hiển thị thông tin tên khách hàng
                lb_TenKhachHang.Text = dtPhieuKham.Rows[0]["tenKhachHang"].ToString();

                // Hiển thị thông tin phiếu khám vào DataGridView
                dgv_ThanhToan.AutoGenerateColumns = false;
                dgv_ThanhToan.DataSource = dtPhieuKham;

                // Tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dtPhieuKham.Rows)
                {
                    tongTien += Convert.ToDecimal(row["thanhTien"]);
                }

                // Hiển thị tổng tiền
                lb_TongTien.Text = string.Format("{0:N0}", tongTien).Replace(",", ".") + " VND";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txt_TimKiemChoThanhToan_TextChanged(object sender, EventArgs e)
        {
            string tenKhachHang = txt_TimKiemChoThanhToan.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(tenKhachHang))
                {
                    // Load lại danh sách ban đầu
                    DataTable dt = hoaDonBUL.LayDSChoThanhToan();
                    dgv_ChoThanhToan.DataSource = dt;
                }
                else
                {
                    // Lọc danh sách theo tên khách hàng
                    DataTable dt = hoaDonBUL.LayDSChoThanhToanTheoTenKhachHang(tenKhachHang);
                    dgv_ChoThanhToan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi hoặc log lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        #endregion

        #region Lịch sử thanh toán
        private void loadLSThanhtoan()
        {
            dgv_LichSuThanhToan.AutoGenerateColumns = false;
            dgv_LichSuThanhToan.DataSource = hoaDonBUL.getLSThanhToan();
        }
        #endregion

        #region Thanh toán vaccine

        private void btn_TTTienMat_Click(object sender, EventArgs e)
        {
            lb_TienTra.Visible = true;
            lb_NoiDung.Visible = true;
            lb_TienThua.Visible = true;
            txt_GhiChu.Visible = true;
            txt_TienTra.Visible = true;
            lb_Tien.Visible = true;
            phuongThucThanhToan = "Tiền mặt";
            btn_Luu.Enabled = true;

        }

        private void btn_TTChuyenKhoan_Click(object sender, EventArgs e)
        {
            phuongThucThanhToan = "Chuyển khoản";
            btn_Luu.Enabled = true;
            if (dgv_ThanhToan.SelectedRows.Count > 0)
            {
                string maPhieuKham = dgv_ThanhToan.SelectedRows[0].Cells["MaPhieuKham"].Value.ToString().Trim();


                if (!decimal.TryParse(lb_TongTien.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                {
                    MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string noiDung = txt_GhiChu.Text.Trim();
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử hàm tạo mã hóa đơn tự động

                // Tạo đối tượng HoaDonDTO
                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    MaHD = maHoaDon,
                    NgayLap = DateTime.Now,
                    TienTra = tongTien,
                    TienThua = 0,
                    TongTien = tongTien,
                    PhuongThucThanhToan = phuongThucThanhToan,
                    KieuThanhToan = "Thanh toán hết",
                    TrangThai = 1, // Đã thanh toán
                    NoiDung = noiDung,
                    MaPhieuKham = maPhieuKham
                };


                QRPay qrPay = QRPay.InitVietQR(
                    bankBin: BankApp.BanksObject[BankKey.MBBANK].bin, // Mã ngân hàng
                    bankNumber: "99133336868", // Số tài khoản
                    amount: tongTien.ToString("0", new CultureInfo("vi-VN")), // Định dạng tiền tệ Việt Nam (VND) không có dấu và khoảng cách
                    purpose: $"Hóa đơn: {hoaDon.MaHD}\nKhám bệnh: {hoaDon.MaPhieuKham}" // Nội dung thanh toán
                );

                //Print amount
                //MessageBox.Show("Số tiền cần thanh toán: " + tongTien.ToString("0", new CultureInfo("vi-VN")));


                // Tạo mã QR
                string content = qrPay.Build();
                Image imageQR = QRCodeHelper.TaoVietQRCodeImage(content);

                // Hiển thị mã QR trên PictureBox
                frm_QRCode formQR = new frm_QRCode(imageQR, tongTien);
                formQR.ShowDialog();
                //picQRPay.Image = imageQR;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void TinhTienThua()
        {
            try
            {
                // Lấy tổng tiền từ lb_TongTien (loại bỏ VND và dấu phân cách nhóm nghìn)
                string tongTienText = lb_TongTien.Text.Replace(" VND", "").Replace(".", "").Trim();
                decimal tongTien = Convert.ToDecimal(tongTienText);

                // Lấy số tiền khách đưa từ txt_TienTra
                string tienKhachDuaText = txt_TienTra.Text.Trim();

                // Chuyển đổi dấu phẩy thành dấu chấm nếu hệ thống dùng dấu phẩy làm phân cách thập phân
                tienKhachDuaText = tienKhachDuaText.Replace(",", "."); // Nếu có dấu phẩy thập phân, chuyển thành dấu chấm

                decimal tienKhachDua;
                if (!decimal.TryParse(tienKhachDuaText, out tienKhachDua))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng phương thức nếu số không hợp lệ
                }

                // Tính tiền thừa
                decimal tienThua = tienKhachDua - tongTien;

                // Hiển thị tiền thừa lên lb_TienThua
                lb_TienThua.Text = string.Format("{0:N0} VND", tienThua); // Định dạng tiền thừa với dấu phân cách nghìn và VND

                // Thay đổi màu sắc của lb_TienThua dựa trên giá trị tiền thừa
                lb_TienThua.ForeColor = tienThua < 0 ? Color.Red : Color.Black; // Màu đỏ nếu < 0, màu đen nếu >= 0
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tiền thừa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txt_TienTra_TextChange(object sender, EventArgs e)
        {
            TinhTienThua();
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            btn_inBienLai.Enabled = true;
            try
            {
                // Kiểm tra xem người dùng chọn phương thức thanh toán là Tiền Mặt hay Chuyển Khoản
                if (this.phuongThucThanhToan == "Tiền mặt")
                {
                    // Gọi phương thức lưu hóa đơn cho thanh toán tiền mặt
                    LuuHoaDonTienMat();
                }
                else if (this.phuongThucThanhToan == "Chuyển khoản")
                {
                    // Gọi phương thức lưu hóa đơn cho thanh toán chuyển khoản
                    LuuHoaDonChuyenKhoan();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Phương thức chung để lưu hóa đơn
        private void LuuHoaDonTienMat()
        {
            try
            {
                // Xác nhận người dùng có muốn lưu không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return; // Nếu chọn No, thoát khỏi phương thức
                }

                // Lấy mã hóa đơn tự động
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử có hàm tạo mã hóa đơn tự động

                // Lấy mã phiếu khám từ DataGridView (giả sử mã phiếu khám nằm trong cột có tên "MaPhieuKham")
                if (dgv_ThanhToan.SelectedRows.Count > 0)
                {
                    string maPhieuKham = dgv_ThanhToan.SelectedRows[0].Cells["MaPhieuKham"].Value.ToString().Trim(); // Lấy mã phiếu khám từ cột "MaPhieuKham"

                    // Lấy thông tin từ các điều khiển
                    if (!decimal.TryParse(txt_TienTra.Text.Trim(), out decimal tienTra))
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số cho số tiền trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(lb_TongTien.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                    {
                        MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal tienThua = tienTra - tongTien; // Tính tiền thừa nếu có

                    string phuongThucThanhToan = this.phuongThucThanhToan; // Lấy phương thức thanh toán
                    string noiDung = txt_GhiChu.Text.Trim(); // Lấy nội dung từ TextBox ghi chú

                    // Tạo đối tượng HoaDonDTO
                    HoaDonDTO hoaDon = new HoaDonDTO
                    {
                        MaHD = maHoaDon,
                        NgayLap = DateTime.Now,
                        TienTra = tienTra,  // Tiền trả cho thanh toán tiền mặt
                        TienThua = tienThua, // Tiền thừa
                        TongTien = tongTien,
                        PhuongThucThanhToan = phuongThucThanhToan,
                        KieuThanhToan = "Thanh toán hết", // Nếu không có khác biệt, sử dụng cùng giá trị
                        TrangThai = 1, // Giả sử trạng thái 1 là "Đã thanh toán"
                        NoiDung = noiDung,
                        MaPhieuKham = maPhieuKham
                    };

                    // Gọi phương thức lưu hóa đơn từ lớp BUL
                    bool result = hoaDonBUL.LuuHoaDon(hoaDon);

                    if (result)
                    {
                        MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachChoThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu khám trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức lưu hóa đơn cho Thanh toán Chuyển Khoản
        private void LuuHoaDonChuyenKhoan()
        {
            try
            {
                // Xác nhận người dùng có muốn lưu không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return; // Nếu chọn No, thoát khỏi phương thức
                }

                // Lấy mã hóa đơn tự động
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử có hàm tạo mã hóa đơn tự động

                // Lấy mã phiếu khám từ DataGridView (giả sử mã phiếu khám nằm trong cột có tên "MaPhieuKham")
                if (dgv_ThanhToan.SelectedRows.Count > 0)
                {
                    string maPhieuKham = dgv_ThanhToan.SelectedRows[0].Cells["MaPhieuKham"].Value.ToString().Trim(); // Lấy mã phiếu khám từ cột "MaPhieuKham"

                    // Lấy thông tin từ các điều khiển
                    if (!decimal.TryParse(lb_TongTien.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                    {
                        MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string phuongThucThanhToan = this.phuongThucThanhToan; // Lấy phương thức thanh toán
                    string noiDung = txt_GhiChu.Text.Trim(); // Lấy nội dung từ TextBox ghi chú

                    // Tạo đối tượng HoaDonDTO cho chuyển khoản
                    HoaDonDTO hoaDon = new HoaDonDTO
                    {
                        MaHD = maHoaDon,
                        NgayLap = DateTime.Now,
                        TienTra = 0,  // Tiền trả = 0 (Chuyển khoản)
                        TienThua = 0, // Tiền thừa = 0
                        TongTien = tongTien,
                        PhuongThucThanhToan = phuongThucThanhToan,
                        KieuThanhToan = "Thanh toán hết", // Nếu không có khác biệt, sử dụng cùng giá trị
                        TrangThai = 1, // Giả sử trạng thái 1 là "Đã thanh toán"
                        NoiDung = noiDung,
                        MaPhieuKham = maPhieuKham
                    };

                    // Gọi phương thức lưu hóa đơn từ lớp BUL
                    bool result = hoaDonBUL.LuuHoaDon(hoaDon);

                    if (result)
                    {
                        MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachChoThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu khám trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức xử lý khi nhấn nút Thanh Toán Tiền Mặt

        #endregion

        #region Thanh toán Gói vaccine
        private void HienThiThongTinPhieuKhamGoi(DataTable dtPhieuKhamGoi)
        {
            if (dtPhieuKhamGoi.Rows.Count > 0)
            {
                // Hiển thị thông tin tên khách hàng
                lb_TenKh.Text = dtPhieuKhamGoi.Rows[0]["tenKhachHang"].ToString();

                // Hiển thị thông tin phiếu khám vào DataGridView
                dgv_ThanhToanGoi.AutoGenerateColumns = false;
                dgv_ThanhToanGoi.DataSource = dtPhieuKhamGoi;
                dgv_ThanhToanGoi.Columns["ThanhTienGoi"].DefaultCellStyle.Format = "C0";
                dgv_ThanhToanGoi.Columns["ThanhTienGoi"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
                dgv_ThanhToanGoi.Columns["GiaBanGoi"].DefaultCellStyle.Format = "C0";
                dgv_ThanhToanGoi.Columns["GiaBanGoi"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");

                // Tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dtPhieuKhamGoi.Rows)
                {
                    tongTien += Convert.ToDecimal(row["thanhTien"]);
                }

                // Hiển thị tổng tiền
                lb_TongTienGoi.Text = string.Format("{0:N0}", tongTien).Replace(",", ".") + " VND";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void btn_TienMatGoi_Click(object sender, EventArgs e)
        {
            lb_TienKhachTra.Visible = true;
            lb_NoiDungGoi.Visible = true;
            lb_TienThuaGoi.Visible = true;
            txt_NoiDungGoi.Visible = true;
            txt_TienTraGoi.Visible = true;
            lb_TienConThua.Visible = true;
            phuongThucThanhToan = "Tiền mặt";
            btn_LuuGoi.Enabled = true;
        }
        private void TinhTienThuaGoi()
        {
            try
            {
                // Lấy tổng tiền từ lb_TongTienGoi (loại bỏ VND và dấu phân cách nhóm nghìn)
                string tongTienText = lb_TongTienGoi.Text.Replace(" VND", "").Replace(".", "").Trim();
                decimal tongTien = Convert.ToDecimal(tongTienText);

                // Lấy số tiền khách đưa từ txt_TienTraGoi
                string tienKhachDuaText = txt_TienTraGoi.Text.Trim();

                // Chuyển đổi dấu phẩy thành dấu chấm nếu hệ thống dùng dấu phẩy làm phân cách thập phân
                tienKhachDuaText = tienKhachDuaText.Replace(",", "."); // Nếu có dấu phẩy thập phân, chuyển thành dấu chấm

                decimal tienKhachDua;
                if (!decimal.TryParse(tienKhachDuaText, out tienKhachDua))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng phương thức nếu số không hợp lệ
                }

                // Tính tiền thừa
                decimal tienThua = tienKhachDua - tongTien;

                // Hiển thị tiền thừa lên lb_TienThuaGoi
                lb_TienThuaGoi.Text = string.Format("{0:N0} VND", tienThua); // Định dạng tiền thừa với dấu phân cách nghìn và VND

                // Thay đổi màu sắc của lb_TienThuaGoi dựa trên giá trị tiền thừa
                lb_TienThuaGoi.ForeColor = tienThua < 0 ? Color.Red : Color.Black; // Màu đỏ nếu < 0, màu đen nếu >= 0
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tiền thừa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_TienTraGoi_TextChange(object sender, EventArgs e)
        {
            TinhTienThuaGoi();
        }
        private void LuuHoaDonGoiTienMat()
        {
            try
            {
                // Xác nhận người dùng có muốn lưu không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return; // Nếu chọn No, thoát khỏi phương thức
                }

                // Lấy mã hóa đơn tự động
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử có hàm tạo mã hóa đơn tự động

                // Lấy mã phiếu khám từ DataGridView (giả sử mã phiếu khám nằm trong cột có tên "MaPhieuKham")
                if (dgv_ThanhToanGoi.SelectedRows.Count > 0)
                {
                    string maPhieuKham = dgv_ThanhToanGoi.SelectedRows[0].Cells["maPhieuKhamGoi"].Value.ToString().Trim(); // Lấy mã phiếu khám từ cột "MaPhieuKham"

                    // Lấy thông tin từ các điều khiển
                    if (!decimal.TryParse(txt_TienTraGoi.Text.Trim(), out decimal tienTra))
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số cho số tiền trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(lb_TongTienGoi.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                    {
                        MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal tienThua = tienTra - tongTien; // Tính tiền thừa nếu có

                    string phuongThucThanhToan = this.phuongThucThanhToan; // Lấy phương thức thanh toán
                    string noiDung = txt_NoiDungGoi.Text.Trim(); // Lấy nội dung từ TextBox ghi chú

                    // Tạo đối tượng HoaDonDTO
                    HoaDonDTO hoaDon = new HoaDonDTO
                    {
                        MaHD = maHoaDon,
                        NgayLap = DateTime.Now,
                        TienTra = tienTra,  // Tiền trả cho thanh toán tiền mặt
                        TienThua = tienThua, // Tiền thừa
                        TongTien = tongTien,
                        PhuongThucThanhToan = phuongThucThanhToan,
                        KieuThanhToan = "Thanh toán hết", // Nếu không có khác biệt, sử dụng cùng giá trị
                        TrangThai = 1, // Giả sử trạng thái 1 là "Đã thanh toán"
                        NoiDung = noiDung,
                        MaPhieuKham = maPhieuKham
                    };

                    // Gọi phương thức lưu hóa đơn từ lớp BUL
                    bool result = hoaDonBUL.LuuHoaDon(hoaDon);

                    if (result)
                    {
                        MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachChoThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu khám trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LuuHoaDonGoiChuyenKhoan()
        {
            try
            {
                // Xác nhận người dùng có muốn lưu không
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return; // Nếu chọn No, thoát khỏi phương thức
                }

                // Lấy mã hóa đơn tự động
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử có hàm tạo mã hóa đơn tự động

                // Lấy mã phiếu khám từ DataGridView (giả sử mã phiếu khám nằm trong cột có tên "MaPhieuKham")
                if (dgv_ThanhToanGoi.SelectedRows.Count > 0)
                {
                    string maPhieuKham = dgv_ThanhToanGoi.SelectedRows[0].Cells["maPhieuKhamGoi"].Value.ToString().Trim(); // Lấy mã phiếu khám từ cột "MaPhieuKham"

                    // Lấy thông tin từ các điều khiển
                    if (!decimal.TryParse(lb_TongTienGoi.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                    {
                        MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string phuongThucThanhToan = this.phuongThucThanhToan; // Lấy phương thức thanh toán
                    string noiDung = txt_NoiDungGoi.Text.Trim(); // Lấy nội dung từ TextBox ghi chú

                    // Tạo đối tượng HoaDonDTO cho chuyển khoản
                    HoaDonDTO hoaDon = new HoaDonDTO
                    {
                        MaHD = maHoaDon,
                        NgayLap = DateTime.Now,
                        TienTra = tongTien,  // Tiền trả = 0 (Chuyển khoản)
                        TienThua = 0, // Tiền thừa = 0
                        TongTien = tongTien,
                        PhuongThucThanhToan = phuongThucThanhToan,
                        KieuThanhToan = "Thanh toán hết", // Nếu không có khác biệt, sử dụng cùng giá trị
                        TrangThai = 1, // Giả sử trạng thái 1 là "Đã thanh toán"
                        NoiDung = noiDung,
                        MaPhieuKham = maPhieuKham
                    };

                    // Gọi phương thức lưu hóa đơn từ lớp BUL
                    bool result = hoaDonBUL.LuuHoaDon(hoaDon);

                    if (result)
                    {
                        MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachChoThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu khám trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LuuGoi_Click(object sender, EventArgs e)
        {
            btn_InBienLaiGoi.Enabled = true;
            try
            {
                // Kiểm tra xem người dùng chọn phương thức thanh toán là Tiền Mặt hay Chuyển Khoản
                if (this.phuongThucThanhToan == "Tiền mặt")
                {
                    // Gọi phương thức lưu hóa đơn cho thanh toán tiền mặt
                    LuuHoaDonGoiTienMat();
                }
                else if (this.phuongThucThanhToan == "Chuyển khoản")
                {
                    // Gọi phương thức lưu hóa đơn cho thanh toán chuyển khoản
                    LuuHoaDonGoiChuyenKhoan();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_ChuyenKhoanGoi_Click(object sender, EventArgs e)
        {
            phuongThucThanhToan = "Chuyển khoản";
            btn_LuuGoi.Enabled = true;
            if (dgv_ThanhToanGoi.SelectedRows.Count > 0)
            {
                string maPhieuKham = dgv_ThanhToanGoi.SelectedRows[0].Cells["MaPhieuKhamGoi"].Value.ToString().Trim();


                if (!decimal.TryParse(lb_TongTienGoi.Text.Replace(" VND", "").Replace(".", "").Trim(), out decimal tongTien))
                {
                    MessageBox.Show("Lỗi khi lấy tổng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string noiDung = txt_NoiDungGoi.Text.Trim();
                string maHoaDon = hoaDonBUL.taoMaHoaDon(); // Giả sử hàm tạo mã hóa đơn tự động

                // Tạo đối tượng HoaDonDTO
                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    MaHD = maHoaDon,
                    NgayLap = DateTime.Now,
                    TienTra = tongTien,
                    TienThua = 0,
                    TongTien = tongTien,
                    PhuongThucThanhToan = phuongThucThanhToan,
                    KieuThanhToan = "Thanh toán hết",
                    TrangThai = 1, // Đã thanh toán
                    NoiDung = noiDung,
                    MaPhieuKham = maPhieuKham
                };

                // Tạo nội dung QR dựa trên thông tin hóa đơn
                QRPay qrPay = QRPay.InitVietQR(
                    bankBin: BankApp.BanksObject[BankKey.MBBANK].bin, // Mã ngân hàng
                    bankNumber: "99133336868", // Số tài khoản
                    amount: tongTien.ToString("0", new CultureInfo("vi-VN")),
                    purpose: $"Hóa đơn: {hoaDon.MaHD}\nKhám bệnh: {hoaDon.MaPhieuKham}"
                );

                // Tạo mã QR
                string content = qrPay.Build();
                Image imageQR = QRCodeHelper.TaoVietQRCodeImage(content);

                // Hiển thị mã QR trên PictureBox
                frm_QRCode formQR = new frm_QRCode(imageQR, tongTien);
                formQR.ShowDialog();
                //picQRPay.Image = imageQR;

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_inBienLai_Click(object sender, EventArgs e)
        {
            string maPhieuKham = dgv_ThanhToan.SelectedRows[0].Cells["maPhieuKham"].Value.ToString().Trim();

            HoaDonKhachHangDTO hoaDonKhachHang = hoaDonBUL.GetHoaDonKhachHangByMaPhieuKham(maPhieuKham);
            if (hoaDonKhachHang == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<DanhSachVaccineDTO> danhSachVacXin = hoaDonBUL.GetPhieuKhamByHoaDon(maPhieuKham);

            // Tạo dictionary chứa các giá trị cần thay thế
            Dictionary<string, string> fieldValues = new Dictionary<string, string>
            {
                { "Ngay", DateTime.Now.Day.ToString() },
                { "Thang", DateTime.Now.Month.ToString() },
                { "Nam", DateTime.Now.Year.ToString() },
                { "PhuongThucThanhToan", hoaDonKhachHang.PhuongThucThanhToan },
                { "GioiTinh", hoaDonKhachHang.GioiTinh },
                { "Tuoi",hoaDonKhachHang.Tuoi.ToString() },
                { "HoTenKhachHang", hoaDonKhachHang.HoTenKhachHang },
                { "MaKH", hoaDonKhachHang.MaKH },
                { "SDT", hoaDonKhachHang.SDT },
                { "DiaChi", hoaDonKhachHang.DiaChi },
                //{ "HoTenNguoiGiamHo",hoaDonKhachHang.HoTenNguoiGiamHo },
                { "TongTien", hoaDonKhachHang.TongTien.ToString("N0") },
                { "TienTra", hoaDonKhachHang.TienTra.ToString("N0") },
                { "TienThua", hoaDonKhachHang.TienThua.ToString("N0") }
            };

            // Kiểm tra và thêm trường HoTenNguoiGiamHo nếu có giá trị
            if (!string.IsNullOrEmpty(hoaDonKhachHang.HoTenNguoiGiamHo))
            {
                fieldValues.Add("HoTenNguoiGiamHo", hoaDonKhachHang.HoTenNguoiGiamHo);
            }

            // Tạo DataTable chứa thông tin bảng vaccine
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(int));
            dataTable.Columns.Add("TenVaccine", typeof(string));
            dataTable.Columns.Add("DonGia", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("ThanhTien", typeof(string));

            int stt = 1;
            foreach (DanhSachVaccineDTO VacXin in danhSachVacXin)
            {
                dataTable.Rows.Add(
                    stt++,
                    VacXin.TenVaccine,
                    string.Format("{0:N0}", VacXin.GiaBan),
                    VacXin.Mui,
                    string.Format("{0:N0}", VacXin.ThanhTien)
                );
            }

            string templatePath = Path.Combine(Application.StartupPath, "Template", "BienLaiVaccine.docx");
            string outputPath = string.Format("C:\\Desktop\\BienLai_{0}.docx", hoaDonKhachHang.MaKH);

            try
            {
                // Tạo đối tượng WordExport
                Utilities.WordExport wordExport = new Utilities.WordExport();

                // Mở file template
                wordExport.WordUltil(templatePath, false);

                // Điền dữ liệu vào các trường trong Word
                wordExport.WriteFields(fieldValues);

                if (string.IsNullOrEmpty(hoaDonKhachHang.HoTenNguoiGiamHo))
                {
                    wordExport.DeleteFieldCompletely("«HoTenNguoiGiamHo»");
                }

                // Viết thông tin bảng vào template Word tại chỉ số bảng 1
                wordExport.WriteTablePay(dataTable, 1);

                // Lưu file Word đã điền thông tin
                //wordExport.SaveAs(outputPath);
                wordExport.Close();

                MessageBox.Show("Biên lai đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file Word đã tạo
                // System.Diagnostics.Process.Start("explorer.exe", outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biên lai: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btn_InBienLaiGoi_Click(object sender, EventArgs e)
        {
            string maPhieuKhamGoi = dgv_ThanhToanGoi.SelectedRows[0].Cells["MaPhieuKhamGoi"].Value.ToString().Trim();

            HoaDonKhachHangDTO hoaDonKhachHang = hoaDonBUL.GetHoaDonKhachHangByMaPhieuKham(maPhieuKhamGoi);
            if (hoaDonKhachHang == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<DanhSachGoiVaccineDTO> danhSachGoiVacXin = hoaDonBUL.GetPhieuKhamByHoaDonId(maPhieuKhamGoi);

            // Tạo dictionary chứa các giá trị cần thay thế
            Dictionary<string, string> fieldValues = new Dictionary<string, string>
            {
                { "Ngay", DateTime.Now.Day.ToString() },
                { "Thang", DateTime.Now.Month.ToString() },
                { "Nam", DateTime.Now.Year.ToString() },
                { "PhuongThucThanhToan", hoaDonKhachHang.PhuongThucThanhToan },
                { "GioiTinh", hoaDonKhachHang.GioiTinh },
                { "Tuoi",hoaDonKhachHang.Tuoi.ToString() },
                { "HoTenKhachHang", hoaDonKhachHang.HoTenKhachHang },
                { "MaKH", hoaDonKhachHang.MaKH },
                { "SDT", hoaDonKhachHang.SDT },
                { "DiaChi", hoaDonKhachHang.DiaChi },
                //{ "HoTenNguoiGiamHo",hoaDonKhachHang.HoTenNguoiGiamHo },
                { "TongTien", hoaDonKhachHang.TongTien.ToString("N0") },
                { "TienTra", hoaDonKhachHang.TienTra.ToString("N0") },
                { "TienThua", hoaDonKhachHang.TienThua.ToString("N0") }
            };

            // Kiểm tra và thêm trường HoTenNguoiGiamHo nếu có giá trị
            if (!string.IsNullOrEmpty(hoaDonKhachHang.HoTenNguoiGiamHo))
            {
                fieldValues.Add("HoTenNguoiGiamHo", hoaDonKhachHang.HoTenNguoiGiamHo);
            }





            // Tạo DataTable chứa thông tin bảng vaccine
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(int));
            dataTable.Columns.Add("TenGoi", typeof(string)); // Thêm cột TenGoi
            dataTable.Columns.Add("DonGia", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("ThanhTien", typeof(string));

            int stt = 1;
            foreach (DanhSachGoiVaccineDTO goiVacXin in danhSachGoiVacXin)
            {
                dataTable.Rows.Add(
                    stt++,
                    goiVacXin.TenGoi, // Thêm tenGoi vào đây
                    string.Format("{0:N0}", goiVacXin.GiaBan),
                    goiVacXin.Mui,
                    string.Format("{0:N0}", goiVacXin.ThanhTien)
                );
            }

            string templatePath = Path.Combine(Application.StartupPath, "Template", "BienLaiGoiVaccine.docx");
            string outputPath = string.Format("C:\\Desktop\\BienLai_{0}.docx", hoaDonKhachHang.MaKH);

            try
            {
                // Tạo đối tượng WordExport
                Utilities.WordExport wordExport = new Utilities.WordExport();

                // Mở file template
                wordExport.WordUltil(templatePath, false);

                // Điền dữ liệu vào các trường trong Word
                wordExport.WriteFields(fieldValues);

                if (string.IsNullOrEmpty(hoaDonKhachHang.HoTenNguoiGiamHo))
                {
                    wordExport.DeleteFieldCompletely("«HoTenNguoiGiamHo»");
                }

                // Viết thông tin bảng vào template Word tại chỉ số bảng 1
                wordExport.WriteTablePay(dataTable, 1);

                // Lưu file Word đã điền thông tin
                //wordExport.SaveAs(outputPath);
                wordExport.Close();

                MessageBox.Show("Biên lai đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file Word đã tạo
                // System.Diagnostics.Process.Start("explorer.exe", outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biên lai: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
