//using BUL;
//using DTO;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Windows.Forms;

//namespace GUI
//{
//    public partial class frm_DSDangKyTiemChung : Form
//    {
//        private bool isComboBoxInitialized = false;
//        private KeHoachTiemChungBUL keHoachTiemChungBUL;
//        private KhachHangBUL khachhangBUL;
//        private LichSuTiemChungBUL lichSuTiemChungBUL;
//        private LichTiemChungBUL lichTiemChungBUL;
//        private NguoiGiamHoBUL nguoiGiamHoBUL;
//        private TiemChungBUL tiemchungBUL;
//        private NhanVienBUL nhanvienBUL;
//        private VaccineBUL vaccineBUL;
//        private LichTiemChungBUL lichtiemchungBUL;
//        private List<TiemChungDTO> danhSachtiemchung;
//        private List<NguoiGiamHoDTO> danhSachNguoiGiamHo;
//        private List<KhachHangDTO> danhSachKhachHang;
//        private List<LichTiemChungDTO> danhSachLichTiemChung;
//        private KhachHangDTO khhang;
//        string hoTenNhanVien, maNV;
//        string maNguoiGH;
//        public frm_DSDangKyTiemChung(string hoTenNhanVien, string maNV)
//        {
//            InitializeComponent();
//            lichSuTiemChungBUL = new LichSuTiemChungBUL();
//            keHoachTiemChungBUL = new KeHoachTiemChungBUL();
//            lichTiemChungBUL = new LichTiemChungBUL();
//            nguoiGiamHoBUL = new NguoiGiamHoBUL();
//            khachhangBUL = new KhachHangBUL();
//            tiemchungBUL = new TiemChungBUL();
//            nhanvienBUL = new NhanVienBUL();
//            vaccineBUL = new VaccineBUL();
//            lichtiemchungBUL = new LichTiemChungBUL();
//            LoadGioiTinhRadioButton();
//            LoadGioiTinhComboBox();
//            txt_makh.Enabled = false;
//            txt_makh.Text = GenerateMaKhachHang();
//            txt_maphieu.Enabled = false;
//            txt_maphieu.Text = GenerateMaPhieuDangKy();
//            txtmalichtiemchung.Enabled = false;
//            txtmalichtiemchung.Text = GenerateMaLichTiemChung();
//            loadData();
//            loadkhachhang();
//            loadkhachhangtiemchung();
//            //loadComboboxDataNhanVien();
//            loadDataDangChoKham();
//            loadComboboxDataKeHoach();
//            //LoadLichTiemChung();
//            loadthemkhachhang();
//            LoadLichTiemChungTheoMa();
//            LoadLichSuTiemChungTheoMa();
//            dgv_SuaKhachHang.CellClick += dgv_SuaKhachHang_CellClick;
//            dgv_TiemChung.CellClick += dgv_TiemChung_CellClick;
//            dpk_ngaysinh.ValueChanged += dpk_ngaysinh_ValueChanged;

//            this.hoTenNhanVien = hoTenNhanVien;
//            this.maNV = maNV;
//            txt_TenNVDKy.Text = hoTenNhanVien;
//        }
//        private void loadComboboxDataKeHoach()
//        {
//            List<KeHoachTiemChungDTO> dskehoach = keHoachTiemChungBUL.GetKeHoachCombo();
//            cbo_kehoach.DataSource = dskehoach;
//            cbo_kehoach.DisplayMember = "tenKeHoach";
//            cbo_kehoach.ValueMember = "maKeHoach";

//            // Đánh dấu là đã khởi tạo xong dữ liệu
//            isComboBoxInitialized = true;
//        }
//        private void LoadLichSuTiemChungTheoMa()
//        {
//            // Lấy mã khách hàng từ label
//            string maKhachHang = lbmakhachhang.Text.Trim();
//            // Lấy dữ liệu lịch sử tiêm chủng theo mã khách hàng
//            DataTable originalDataTable = lichSuTiemChungBUL.GetLichSuTiemChungByKhachHang(maKhachHang);

//            // Nếu mã khách hàng trống hoặc không hợp lệ thì không làm gì
//            if (string.IsNullOrEmpty(maKhachHang))
//            {
//                // Xóa dữ liệu trên DataGridView nếu không có mã khách hàng
//                dgv_LichSu.DataSource = null;
//                // Không chuyển tab nếu không có mã khách hàng
//                return;
//            }
//            // Kiểm tra nếu không có dữ liệu trả về
//            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
//            {
//                // Xóa dữ liệu trên DataGridView
//                dgv_LichSu.DataSource = null;
//                return;
//            }

//            // Gán dữ liệu vào DataGridView
//            dgv_LichSu.DataSource = originalDataTable;
//        }
//        private void LoadLichTiemChungTheoMa()
//        {
//            // Lấy mã khách hàng từ label
//            string maKhachHang = lbmakhachhang.Text.Trim();

//            // Lấy toàn bộ dữ liệu lịch tiêm
//            DataTable originalDataTable = lichTiemChungBUL.LayTatCaLichTiem();

//            // Kiểm tra nếu không có dữ liệu trả về từ LayTatCaLichTiem
//            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
//            {
//                MessageBox.Show("Không có dữ liệu lịch tiêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            // Kiểm tra cột "maKhachHang" có tồn tại trong originalDataTable
//            if (!originalDataTable.Columns.Contains("maKhachHang"))
//            {
//                MessageBox.Show("Cột 'maKhachHang' không tồn tại trong dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Tạo một DataView để lọc dữ liệu theo mã khách hàng
//            DataView dvFiltered = new DataView(originalDataTable);
//            dvFiltered.RowFilter = $"maKhachHang = '{maKhachHang}'"; // Lọc theo mã khách hàng

//            // Kiểm tra nếu không có dữ liệu sau khi lọc
//            if (dvFiltered.Count == 0)
//            {
//                //MessageBox.Show($"Không tìm thấy lịch tiêm nào cho mã khách hàng '{maKhachHang}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                dgv_LichTiemChung.DataSource = null; // Xóa dữ liệu trên DataGridView nếu không tìm thấy
//                return;
//            }

//            // Gán dữ liệu đã lọc vào DataGridView
//            dgv_LichTiemChung.DataSource = dvFiltered;
//            txt_TenNV.Text = dgv_LichTiemChung.Rows[0].Cells["HoTenNVLichTiem"].Value.ToString();
//        }
//        public void SetNguoiGiamHoInfo(string maNguoiGiamHo, string hoTen)
//        {
//            // Lưu mã người giám hộ vào TextBox txtnguoigiamho
//            txtnguoigiamho.Text = hoTen;
//            maNguoiGH = maNguoiGiamHo;
//        }
//        private void dgv_TiemChung_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
//            {
//                // Lấy dòng hiện tại
//                DataGridViewRow row = dgv_TiemChung.Rows[e.RowIndex];

//                // Gán dữ liệu từ dòng đã chọn vào các Label và kiểm tra null
//                lbNguoiGiamHo.Text = row.Cells["MaNguoiGH"]?.Value?.ToString() ?? "N/A";
//                lb_hoten.Text = row.Cells["HoTenDK"]?.Value?.ToString() ?? "N/A";
//                lb_gioitinh.Text = row.Cells["GioiTinhDK"]?.Value?.ToString() ?? "N/A";
//                lb_maKhachHang.Text = row.Cells["MaKH"].Value?.ToString(); // Gán mã khách hàng
//                lbhoten.Text = row.Cells["HoTenDK"]?.Value?.ToString() ?? "N/A";
//                lbgioitinh.Text = row.Cells["GioiTinhDK"]?.Value?.ToString() ?? "N/A";
//                lbmakhachhang.Text = row.Cells["MaKH"].Value?.ToString();

