using BUL;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_NhapVaccine : Form
    {
        NhaCungCapBUL nccBUL;
        PhieuNhapBUL phieuNhapBUL;
        CTPhieuNhapBUL cTPhieuNhapBUL;
        LoVaccineBUL loVaccineBUL = new LoVaccineBUL();
        string tenNhanVien;
        string maNhanVien;

        public frm_NhapVaccine(string tenNhanVien, string maNhanVien)
        {
            InitializeComponent();
            nccBUL = new NhaCungCapBUL();
            phieuNhapBUL = new PhieuNhapBUL();
            loVaccineBUL = new LoVaccineBUL();
            cTPhieuNhapBUL = new CTPhieuNhapBUL();
            //loadData();
            loadComboboNCC();

            this.tenNhanVien = tenNhanVien;
            this.maNhanVien = maNhanVien;
            txt_TenNhanVien.Text = tenNhanVien;
            SetupAutoComplete();

            // Define columns for DataGridView
            dgv_DSPhieuNhap.Columns.Add("MaPhieu", "Mã phiếu");
            dgv_DSPhieuNhap.Columns.Add("SoLo", "Số lô");
            dgv_DSPhieuNhap.Columns.Add("MaNhaCungCap", "Mã nhà cung cấp");
            dgv_DSPhieuNhap.Columns.Add("SoLuong", "Số lượng");
            dgv_DSPhieuNhap.Columns.Add("DonGiaNhap", "Đơn giá nhập");
            dgv_DSPhieuNhap.Columns.Add("ThanhTien", "Thành tiền");


            // Nội dung trong các cột căn sang phải
            dgv_DSPhieuNhap.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_DSPhieuNhap.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_DSPhieuNhap.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            //// Header của tất cả các cột căn ra giữa
            foreach (DataGridViewColumn column in dgv_DSPhieuNhap.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Set border style between columns
            dgv_DSPhieuNhap.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            enbaleButton(true);
        }

        public void enbaleButton(bool t)
        {
            btn_TaoMoi.Enabled = t;
            btn_Them.Enabled = !t;
            btn_Sua.Enabled = !t;
            btn_Xoa.Enabled = !t;
            btn_Luu.Enabled = !t;
        }

        private void SetupAutoComplete()
        {
            List<string> maLoList = loVaccineBUL.layTatCaMaLo();
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (string maLo in maLoList)
            {
                autoCompleteCollection.Add(maLo.Trim());
            }

            txt_SoLo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_SoLo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_SoLo.AutoCompleteCustomSource = autoCompleteCollection;
        }


        public void loadData()
        {
            dgv_DSPhieuNhap.DataSource = phieuNhapBUL.layTatCaPhieuNhap();
        }

        //public void timKiemThongTinVaccineTheoMaLo(string maLo)
        //{
        //    System.Data.DataTable loVaccine = loVaccineBUL.layLoVaccineTheoMa(maLo);
        //    if (loVaccine.Rows.Count > 0)
        //    {
        //        // Danh sách tên vaccine
        //        cboTenVaccine.DataSource = loVaccine;
        //        cboTenVaccine.DisplayMember = "tenVaccine";
        //        cboTenVaccine.ValueMember = "maVaccine";
        //        //cboTenVaccine.SelectedIndex = -1;
        //        txt_SoLuong.Text = loVaccine.Rows[0]["soLuongVaccine"].ToString();

        //        decimal giaNhap = decimal.Parse(loVaccine.Rows[0]["giaNhap"].ToString());
        //        CultureInfo culture = new CultureInfo("vi-VN");
        //        txt_DonGiaNhap.Text = giaNhap.ToString("C0", culture);

        //        decimal soLuong = decimal.Parse(txt_SoLuong.Text);
        //        decimal thanhTien = soLuong * giaNhap;
        //        txt_ThanhTien.Text = thanhTien.ToString("C0", culture);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy lô vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private bool isUpdatingComboBox = false;

        public void timKiemThongTinVaccineTheoMaLo(string maLo)
        {
            // Lấy thông tin vaccine từ cơ sở dữ liệu
            DataTable loVaccine = loVaccineBUL.layLoVaccineTheoMa(maLo);

            // Kiểm tra nếu có vaccine trong lô
            if (loVaccine.Rows.Count > 0)
            {
                // Set the flag to indicate that the ComboBox is being updated
                isUpdatingComboBox = true;

                // Cập nhật ComboBox với tất cả vaccine của lô
                cboTenVaccine.DataSource = loVaccine;
                cboTenVaccine.DisplayMember = "tenVaccine"; // Tên vaccine hiển thị
                cboTenVaccine.ValueMember = "maVaccine";   // Mã vaccine

                // Đặt lại chỉ số để không tự động chọn mục nào
                cboTenVaccine.SelectedIndex = -1;

                // Reset the flag after the ComboBox update is complete
                isUpdatingComboBox = false;

                //// Hiển thị thông tin vaccine đầu tiên của lô vào các TextBox
                //txt_SoLuong.Text = loVaccine.Rows[0]["soLuongVaccine"].ToString();

                //decimal giaNhap = decimal.Parse(loVaccine.Rows[0]["giaNhap"].ToString());
                //CultureInfo culture = new CultureInfo("vi-VN");
                //txt_DonGiaNhap.Text = giaNhap.ToString("C0", culture);

                //decimal soLuong = decimal.Parse(txt_SoLuong.Text);
                //decimal thanhTien = soLuong * giaNhap;
                //txt_ThanhTien.Text = thanhTien.ToString("C0", culture);
            }
            else
            {
                MessageBox.Show("Không tìm thấy lô vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void loadComboboNCC()
        {
            cbo_NCC.DataSource = nccBUL.getNhaCungCap();
            cbo_NCC.DisplayMember = "TenNhaCungCap";
            cbo_NCC.ValueMember = "MaNhaCungCap";
            cbo_NCC.SelectedIndex = -1;
        }

        private void btn_TaoMoi_Click(object sender, System.EventArgs e)
        {
            txt_MaPhieu.Text = phieuNhapBUL.taoMaPhieuNhap();
            enbaleButton(false);
        }

        private void txt_SoLo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiemThongTinVaccineTheoMaLo(txt_SoLo.Text);
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgv_DSPhieuNhap.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), NumberStyles.Currency, new CultureInfo("vi-VN"), out decimal thanhTien))
                {
                    tongTien += thanhTien;
                }
            }

            lb_TongTien.Text = tongTien.ToString("C0", new CultureInfo("vi-VN"));
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            enbaleButton(false);
            // Check if all required fields are filled
            if (string.IsNullOrEmpty(txt_MaPhieu.Text) || string.IsNullOrEmpty(txt_SoLo.Text) ||
                string.IsNullOrEmpty(txt_SoLuong.Text) || string.IsNullOrEmpty(txt_DonGiaNhap.Text) ||
                string.IsNullOrEmpty(txt_ThanhTien.Text) || cbo_NCC.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if the batch code already exists in the DataGridView
            foreach (DataGridViewRow row in dgv_DSPhieuNhap.Rows)
            {
                if (row.Cells["SoLo"].Value != null && row.Cells["SoLo"].Value.ToString() == txt_SoLo.Text)
                {
                    MessageBox.Show("Lô vaccine đã tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Add the new row to the DataGridView
            dgv_DSPhieuNhap.Rows.Add(txt_MaPhieu.Text, txt_SoLo.Text, cbo_NCC.SelectedValue.ToString(), txt_SoLuong.Text, txt_DonGiaNhap.Text, txt_ThanhTien.Text);

            UpdateTongTien();
        }

        private void btn_Luu_Click(object sender, System.EventArgs e)
        {
            // Check if there are any rows in the DataGridView
            if (dgv_DSPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách phiếu nhập rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create a new PhieuNhapDTO object
            PhieuNhapDTO phieuNhapDTO = new PhieuNhapDTO
            {
                MaPhieuNhap = txt_MaPhieu.Text,
                MaNhanVien = maNhanVien,
                MaNhaCungCap = cbo_NCC.SelectedValue.ToString(),
                NgayLap = dtp_NgayLap.Value
            };

            // Save the PhieuNhap
            if (phieuNhapBUL.themPhieuNhap(phieuNhapDTO))
            {
                // Save the details of each row in the DataGridView
                foreach (DataGridViewRow row in dgv_DSPhieuNhap.Rows)
                {
                    if (row.IsNewRow) continue;

                    CTPhieuNhapDTO ctPhieuNhapDTO = new CTPhieuNhapDTO
                    {
                        MaPhieuNhap = phieuNhapDTO.MaPhieuNhap,
                        MaLo = row.Cells["SoLo"].Value.ToString(),
                        SoLuongNhap = int.Parse(row.Cells["SoLuong"].Value.ToString())
                    };

                    if (!cTPhieuNhapBUL.themCTPhieuNhap(ctPhieuNhapDTO))
                    {
                        MessageBox.Show("Lỗi khi lưu chi tiết phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Lưu phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                enbaleButton(true);

            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgv_DSPhieuNhap.Rows.Clear();

        }

        private void dgv_DSPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DSPhieuNhap.Rows[e.RowIndex];
                txt_MaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
                txt_SoLo.Text = row.Cells["SoLo"].Value.ToString();
                txt_SoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txt_DonGiaNhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
                txt_ThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
                cbo_NCC.SelectedValue = row.Cells["MaNhaCungCap"].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (dgv_DSPhieuNhap.SelectedRows.Count > 0)
            {
                dgv_DSPhieuNhap.Rows.Remove(dgv_DSPhieuNhap.SelectedRows[0]);
                UpdateTongTien();
            }
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (dgv_DSPhieuNhap.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv_DSPhieuNhap.SelectedRows[0];
                row.Cells["SoLo"].Value = txt_SoLo.Text;
                row.Cells["TenVaccine"].Value = cboTenVaccine.Text;
                row.Cells["SoLuong"].Value = txt_SoLuong.Text;
                row.Cells["DonGiaNhap"].Value = txt_DonGiaNhap.Text;
                row.Cells["ThanhTien"].Value = txt_ThanhTien.Text;
                row.Cells["MaNhaCungCap"].Value = cbo_NCC.SelectedValue.ToString();

                UpdateTongTien();
            }
        }

        private void btn_ThemLo_Click(object sender, System.EventArgs e)
        {
            frm_QLLoVaccine frm = new frm_QLLoVaccine();
            frm.FormClosed += new FormClosedEventHandler(frm_QLLoaiVaccine_FormClosed);
            frm.Show();
            //Load lại danh sách mã lô vaccine
            SetupAutoComplete();

        }

        private void frm_QLLoaiVaccine_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_QLLoVaccine frm = sender as frm_QLLoVaccine;
            if (frm != null && !string.IsNullOrEmpty(frm.soLo))
            {
                txt_SoLo.Text = frm.soLo;
                timKiemThongTinVaccineTheoMaLo(frm.soLo);
            }
        }

        private void cboTenVaccine_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Check if the ComboBox is being updated programmatically
            if (isUpdatingComboBox)
            {
                return;
            }

            if (cboTenVaccine.SelectedIndex != -1 && !string.IsNullOrEmpty(txt_SoLo.Text))
            {
                string maVaccine = cboTenVaccine.SelectedValue.ToString();
                string maLo = txt_SoLo.Text;
                DataTable dt = loVaccineBUL.layLoVaccineTheoMaVaccine(maVaccine, maLo);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txt_DonGiaNhap.Text = decimal.Parse(row["giaNhap"].ToString()).ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN"));
                    txt_SoLuong.Text = row["soLuongVaccine"].ToString();

                    // Calculate Thanh Tien
                    decimal giaNhap = decimal.Parse(row["giaNhap"].ToString());
                    int soLuongNhap = int.Parse(row["soLuongVaccine"].ToString());
                    decimal thanhTien = giaNhap * soLuongNhap;
                    txt_ThanhTien.Text = thanhTien.ToString("C0", new CultureInfo("vi-VN"));
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin vaccine", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_XemDS_Click(object sender, System.EventArgs e)
        {
            frm_XemDSPhieuNhap frm = new frm_XemDSPhieuNhap();
            frm.Show();
        }
    }
}