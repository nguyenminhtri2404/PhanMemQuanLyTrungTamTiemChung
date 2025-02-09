using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace GUI
{
    public partial class frm_DSKhamSangLoc : Form
    {
        private int clickCount = 0;
        private const int maxClicks = 5;
        private bool isComboBoxInitialized = false;
        private TextBox txtMui, txtGiaBan, txtLieuLuong, txtTinhTrang;
        private List<List<Control>> createdControlGroups = new List<List<Control>>();
        private int nextYPosition = 70;
        List<Control> vaccineControls = new List<Control>();
        private List<int> deletedYPositions = new List<int>();
        private List<List<Control>> deletedControlGroups = new List<List<Control>>();
        private LichSuTiemChungBUL lichSuTiemChungBUL;
        private LichTiemChungBUL lichTiemChungBUL;
        private PhieuKhamSangLocBUL phieuKhamSangLocBUL;
        private CauHoiSangLocBUL cauHoiSangLocBUL;
        private KhachHangBUL khachhangBUL;
        private TiemChungBUL tiemchungBUL;
        private NhanVienBUL nhanvienBUL;
        private KeHoachTiemChungBUL keHoachTiemChungBUL;
        private PhongBenhBUL phongBenhBUL;
        private PhieuKham_VaccineBUL phieuKham_VaccineBUL;
        private VaccineBUL vaccineBUL;
        private KhuyenMaiBUL khuyenMaiBUL;
        private GoiVaccineBUL goiVaccineBUL;
        private ThongTinChiTietVaccineBUL thongtinchitietvacxinBUL;
        private LichTiemChungBUL lichtiemchungBUL;
        private List<TiemChungDTO> danhSachtiemchung;
        private List<KhachHangDTO> danhSachKhachHang;
        private List<PhieuKhamSangLocDTO> danhsachPhieuKhamSangLoc;
        private List<LichTiemChungDTO> danhSachLichTiemChung;
        private KhachHangDTO khhang;
        string hoTen, maNV;
        public frm_DSKhamSangLoc(string hoTen, string maNhanVien)
        {
            InitializeComponent();
            lichTiemChungBUL = new LichTiemChungBUL();
            lichSuTiemChungBUL = new LichSuTiemChungBUL();
            keHoachTiemChungBUL = new KeHoachTiemChungBUL();
            phongBenhBUL = new PhongBenhBUL();
            khuyenMaiBUL = new KhuyenMaiBUL();
            khachhangBUL = new KhachHangBUL();
            tiemchungBUL = new TiemChungBUL();
            nhanvienBUL = new NhanVienBUL();
            vaccineBUL = new VaccineBUL();
            lichtiemchungBUL = new LichTiemChungBUL();
            cauHoiSangLocBUL = new CauHoiSangLocBUL();
            phieuKhamSangLocBUL = new PhieuKhamSangLocBUL();
            phieuKham_VaccineBUL = new PhieuKham_VaccineBUL();
            thongtinchitietvacxinBUL = new ThongTinChiTietVaccineBUL();
            goiVaccineBUL = new GoiVaccineBUL();
            InitializeVaccinePanelControls();
            LoadCauHoi();
            loadDataDanhSachGoiVaccine();
            loadDataDangChoKham();
            //loadComboboxDataNhanVien();
            //LoadLichTiemChung();
            //loadComboboxDataVaccine();
            LoadPhieuKhamSangLoc();
            loadComboboxDataKhuyenMai();
            loadComboboxDataTenGoi();
            SetupDataGridView();
            loadDataThemDanhSachGoiVaccine();
            loadComboboxDataKeHoach();
            //LoadLichTiemChungTheoMa();
            //LoadLichSuTiemChungTheoMa();
            ComboBox cbVaccine = new ComboBox();
            cbVaccine.Location = new Point(10, 30);
            cbVaccine.Size = new Size(120, 20);
            panel_vacxin.Controls.Add(cbVaccine);
            //LoadVaccineComboBox(cbVaccine);
            txtmalichtiemchung.Enabled = false;
            txtmalichtiemchung.Text = GenerateMaLichTiemChung();
            txtmagoi.Enabled = false;
            txtmagoi.Text = GenerateMaGoi();
            dgv_chokham.CellClick += dgv_chokham_CellClick;
            dgv_phieukhamsangloc.CellClick += dgv_phieukhamsangloc_CellClick;

            this.hoTen = hoTen;
            this.maNV = maNhanVien;
            bunifuButton7.Enabled = false;

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
        }
        private string GenerateMaGoi()
        {
            int maxMaGoi = goiVaccineBUL.GetMaxMaGoi();
            int newMaGoi = maxMaGoi + 1;
            return "GV" + newMaGoi.ToString().PadLeft(3, '0');
        }
        private void loadComboboxDataTenGoi()
        {
            List<GoiVaccineDTO> dsgoivaccine = goiVaccineBUL.LayDanhSachGoiVaccines();


            cbogoi.DataSource = dsgoivaccine;
            cbogoi.DisplayMember = "tenGoi";
            cbogoi.ValueMember = "maGoi";
        }

        private void loadComboboxDataKhuyenMai()
        {
            List<KhuyenMaiDTO> dskhuyenmai = khuyenMaiBUL.getKhuyenMai();
            cbo_khuyenmai.DataSource = dskhuyenmai;
            cbo_khuyenmai.DisplayMember = "tenKhuyenMai";
            cbo_khuyenmai.ValueMember = "maKhuyenMai";

        }
        public void loadDataThemDanhSachGoiVaccine(string keyword = "")
        {
            // Lấy danh sách gói vaccine từ lớp nghiệp vụ
            List<GoiVaccineDTO> danhSachGoiVaccine = goiVaccineBUL.LayDanhSachGoiVaccines();

            // Kiểm tra nếu danh sách trả về không có dữ liệu
            if (danhSachGoiVaccine == null || danhSachGoiVaccine.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu gói vaccine!");
                return;
            }

            // Lọc danh sách: chỉ lấy các bản ghi có trangThai bằng 0 và khớp với từ khóa tìm kiếm
            List<DTO.GoiVaccineDTO> danhSachTrangThai1 = danhSachGoiVaccine
                .Where(gv => gv.trangThai == 1 &&
                             (string.IsNullOrEmpty(keyword) ||
                              gv.TenGoi.ToLower().Contains(keyword.ToLower()) ||
                              gv.MaKhuyenMai.ToLower().Contains(keyword.ToLower()) ||
                              gv.TongTienGoi.ToString().Contains(keyword)))
                .ToList();

            // Kiểm tra nếu sau khi lọc, danh sách không có kết quả
            if (danhSachTrangThai1.Count == 0)
            {
                MessageBox.Show("Không có kết quả tìm kiếm khớp!");
                return;
            }

            // Gán nguồn dữ liệu sau khi đã lọc
            dgv_dsgoiVaccine.DataSource = null; // Đặt lại DataSource để làm mới DataGridView
            dgv_dsgoiVaccine.AutoGenerateColumns = false;
            dgv_dsgoiVaccine.DataSource = danhSachTrangThai1;

            // Xóa tất cả các cột hiện có để tránh lỗi
            dgv_dsgoiVaccine.Columns.Clear();

            // Tạo các cột DataGridView
            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maGoi",
                Name = "maGoi",
                HeaderText = "Mã Gói"
            });

            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tenGoi",
                Name = "tenGoi",
                HeaderText = "Tên Gói"
            });

            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "thoiHanSuDung",
                Name = "thoiHanSuDung",
                HeaderText = "Thời Hạn Sử Dụng",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } // Định dạng ngày tháng
            });

            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "trangThai",
                Name = "trangThai",
                HeaderText = "Trạng Thái"
            });

            DataGridViewColumn trangThaiColumn = dgv_dsgoiVaccine.Columns["trangThai"];
            if (trangThaiColumn != null)
            {
                trangThaiColumn.Visible = false;
            }
            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maKhuyenMai",
                Name = "maKhuyenMai",
                HeaderText = "Mã Khuyến Mãi"
            });

            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tongTienGoi",
                Name = "tongTienGoi",
                HeaderText = "Tổng Tiền Gói",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0" } // Định dạng số tiền
            });

            // Thêm cột hiển thị trạng thái "Text" để hiển thị thông tin trạng thái theo dạng text
            dgv_dsgoiVaccine.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThaiText",
                Name = "TrangThaiText",
                HeaderText = "Trạng Thái"
            });
            foreach (DataGridViewRow row in dgv_dsgoiVaccine.Rows)
            {
                if (row.Cells["TrangThai"].Value != null && (int)row.Cells["TrangThai"].Value == 1)
                {
                    row.Cells["TrangThaiText"].Value = "Đang chờ";
                }
            }
        }
        public void loadDataDanhSachGoiVaccine(string keyword = "")
        {
            // Lấy danh sách gói vaccine từ lớp nghiệp vụ
            List<GoiVaccineDTO> danhSachGoiVaccine = goiVaccineBUL.LayDanhSachGoiVaccines();

            // Kiểm tra nếu danh sách trả về không có dữ liệu
            if (danhSachGoiVaccine == null || danhSachGoiVaccine.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu gói vaccine!");
                return;
            }

            // Lọc danh sách: chỉ lấy các bản ghi có trangThai bằng 0 và khớp với từ khóa tìm kiếm
            List<DTO.GoiVaccineDTO> danhSachTrangThai1 = danhSachGoiVaccine
                .Where(gv => gv.trangThai == 1 &&
                             (string.IsNullOrEmpty(keyword) ||
                              gv.TenGoi.ToLower().Contains(keyword.ToLower()) ||
                              gv.MaKhuyenMai.ToLower().Contains(keyword.ToLower()) ||
                              gv.TongTienGoi.ToString().Contains(keyword)))
                .ToList();

            // Kiểm tra nếu sau khi lọc, danh sách không có kết quả
            if (danhSachTrangThai1.Count == 0)
            {
                MessageBox.Show("Không có kết quả tìm kiếm khớp!");
                return;
            }

            // Gán nguồn dữ liệu sau khi đã lọc
            dgv_danhsachgoi.DataSource = null; // Đặt lại DataSource để làm mới DataGridView
            dgv_danhsachgoi.AutoGenerateColumns = false;
            dgv_danhsachgoi.DataSource = danhSachTrangThai1;

            // Xóa tất cả các cột hiện có để tránh lỗi
            dgv_danhsachgoi.Columns.Clear();

            // Tạo các cột DataGridView
            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maGoi",
                Name = "maGoi",
                HeaderText = "Mã Gói"
            });

            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tenGoi",
                Name = "tenGoi",
                HeaderText = "Tên Gói"
            });

            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "thoiHanSuDung",
                Name = "thoiHanSuDung",
                HeaderText = "Thời Hạn Sử Dụng",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } // Định dạng ngày tháng
            });

            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "trangThai",
                Name = "trangThai",
                HeaderText = "Trạng Thái"
            });

            DataGridViewColumn trangThaiColumn = dgv_danhsachgoi.Columns["trangThai"];
            if (trangThaiColumn != null)
            {
                trangThaiColumn.Visible = false;
            }
            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maKhuyenMai",
                Name = "maKhuyenMai",
                HeaderText = "Mã Khuyến Mãi"
            });

            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tongTienGoi",
                Name = "tongTienGoi",
                HeaderText = "Tổng Tiền Gói",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0" } // Định dạng số tiền
            });

            // Thêm cột hiển thị trạng thái "Text" để hiển thị thông tin trạng thái theo dạng text
            dgv_danhsachgoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThaiText",
                Name = "TrangThaiText",
                HeaderText = "Trạng Thái"
            });
            foreach (DataGridViewRow row in dgv_danhsachgoi.Rows)
            {
                if (row.Cells["TrangThai"].Value != null && (int)row.Cells["TrangThai"].Value == 1)
                {
                    row.Cells["TrangThaiText"].Value = "Đang chờ";
                }
            }
        }
        private void LoadPhongBenhComboBox(ComboBox cbPhongBenh)
        {
            // Giả sử bạn có phương thức trong BLL để lấy danh sách phòng bệnh
            List<PhongBenhDTO> phongBenhList = phongBenhBUL.GetPhongBenhList();

            cbPhongBenh.DisplayMember = "tenBenh";   // Tên phòng bệnh hiển thị
            cbPhongBenh.ValueMember = "maPhongNgua"; // Mã phòng bệnh
            cbPhongBenh.DataSource = phongBenhList;

            // Tự động load vaccine cho phòng bệnh đầu tiên nếu có dữ liệu
            if (phongBenhList.Count > 0)
            {
                string maPhongNgua = phongBenhList[0].MaPhongNgua;

                // Lấy ComboBox vaccine từ Tag của ComboBox phòng bệnh
                ComboBox cbVaccine = cbPhongBenh.Tag as ComboBox;
                if (cbVaccine != null)
                {
                    LoadVaccineComboBox(maPhongNgua, cbVaccine); // Load vaccine tương ứng với phòng bệnh đầu tiên
                }
            }
        }

        // Cập nhật ComboBox Vaccine dựa trên mã phòng bệnh và ComboBox vaccine tương ứng
        private void LoadVaccineComboBox(string maPhongNgua, ComboBox cbVaccine)
        {
            // Giả sử bạn có phương thức để lấy danh sách vaccine theo phòng bệnh
            List<VaccineDTO> vaccineList = vaccineBUL.GetVaccinesByPhongBenh(maPhongNgua);

            cbVaccine.DataSource = vaccineList;
            cbVaccine.DisplayMember = "tenVaccine";
            cbVaccine.ValueMember = "maVaccine";    // Mã vaccine
        }


        public void LoadPhieuKhamSangLoc()
        {
            // Lấy mã khách hàng từ lb_maKhachHang
            string maPhieuKhamDangKy = lb_maPhieuDangKy.Text.Trim(); // Đảm bảo không có khoảng trắng thừa

            // Kiểm tra xem mã khách hàng có hợp lệ không
            if (string.IsNullOrEmpty(maPhieuKhamDangKy))
            {
                return; // Nếu mã khách hàng rỗng, thoát khỏi phương thức
            }

            // Gọi phương thức GetLichTiemChung với mã khách hàng
            List<PhieuKhamSangLocDTO> danhSachPhieuKhamSangLoc = phieuKhamSangLocBUL.GetPhieuKhamTheoMaPhieuDangKy(maPhieuKhamDangKy);

            // Gán danh sách đã lọc vào DataGridView
            dgv_phieukhamsangloc.DataSource = danhSachPhieuKhamSangLoc;
            dgv_phieukhamsangloc.Columns["maPhieuDangKy"].Visible = false;
            dgv_phieukhamsangloc.Columns["maNhanVien"].Visible = false;
            dgv_phieukhamsangloc.Columns["trangThai"].Visible = false;
        }
        private string GenerateMaLichTiemChung()
        {
            int maxMaLTC = lichtiemchungBUL.GetMaxMaPhieuDangKy();
            int newMaLTC = maxMaLTC + 1;
            return "LTC" + newMaLTC.ToString().PadLeft(3, '0');
        }

        private void InitializeVaccinePanelControls()
        {
            // Tạo danh sách các điều khiển liên quan
            List<Control> controlGroup = new List<Control>();

            // Label "Phòng bệnh"
            Label lblPhongBenh = new Label
            {
                Text = "Phòng bệnh",
                Location = new Point(10, 4),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblPhongBenh);

            // ComboBox "Phòng bệnh"
            ComboBox cbPhongBenh = new ComboBox
            {
                Location = new Point(10, 30),
                Size = new Size(180, 20)
            };
            cbPhongBenh.SelectedIndexChanged += cbPhongBenh_SelectedIndexChanged;
            panel_vacxin.Controls.Add(cbPhongBenh);

            // Label "Vắc xin"
            Label lblVaccine = new Label
            {
                Text = "Vắc xin",
                Location = new Point(200, 4),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblVaccine);

            // ComboBox "Vắc xin"
            ComboBox cbVaccine = new ComboBox
            {
                Location = new Point(200, 30),
                Size = new Size(180, 20),
                Name = "cbVaccine"
            };
            cbVaccine.SelectedIndexChanged += cbVaccine_SelectedIndexChanged;
            panel_vacxin.Controls.Add(cbVaccine);

            // Các điều khiển khác (Mũi, Giá bán, Liều lượng, Tình trạng)
            CreateAndAddControl("Số Mũi", 390, "txtMui", panel_vacxin, controlGroup);
            CreateAndAddControl("Giá bán", 510, "txtGiaBan", panel_vacxin, controlGroup);
            CreateAndAddControl("Liều lượng", 630, "txtLieuLuong", panel_vacxin, controlGroup);
            CreateAndAddControl("Tình trạng", 770, "txtTinhTrang", panel_vacxin, controlGroup);

            // Gán Tag cho ComboBox để chứa nhóm điều khiển
            cbPhongBenh.Tag = cbVaccine;

            // Gán danh sách TextBox vào Tag của ComboBox cbVaccine
            cbVaccine.Tag = controlGroup;

            // Load dữ liệu cho ComboBox phòng bệnh
            LoadPhongBenhComboBox(cbPhongBenh);
        }

        // Hàm hỗ trợ tạo và thêm điều khiển vào panel
        private void CreateAndAddControl(string labelText, int xPosition, string controlName, Panel parentPanel, List<Control> controlGroup)
        {
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(xPosition, 4),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            parentPanel.Controls.Add(label);

            TextBox textBox = new TextBox
            {
                Location = new Point(xPosition, 30),
                Size = new Size(100, 20),
                Name = controlName
            };
            parentPanel.Controls.Add(textBox);

            // Thêm TextBox vào nhóm điều khiển
            controlGroup.Add(textBox);
        }
        private void cbPhongBenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbPhongBenh = (ComboBox)sender;
            string maPhongNgua = cbPhongBenh.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(maPhongNgua))
            {
                // Lấy ComboBox Vaccine tương ứng từ Tag
                if (cbPhongBenh.Tag is ComboBox cbVaccine)
                {
                    LoadVaccineComboBox(maPhongNgua, cbVaccine); // Chỉ cập nhật vaccine của phòng bệnh này
                }
            }
        }
        private void cbVaccine_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ComboBox từ sender
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một vaccine.", "Lỗi");
                return; // Nếu không có vaccine được chọn, dừng lại
            }

            // Lấy nhóm điều khiển từ Tag của ComboBox
            List<Control> controlGroup = comboBox.Tag as List<Control>;
            if (controlGroup == null)
            {
                MessageBox.Show("Không tìm thấy nhóm điều khiển (Tag) trong ComboBox", "Lỗi");
                return; // Nếu không có nhóm điều khiển, dừng lại
            }

            // Tìm các TextBox dựa vào tên
            TextBox txtMuiLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtMui");
            TextBox txtGiaBanLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtGiaBan");
            TextBox txtLieuLuongLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtLieuLuong");
            TextBox txtTinhTrangLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtTinhTrang");

            // Kiểm tra nếu có TextBox nào là null
            if (txtMuiLocal == null || txtGiaBanLocal == null || txtLieuLuongLocal == null || txtTinhTrangLocal == null)
            {
                MessageBox.Show("Không tìm thấy một hoặc nhiều TextBox cần thiết.", "Lỗi");
                return; // Nếu có TextBox không hợp lệ, dừng lại
            }

            // Lấy thông tin vaccine được chọn từ ComboBox
            VaccineDTO selectedVaccine = comboBox.SelectedItem as VaccineDTO;
            if (selectedVaccine == null)
            {
                MessageBox.Show("Không tìm thấy thông tin vaccine đã chọn.", "Lỗi");
                return; // Nếu vaccine không được chọn, dừng lại
            }

            // Lấy thông tin từ kế hoạch tiêm chủng thông qua BUL
            KeHoachTiemChungBUL keHoachBUL = new KeHoachTiemChungBUL();
            KeHoachTiemChungDTO keHoachInfo = keHoachBUL.GetKeHoachTiemChung(selectedVaccine.MaVaccine);

            // Kiểm tra và cập nhật thông tin số mũi
            txtMuiLocal.Text = keHoachInfo?.SoMui?.ToString() ?? string.Empty;

            // Lấy thông tin từ VaccineBUL để kiểm tra liều lượng
            VaccineBUL vaccineBUL = new VaccineBUL();
            VaccineDTO vaccineInfo = vaccineBUL.GetVaccineInfo(selectedVaccine.MaVaccine);

            // Cập nhật thông tin liều lượng từ VaccineDTO vào TextBox
            txtLieuLuongLocal.Text = vaccineInfo?.LieuLuong ?? string.Empty;

            // Kiểm tra thông tin chi tiết vaccine từ DB
            ThongTinChiTietVaccineBUL thongtinchitietvacxinBUL = new ThongTinChiTietVaccineBUL();
            ThongTinChiTietVaccineDTO ctVaccineInfo = thongtinchitietvacxinBUL.GetCTVaccineInfo(selectedVaccine.MaVaccine);
            if (ctVaccineInfo != null)
            {
                txtGiaBanLocal.Text = ctVaccineInfo.GiaBan.HasValue
                    ? ctVaccineInfo.GiaBan.Value.ToString("#,0")
                    : string.Empty;

                txtTinhTrangLocal.Text = ctVaccineInfo.SoLuongTon.HasValue
                    ? (ctVaccineInfo.SoLuongTon.Value > 0 ? "Còn hàng" : "Hết hàng")
                    : string.Empty;
            }
        }
        private void LoadCauHoi()
        {
            // Lấy danh sách câu hỏi từ cơ sở dữ liệu
            List<CauHoiSangLocDTO> danhSachCauHoi = cauHoiSangLocBUL.GetDanhSachCauHoi();

            // Tạo panel cha để chứa tất cả câu hỏi
            Panel panel = new Panel
            {
                Size = new System.Drawing.Size(950, 600),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true // Thêm cuộn nếu danh sách quá dài
            };

            // FlowLayoutPanel để chứa tất cả câu hỏi
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink // Cho phép tự động mở rộng khi cần
            };

            // Duyệt qua danh sách câu hỏi và thêm từng câu hỏi vào panel
            foreach (CauHoiSangLocDTO cauHoi in danhSachCauHoi)
            {
                // Tạo panel cho mỗi câu hỏi
                Panel cauHoiPanel = new Panel
                {
                    Size = new System.Drawing.Size(850, 90),
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(0, 0, 0, 10), // Tạo khoảng cách giữa các câu hỏi
                    AutoSize = true
                };

                // Thêm Label hiển thị nội dung câu hỏi
                Label lblNoiDung = new Label
                {
                    Text = cauHoi.NoiDung,
                    Dock = DockStyle.Top,
                    MaximumSize = new Size(700, 0),
                    AutoSize = true,
                    Font = new Font(SystemFonts.DefaultFont.FontFamily, 9, FontStyle.Bold)
                };

                cauHoiPanel.Controls.Add(lblNoiDung);

                // Panel cho các nút radio
                Panel panel_cautraloi = new Panel
                {
                    Size = new System.Drawing.Size(950, 40),
                    BorderStyle = BorderStyle.None,
                    AutoSize = true
                };
                FlowLayoutPanel radioPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Padding = new Padding(5)
                };
                // Tạo radio button "Có"
                RadioButton radioCo = new RadioButton
                {
                    Text = "Có",
                    Tag = cauHoi
                };

                // Tạo radio button "Không"
                RadioButton radioKhong = new RadioButton
                {
                    Text = "Không",
                    Checked = true,
                    Tag = cauHoi
                };

                // Thêm các radio buttons vào radioPanel
                radioPanel.Controls.Add(radioCo);
                radioPanel.Controls.Add(radioKhong);

                // Thêm radioPanel vào panel_cautraloi
                panel_cautraloi.Controls.Add(radioPanel);

                // Thêm panel_cautraloi vào panel của câu hỏi
                cauHoiPanel.Controls.Add(panel_cautraloi);

                // Thêm panel câu hỏi vào FlowLayoutPanel chính
                flowPanel.Controls.Add(cauHoiPanel);
            }

            // Thêm FlowLayoutPanel vào panel cha
            panel.Controls.Add(flowPanel);

            // Thêm panel vào control để hiển thị lên form (ví dụ: pnlCauHoi)
            pnlCauHoi.Controls.Add(panel);
        }

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
            dgv_chokham.AutoGenerateColumns = false;
            dgv_chokham.DataSource = danhSachTrangThai0;

            // Xóa tất cả các cột hiện có để tránh lỗi
            dgv_chokham.Columns.Clear();

            // Tạo các cột DataGridView
            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maKhachHang",
                Name = "maKhachHang",
                HeaderText = "Mã khách hàng"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "hoTen",
                Name = "hoTen",
                HeaderText = "Họ tên"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ngaySinh",
                Name = "ngaySinh",
                HeaderText = "Ngày sinh"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "gioiTinh",
                Name = "gioiTinh",
                HeaderText = "Giới tính"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "diaChi",
                Name = "diaChi",
                HeaderText = "Địa chỉ"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "hinhThucTiem",
                Name = "hinhThucTiem",
                HeaderText = "Hình Thức tiêm"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "maPhieuDangKy",
                Name = "maPhieuDangKy",
                HeaderText = "Mã phiếu"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ngayDangKy",
                Name = "ngayDangKy",
                HeaderText = "Ngày đăng ký"
            });

            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "trangThai",
                Name = "trangThai",
                HeaderText = "Trạng thái"
            });

            // Ẩn cột "trangThai" nếu không muốn hiển thị
            DataGridViewColumn trangThaiColumn = dgv_chokham.Columns["trangThai"];
            if (trangThaiColumn != null)
            {
                trangThaiColumn.Visible = false;
            }

            // Thêm cột hiển thị trạng thái "Text" để hiển thị thông tin trạng thái theo dạng text
            dgv_chokham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "trangThaiText",
                Name = "trangThaiText",
                HeaderText = "Trạng thái"
            });

            // Cập nhật giá trị cho cột "trangThaiText" để hiển thị "Đang chờ" khi trangThai = 0
            foreach (DataGridViewRow row in dgv_chokham.Rows)
            {
                if (row.Cells["trangThai"].Value != null && (int)row.Cells["trangThai"].Value == 0)
                {
                    row.Cells["trangThaiText"].Value = "Đang chờ";
                }
            }
        }

        void setCurrentTab(int index)
        {

        }
        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCurrentTab(bunifuPages1.SelectedIndex);
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
        }
        private void bunifuButton20_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            bunifuButton7.Enabled = true;
            try
            {
                foreach (Control control in panel_vacxin.Controls)
                {
                    // Chỉ xử lý khi điều khiển là ComboBox và thuộc loại "cbVaccine"
                    if (control is ComboBox cbVaccine && cbVaccine.Name == "cbVaccine")
                    {
                        // Lấy mã vắc xin
                        string maVaccine = cbVaccine.SelectedValue?.ToString();
                        if (string.IsNullOrEmpty(maVaccine))
                        {
                            MessageBox.Show("Vui lòng chọn vắc xin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        string maPhieuKham = lbphieukham.Text; // Mã phiếu khám
                        if (string.IsNullOrEmpty(maPhieuKham))
                        {
                            MessageBox.Show("Mã phiếu khám không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string ghiChu = txtGhiChu.Text; // Ghi chú
                        string ketLuan = txtKetLuan.Text; // Kết luận

                        // Lấy nhóm điều khiển của vắc xin từ Tag
                        List<Control> controlGroup = cbVaccine.Tag as List<Control>;
                        if (controlGroup == null) continue;

                        // Lấy các TextBox từ nhóm điều khiển
                        TextBox txtMui = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtMui");
                        TextBox txtGiaBan = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "txtGiaBan");

                        if (txtMui == null || txtGiaBan == null)
                        {
                            MessageBox.Show("Không tìm thấy các trường dữ liệu cần thiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        // Kiểm tra giá trị hợp lệ
                        if (!int.TryParse(txtMui.Text, out int mui))
                        {
                            MessageBox.Show("Số mũi phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan))
                        {
                            MessageBox.Show("Giá bán phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        // Tính toán thanh tiền
                        decimal thanhTien = mui * giaBan;

                        // Lưu dữ liệu vào cơ sở dữ liệu
                        phieuKham_VaccineBUL.AddVaccineToPhieuKham(maVaccine, maPhieuKham, ghiChu, ketLuan, mui, giaBan);

                        // Thông báo lưu thành công cho mỗi mục
                        MessageBox.Show($"Vắc xin {maVaccine} đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Thông báo sau khi lưu hết các mục
                MessageBox.Show("Tất cả dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
            LoadLichTiemChungTheoMa();
            LoadLichSuTiemChungTheoMa();
            txt_TenNV.Text = hoTen;
        }

        private void frm_DSKhamSangLoc_Load(object sender, EventArgs e)
        {

        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            loadDataDangChoKham(txt_TimKiem.Text);
        }

        private void dgv_chokham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có hàng được chọn (tránh lỗi khi nhấp vào tiêu đề cột hoặc khu vực trống)
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgv_chokham.Rows[e.RowIndex];

                // Gán dữ liệu từ hàng vào các Label
                lb_hoten.Text = selectedRow.Cells["hoTen"].Value?.ToString() ?? string.Empty;
                lb_ngaysinh.Text = selectedRow.Cells["ngaySinh"].Value?.ToString() ?? string.Empty;
                lb_gioitinh.Text = selectedRow.Cells["gioiTinh"].Value?.ToString() ?? string.Empty;
                lb_maPhieuDangKy.Text = selectedRow.Cells["maPhieuDangKy"].Value?.ToString() ?? string.Empty;
                lbhoten.Text = selectedRow.Cells["hoTen"].Value?.ToString() ?? string.Empty;
                lbngaysinh.Text = selectedRow.Cells["ngaySinh"].Value?.ToString() ?? string.Empty;
                lbgioitinh.Text = selectedRow.Cells["gioiTinh"].Value?.ToString() ?? string.Empty;
                lbmakhachhang.Text = selectedRow.Cells["maKhachHang"].Value?.ToString();
                lbht.Text = selectedRow.Cells["hoTen"].Value?.ToString() ?? string.Empty;
                lbns.Text = selectedRow.Cells["ngaySinh"].Value?.ToString() ?? string.Empty;
                lbgt.Text = selectedRow.Cells["gioiTinh"].Value?.ToString() ?? string.Empty;
                lbhten.Text = selectedRow.Cells["hoTen"].Value?.ToString() ?? string.Empty;
                lbnsinh.Text = selectedRow.Cells["ngaySinh"].Value?.ToString() ?? string.Empty;
                lbgtinh.Text = selectedRow.Cells["gioiTinh"].Value?.ToString() ?? string.Empty;
                bunifuPages1.SetPage(1);
            }
            //LoadLichTiemChung();
            LoadPhieuKhamSangLoc();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lb_hoten_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void lb_gioitinh_Click(object sender, EventArgs e)
        {

        }

        private void lb_ngaysinh_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private string GenerateMaDapAn()
        {

            return "DA" + Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        private string GenerateMaPhieuKham()
        {
            int maxMaPhieuKham = phieuKhamSangLocBUL.GetMaxMaPhieuKham();
            int newMaPhieuKham = maxMaPhieuKham + 1;
            return "PK" + newMaPhieuKham.ToString().PadLeft(3, '0');
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng và lưu thông tin phiếu khám
            string maPhieuDangKy = lb_maPhieuDangKy.Text;
            string maPhieuKham = GenerateMaPhieuKham();
            LuuPhieuKham(maPhieuDangKy, maPhieuKham);

            // Lưu thông tin đáp án từ các RadioButton trong panel câu hỏi
            LuuThongTinDapAn(maPhieuKham);
            LoadPhieuKhamSangLoc();
        }
        private void LuuPhieuKham(string maPhieuDangKy, string maPhieuKham)
        {
            // Lấy thông tin từ các TextBox
            string chieuCao = txt_chieuCao.Text;
            string canNang = txt_cannang.Text;
            string thanNhiet = txt_thannhiet.Text;
            int trangThai = rdo_ketluanco.Checked ? 1 : 0; // 1 nếu chọn "Có", 0 nếu chọn "Không"

            // Tạo đối tượng PhieuKhamDTO
            PhieuKhamSangLocDTO phieuKham = new PhieuKhamSangLocDTO
            {
                MaPhieuKham = maPhieuKham,
                ChieuCao = chieuCao,
                CanNang = canNang,
                ThanNhiet = thanNhiet,
                TrangThai = trangThai,
                MaNhanVien = "NV001",  // Mã nhân viên thực hiện (ví dụ NV001)
                MaPhieuDangKy = maPhieuDangKy
            };

            // Lưu phiếu khám vào cơ sở dữ liệu
            PhieuKhamSangLocBUL phieuKhamBUL = new PhieuKhamSangLocBUL();
            phieuKhamBUL.LuuPhieuKham(phieuKham);
        }



        private void LuuThongTinDapAn(string maPhieuKham)
        {
            // Lặp qua tất cả các câu hỏi và lưu đáp án
            foreach (Panel cauHoiControl in pnlCauHoi.Controls.OfType<Panel>())
            {
                LuuDapAnTuPanel(cauHoiControl, maPhieuKham);
            }
        }
        private void LuuDapAnTuPanel(Panel panel, string maPhieuKham)
        {
            string maPhieuDangKy = lb_maPhieuDangKy.Text;
            // Lặp qua tất cả các RadioButton trong Panel
            foreach (RadioButton radioButton in panel.Controls.OfType<RadioButton>())
            {
                // Kiểm tra nếu RadioButton đã được chọn
                if (radioButton.Checked)
                {
                    // Lấy câu hỏi từ tag của radioButton (Tag sẽ chứa thông tin về câu hỏi)
                    if (radioButton.Tag is CauHoiSangLocDTO cauHoi)
                    {
                        // Lưu lại đáp án: "Có" nếu radioButton là "Có", "Không" nếu radioButton là "Không"
                        string luaChon = radioButton.Text;

                        // Tạo đối tượng DapAnDTO và lưu đáp án
                        DapAnDTO dapAn = new DapAnDTO
                        {
                            MaDapAn = GenerateMaDapAn(),  // Hàm tạo mã đáp án (có thể là GUID hoặc ID tự tăng)
                            LuaChon = luaChon,  // Đáp án chọn được
                            MaPhieuKham = maPhieuKham,  // Mã phiếu khám
                            MaCauHoi = cauHoi.MaCauHoi  // Mã câu hỏi liên quan
                        };

                        // Lưu đáp án vào cơ sở dữ liệu
                        DapAnBUL dapAnBUL = new DapAnBUL();
                        dapAnBUL.LuuDapAn(dapAn);  // Gọi hàm lưu đáp án
                    }
                }
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void btn_goiVaccine_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(5);
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            loadDataDanhSachGoiVaccine(txtTimKiem.Text);
        }
        private void LoadThemVaccineComboBox(ComboBox cbVaccine)
        {
            if (thongtinchitietvacxinBUL == null)
            {
                thongtinchitietvacxinBUL = new ThongTinChiTietVaccineBUL(); // Khởi tạo đối tượng mới nếu chưa có
            }

            // Lấy danh sách vắc xin và số lượng tồn từ BUL
            List<ThongTinChiTietVaccineDTO> vaccineList = thongtinchitietvacxinBUL.GetVaccineList();

            // Thiết lập các thuộc tính của ComboBox
            cbVaccine.DisplayMember = "DisplayText";
            cbVaccine.ValueMember = "MaVaccine";
            cbVaccine.DataSource = vaccineList;
        }
        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            panel_goivaccine.AutoScroll = true;
            int nextYPositionToUse;
            List<Control> controlGroupToRestore = null;

            if (deletedYPositions.Count > 0)
            {
                nextYPositionToUse = deletedYPositions[deletedYPositions.Count - 1];
                controlGroupToRestore = deletedControlGroups[deletedControlGroups.Count - 1];
                deletedYPositions.RemoveAt(deletedYPositions.Count - 1);
                deletedControlGroups.RemoveAt(deletedControlGroups.Count - 1);
            }
            else
            {
                nextYPositionToUse = nextYPosition;
            }

            // Label "Vắc xin"
            Label lblVaccine = new Label
            {
                Text = "Vắc xin",
                Location = new Point(10, nextYPositionToUse),
                AutoSize = true
            };
            panel_goivaccine.Controls.Add(lblVaccine);

            // ComboBox "Vắc xin"
            ComboBox cbVaccine = new ComboBox
            {
                Location = new Point(10, nextYPositionToUse + 20),
                Size = new Size(120, 20)
            };
            cbVaccine.SelectedIndexChanged += cbVaccineThem_SelectedIndexChanged;
            panel_goivaccine.Controls.Add(cbVaccine);

            // Label "Mũi"
            Label lblMui = new Label
            {
                Text = "Mũi",
                Location = new Point(150, nextYPositionToUse),
                AutoSize = true
            };
            panel_goivaccine.Controls.Add(lblMui);

            // TextBox "Mũi"
            TextBox txtMui = new TextBox
            {
                Location = new Point(150, nextYPositionToUse + 20),
                Size = new Size(100, 20)
            };
            panel_goivaccine.Controls.Add(txtMui);

            // Label "Giá bán"
            Label lblGiaBan = new Label
            {
                Text = "Giá bán",
                Location = new Point(280, nextYPositionToUse),
                AutoSize = true
            };
            panel_goivaccine.Controls.Add(lblGiaBan);

            // TextBox "Giá bán"
            TextBox txtGiaBan = new TextBox
            {
                Location = new Point(280, nextYPositionToUse + 20),
                Size = new Size(100, 20)
            };
            panel_goivaccine.Controls.Add(txtGiaBan);

            // Label "Liều lượng"
            Label lblLieuLuong = new Label
            {
                Text = "Liều lượng",
                Location = new Point(410, nextYPositionToUse),
                AutoSize = true
            };
            panel_goivaccine.Controls.Add(lblLieuLuong);

            // TextBox "Liều lượng"
            TextBox txtLieuLuong = new TextBox
            {
                Location = new Point(410, nextYPositionToUse + 20),
                Size = new Size(120, 20)
            };
            panel_goivaccine.Controls.Add(txtLieuLuong);

            // Label "Tình trạng"
            Label lblTinhTrang = new Label
            {
                Text = "Tình trạng",
                Location = new Point(550, nextYPositionToUse),
                AutoSize = true
            };
            panel_goivaccine.Controls.Add(lblTinhTrang);

            // TextBox "Tình trạng"
            TextBox txtTinhTrang = new TextBox
            {
                Location = new Point(550, nextYPositionToUse + 20),
                Size = new Size(100, 20)
            };
            panel_goivaccine.Controls.Add(txtTinhTrang);

            // Lưu nhóm điều khiển vào danh sách
            List<Control> controlGroup = new List<Control> { lblVaccine, cbVaccine, lblMui, txtMui, lblGiaBan, txtGiaBan, lblLieuLuong, txtLieuLuong, lblTinhTrang, txtTinhTrang };
            cbVaccine.Tag = controlGroup; // Gán nhóm điều khiển vào Tag của ComboBox

            vaccineControls.AddRange(controlGroup);
            deletedControlGroups.Add(controlGroup);
            nextYPosition = nextYPositionToUse + 60;

            // Tải dữ liệu vào ComboBox
            LoadThemVaccineComboBox(cbVaccine);
        }

        private void cbVaccineThem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox?.Tag == null) return;

            // Lấy nhóm điều khiển từ Tag của ComboBox
            List<Control> controlGroup = comboBox.Tag as List<Control>;

            // Lấy các TextBox liên quan từ nhóm điều khiển
            TextBox txtMuiLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(150, comboBox.Location.Y));
            TextBox txtGiaBanLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(280, comboBox.Location.Y));
            TextBox txtLieuLuongLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(410, comboBox.Location.Y));
            TextBox txtTinhTrangLocal = controlGroup.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(550, comboBox.Location.Y));

            // Kiểm tra và lấy thông tin từ ComboBox
            ThongTinChiTietVaccineDTO selectedVaccine = comboBox.SelectedItem as ThongTinChiTietVaccineDTO;
            if (selectedVaccine == null) return;

            string maVaccine = selectedVaccine.MaVaccine;

            // Lấy thông tin từ các đối tượng nghiệp vụ
            VaccineDTO vaccineInfo = vaccineBUL.GetVaccineInfo(maVaccine);
            ThongTinChiTietVaccineDTO ctVaccineInfo = thongtinchitietvacxinBUL.GetCTVaccineInfo(maVaccine);
            KeHoachTiemChungDTO kehoachInfo = keHoachTiemChungBUL.GetKeHoachTiemChung(maVaccine);

            // Cập nhật thông tin vào các TextBox
            if (ctVaccineInfo != null)
            {
                txtGiaBanLocal.Text = ctVaccineInfo.GiaBan?.ToString("#,0") ?? "0";
                txtTinhTrangLocal.Text = ctVaccineInfo.SoLuongTon > 0 ? "Còn hàng" : "Hết hàng";
            }
            else
            {
                txtGiaBanLocal.Text = "Thông tin không có sẵn";
                txtTinhTrangLocal.Text = "Thông tin không có sẵn";
            }

            if (vaccineInfo != null)
            {
                txtLieuLuongLocal.Text = vaccineInfo.LieuLuong;
            }
            else
            {
                txtLieuLuongLocal.Text = "Thông tin không có sẵn";
            }

            if (kehoachInfo != null)
            {
                txtMuiLocal.Text = kehoachInfo.SoMui.ToString();
            }
            else
            {
                txtMuiLocal.Text = "Thông tin lịch tiêm không có sẵn";
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(6);
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            // Xóa các điều khiển đã tạo từ panel_goivaccine
            foreach (Control control in vaccineControls)
            {
                panel_goivaccine.Controls.Remove(control); // Xóa từng điều khiển khỏi panel_goivaccine
            }

            // Xóa tất cả các điều khiển khỏi danh sách
            vaccineControls.Clear();

            // Reset lại vị trí Y nếu cần
            nextYPosition = 70; // Bạn có thể thay đổi lại nếu cần

            // Cập nhật lại giao diện (refresh panel)
            panel_goivaccine.Refresh();
        }
        private decimal TinhTongTien(Panel panel)
        {
            decimal tongTien = 0;

            // Duyệt qua tất cả các control trong panel_goivaccine
            foreach (Control control in panel.Controls)
            {
                // Kiểm tra nếu control là ComboBox (vì ComboBox chứa mã vaccine)
                if (control is ComboBox cbVaccine)
                {
                    // Lấy nhóm điều khiển từ Tag của ComboBox
                    List<Control> controlGroup = cbVaccine.Tag as List<Control>;

                    // Lấy các TextBox liên quan từ nhóm điều khiển
                    TextBox txtMuiLocal = controlGroup?.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(150, cbVaccine.Location.Y));
                    TextBox txtGiaBanLocal = controlGroup?.OfType<TextBox>().FirstOrDefault(tb => tb.Location == new Point(280, cbVaccine.Location.Y));

                    // Kiểm tra thông tin giá bán và số lượng
                    if (txtGiaBanLocal != null && decimal.TryParse(txtGiaBanLocal.Text, out decimal giaVaccine)
                        && txtMuiLocal != null && int.TryParse(txtMuiLocal.Text, out int soLuong))
                    {
                        // Tính tổng tiền cho vaccine này
                        tongTien += giaVaccine * soLuong;
                    }
                }
            }
            return tongTien;
        }
        private void btnL_Click(object sender, EventArgs e)
        {
            // Tạo DTO cho GoiVaccine từ các TextBox và Controls
            DTO.GoiVaccineDTO goiVaccineDto = new DTO.GoiVaccineDTO
            {
                MaGoi = txtmagoi.Text,
                TenGoi = txttengoi.Text,
                ThoiHanSuDung = dpk_thoihan.Value,
                trangThai = 1,
                MaKhuyenMai = cbo_khuyenmai.SelectedValue?.ToString(),
                TongTienGoi = 0, // Đặt giá trị ban đầu là 0, trigger sẽ cập nhật sau
                Vaccines = LayVaccines()
            };

            // Sử dụng BUL để lưu GoiVaccine
            GoiVaccineBUL goiVaccineBUL = new GoiVaccineBUL();
            goiVaccineBUL.LuuGoiVaccine(goiVaccineDto);

            MessageBox.Show("Dữ liệu đã được lưu thành công!");
        }

        private List<DTO.VaccineGoiVaccineDTO> LayVaccines()
        {
            List<DTO.VaccineGoiVaccineDTO> vaccines = new List<DTO.VaccineGoiVaccineDTO>();

            // Duyệt qua tất cả các điều khiển trong panel_goivaccine
            foreach (Control control in panel_goivaccine.Controls)
            {
                // Kiểm tra nếu điều khiển là ComboBox (dùng cho việc chọn vaccine)
                if (control is ComboBox cbVaccine && cbVaccine.Tag != null)
                {
                    // Lấy nhóm điều khiển từ Tag của ComboBox
                    List<Control> controlGroup = cbVaccine.Tag as List<Control>;

                    // Lấy TextBox tương ứng với số lượng mũi vaccine
                    TextBox txtMuiLocal = controlGroup?.OfType<TextBox>()
                                                        .FirstOrDefault(tb => tb.Location == new Point(150, cbVaccine.Location.Y));

                    // Nếu tìm thấy TextBox và có thể chuyển đổi số lượng từ TextBox thành int
                    if (txtMuiLocal != null && int.TryParse(txtMuiLocal.Text, out int soLuong))
                    {
                        // Thêm VaccineGoiVaccineDTO vào danh sách
                        vaccines.Add(new DTO.VaccineGoiVaccineDTO
                        {
                            MaGoi = txtmagoi.Text,  // MaGoi lấy từ TextBox txtmagoi
                            MaVaccine = cbVaccine.SelectedValue?.ToString(),  // Mã vaccine lấy từ ComboBox
                            SoLuong = soLuong  // Số lượng từ TextBox txtMuiLocal
                        });
                    }
                }
            }

            return vaccines;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_danhsachgoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_dangKygoi_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(4);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {

                GoiVaccineDTO selectedGoiVaccine = cbogoi.SelectedItem as GoiVaccineDTO;

                // Kiểm tra xem đối tượng có null không
                if (selectedGoiVaccine != null)
                {
                    string maGoi = selectedGoiVaccine.MaGoi;
                    string maPhieuKham = lb_phieukham.Text;
                    string ghiChu = txt_ghichugoi.Text;
                    string moTa = txt_motagoi.Text;
                    int mui = int.Parse(txt_mui.Text);
                    decimal giaBan = decimal.Parse(txtGiaBanGoi.Text);
                    decimal thanhTien = decimal.Parse(txtThanhTien.Text);

                    // Tạo đối tượng DTO
                    PhieuKham_GoiVacXinDTO phieuDTO = new PhieuKham_GoiVacXinDTO
                    {
                        MaGoi = maGoi,
                        MaPhieuKham = maPhieuKham,
                        GhiChu = ghiChu,
                        MoTa = moTa,
                        Mui = mui,
                        GiaBan = giaBan,
                        ThanhTien = thanhTien
                    };

                    // Tạo đối tượng BUL và gọi phương thức thêm vaccine vào phiếu khám
                    PhieuKham_GoiVaccineBUL phieuBUL = new PhieuKham_GoiVaccineBUL();
                    bool result = phieuBUL.AddVaccineToPhieuKham(phieuDTO);

                    if (result)
                    {
                        MessageBox.Show("Thêm vaccine vào phiếu khám thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm vaccine vào phiếu khám.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn gói vaccine.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void SetupDataGridView()
        {
            dgv_vaccine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void cbogoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem mục được chọn trong ComboBox có phải là một GoiVaccineDTO
            if (cbogoi.SelectedItem is DTO.GoiVaccineDTO selectedGoi)
            {
                // Cập nhật DataGridView với danh sách vaccine của gói đã chọn
                dgv_vaccine.DataSource = selectedGoi.Vaccines;

                // Cập nhật thông tin chi tiết về gói vaccine
                txtthoigian.Text = selectedGoi.ThoiHanSuDung.HasValue
                    ? selectedGoi.ThoiHanSuDung.Value.ToString("dd/MM/yyyy")
                    : string.Empty;

                txtKhuyenMai.Text = !string.IsNullOrEmpty(selectedGoi.MaKhuyenMai)
                    ? selectedGoi.MaKhuyenMai
                    : string.Empty;

                // Hiển thị tổng tiền không dùng dấu $ và không có dấu phẩy
                txtThanhTien.Text = selectedGoi.TongTienGoi.HasValue
                    ? selectedGoi.TongTienGoi.Value.ToString("N2").Replace(",", "")
                    : string.Empty;
                txtGiaBanGoi.Text = selectedGoi.TongTienGoi.HasValue
                    ? selectedGoi.TongTienGoi.Value.ToString("N2").Replace(",", "")
                    : string.Empty;

                // Tính tổng số lượng từ DataGridView và hiển thị trong txt_mui
                int totalQuantity = 0;
                foreach (DataGridViewRow row in dgv_vaccine.Rows)
                {
                    if (row.Cells["SoLuong"]?.Value is int quantity)
                    {
                        totalQuantity += quantity;
                    }
                }
                txt_mui.Text = totalQuantity.ToString();
            }
            else
            {
                // Nếu không có gói vaccine hợp lệ được chọn, xóa thông tin hiển thị
                dgv_vaccine.DataSource = null;
                txtthoigian.Text = string.Empty;
                txtKhuyenMai.Text = string.Empty;
                txtThanhTien.Text = string.Empty;
                txtGiaBanGoi.Text = string.Empty;
                txt_mui.Text = string.Empty;
            }
        }

        private void dgv_vaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlCauHoi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }

        private void bunifuGroupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void dgv_vaccine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel31_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton17_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
            dgv_LichSu_CD.AutoGenerateColumns = false;
            dgv_LichSu_CD.DataSource = lichSuTiemChungBUL.GetLichSuTiemChungByKhachHang(lbmakhachhang.Text);
        }

        private void txtGiaBanGoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuGroupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void txt_ghichu_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void cbonhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmalichtiemchung_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void cbo_vacxin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dpk_ngayhen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

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

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            DateTime ngayHen = dpk_ngayhen.Value;
            string muitiemStr = txtmui1.Text.Trim();
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

        //private void bunifuButton7_Click(object sender, EventArgs e)
        //{
        //    bunifuButton7.Enabled = true;
        //    try
        //    {
        //        // Lấy danh sách chi tiết phiếu khám
        //        List<PhieuKhamDetailsDTO> phieuKhamDetails = phieuKhamSangLocBUL.GetPhieuKhamDetails(lbphieukham.Text);

        //        // Kiểm tra dữ liệu
        //        if (phieuKhamDetails == null || phieuKhamDetails.Count == 0)
        //        {
        //            MessageBox.Show("Không có dữ liệu để hiển thị.");
        //            return;
        //        }

        //        //// Tạo một DataTable mới và định nghĩa tất cả các cột cần thiết
        //        //DataTable phieuKhamDetailsTable = new DataTable();
        //        //phieuKhamDetailsTable.Columns.Add("STT", typeof(int));
        //        //phieuKhamDetailsTable.Columns.Add("Mã Vaccine", typeof(string));
        //        //phieuKhamDetailsTable.Columns.Add("Tên Vaccine", typeof(string));
        //        //phieuKhamDetailsTable.Columns.Add("Số lượng", typeof(int));
        //        //phieuKhamDetailsTable.Columns.Add("Giá Bán", typeof(decimal));
        //        //phieuKhamDetailsTable.Columns.Add("Thành Tiền", typeof(decimal));

        //        //// Cập nhật dữ liệu vào DataTable
        //        //for (int i = 0; i < phieuKhamDetails.Count; i++)
        //        //{
        //        //    DataRow row = phieuKhamDetailsTable.NewRow();
        //        //    row["STT"] = i + 1;
        //        //    row["Mã Vaccine"] = phieuKhamDetails[i].MaVaccine;
        //        //    row["Tên Vaccine"] = phieuKhamDetails[i].TenVaccine;
        //        //    row["Số lượng"] = phieuKhamDetails[i].Mui;
        //        //    row["Giá Bán"] = phieuKhamDetails[i].GiaBan;
        //        //    row["Thành Tiền"] = phieuKhamDetails[i].ThanhTien;
        //        //    phieuKhamDetailsTable.Rows.Add(row);
        //        //}

        //        DataTable phieuKhamDetailsTable = new DataTable();
        //        phieuKhamDetailsTable.Columns.Add("STT", typeof(int));
        //        phieuKhamDetailsTable.Columns.Add("Mã Vaccine", typeof(string));
        //        phieuKhamDetailsTable.Columns.Add("Tên Vaccine", typeof(string));
        //        phieuKhamDetailsTable.Columns.Add("Số lượng", typeof(int));
        //        phieuKhamDetailsTable.Columns.Add("Giá Bán", typeof(string)); // Change to string to hold formatted value
        //        phieuKhamDetailsTable.Columns.Add("Thành Tiền", typeof(string)); // Change to string to hold formatted value

        //        // Cập nhật dữ liệu vào DataTable
        //        for (int i = 0; i < phieuKhamDetails.Count; i++)
        //        {
        //            DataRow row = phieuKhamDetailsTable.NewRow();
        //            row["STT"] = i + 1;
        //            row["Mã Vaccine"] = phieuKhamDetails[i].MaVaccine ?? string.Empty;
        //            row["Tên Vaccine"] = phieuKhamDetails[i].TenVaccine ?? string.Empty;
        //            row["Số lượng"] = phieuKhamDetails[i].Mui ?? 0;
        //            row["Giá Bán"] = phieuKhamDetails[i].GiaBan.HasValue ? phieuKhamDetails[i].GiaBan.Value.ToString("N0") + " VND" : "0 VND"; // Format as currency
        //            row["Thành Tiền"] = phieuKhamDetails[i].ThanhTien.HasValue ? phieuKhamDetails[i].ThanhTien.Value.ToString("N0") + " VND" : "0 VND"; // Format as currency
        //            phieuKhamDetailsTable.Rows.Add(row);
        //        }

        //        // Tính tổng thành tiền
        //        decimal tongThanhTien = 0;
        //        foreach (DataRow row in phieuKhamDetailsTable.Rows)
        //        {
        //            tongThanhTien += Convert.ToDecimal(row["Thành Tiền"]);
        //        }

        //        // Chuẩn bị từ điển cho Word
        //        Dictionary<string, string> dic = new Dictionary<string, string>
        //        {
        //            { "maphieukham", lbphieukham.Text },
        //            { "tenkhachhang", lbhoten.Text },
        //            { "soluongvaccine", phieuKhamDetailsTable.Rows.Count.ToString() },
        //            { "tongtien", tongThanhTien.ToString("N0") }
        //        };

        //        // Tạo file Word từ template
        //        WordExport wd = new WordExport();
        //        string filePath = Application.StartupPath + "/Template/MauPhieuKhamSangLoc.dotx";
        //        wd.WordUltil(filePath, true);
        //        wd.WriteFields(dic);
        //        wd.WriteTable(phieuKhamDetailsTable, 1);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuButton7.Enabled = true;
            try
            {
                // Lấy danh sách chi tiết phiếu khám
                List<PhieuKhamDetailsDTO> phieuKhamDetails = phieuKhamSangLocBUL.GetPhieuKhamDetails(lbphieukham.Text);

                // Kiểm tra dữ liệu
                if (phieuKhamDetails == null || phieuKhamDetails.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                    return;
                }

                DataTable phieuKhamDetailsTable = new DataTable();
                phieuKhamDetailsTable.Columns.Add("STT", typeof(int));
                phieuKhamDetailsTable.Columns.Add("Mã Vaccine", typeof(string));
                phieuKhamDetailsTable.Columns.Add("Tên Vaccine", typeof(string));
                phieuKhamDetailsTable.Columns.Add("Số lượng", typeof(int));
                phieuKhamDetailsTable.Columns.Add("Giá Bán", typeof(decimal)); // Store as decimal
                phieuKhamDetailsTable.Columns.Add("Thành Tiền", typeof(decimal)); // Store as decimal

                // Cập nhật dữ liệu vào DataTable
                for (int i = 0; i < phieuKhamDetails.Count; i++)
                {
                    DataRow row = phieuKhamDetailsTable.NewRow();
                    row["STT"] = i + 1;
                    row["Mã Vaccine"] = phieuKhamDetails[i].MaVaccine ?? string.Empty;
                    row["Tên Vaccine"] = phieuKhamDetails[i].TenVaccine ?? string.Empty;
                    row["Số lượng"] = phieuKhamDetails[i].Mui ?? 0;
                    row["Giá Bán"] = phieuKhamDetails[i].GiaBan ?? 0;
                    row["Thành Tiền"] = phieuKhamDetails[i].ThanhTien ?? 0;
                    phieuKhamDetailsTable.Rows.Add(row);
                }

                // Tính tổng thành tiền
                decimal tongThanhTien = 0;
                foreach (DataRow row in phieuKhamDetailsTable.Rows)
                {
                    tongThanhTien += Convert.ToDecimal(row["Thành Tiền"]);
                }

                // Chuẩn bị từ điển cho Word
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    { "maphieukham", lbphieukham.Text },
                    { "tenkhachhang", lbhoten.Text },
                    { "soluongvaccine", phieuKhamDetailsTable.Rows.Count.ToString() },
                    { "tongtien", tongThanhTien.ToString("N0")}
                };

                // Tạo file Word từ template
                WordExport wd = new WordExport();
                string filePath = Application.StartupPath + "/Template/MauPhieuKhamSangLoc.dotx";
                wd.WordUltil(filePath, true);
                wd.WriteFields(dic);

                // Format the DataTable for Word export
                DataTable formattedTable = phieuKhamDetailsTable.Clone();
                formattedTable.Columns["Giá Bán"].DataType = typeof(string);
                formattedTable.Columns["Thành Tiền"].DataType = typeof(string);

                foreach (DataRow row in phieuKhamDetailsTable.Rows)
                {
                    DataRow newRow = formattedTable.NewRow();
                    newRow["STT"] = row["STT"];
                    newRow["Mã Vaccine"] = row["Mã Vaccine"];
                    newRow["Tên Vaccine"] = row["Tên Vaccine"];
                    newRow["Số lượng"] = row["Số lượng"];
                    newRow["Giá Bán"] = Convert.ToDecimal(row["Giá Bán"]).ToString("N0");
                    newRow["Thành Tiền"] = Convert.ToDecimal(row["Thành Tiền"]).ToString("N0");
                    formattedTable.Rows.Add(newRow);
                }

                wd.WriteTable(formattedTable, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel41_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void dgv_phieukhamsangloc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgv_phieukhamsangloc.Rows[e.RowIndex];
                lbphieukham.Text = selectedRow.Cells["MaPhieuKham"].Value?.ToString() ?? string.Empty;
                lb_phieukham.Text = selectedRow.Cells["MaPhieuKham"].Value?.ToString() ?? string.Empty;
                bunifuPages1.SetPage(1);
            }
        }
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            // Kiểm tra số lần nhấn nút
            if (clickCount >= maxClicks)
            {
                MessageBox.Show($"Bạn chỉ có thể thêm tối đa {maxClicks} dòng vaccine!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panel_vacxin.AutoScroll = true;

            // Tạo danh sách nhóm điều khiển
            List<Control> controlGroup = new List<Control>();

            // Label "Phòng bệnh"
            Label lblPhongBenh = new Label
            {
                Text = "Phòng bệnh",
                Location = new Point(10, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblPhongBenh);
            vaccineControls.Add(lblPhongBenh); // Thêm vào vaccineControls

            // Tạo ComboBox Phòng bệnh
            ComboBox cbPhongBenhThem = new ComboBox
            {
                Location = new Point(10, nextYPosition + 26),
                Size = new Size(180, 20)
            };
            cbPhongBenhThem.SelectedIndexChanged += cbPhongBenh_SelectedIndexChanged;
            panel_vacxin.Controls.Add(cbPhongBenhThem);
            vaccineControls.Add(cbPhongBenhThem);
            controlGroup.Add(cbPhongBenhThem);

            // Label "Vắc xin"
            Label lblVaccine = new Label
            {
                Text = "Vắc xin",
                Location = new Point(200, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblVaccine);
            vaccineControls.Add(lblVaccine); // Thêm vào vaccineControls

            // ComboBox "Vắc xin"
            ComboBox cbVaccine = new ComboBox
            {
                Location = new Point(200, nextYPosition + 26),
                Size = new Size(180, 20),
                Name = "cbVaccine"
            };

            cbVaccine.SelectedIndexChanged += cbVaccine_SelectedIndexChanged;
            panel_vacxin.Controls.Add(cbVaccine);
            vaccineControls.Add(cbVaccine);
            // Thêm ComboBox vào controlGroup
            controlGroup.Add(cbVaccine);

            // Các điều khiển khác (Mũi, Giá bán, Liều lượng, Tình trạng)
            Label lblMui = new Label
            {
                Text = "Số Mũi",
                Location = new Point(390, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblMui);
            vaccineControls.Add(lblMui); // Thêm vào vaccineControls

            TextBox txtMui = new TextBox
            {
                Name = "txtMui",
                Location = new Point(390, nextYPosition + 26),
                Size = new Size(100, 20)
            };
            panel_vacxin.Controls.Add(txtMui);
            vaccineControls.Add(txtMui); // Thêm vào vaccineControls

            // Thêm TextBox vào controlGroup
            controlGroup.Add(txtMui);

            // Các điều khiển khác (Giá bán, Liều lượng, Tình trạng)
            Label lblGiaBan = new Label
            {
                Text = "Giá bán",
                Location = new Point(510, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblGiaBan);
            vaccineControls.Add(lblGiaBan); // Thêm vào vaccineControls

            TextBox txtGiaBan = new TextBox
            {
                Name = "txtGiaBan",
                Location = new Point(510, nextYPosition + 26),
                Size = new Size(100, 20)
            };
            panel_vacxin.Controls.Add(txtGiaBan);
            vaccineControls.Add(txtGiaBan); // Thêm vào vaccineControls

            // Thêm TextBox vào controlGroup
            controlGroup.Add(txtGiaBan);

            Label lblLieuLuong = new Label
            {
                Text = "Liều lượng",
                Location = new Point(630, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblLieuLuong);
            vaccineControls.Add(lblLieuLuong); // Thêm vào vaccineControls

            TextBox txtLieuLuong = new TextBox
            {
                Name = "txtLieuLuong",
                Location = new Point(630, nextYPosition + 26),
                Size = new Size(120, 20)
            };
            panel_vacxin.Controls.Add(txtLieuLuong);
            vaccineControls.Add(txtLieuLuong); // Thêm vào vaccineControls

            // Thêm TextBox vào controlGroup
            controlGroup.Add(txtLieuLuong);

            Label lblTinhTrang = new Label
            {
                Text = "Tình trạng",
                Location = new Point(770, nextYPosition),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel_vacxin.Controls.Add(lblTinhTrang);
            vaccineControls.Add(lblTinhTrang); // Thêm vào vaccineControls

            TextBox txtTinhTrang = new TextBox
            {
                Name = "txtTinhTrang",
                Location = new Point(770, nextYPosition + 26),
                Size = new Size(100, 20)
            };
            panel_vacxin.Controls.Add(txtTinhTrang);
            vaccineControls.Add(txtTinhTrang); // Thêm vào vaccineControls

            // Thêm TextBox vào controlGroup
            controlGroup.Add(txtTinhTrang);

            // Gán Tag cho ComboBox phòng bệnh để chứa nhóm điều khiển
            cbPhongBenhThem.Tag = cbVaccine;
            cbVaccine.Tag = controlGroup;

            // Load dữ liệu cho ComboBox Phòng bệnh
            LoadPhongBenhComboBox(cbPhongBenhThem);

            // Cập nhật vị trí Y sau khi thêm nhóm điều khiển
            nextYPosition += 60;

            // Lưu nhóm điều khiển vào danh sách đã tạo
            createdControlGroups.Add(controlGroup);
            clickCount++;
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa vaccine?",
                 "Xác nhận xóa",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
             );
            // Xóa các điều khiển đã tạo từ panel_goivaccine
            foreach (Control control in vaccineControls)
            {
                panel_vacxin.Controls.Remove(control); // Xóa từng điều khiển khỏi panel_goivaccine
            }

            // Xóa tất cả các điều khiển khỏi danh sách
            vaccineControls.Clear();

            // Reset lại vị trí Y nếu cần
            nextYPosition = 70; // Bạn có thể thay đổi lại nếu cần

            // Cập nhật lại giao diện (refresh panel)
            panel_vacxin.Refresh();
            clickCount = 0;
        }
    }
}