//                // Kiểm tra và chuyển đổi ngày sinh nếu không null
//                if (DateTime.TryParse(row.Cells["NgaySinhDK"]?.Value?.ToString(), out DateTime ngaySinh))
//                {
//                    lb_ngaysinh.Text = ngaySinh.ToString("dd/MM/yyyy");
//                    lbngaysinh.Text = ngaySinh.ToString("dd/MM/yyyy");
//                }
//                else
//                {
//                    lb_ngaysinh.Text = "N/A";
//                    lbngaysinh.Text = "N/A";
//                }

//                lb_sdt.Text = row.Cells["SDTDK"]?.Value?.ToString() ?? "N/A";
//                lbsdt.Text = row.Cells["SDTDK"]?.Value?.ToString() ?? "N/A";


//                //LoadLichTiemChung();
//            }
//        }

//        public KhachHangDTO AddedKhachHang { get; private set; }
//        //private void loadComboboxDataNhanVien()
//        //{
//        //    List<NhanVienDTO> dsnv = nhanvienBUL.GetNhanVienCombo();
//        //    cbo_nhanvien.DataSource = dsnv;
//        //    cbo_nhanvien.DisplayMember = "hoTen";
//        //    cbo_nhanvien.ValueMember = "maNhanVien";
//        //    cbonhanvien.DataSource = dsnv;
//        //    cbonhanvien.DisplayMember = "hoTen";
//        //    cbonhanvien.ValueMember = "maNhanVien";
//        //}

//        public void loadDataDangChoKham(string keyword = "")
//        {
//            // Lấy danh sách tiêm chủng từ lớp nghiệp vụ
//            danhSachtiemchung = tiemchungBUL.getTiemChungDangCho();

//            // Lọc danh sách: chỉ lấy các bản ghi có trangThai bằng 0 và khớp với từ khóa tìm kiếm
//            List<TiemChungDTO> danhSachTrangThai0 = danhSachtiemchung
//            .Where(tc => tc.trangThai == 0 &&
//                         (string.IsNullOrEmpty(keyword) ||
//                          tc.hoTen.ToLower().Contains(keyword.ToLower()) ||
//                          tc.maPhieuDangKy.ToLower().Contains(keyword.ToLower()) ||
//                          tc.diaChi.ToLower().Contains(keyword.ToLower()) ||
//                          tc.hinhThucTiem.ToLower().Contains(keyword.ToLower()) ||
//                          tc.gioiTinh.ToLower().Contains(keyword.ToLower()) ||
//                          tc.ngaySinh.ToString().Contains(keyword) ||
//                          tc.ngayDangKy.ToString().Contains(keyword)))
//            .ToList();


//            // Gán nguồn dữ liệu sau khi đã lọc
//            dgv_chokham.DataSource = null; // Đặt lại DataSource để làm mới DataGridView
//            dgv_chokham.DataSource = danhSachTrangThai0;

//            // Ẩn các cột không cần thiết trong DataGridView
//            dgv_chokham.Columns["ghiChu"].Visible = false;
//            dgv_chokham.Columns["MaNhanVien"].Visible = false;
//            dgv_chokham.Columns["MaKhachHang"].Visible = false;
//            dgv_chokham.Columns["trangThai"].Visible = false;
//            dgv_chokham.AutoGenerateColumns = false;
//            // Đảm bảo cột "TrangThaiText" xuất hiện và hiển thị trạng thái dưới dạng chuỗi
//            if (!dgv_chokham.Columns.Contains("trangThai"))
//            {
//                dgv_chokham.Columns.Add("trangThai", "Trạng Thái");
//            }
//        }

//        public void loadData()
//        {
//            danhSachtiemchung = tiemchungBUL.getTiemChungDangCho();
//            List<TiemChungDTO> danhSachTrangThai1 = danhSachtiemchung.Where(tc => tc.trangThai == 1).ToList();
//            dgv_ThongTinTiemChung.DataSource = danhSachTrangThai1;
//            dgv_ThongTinTiemChung.Columns["trangThai"].Visible = false;
//            dgv_ThongTinTiemChung.Columns["ghiChu"].Visible = false;
//            dgv_ThongTinTiemChung.Columns["MaNhanVien"].Visible = false;
//            dgv_ThongTinTiemChung.Columns["MaKhachHang"].Visible = false;
//        }
//        public void loadkhachhang()
//        {
//            danhSachKhachHang = khachhangBUL.GetKhachHang();
//            dgv_SuaKhachHang.DataSource = danhSachKhachHang;
//            dgv_SuaKhachHang.Columns["tinhtrang"].Visible = false;
//            dgv_themkhachhang.DataSource = danhSachKhachHang;
//        }
//        public void loadthemkhachhang()
//        {
//            danhSachKhachHang = khachhangBUL.GetKhachHang();
//            dgv_themkhachhang.DataSource = danhSachKhachHang;
//            dgv_themkhachhang.Columns["tinhtrang"].Visible = false;
//        }
//        public void loadkhachhangtiemchung()
//        {
//            danhSachKhachHang = khachhangBUL.GetKhachHang();
//            dgv_TiemChung.DataSource = danhSachKhachHang;
//            dgv_TiemChung.Columns["tinhtrang"].Visible = false;
//        }
//        //public void LoadLichTiemChung()
//        //{
//        //    // Lấy mã khách hàng từ lb_maKhachHang
//        //    string maKhachHang = lb_maKhachHang.Text.Trim(); // Đảm bảo không có khoảng trắng thừa

//        //    // Kiểm tra xem mã khách hàng có hợp lệ không
//        //    if (string.IsNullOrEmpty(maKhachHang))
//        //    {
//        //        return; // Nếu mã khách hàng rỗng, thoát khỏi phương thức
//        //    }

//        //    // Gọi phương thức GetLichTiemChung với mã khách hàng
//        //    List<LichTiemChungDTO> danhSachLichTiemChung = lichtiemchungBUL.GetLichTiemChungTheoMaKH(maKhachHang);

//        //    // Gán danh sách đã lọc vào DataGridView
//        //    dgv_lichtiemchung.DataSource = danhSachLichTiemChung;

//        //    // Ẩn các cột không cần thiết
//        //    dgv_lichtiemchung.Columns["maKhachHang"].Visible = false;
//        //    dgv_lichtiemchung.Columns["gioiTinh"].Visible = false;
//        //    dgv_lichtiemchung.Columns["ngaySinh"].Visible = false;
//        //    dgv_lichtiemchung.Columns["diaChi"].Visible = false;
//        //    dgv_lichtiemchung.Columns["MaNhanVien"].Visible = false;
//        //    dgv_lichtiemchung.Columns["trangThai"].Visible = false;
//        //}
//        private void LoadGioiTinhComboBox()
//        {
//            cbogioitinh.Items.Clear();
//            cbogioitinh.Items.Add("Nam");
//            cbogioitinh.Items.Add("Nữ");
//            cbogioitinh.SelectedIndex = 0;
//        }
//        private void LoadGioiTinhRadioButton()
//        {
//            rdoNam.Text = "Nam";
//            rdoNu.Text = "Nữ";

//            rdoNam.Checked = true;
//        }

//        private void setCurrentTab(int index)
//        {

//            bunifuPages1.SetPage(index);
//        }

//        private void frm_DSDangKyTiemChung_Load(object sender, EventArgs e)
//        {

//        }

//        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            setCurrentTab(bunifuPages1.SelectedIndex);
//        }
//        private void btnDanhSach_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(0);
//            loadData();
//        }
//        private void bunifuButton1_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(1);
//        }
//        private void bunifuButton2_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(2);
//            LoadLichTiemChungTheoMa();
//            LoadLichSuTiemChungTheoMa();
//        }
//        private void bunifuButton4_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(3);
//        }

//        private void bunifuButton11_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(4);
//        }

//        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
//        {
//            if (danhSachtiemchung == null)
//            {
//                MessageBox.Show("Danh sách tiêm chủng chưa được khởi tạo.");
//                return;
//            }

//            string tuKhoa = txt_TimKiem.Text.Trim().ToLower();

//            List<TiemChungDTO> ketQuaTimKiem = danhSachtiemchung
//                .Where(tiemchung =>
//                    (tiemchung.maPhieuDangKy != null && tiemchung.maPhieuDangKy.ToLower().Contains(tuKhoa)) ||
//                    (tiemchung.hinhThucTiem != null && tiemchung.hinhThucTiem.ToLower().Contains(tuKhoa)) ||
//                    (tiemchung.hoTen != null && tiemchung.hoTen.ToLower().Contains(tuKhoa)) ||
//                    (tiemchung.gioiTinh != null && tiemchung.gioiTinh.ToLower().Contains(tuKhoa)) ||
//                    (tiemchung.diaChi != null && tiemchung.diaChi.ToLower().Contains(tuKhoa)))
//                .ToList();

//            dgv_ThongTinTiemChung.DataSource = ketQuaTimKiem;
//        }

//        private void btn_them_Click(object sender, EventArgs e)
//        {
//            // Lấy dữ liệu từ form
//            string maKhachHang = GenerateMaKhachHang();
//            string hoTen = txt_hoten.Text.Trim();
//            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
//            DateTime ngaySinh = dpk_ngaysinh.Value;
//            string diaChi = txt_diachi.Text.Trim();
//            string sdt = txt_sdt.Text.Trim();
//            string email = txt_email.Text.Trim();
//            string magiamho = maNguoiGH;

//            if (!string.IsNullOrEmpty(magiamho) && !nguoiGiamHoBUL.KiemTraNguoiGiamHoTonTai(magiamho))
//            {
//                MessageBox.Show("Mã người giám hộ không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                loadkhachhang();
//                return;
//            }

//            // Kiểm tra tên khách hàng không để trống
//            if (string.IsNullOrEmpty(hoTen))
//            {
//                MessageBox.Show("Tên khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            //if (txtnguoigiamho.Enabled && !int.TryParse(txtmui.Text, out int mui))
//            //{
//            //    MessageBox.Show("Tên người giám hộ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            //    return;
//            //}
//            // Tạo đối tượng KhachHangDTO
//            KhachHangDTO khachHang = new KhachHangDTO
//            {
//                maKH = maKhachHang,
//                hoTen = hoTen,
//                gioiTinh = gioiTinh,
//                ngaySinh = ngaySinh,
//                diaChi = diaChi,
//                SDT = sdt,
//                email = email,
//                MaNguoiGiamHo = string.IsNullOrEmpty(magiamho) ? null : magiamho // Nếu mã người giám hộ trống, gán null
//            };



//            (bool isSuccess, string message) result = khachhangBUL.ThemKhachHang(khachHang); // Gọi phương thức từ BUS

//            if (result.isSuccess)
//            {
//                MessageBox.Show(result.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                loadkhachhang();
//            }
//            else
//            {
//                MessageBox.Show(result.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//        }
//        private void ResetFields()
//        {
//            txt_hoten.Text = string.Empty;
//            rdoNam.Checked = true;
//            dpk_ngaysinh.Value = DateTime.Now;
//            txt_diachi.Text = string.Empty;
//            txt_sdt.Text = string.Empty;
//            txt_email.Text = string.Empty;
//            txt_makh.Text = GenerateMaKhachHang();
//        }
//        // Hàm sinh mã khách hàng tự động
//        private string GenerateMaKhachHang()
//        {
//            int maxMaKH = khachhangBUL.GetMaxMaKhachHang();
//            int newMaKH = maxMaKH + 1;
//            return "KH" + newMaKH.ToString().PadLeft(3, '0');
//        }


//        private void btn_Sua_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(5);
//        }

//        private void bunifuButton10_Click(object sender, EventArgs e)
//        {
//            // Gán các giá trị từ các trường nhập vào đối tượng khhang
//            khhang.hoTen = txtten.Text.Trim();
//            khhang.gioiTinh = cbogioitinh.Text.Trim();
//            khhang.diaChi = txt_dc.Text.Trim();
//            khhang.SDT = txtsdt.Text.Trim();
//            khhang.email = txtemail.Text.Trim();
//            khhang.ngaySinh = dpkngaysinh.Value; // Cập nhật lại ngày sinh từ DateTimePicker

//            // Gọi phương thức để sửa thông tin khách hàng
//            bool isSuccess = khachhangBUL.SuaKhachHang(khhang);

//            // Kiểm tra kết quả và hiển thị thông báo
//            if (isSuccess)
//            {
//                MessageBox.Show("Sửa thành công!");
//                this.DialogResult = DialogResult.OK;
//                loadkhachhang();
//            }
//            else
//            {
//                MessageBox.Show("Sửa khách hàng thất bại!");
//            }
//        }

//        private void dgv_SuaKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                DataGridViewRow row = dgv_SuaKhachHang.Rows[e.RowIndex];
//                khhang = new KhachHangDTO
//                {
//                    maKH = row.Cells["maKH"].Value.ToString(),
//                    hoTen = row.Cells["hoTen"].Value.ToString(),
//                    gioiTinh = row.Cells["gioiTinh"].Value.ToString(),
//                    diaChi = row.Cells["diaChi"].Value.ToString(),
//                    SDT = row.Cells["SDT"].Value.ToString(),
//                    email = row.Cells["email"].Value.ToString()
//                };

//                txt_ma.Text = khhang.maKH;
//                txt_ma.Enabled = false;
//                txtten.Text = khhang.hoTen;
//                rdoNam.Checked = khhang.gioiTinh == "Nam";
//                rdoNu.Checked = khhang.gioiTinh == "Nữ";

//                if (DateTime.TryParse(row.Cells["ngaySinh"].Value.ToString(), out DateTime ngaySinh))
//                {
//                    dpkngaysinh.Value = ngaySinh;
//                    khhang.ngaySinh = ngaySinh;
//                }

//                txt_dc.Text = khhang.diaChi;
//                txtsdt.Text = khhang.SDT;
//                txtemail.Text = khhang.email;
//            }
//        }

//        private void dgv_ThongTinTiemChung_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//        private void txt_makh_TextChanged(object sender, EventArgs e)
//        {

//        }
//        private void bunifuButton13_Click(object sender, EventArgs e)
//        {
//            // Kiểm tra hình thức tiêm
//            string hinhThucTiem = rdoTiemLe.Checked ? "Tiêm lẻ" : (rdoTiemGoi.Checked ? "Tiêm gói" : null);
//            if (hinhThucTiem == null)
//            {
//                MessageBox.Show("Vui lòng chọn hình thức tiêm.");
//                return;
//            }

//            // Lấy thông tin từ các trường
//            string nguoiGiamHo = lbNguoiGiamHo.Text.Trim();
//            DateTime ngayDangKy = dpkNgayTiem.Value;
//            string ghiChu = txtGhiChu.Text.Trim();
//            string maNhanVien = maNV;
//            string maKhachHang = lb_maKhachHang.Text.Trim();

//            //// Kiểm tra các trường dữ liệu không được để trống
//            //if (string.IsNullOrEmpty(nguoiGiamHo))
//            //{
//            //    MessageBox.Show("Vui lòng nhập tên người giám hộ.");
//            //    return;
//            //}
//            if (string.IsNullOrEmpty(maKhachHang))
//            {
//                MessageBox.Show("Vui lòng chọn khách hàng.");
//                return;
//            }
//            if (string.IsNullOrEmpty(maNhanVien))
//            {
//                MessageBox.Show("Vui lòng chọn nhân viên.");
//                return;
//            }

//            // Kiểm tra mã phiếu đăng ký (nếu cần)
//            string maPhieuDangKy = GenerateMaPhieuDangKy();
//            if (string.IsNullOrEmpty(maPhieuDangKy))
//            {
//                MessageBox.Show("Không thể tạo mã phiếu đăng ký. Vui lòng thử lại.");
//                return;
//            }

//            // Lấy trạng thái tiêm (1: đã tiêm, 0: chưa tiêm)
//            int? trangThai = rdodatiem.Checked ? 1 : (rdochuatiem.Checked ? 0 : (int?)null);
//            if (trangThai == null)
//            {
//                MessageBox.Show("Vui lòng chọn trạng thái.");
//                return;
//            }

//            // Tạo đối tượng TiemChungDTO
//            TiemChungDTO tiemChung = new TiemChungDTO
//            {
//                hinhThucTiem = hinhThucTiem,
//                ngayDangKy = ngayDangKy,
//                GhiChu = ghiChu,
//                MaNhanVien = maNhanVien,
//                maKhachHang = maKhachHang,
//                maPhieuDangKy = maPhieuDangKy,
//                trangThai = trangThai.Value
//            };

//            // Gán mã phiếu vào textbox để hiển thị
//            txt_maphieu.Text = tiemChung.maPhieuDangKy;

//            try
//            {
//                // Lưu thông tin tiêm chủng
//                tiemchungBUL.SaveTiemChung(tiemChung);
//                MessageBox.Show("Lưu thông tin tiêm chủng thành công!");
//                loadDataDangChoKham();
//                txt_maphieu.Text = GenerateMaPhieuDangKy();
//                lbNguoiGiamHo.Text = "";
//                lb_hoten.Text = "";
//                lb_gioitinh.Text = "";
//                lb_ngaysinh.Text = "";
//                lb_maKhachHang.Text = "";
//                lb_sdt.Text = "";
//                loadData();


//            }
//            catch (ArgumentException ex)
//            {
//                MessageBox.Show("Lỗi: " + ex.Message);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
//            }
//        }
//        private string GenerateMaPhieuDangKy()
//        {
//            int maxMaDK = tiemchungBUL.GetMaxMaPhieuDangKy();
//            int newMaDk = maxMaDK + 1;
//            return "PDK" + newMaDk.ToString().PadLeft(3, '0');
//        }
//        private string GenerateMaLichTiemChung()
//        {
//            int maxMaLTC = lichtiemchungBUL.GetMaxMaPhieuDangKy();
//            int newMaLTC = maxMaLTC + 1;
//            return "LTC" + newMaLTC.ToString().PadLeft(3, '0');
//        }
//        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void cbo_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void txt_NguoiGiamHo_TextChanged(object sender, EventArgs e)
//        {

//        }



//        private void txtTimKiem_TextChanged(object sender, EventArgs e)
//        {
//            loadDataDangChoKham(txtTimKiem.Text);
//        }

//        private void bunifuLabel45_Click(object sender, EventArgs e)
//        {

//        }

//        private void bunifuButton6_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(4);
//        }

//        private void bunifuButton8_Click(object sender, EventArgs e)
//        {

//        }

//        private void bunifuButton5_Click(object sender, EventArgs e)
//        {

//        }

//        private void bunifuButton7_Click(object sender, EventArgs e)
//        {
//            DateTime ngayHen = dpk_ngayhen.Value;
//            string muitiemStr = txtmui.Text.Trim();
//            string maNhanVien = maNV;
//            string makehoach = cbo_kehoach.SelectedValue?.ToString();
//            string ghichu = txt_ghichu.Text.Trim();
//            string maKhachHang = lbmakhachhang.Text.Trim();

//            // Kiểm tra vaccine và nhân viên
//            if (string.IsNullOrEmpty(makehoach))
//            {
//                MessageBox.Show("Vui lòng chọn kế hoạch.");
//                return;
//            }
//            if (string.IsNullOrEmpty(maNhanVien))
//            {
//                MessageBox.Show("Vui lòng chọn nhân viên.");
//                return;
//            }
//            if (string.IsNullOrEmpty(muitiemStr))
//            {
//                MessageBox.Show("Vui lòng nhập mũi tiêm.");
//                return;
//            }

//            // Kiểm tra mã phiếu đăng ký
//            string malichtiemchung = GenerateMaLichTiemChung();
//            if (string.IsNullOrEmpty(malichtiemchung))
//            {
//                MessageBox.Show("Không thể tạo mã lịch tiêm chủng. Vui lòng thử lại.");
//                return;
//            }

//            // Chuyển đổi mũi tiêm từ chuỗi sang int?
//            if (!int.TryParse(muitiemStr, out int result))
//            {
//                MessageBox.Show("Mũi tiêm không hợp lệ. Vui lòng nhập số nguyên.");
//                return;
//            }

//            // Tạo đối tượng LichTiemChungDTO
//            LichTiemChungDTO lichtiemChung = new LichTiemChungDTO
//            {
//                Mui = result, // Gán mũi tiêm
//                NgayHen = ngayHen,
//                GhiChu = ghichu,
//                MaNhanVien = maNhanVien, // Gán mã nhân viên
//                MaKhachHang = maKhachHang, // Gán mã khách hàng
//                MaLichTiemChung = malichtiemchung, // Gán mã lịch tiêm chủng
//                MaKeHoach = makehoach,
//                TrangThai = 1
//            };

//            // Gán mã phiếu vào textbox để hiển thị
//            txtmalichtiemchung.Text = lichtiemChung.MaLichTiemChung;

//            try
//            {
//                if (lichtiemchungBUL.ThemLichTiemChung(lichtiemChung))
//                {
//                    MessageBox.Show("Lưu thông tin lịch tiêm chủng thành công!");
//                    LoadLichTiemChungTheoMa();
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                MessageBox.Show("Lỗi: " + ex.Message);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
//            }
//            LoadLichTiemChungTheoMa();
//        }

//        private void bunifuButton9_Click(object sender, EventArgs e)
//        {
//            setCurrentTab(4);
//        }

//        private void dgv_ThongTinTiemChung_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//        private void bunifuLabel5_Click(object sender, EventArgs e)
//        {

//        }

//        private void btn_themnguoigiamho_Click(object sender, EventArgs e)
//        {
//            ThemNguoiGiamHo frm = new ThemNguoiGiamHo();
//            frm.Owner = this;
//            frm.Show();
//        }

//        private void dgv_SuaKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//        private void lbNguoiGiam_Click(object sender, EventArgs e)
//        {

//        }
//        private void tabPage5_Click(object sender, EventArgs e)
//        {

//        }

//        private void rdoTiemLe_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
//        {
//            if (rdoTiemLe.Checked)
//            {
//                rdodatiem.Enabled = true;
//                rdochuatiem.Enabled = true;
//                rdochuatiem.Checked = true;
//            }
//        }

//        private void rdoTiemGoi_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
//        {
//            if (rdoTiemGoi.Checked)
//            {
//                rdodatiem.Enabled = true;
//                rdochuatiem.Enabled = true;
//                rdochuatiem.Checked = true;
//            }
//        }

//        private void cbo_kehoach_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            // Chỉ xử lý nếu ComboBox đã khởi tạo xong
//            if (isComboBoxInitialized && cbo_kehoach.SelectedValue != null)
//            {
//                // Lấy mã kế hoạch được chọn từ ComboBox
//                string maKeHoach = cbo_kehoach.SelectedValue.ToString();

//                // Lấy dữ liệu danh sách kế hoạch từ cơ sở dữ liệu hoặc danh sách
//                List<KeHoachTiemChungDTO> dsKeHoach = keHoachTiemChungBUL.GetKeHoachByMa(maKeHoach);

//                // Tạo form chi tiết và hiển thị dữ liệu
//                frm_CTKeHoach frmChiTiet = new frm_CTKeHoach();
//                frmChiTiet.LoadData(dsKeHoach);
//                frmChiTiet.Show();
//            }
//        }

//        private void tabPage4_Click(object sender, EventArgs e)
//        {

//        }

//        private void dpk_ngaysinh_ValueChanged(object sender, EventArgs e)
//        {
//            // Lấy ngày sinh từ DateTimePicker
//            DateTime selectedDate = dpk_ngaysinh.Value;
//            // Kiểm tra nếu ngày sinh lớn hơn ngày hiện tại
//            if (selectedDate > DateTime.Now)
//            {
//                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return; // Dừng thực hiện nếu ngày không hợp lệ
//            }
//            // Tính tuổi
//            int age = DateTime.Now.Year - selectedDate.Year;
//            if (selectedDate > DateTime.Now.AddYears(-age)) // Kiểm tra nếu chưa đến ngày sinh nhật
//            {
//                age--;
//            }

//            // Debug: kiểm tra ngày sinh và tuổi
//            Console.WriteLine($"Ngày sinh: {selectedDate.ToShortDateString()}, Tuổi: {age}");

//            // Kiểm tra tuổi và cập nhật trạng thái của các điều khiển
//            if (age < 18)
//            {
//                txtnguoigiamho.Enabled = true;  // Vô hiệu hóa TextBox người giám hộ
//                btn_themnguoigiamho.Enabled = true; // Vô hiệu hóa Button thêm người giám hộ
//                Console.WriteLine("Tuổi nhỏ hơn 18: Vô hiệu hóa các điều khiển");
//            }
//            else
//            {
//                txtnguoigiamho.Enabled = false;   // Kích hoạt TextBox người giám hộ
//                btn_themnguoigiamho.Enabled = false; // Kích hoạt Button thêm người giám hộ
//                Console.WriteLine("Tuổi từ 18 trở lên: Kích hoạt các điều khiển");
//            }
//        }
//    }
//}




using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_DSDangKyTiemChung : Form
    {
        private bool isComboBoxInitialized = false;
        private KeHoachTiemChungBUL keHoachTiemChungBUL;
        private KhachHangBUL khachhangBUL;
        private LichSuTiemChungBUL lichSuTiemChungBUL;
        private LichTiemChungBUL lichTiemChungBUL;
        private NguoiGiamHoBUL nguoiGiamHoBUL;
        private TiemChungBUL tiemchungBUL;
        private NhanVienBUL nhanvienBUL;
        private VaccineBUL vaccineBUL;
        private LichTiemChungBUL lichtiemchungBUL;
        private List<TiemChungDTO> danhSachtiemchung;
        private List<NguoiGiamHoDTO> danhSachNguoiGiamHo;
        private List<KhachHangDTO> danhSachKhachHang;
        private List<LichTiemChungDTO> danhSachLichTiemChung;
        private KhachHangDTO khhang;
        string hoTenNhanVien, maNV;
        string maNguoiGH, diaChiGH, soDienThoaiGH, emailGH;
        public frm_DSDangKyTiemChung(string hoTenNhanVien, string maNV)
        {
            InitializeComponent();
            lichSuTiemChungBUL = new LichSuTiemChungBUL();
            keHoachTiemChungBUL = new KeHoachTiemChungBUL();
            lichTiemChungBUL = new LichTiemChungBUL();
            nguoiGiamHoBUL = new NguoiGiamHoBUL();
            khachhangBUL = new KhachHangBUL();
            tiemchungBUL = new TiemChungBUL();
            nhanvienBUL = new NhanVienBUL();
            vaccineBUL = new VaccineBUL();
            lichtiemchungBUL = new LichTiemChungBUL();
            LoadGioiTinhRadioButton();
            LoadGioiTinhComboBox();
            txt_makh.Enabled = false;
            txt_makh.Text = GenerateMaKhachHang();
            txt_maphieu.Enabled = false;
            txt_maphieu.Text = GenerateMaPhieuDangKy();
            txtmalichtiemchung.Enabled = false;
            txtmalichtiemchung.Text = GenerateMaLichTiemChung();
            loadData();
            loadkhachhang();
            loadkhachhangtiemchung();
            //loadComboboxDataNhanVien();
            loadDataDangChoKham();
            loadComboboxDataKeHoach();
            //LoadLichTiemChung();
            loadthemkhachhang();
            LoadLichTiemChungTheoMa();
            LoadLichSuTiemChungTheoMa();
            dgv_SuaKhachHang.CellClick += dgv_SuaKhachHang_CellClick;
            dgv_TiemChung.CellClick += dgv_TiemChung_CellClick;
            dpk_ngaysinh.ValueChanged += dpk_ngaysinh_ValueChanged;

            this.hoTenNhanVien = hoTenNhanVien;
            this.maNV = maNV;
            txt_TenNVDKy.Text = hoTenNhanVien;
        }
        private void loadComboboxDataKeHoach()
        {
            List<KeHoachTiemChungDTO> dskehoach = keHoachTiemChungBUL.GetKeHoachCombo();
            cbo_kehoach.DataSource = dskehoach;
            cbo_kehoach.DisplayMember = "tenKeHoach";
            cbo_kehoach.ValueMember = "maKeHoach";

            // Đánh dấu là đã khởi tạo xong dữ liệu
            isComboBoxInitialized = true;
        }
        private void LoadLichSuTiemChungTheoMa()
        {
            // Lấy mã khách hàng từ label
            string maKhachHang = lbmakhachhang.Text.Trim();
            // Lấy dữ liệu lịch sử tiêm chủng theo mã khách hàng
            DataTable originalDataTable = lichSuTiemChungBUL.GetLichSuTiemChungByKhachHang(maKhachHang);

            // Nếu mã khách hàng trống hoặc không hợp lệ thì không làm gì
            if (string.IsNullOrEmpty(maKhachHang))
            {
                // Xóa dữ liệu trên DataGridView nếu không có mã khách hàng
                dgv_LichSu.DataSource = null;
                // Không chuyển tab nếu không có mã khách hàng
                return;
            }
            // Kiểm tra nếu không có dữ liệu trả về
            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
            {
                // Xóa dữ liệu trên DataGridView
                dgv_LichSu.DataSource = null;
                return;
            }

            // Gán dữ liệu vào DataGridView
            dgv_LichSu.DataSource = originalDataTable;
        }
        private void LoadLichTiemChungTheoMa()
        {
            // Lấy mã khách hàng từ label
            string maKhachHang = lbmakhachhang.Text.Trim();

            // Lấy toàn bộ dữ liệu lịch tiêm
            DataTable originalDataTable = lichTiemChungBUL.LayTatCaLichTiem();

            // Kiểm tra nếu không có dữ liệu trả về từ LayTatCaLichTiem
            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu lịch tiêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra cột "maKhachHang" có tồn tại trong originalDataTable
            if (!originalDataTable.Columns.Contains("maKhachHang"))
            {
                MessageBox.Show("Cột 'maKhachHang' không tồn tại trong dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo một DataView để lọc dữ liệu theo mã khách hàng
            DataView dvFiltered = new DataView(originalDataTable);
            dvFiltered.RowFilter = $"maKhachHang = '{maKhachHang}'"; // Lọc theo mã khách hàng

            // Kiểm tra nếu không có dữ liệu sau khi lọc
            if (dvFiltered.Count == 0)
            {
                //MessageBox.Show($"Không tìm thấy lịch tiêm nào cho mã khách hàng '{maKhachHang}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_LichTiemChung.DataSource = null; // Xóa dữ liệu trên DataGridView nếu không tìm thấy
                return;
            }

            // Gán dữ liệu đã lọc vào DataGridView
            dgv_LichTiemChung.DataSource = dvFiltered;
            txt_TenNV.Text = dgv_LichTiemChung.Rows[0].Cells["HoTenNVLichTiem"].Value.ToString();
        }
        public void SetNguoiGiamHoInfo(string maNguoiGiamHo, string hoTen, string diaChi, string sDT, string email)
        {
            // Lưu mã người giám hộ vào TextBox txtnguoigiamho
            txtnguoigiamho.Text = hoTen;
            maNguoiGH = maNguoiGiamHo;
            txt_diachi.Text = diaChi;
            txt_sdt.Text = sDT;
            txt_email.Text = email;
        }
        private void dgv_TiemChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dgv_TiemChung.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng đã chọn vào các Label và kiểm tra null
                lbNguoiGiamHo.Text = row.Cells["MaNguoiGH"]?.Value?.ToString() ?? "N/A";
                lb_hoten.Text = row.Cells["HoTenDK"]?.Value?.ToString() ?? "N/A";
                lb_gioitinh.Text = row.Cells["GioiTinhDK"]?.Value?.ToString() ?? "N/A";
                lb_maKhachHang.Text = row.Cells["MaKH"].Value?.ToString(); // Gán mã khách hàng
                lbhoten.Text = row.Cells["HoTenDK"]?.Value?.ToString() ?? "N/A";
                lbgioitinh.Text = row.Cells["GioiTinhDK"]?.Value?.ToString() ?? "N/A";
                lbmakhachhang.Text = row.Cells["MaKH"].Value?.ToString();

                // Kiểm tra và chuyển đổi ngày sinh nếu không null
                if (DateTime.TryParse(row.Cells["NgaySinhDK"]?.Value?.ToString(), out DateTime ngaySinh))
                {
                    lb_ngaysinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                    lbngaysinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                else
                {
                    lb_ngaysinh.Text = "N/A";
                    lbngaysinh.Text = "N/A";
                }

                lb_sdt.Text = row.Cells["SDTDK"]?.Value?.ToString() ?? "N/A";
                lbsdt.Text = row.Cells["SDTDK"]?.Value?.ToString() ?? "N/A";


                //LoadLichTiemChung();
            }
        }

        public KhachHangDTO AddedKhachHang { get; private set; }
        //private void loadComboboxDataNhanVien()
        //{
        //    List<NhanVienDTO> dsnv = nhanvienBUL.GetNhanVienCombo();
        //    cbo_nhanvien.DataSource = dsnv;
        //    cbo_nhanvien.DisplayMember = "hoTen";
        //    cbo_nhanvien.ValueMember = "maNhanVien";
        //    cbonhanvien.DataSource = dsnv;
        //    cbonhanvien.DisplayMember = "hoTen";
        //    cbonhanvien.ValueMember = "maNhanVien";
        //}

        public void loadDataDangChoKham(string keyword = "")
        {
            // Lấy danh sách tiêm chủng từ lớp nghiệp vụ
            danhSachtiemchung = tiemchungBUL.getTiemChungDangCho();

            // Lọc danh sách: chỉ lấy các bản ghi có trangThai bằng 0 và khớp với từ khóa tìm kiếm
            List<TiemChungDTO> danhSachTrangThai0 = danhSachtiemchung
            .Where(tc => tc.trangThai == 0 &&
                         (string.IsNullOrEmpty(keyword) ||
                          tc.hoTen.ToLower().Contains(keyword.ToLower()) ||
                          tc.maPhieuDangKy.ToLower().Contains(keyword.ToLower()) ||
                          tc.diaChi.ToLower().Contains(keyword.ToLower()) ||
                          tc.hinhThucTiem.ToLower().Contains(keyword.ToLower()) ||
                          tc.gioiTinh.ToLower().Contains(keyword.ToLower()) ||
                          tc.ngaySinh.ToString().Contains(keyword) ||
                          tc.ngayDangKy.ToString().Contains(keyword)))
            .ToList();


            // Gán nguồn dữ liệu sau khi đã lọc
            dgv_chokham.DataSource = null; // Đặt lại DataSource để làm mới DataGridView
            dgv_chokham.DataSource = danhSachTrangThai0;

            // Ẩn các cột không cần thiết trong DataGridView
            dgv_chokham.Columns["ghiChu"].Visible = false;
            dgv_chokham.Columns["MaNhanVien"].Visible = false;
            dgv_chokham.Columns["MaKhachHang"].Visible = false;
            dgv_chokham.Columns["trangThai"].Visible = false;
            dgv_chokham.AutoGenerateColumns = false;
            // Đảm bảo cột "TrangThaiText" xuất hiện và hiển thị trạng thái dưới dạng chuỗi
            if (!dgv_chokham.Columns.Contains("trangThai"))
            {
                dgv_chokham.Columns.Add("trangThai", "Trạng Thái");
            }
        }

        public void loadData()
        {
            danhSachtiemchung = tiemchungBUL.getTiemChungDangCho();
            List<TiemChungDTO> danhSachTrangThai1 = danhSachtiemchung.Where(tc => tc.trangThai == 1).ToList();
            dgv_ThongTinTiemChung.DataSource = danhSachTrangThai1;
            dgv_ThongTinTiemChung.Columns["trangThai"].Visible = false;
            dgv_ThongTinTiemChung.Columns["ghiChu"].Visible = false;
            dgv_ThongTinTiemChung.Columns["MaNhanVien"].Visible = false;
            dgv_ThongTinTiemChung.Columns["MaKhachHang"].Visible = false;
        }
        public void loadkhachhang()
        {
            danhSachKhachHang = khachhangBUL.GetKhachHang();
            dgv_SuaKhachHang.DataSource = danhSachKhachHang;
            dgv_SuaKhachHang.Columns["tinhtrang"].Visible = false;
            dgv_themkhachhang.DataSource = danhSachKhachHang;
        }
        public void loadthemkhachhang()
        {
            danhSachKhachHang = khachhangBUL.GetKhachHang();
            dgv_themkhachhang.DataSource = danhSachKhachHang;
            dgv_themkhachhang.Columns["tinhtrang"].Visible = false;
        }
        public void loadkhachhangtiemchung()
        {
            danhSachKhachHang = khachhangBUL.GetKhachHang();
            dgv_TiemChung.DataSource = danhSachKhachHang;
            dgv_TiemChung.Columns["tinhtrang"].Visible = false;
        }
        //public void LoadLichTiemChung()
        //{
        //    // Lấy mã khách hàng từ lb_maKhachHang
        //    string maKhachHang = lb_maKhachHang.Text.Trim(); // Đảm bảo không có khoảng trắng thừa

        //    // Kiểm tra xem mã khách hàng có hợp lệ không
        //    if (string.IsNullOrEmpty(maKhachHang))
        //    {
        //        return; // Nếu mã khách hàng rỗng, thoát khỏi phương thức
        //    }

        //    // Gọi phương thức GetLichTiemChung với mã khách hàng
        //    List<LichTiemChungDTO> danhSachLichTiemChung = lichtiemchungBUL.GetLichTiemChungTheoMaKH(maKhachHang);

        //    // Gán danh sách đã lọc vào DataGridView
        //    dgv_lichtiemchung.DataSource = danhSachLichTiemChung;

        //    // Ẩn các cột không cần thiết
        //    dgv_lichtiemchung.Columns["maKhachHang"].Visible = false;
        //    dgv_lichtiemchung.Columns["gioiTinh"].Visible = false;
        //    dgv_lichtiemchung.Columns["ngaySinh"].Visible = false;
        //    dgv_lichtiemchung.Columns["diaChi"].Visible = false;
        //    dgv_lichtiemchung.Columns["MaNhanVien"].Visible = false;
        //    dgv_lichtiemchung.Columns["trangThai"].Visible = false;
        //}
        private void LoadGioiTinhComboBox()
        {
            cbogioitinh.Items.Clear();
            cbogioitinh.Items.Add("Nam");
            cbogioitinh.Items.Add("Nữ");
            cbogioitinh.SelectedIndex = 0;
        }
        private void LoadGioiTinhRadioButton()
        {
            rdoNam.Text = "Nam";
            rdoNu.Text = "Nữ";

            rdoNam.Checked = true;
        }

        private void setCurrentTab(int index)
        {

            bunifuPages1.SetPage(index);
        }

        private void frm_DSDangKyTiemChung_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCurrentTab(bunifuPages1.SelectedIndex);
        }
        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            setCurrentTab(0);
            loadData();
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            setCurrentTab(1);
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            setCurrentTab(2);
            LoadLichTiemChungTheoMa();
            LoadLichSuTiemChungTheoMa();
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            setCurrentTab(3);
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            setCurrentTab(4);
            loadkhachhangtiemchung();
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if (danhSachtiemchung == null)
            {
                MessageBox.Show("Danh sách tiêm chủng chưa được khởi tạo.");
                return;
            }

            string tuKhoa = txt_TimKiem.Text.Trim().ToLower();

            List<TiemChungDTO> ketQuaTimKiem = danhSachtiemchung
                .Where(tiemchung =>
                    (tiemchung.maPhieuDangKy != null && tiemchung.maPhieuDangKy.ToLower().Contains(tuKhoa)) ||
                    (tiemchung.hinhThucTiem != null && tiemchung.hinhThucTiem.ToLower().Contains(tuKhoa)) ||
                    (tiemchung.hoTen != null && tiemchung.hoTen.ToLower().Contains(tuKhoa)) ||
                    (tiemchung.gioiTinh != null && tiemchung.gioiTinh.ToLower().Contains(tuKhoa)) ||
                    (tiemchung.diaChi != null && tiemchung.diaChi.ToLower().Contains(tuKhoa)))
                .ToList();

            dgv_ThongTinTiemChung.DataSource = ketQuaTimKiem;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string maKhachHang = GenerateMaKhachHang();
            string hoTen = txt_hoten.Text.Trim();
            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dpk_ngaysinh.Value;
            string diaChi = txt_diachi.Text.Trim();
            string sdt = txt_sdt.Text.Trim();
            string email = txt_email.Text.Trim();
            string magiamho = maNguoiGH;

            if (!string.IsNullOrEmpty(magiamho) && !nguoiGiamHoBUL.KiemTraNguoiGiamHoTonTai(magiamho))
            {
                MessageBox.Show("Mã người giám hộ không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loadkhachhang();
                return;
            }

            // Kiểm tra tên khách hàng không để trống
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txtnguoigiamho.Enabled && !int.TryParse(txtmui.Text, out int mui))
            //{
            //    MessageBox.Show("Tên người giám hộ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            // Tạo đối tượng KhachHangDTO
            KhachHangDTO khachHang = new KhachHangDTO
            {
                maKH = maKhachHang,
                hoTen = hoTen,
                gioiTinh = gioiTinh,
                ngaySinh = ngaySinh,
                diaChi = diaChi,
                SDT = sdt,
                email = email,
                MaNguoiGiamHo = string.IsNullOrEmpty(magiamho) ? null : magiamho // Nếu mã người giám hộ trống, gán null
            };



            (bool isSuccess, string message) result = khachhangBUL.ThemKhachHang(khachHang); // Gọi phương thức từ BUS

            if (result.isSuccess)
            {
                MessageBox.Show(result.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadkhachhang();
            }
            else
            {
                MessageBox.Show(result.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ResetFields()
        {
            txt_hoten.Text = string.Empty;
            rdoNam.Checked = true;
            dpk_ngaysinh.Value = DateTime.Now;
            txt_diachi.Text = string.Empty;
            txt_sdt.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_makh.Text = GenerateMaKhachHang();
        }
        // Hàm sinh mã khách hàng tự động
        private string GenerateMaKhachHang()
        {
            int maxMaKH = khachhangBUL.GetMaxMaKhachHang();
            int newMaKH = maxMaKH + 1;
            return "KH" + newMaKH.ToString().PadLeft(3, '0');
        }


        private void btn_Sua_Click(object sender, EventArgs e)
        {
            setCurrentTab(5);
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            // Gán các giá trị từ các trường nhập vào đối tượng khhang
            khhang.hoTen = txtten.Text.Trim();
            khhang.gioiTinh = cbogioitinh.Text.Trim();
            khhang.diaChi = txt_dc.Text.Trim();
            khhang.SDT = txtsdt.Text.Trim();
            khhang.email = txtemail.Text.Trim();
            khhang.ngaySinh = dpkngaysinh.Value; // Cập nhật lại ngày sinh từ DateTimePicker

            // Gọi phương thức để sửa thông tin khách hàng
            bool isSuccess = khachhangBUL.SuaKhachHang(khhang);

            // Kiểm tra kết quả và hiển thị thông báo
            if (isSuccess)
            {
                MessageBox.Show("Sửa thành công!");
                this.DialogResult = DialogResult.OK;
                loadkhachhang();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại!");
            }
        }

        private void dgv_SuaKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_SuaKhachHang.Rows[e.RowIndex];
                khhang = new KhachHangDTO
                {
                    maKH = row.Cells["maKH"].Value.ToString(),
                    hoTen = row.Cells["hoTen"].Value.ToString(),
                    gioiTinh = row.Cells["gioiTinh"].Value.ToString(),
                    diaChi = row.Cells["diaChi"].Value.ToString(),
                    SDT = row.Cells["SDT"].Value.ToString(),
                    email = row.Cells["email"].Value.ToString()
                };

                txt_ma.Text = khhang.maKH;
                txt_ma.Enabled = false;
                txtten.Text = khhang.hoTen;
                rdoNam.Checked = khhang.gioiTinh == "Nam";
                rdoNu.Checked = khhang.gioiTinh == "Nữ";

                if (DateTime.TryParse(row.Cells["ngaySinh"].Value.ToString(), out DateTime ngaySinh))
                {
                    dpkngaysinh.Value = ngaySinh;
                    khhang.ngaySinh = ngaySinh;
                }

                txt_dc.Text = khhang.diaChi;
                txtsdt.Text = khhang.SDT;
                txtemail.Text = khhang.email;
            }
        }

        private void dgv_ThongTinTiemChung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_makh_TextChanged(object sender, EventArgs e)
        {

        }
        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            // Kiểm tra hình thức tiêm
            string hinhThucTiem = rdoTiemLe.Checked ? "Tiêm lẻ" : (rdoTiemGoi.Checked ? "Tiêm gói" : null);
            if (hinhThucTiem == null)
            {
                MessageBox.Show("Vui lòng chọn hình thức tiêm.");
                return;
            }

            // Lấy thông tin từ các trường
            string nguoiGiamHo = lbNguoiGiamHo.Text.Trim();
            DateTime ngayDangKy = dpkNgayTiem.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            string maNhanVien = maNV;
            string maKhachHang = lb_maKhachHang.Text.Trim();

            //// Kiểm tra các trường dữ liệu không được để trống
            //if (string.IsNullOrEmpty(nguoiGiamHo))
            //{
            //    MessageBox.Show("Vui lòng nhập tên người giám hộ.");
            //    return;
            //}
            if (string.IsNullOrEmpty(maKhachHang))
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }
            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            // Kiểm tra mã phiếu đăng ký (nếu cần)
            string maPhieuDangKy = GenerateMaPhieuDangKy();
            if (string.IsNullOrEmpty(maPhieuDangKy))
            {
                MessageBox.Show("Không thể tạo mã phiếu đăng ký. Vui lòng thử lại.");
                return;
            }

            // Lấy trạng thái tiêm (1: đã tiêm, 0: chưa tiêm)
            int? trangThai = rdodatiem.Checked ? 1 : (rdochuatiem.Checked ? 0 : (int?)null);
            if (trangThai == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                return;
            }

            // Tạo đối tượng TiemChungDTO
            TiemChungDTO tiemChung = new TiemChungDTO
            {
                hinhThucTiem = hinhThucTiem,
                ngayDangKy = ngayDangKy,
                GhiChu = ghiChu,
                MaNhanVien = maNhanVien,
                maKhachHang = maKhachHang,
                maPhieuDangKy = maPhieuDangKy,
                trangThai = trangThai.Value
            };

            // Gán mã phiếu vào textbox để hiển thị
            txt_maphieu.Text = tiemChung.maPhieuDangKy;

            try
            {
                // Lưu thông tin tiêm chủng
                tiemchungBUL.SaveTiemChung(tiemChung);
                MessageBox.Show("Lưu thông tin tiêm chủng thành công!");
                loadDataDangChoKham();
                txt_maphieu.Text = GenerateMaPhieuDangKy();
                lbNguoiGiamHo.Text = "";
                lb_hoten.Text = "";
                lb_gioitinh.Text = "";
                lb_ngaysinh.Text = "";
                lb_maKhachHang.Text = "";
                lb_sdt.Text = "";
                loadData();


            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private string GenerateMaPhieuDangKy()
        {
            int maxMaDK = tiemchungBUL.GetMaxMaPhieuDangKy();
            int newMaDk = maxMaDK + 1;
            return "PDK" + newMaDk.ToString().PadLeft(3, '0');
        }
        private string GenerateMaLichTiemChung()
        {
            int maxMaLTC = lichtiemchungBUL.GetMaxMaPhieuDangKy();
            int newMaLTC = maxMaLTC + 1;
            return "LTC" + newMaLTC.ToString().PadLeft(3, '0');
        }
        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_NguoiGiamHo_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            loadDataDangChoKham(txtTimKiem.Text);
        }

        private void bunifuLabel45_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            setCurrentTab(4);
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            DateTime ngayHen = dpk_ngayhen.Value;
            string muitiemStr = txtmui.Text.Trim();
            string maNhanVien = maNV;
            string makehoach = cbo_kehoach.SelectedValue?.ToString();
            string ghichu = txt_ghichu.Text.Trim();
            string maKhachHang = lbmakhachhang.Text.Trim();

            // Kiểm tra vaccine và nhân viên
            if (string.IsNullOrEmpty(makehoach))
            {
                MessageBox.Show("Vui lòng chọn kế hoạch.");
                return;
            }
            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }
            if (string.IsNullOrEmpty(muitiemStr))
            {
                MessageBox.Show("Vui lòng nhập mũi tiêm.");
                return;
            }

            // Kiểm tra mã phiếu đăng ký
            string malichtiemchung = GenerateMaLichTiemChung();
            if (string.IsNullOrEmpty(malichtiemchung))
            {
                MessageBox.Show("Không thể tạo mã lịch tiêm chủng. Vui lòng thử lại.");
                return;
            }

            // Chuyển đổi mũi tiêm từ chuỗi sang int?
            if (!int.TryParse(muitiemStr, out int result))
            {
                MessageBox.Show("Mũi tiêm không hợp lệ. Vui lòng nhập số nguyên.");
                return;
            }

            // Tạo đối tượng LichTiemChungDTO
            LichTiemChungDTO lichtiemChung = new LichTiemChungDTO
            {
                Mui = result, // Gán mũi tiêm
                NgayHen = ngayHen,
                GhiChu = ghichu,
                MaNhanVien = maNhanVien, // Gán mã nhân viên
                MaKhachHang = maKhachHang, // Gán mã khách hàng
                MaLichTiemChung = malichtiemchung, // Gán mã lịch tiêm chủng
                MaKeHoach = makehoach,
                TrangThai = 1
            };

            // Gán mã phiếu vào textbox để hiển thị
            txtmalichtiemchung.Text = lichtiemChung.MaLichTiemChung;

            try
            {
                if (lichtiemchungBUL.ThemLichTiemChung(lichtiemChung))
                {
                    MessageBox.Show("Lưu thông tin lịch tiêm chủng thành công!");
                    LoadLichTiemChungTheoMa();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            LoadLichTiemChungTheoMa();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            setCurrentTab(4);
            loadkhachhangtiemchung();
        }

        private void dgv_ThongTinTiemChung_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btn_themnguoigiamho_Click(object sender, EventArgs e)
        {
            ThemNguoiGiamHo frm = new ThemNguoiGiamHo();
            frm.Owner = this;
            frm.Show();
        }

        private void dgv_SuaKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbNguoiGiam_Click(object sender, EventArgs e)
        {

        }
        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void rdoTiemLe_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rdoTiemLe.Checked)
            {
                rdodatiem.Enabled = true;
                rdochuatiem.Enabled = true;
                rdochuatiem.Checked = true;
            }
        }

        private void rdoTiemGoi_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rdoTiemGoi.Checked)
            {
                rdodatiem.Enabled = true;
                rdochuatiem.Enabled = true;
                rdochuatiem.Checked = true;
            }
        }

        private void cbo_kehoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ xử lý nếu ComboBox đã khởi tạo xong
            if (isComboBoxInitialized && cbo_kehoach.SelectedValue != null)
            {
                // Lấy mã kế hoạch được chọn từ ComboBox
                string maKeHoach = cbo_kehoach.SelectedValue.ToString();

                // Lấy dữ liệu danh sách kế hoạch từ cơ sở dữ liệu hoặc danh sách
                List<KeHoachTiemChungDTO> dsKeHoach = keHoachTiemChungBUL.GetKeHoachByMa(maKeHoach);

                // Tạo form chi tiết và hiển thị dữ liệu
                frm_CTKeHoach frmChiTiet = new frm_CTKeHoach();
                frmChiTiet.LoadData(dsKeHoach);
                frmChiTiet.Show();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dpk_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày sinh từ DateTimePicker
            DateTime selectedDate = dpk_ngaysinh.Value;
            // Kiểm tra nếu ngày sinh lớn hơn ngày hiện tại
            if (selectedDate > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu ngày không hợp lệ
            }
            // Tính tuổi
            int age = DateTime.Now.Year - selectedDate.Year;
            if (selectedDate > DateTime.Now.AddYears(-age)) // Kiểm tra nếu chưa đến ngày sinh nhật
            {
                age--;
            }

            // Debug: kiểm tra ngày sinh và tuổi
            Console.WriteLine($"Ngày sinh: {selectedDate.ToShortDateString()}, Tuổi: {age}");

            // Kiểm tra tuổi và cập nhật trạng thái của các điều khiển
            if (age < 18)
            {
                txtnguoigiamho.Enabled = true;  // Vô hiệu hóa TextBox người giám hộ
                btn_themnguoigiamho.Enabled = true; // Vô hiệu hóa Button thêm người giám hộ
                Console.WriteLine("Tuổi nhỏ hơn 18: Vô hiệu hóa các điều khiển");
            }
            else
            {
                txtnguoigiamho.Enabled = false;   // Kích hoạt TextBox người giám hộ
                btn_themnguoigiamho.Enabled = false; // Kích hoạt Button thêm người giám hộ
                Console.WriteLine("Tuổi từ 18 trở lên: Kích hoạt các điều khiển");
            }
        }
    }
}

