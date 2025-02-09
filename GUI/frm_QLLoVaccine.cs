//using BUL;
//using DTO;
//using System;
//using System.Globalization;
//using System.Windows.Forms;

//namespace GUI
//{
//    public partial class frm_QLLoVaccine : Form
//    {
//        LoVaccineBUL loVaccineBUL;
//        VaccineBUL vaccineBUL;
//        ThongTinChiTietVaccineBUL thongTinChiTietVacXinBUL;
//        int flag = 0;
//        string maLoVaccine;
//        public string soLo { get; private set; }
//        public frm_QLLoVaccine()
//        {
//            InitializeComponent();
//            loVaccineBUL = new LoVaccineBUL();
//            vaccineBUL = new VaccineBUL();
//            thongTinChiTietVacXinBUL = new ThongTinChiTietVaccineBUL();
//            //loadData();
//            //enbaleButton(true);
//            clearData();
//            loadComboboxVaccine();
//        }

//        //public void loadData()
//        //{
//        //    dgv_DSLoVaccine.AutoGenerateColumns = false;
//        //    dgv_DSLoVaccine.DataSource = loVaccineBUL.layTatCaLoVaccine();
//        //}

//        public void loadComboboxVaccine()
//        {
//            cbo_TenVaccine.DataSource = vaccineBUL.LayTatCaVaccine();
//            cbo_TenVaccine.DisplayMember = "TenVaccine";
//            cbo_TenVaccine.ValueMember = "MaVaccine";
//            cbo_TenVaccine.SelectedIndex = -1;

//            string[] donViTinh = { "Lọ", "Chai", "Hộp" };
//            //add item to combobox
//            foreach (string item in donViTinh)
//            {
//                cbo_DVT.Items.Add(item);
//            }
//            cbo_DVT.SelectedIndex = -1;
//            cbo_DVT.DisplayMember = "DonViTinh";
//            cbo_DVT.ValueMember = "DonViTinh";
//        }

//        public void clearData()
//        {
//            //txt_SoLo.Text = ""; ;
//            txt_GiaNhap.Text = "";
//            txt_SoLuongVaccine.Text = "";
//            txt_GiaBan.Text = "";
//            cbo_TenVaccine.SelectedIndex = -1;
//            cbo_DVT.SelectedIndex = -1;
//        }

//        public void enbaleButton(bool t)
//        {
//            btn_Them.Enabled = t;
//            btn_Sua.Enabled = t;
//            btn_Xoa.Enabled = t;
//            btn_Luu.Enabled = !t;
//            btn_Xoa.Enabled = t;
//        }

//        private void dgv_DSLoVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            int index = e.RowIndex;
//            if (index >= 0)
//            {
//                maLoVaccine = dgv_DSLoVaccine.Rows[index].Cells["maLo"].Value.ToString();
//                txt_SoLo.Text = dgv_DSLoVaccine.Rows[index].Cells["maLo"].Value.ToString();
//                dtp_NgaySX.Text = dgv_DSLoVaccine.Rows[index].Cells["ngaySanXuat"].Value.ToString();
//                dtp_HanSuDung.Text = dgv_DSLoVaccine.Rows[index].Cells["hanSuDung"].Value.ToString();
//                txt_GiaNhap.Text = dgv_DSLoVaccine.Rows[index].Cells["giaNhap"].Value.ToString();
//                txt_SoLuongVaccine.Text = dgv_DSLoVaccine.Rows[index].Cells["soLuongVaccine"].Value.ToString();
//                cbo_DVT.Text = dgv_DSLoVaccine.Rows[index].Cells["donViTinh"].Value.ToString();
//                txt_GiaBan.Text = dgv_DSLoVaccine.Rows[index].Cells["giaBan"].Value.ToString();
//                cbo_TenVaccine.Text = dgv_DSLoVaccine.Rows[index].Cells["maVaccine"].Value.ToString();

//                soLo = maLoVaccine;

//            }
//        }

//        private void btn_Them_Click(object sender, System.EventArgs e)
//        {
//            //flag = 1;
//            //enbaleButton(false);
//            //dgv_DSLoVaccine.Enabled = false;
//            if (kiemTraDuLieu() == false)
//            {
//                return;
//            }

//            if (kiemTraNgayThang() == false)
//            {
//                return;
//            }

//            // Kiểm tra xem vaccine đã tồn tại trong danh sách hay chưa
//            foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
//            {
//                if (row.Cells["maVaccine"].Value != null && row.Cells["maVaccine"].Value.ToString() == cbo_TenVaccine.SelectedValue.ToString())
//                {
//                    MessageBox.Show("Vaccine đã tồn tại trong danh sách");
//                    return;
//                }
//            }

//            // Thêm hàng mới vào DataGridView
//            dgv_DSLoVaccine.Rows.Add(txt_SoLo.Text, cbo_TenVaccine.SelectedValue.ToString(), dtp_NgaySX.Value, dtp_HanSuDung.Value, txt_GiaNhap.Text, txt_GiaBan.Text, txt_SoLuongVaccine.Text, cbo_DVT.Text);
//            clearData();


//        }

//        public bool kiemTraDuLieu()
//        {
//            if (txt_SoLo.Text == "" || txt_GiaNhap.Text == "" || txt_SoLuongVaccine.Text == "" || cbo_TenVaccine.SelectedIndex == -1 || cbo_DVT.SelectedIndex == -1 || txt_GiaBan.Text == "")
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
//                return false;
//            }
//            return true;
//        }

//        public bool kiemTraNgayThang()
//        {
//            // Kiểm tra ngày sản xuất không được chọn về quá khứ
//            if (dtp_NgaySX.Value.Date < System.DateTime.Now.Date)
//            {
//                MessageBox.Show("Ngày sản xuất không được nhỏ hơn ngày hiện tại");
//                return false;
//            }

//            // Kiểm tra ngày sản xuất phải nhỏ hơn hạn sử dụng
//            if (dtp_NgaySX.Value > dtp_HanSuDung.Value)
//            {
//                MessageBox.Show("Ngày sản xuất phải nhỏ hơn hạn sử dụng");
//                return false;
//            }

//            // Kiểm tra hạn sử dụng phải lớn hơn ngày hiện tại
//            if (dtp_HanSuDung.Value < System.DateTime.Now.Date)
//            {
//                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại");
//                return false;
//            }

//            return true;
//        }


//        private void btn_Luu_Click(object sender, EventArgs e)
//        {
//            if (dgv_DSLoVaccine.Rows.Count == 0)
//            {
//                MessageBox.Show("Vui lòng thêm vaccine vào danh sách");
//                return;
//            }

//            LoVaccineDTO loVaccineDTO = new LoVaccineDTO()
//            {
//                MaLo = txt_SoLo.Text,
//                NgaySanXuat = dtp_NgaySX.Value,
//                HanSuDung = dtp_HanSuDung.Value,
//                GiaNhap = decimal.Parse(txt_GiaNhap.Text),
//                SoLuongVaccine = int.Parse(txt_SoLuongVaccine.Text)
//            };

//            (bool isSuccess, string message) result = loVaccineBUL.themLoVaccine(loVaccineDTO); // Gọi BUS

//            if (result.isSuccess)
//            {
//                foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
//                {
//                    if (row.Cells["maVaccine"].Value != null)
//                    {
//                        string maVaccine = row.Cells["maVaccine"].Value.ToString();
//                        DateTime ngaySX = (DateTime)row.Cells["ngaySanXuat"].Value;
//                        DateTime hanSD = (DateTime)row.Cells["hanSuDung"].Value;
//                        decimal giaNhap = decimal.Parse(row.Cells["giaNhap"].Value.ToString());
//                        int soLuong = int.Parse(row.Cells["soLuongVaccine"].Value.ToString());
//                        string dvt = row.Cells["donViTinh"].Value.ToString();
//                        decimal giaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString());

//                        ThongTinChiTietVaccineDTO thongTinChiTietVaccineDTO = new ThongTinChiTietVaccineDTO
//                        {
//                            MaVaccine = row.Cells["maVaccine"].Value.ToString(),
//                            MaLo = row.Cells["maLo"].Value.ToString(),
//                            GiaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString()),
//                            SoLuongTon = int.Parse(row.Cells["soLuongVaccine"].Value.ToString()),
//                            DonViTinh = row.Cells["donViTinh"].Value.ToString()
//                        };

//                        // Thêm thông tin chi tiết vaccine
//                        thongTinChiTietVacXinBUL.ThemCTVaccine(thongTinChiTietVaccineDTO);
//                    }
//                }

//                MessageBox.Show(result.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                clearData();
//                dgv_DSLoVaccine.Rows.Clear();
//            }
//            else
//            {
//                MessageBox.Show(result.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private void btn_Sua_Click(object sender, System.EventArgs e)
//        {
//            if (kiemTraDuLieu() == false)
//            {
//                return;
//            }

//            if (kiemTraNgayThang() == false)
//            {
//                return;
//            }

//            if (dgv_DSLoVaccine.SelectedRows.Count > 0)
//            {
//                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
//                {
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["maLo"].Value = txt_SoLo.Text;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["maVaccine"].Value = cbo_TenVaccine.SelectedValue.ToString();
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["ngaySanXuat"].Value = dtp_NgaySX.Value;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["hanSuDung"].Value = dtp_HanSuDung.Value;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["giaNhap"].Value = txt_GiaNhap.Text;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["soLuongVaccine"].Value = txt_SoLuongVaccine.Text;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["donViTinh"].Value = cbo_DVT.Text;
//                    dgv_DSLoVaccine.SelectedRows[0].Cells["giaBan"].Value = txt_GiaBan.Text;
//                }
//            }
//        }

//        private void btn_Huy_Click(object sender, System.EventArgs e)
//        {
//            flag = 0;
//            clearData();
//            enbaleButton(true);
//            dgv_DSLoVaccine.Enabled = true;
//        }

//        private void btn_Xoa_Click(object sender, System.EventArgs e)
//        {
//            if (dgv_DSLoVaccine.SelectedRows.Count > 0)
//            {
//                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {
//                    dgv_DSLoVaccine.Rows.RemoveAt(dgv_DSLoVaccine.SelectedRows[0].Index);
//                }
//            }
//        }

//        //txt_GiaBan = txt_GiaNhap + 10%
//        private void txt_GiaNhap_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                if (!string.IsNullOrEmpty(txt_GiaNhap.Text))
//                {
//                    if (decimal.TryParse(txt_GiaNhap.Text, out decimal giaNhap))
//                    {
//                        decimal vatRate = 0.05m; // 5% VAT as a decimal
//                        decimal giaBan = giaNhap + (giaNhap * vatRate);
//                        txt_GiaBan.Text = giaBan.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
//                    }
//                    else
//                    {
//                        MessageBox.Show("Vui lòng nhập số!");
//                    }
//                }

//                // Prevent the beep sound on Enter key press
//                e.SuppressKeyPress = true;
//            }
//        }

//        private void btn_TaoMoi_Click(object sender, System.EventArgs e)
//        {
//            txt_SoLo.Text = loVaccineBUL.taoMaLoVaccine();
//        }

//        private void btn_XemDSLo_Click(object sender, EventArgs e)
//        {
//            frm_XemDSLoVaccine frm = new frm_XemDSLoVaccine();
//            frm.Show();
//        }


//        private void cbo_TenVaccine_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            // Lấy mã vaccine từ combobox
//            //string maVaccine = cbo_TenVaccine.SelectedValue?.ToString();
//            //// Lấy thông tin vaccine từ mã vaccine
//            //ThongTinChiTietVaccineDTO vaccine = thongTinChiTietVacXinBUL.GetCTVaccineInfo(maVaccine);
//            //// Hiển thị thông tin vaccine lên textbox
//            //if (vaccine != null)
//            //{
//            //    cbo_DVT.Text = vaccine.DonViTinh;
//            //    txt_GiaBan.Text = vaccine.GiaBan.ToString();
//            //}
//            //else // Nếu không có thông tin vaccine
//            //{
//            //    cbo_DVT.Text = "";
//            //    txt_GiaBan.Text = "";
//            //}

//        }

//        //private void btn_Luu_Click(object sender, System.EventArgs e)
//        //{
//        //    if (dgv_DSLoVaccine.Rows.Count == 0)
//        //    {
//        //        MessageBox.Show("Vui lòng thêm vaccine vào danh sách");
//        //        return;
//        //    }

//        //    LoVaccineDTO loVaccineDTO = new LoVaccineDTO()
//        //    {
//        //        MaLo = txt_SoLo.Text,
//        //        NgaySanXuat = dtp_NgaySX.Value,
//        //        HanSuDung = dtp_HanSuDung.Value,
//        //        GiaNhap = decimal.Parse(txt_GiaNhap.Text),
//        //        SoLuongVaccine = int.Parse(txt_SoLuongVaccine.Text)
//        //    };

//        //    if (loVaccineBUL.themLoVaccine(loVaccineDTO))
//        //    {
//        //        foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
//        //        {
//        //            if (row.Cells["maVaccine"].Value != null)
//        //            {
//        //                string maVaccine = row.Cells["maVaccine"].Value.ToString();
//        //                DateTime ngaySX = (DateTime)row.Cells["ngaySanXuat"].Value;
//        //                DateTime hanSD = (DateTime)row.Cells["hanSuDung"].Value;
//        //                decimal giaNhap = decimal.Parse(row.Cells["giaNhap"].Value.ToString());
//        //                int soLuong = int.Parse(row.Cells["soLuongVaccine"].Value.ToString());
//        //                string dvt = row.Cells["donViTinh"].Value.ToString();
//        //                decimal giaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString());

//        //                ThongTinChiTietVaccineDTO thongTinChiTietVaccineDTO = new ThongTinChiTietVaccineDTO
//        //                {
//        //                    MaVaccine = row.Cells["maVaccine"].Value.ToString(),
//        //                    MaLo = row.Cells["maLo"].Value.ToString(),
//        //                    GiaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString()),
//        //                    SoLuongTon = int.Parse(row.Cells["soLuongVaccine"].Value.ToString()),
//        //                    DonViTinh = row.Cells["donViTinh"].Value.ToString()
//        //                };

//        //                // Thêm thông tin chi tiết vaccine
//        //                thongTinChiTietVacXinBUL.ThemCTVaccine(thongTinChiTietVaccineDTO);

//        //            }
//        //        }

//        //        MessageBox.Show("Thêm lô vaccine thành công");
//        //        clearData();
//        //        dgv_DSLoVaccine.Rows.Clear();
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("Thêm lô vaccine thất bại");
//        //    }

//        //}
//    }
//}





using BUL;
using DTO;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QLLoVaccine : Form
    {
        LoVaccineBUL loVaccineBUL;
        VaccineBUL vaccineBUL;
        ThongTinChiTietVaccineBUL thongTinChiTietVacXinBUL;
        int flag = 0;
        string maLoVaccine;
        public string soLo { get; private set; }
        public frm_QLLoVaccine()
        {
            InitializeComponent();
            loVaccineBUL = new LoVaccineBUL();
            vaccineBUL = new VaccineBUL();
            thongTinChiTietVacXinBUL = new ThongTinChiTietVaccineBUL();
            //loadData();
            //enbaleButton(true);
            clearData();
            loadComboboxVaccine();
        }

        //public void loadData()
        //{
        //    dgv_DSLoVaccine.AutoGenerateColumns = false;
        //    dgv_DSLoVaccine.DataSource = loVaccineBUL.layTatCaLoVaccine();
        //}

        public void loadComboboxVaccine()
        {
            cbo_TenVaccine.DataSource = vaccineBUL.LayTatCaVaccine();
            cbo_TenVaccine.DisplayMember = "TenVaccine";
            cbo_TenVaccine.ValueMember = "MaVaccine";
            cbo_TenVaccine.SelectedIndex = -1;

            string[] donViTinh = { "Lọ", "Chai", "Hộp" };
            //add item to combobox
            foreach (string item in donViTinh)
            {
                cbo_DVT.Items.Add(item);
            }
            cbo_DVT.SelectedIndex = -1;
            cbo_DVT.DisplayMember = "DonViTinh";
            cbo_DVT.ValueMember = "DonViTinh";
        }

        public void clearData()
        {
            //txt_SoLo.Text = ""; ;
            txt_GiaNhap.Text = "";
            txt_SoLuongVaccine.Text = "";
            txt_GiaBan.Text = "";
            cbo_TenVaccine.SelectedIndex = -1;
            cbo_DVT.SelectedIndex = -1;
        }

        public void enbaleButton(bool t)
        {
            btn_Them.Enabled = t;
            btn_Sua.Enabled = t;
            btn_Xoa.Enabled = t;
            btn_Luu.Enabled = !t;
            btn_Xoa.Enabled = t;
        }

        private void dgv_DSLoVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                maLoVaccine = dgv_DSLoVaccine.Rows[index].Cells["maLo"].Value.ToString();
                txt_SoLo.Text = dgv_DSLoVaccine.Rows[index].Cells["maLo"].Value.ToString();
                dtp_NgaySX.Text = dgv_DSLoVaccine.Rows[index].Cells["ngaySanXuat"].Value.ToString();
                dtp_HanSuDung.Text = dgv_DSLoVaccine.Rows[index].Cells["hanSuDung"].Value.ToString();
                txt_GiaNhap.Text = dgv_DSLoVaccine.Rows[index].Cells["giaNhap"].Value.ToString();
                txt_SoLuongVaccine.Text = dgv_DSLoVaccine.Rows[index].Cells["soLuongVaccine"].Value.ToString();
                cbo_DVT.Text = dgv_DSLoVaccine.Rows[index].Cells["donViTinh"].Value.ToString();
                txt_GiaBan.Text = dgv_DSLoVaccine.Rows[index].Cells["giaBan"].Value.ToString();
                cbo_TenVaccine.Text = dgv_DSLoVaccine.Rows[index].Cells["maVaccine"].Value.ToString();

                soLo = maLoVaccine;

            }
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            //flag = 1; // Set flag to 1 when adding a new record
            //enbaleButton(false);
            dgv_DSLoVaccine.Enabled = false;

            if (kiemTraDuLieu() == false)
            {
                return;
            }

            if (kiemTraNgayThang() == false)
            {
                return;
            }

            // Kiểm tra xem vaccine đã tồn tại trong danh sách hay chưa
            foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
            {
                if (row.Cells["maVaccine"].Value != null && row.Cells["maVaccine"].Value.ToString() == cbo_TenVaccine.SelectedValue.ToString())
                {
                    MessageBox.Show("Vaccine đã tồn tại trong danh sách");
                    return;
                }
            }

            // Thêm hàng mới vào DataGridView
            dgv_DSLoVaccine.Rows.Add(txt_SoLo.Text, cbo_TenVaccine.SelectedValue.ToString(), dtp_NgaySX.Value, dtp_HanSuDung.Value, txt_GiaNhap.Text, txt_GiaBan.Text, txt_SoLuongVaccine.Text, cbo_DVT.Text);
            //clearData();
        }

        public bool kiemTraDuLieu()
        {
            if (txt_SoLo.Text == "" || txt_GiaNhap.Text == "" || txt_SoLuongVaccine.Text == "" || cbo_TenVaccine.SelectedIndex == -1 || cbo_DVT.SelectedIndex == -1 || txt_GiaBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

        public bool kiemTraNgayThang()
        {
            // Kiểm tra ngày sản xuất không được chọn về quá khứ
            if (dtp_NgaySX.Value.Date < System.DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sản xuất không được nhỏ hơn ngày hiện tại");
                return false;
            }

            // Kiểm tra ngày sản xuất phải nhỏ hơn hạn sử dụng
            if (dtp_NgaySX.Value > dtp_HanSuDung.Value)
            {
                MessageBox.Show("Ngày sản xuất phải nhỏ hơn hạn sử dụng");
                return false;
            }

            // Kiểm tra hạn sử dụng phải lớn hơn ngày hiện tại
            if (dtp_HanSuDung.Value < System.DateTime.Now.Date)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại");
                return false;
            }

            return true;
        }

        //private void btn_Luu_Click(object sender, EventArgs e)
        //{
        //    if (dgv_DSLoVaccine.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Vui lòng thêm vaccine vào danh sách");
        //        return;
        //    }

        //    //Hiển thị txt_GiaNhap bằng MessageBox
        //    MessageBox.Show(txt_GiaNhap.Text);

        //    LoVaccineDTO loVaccineDTO = new LoVaccineDTO()
        //    {
        //        MaLo = txt_SoLo.Text,
        //        NgaySanXuat = dtp_NgaySX.Value,
        //        HanSuDung = dtp_HanSuDung.Value,
        //        GiaNhap = decimal.Parse(txt_GiaNhap.Text),
        //        SoLuongVaccine = int.Parse(txt_SoLuongVaccine.Text)
        //    };

        //    (bool isSuccess, string message) result = loVaccineBUL.themLoVaccine(loVaccineDTO); // Gọi BUS

        //    if (result.isSuccess)
        //    {
        //        foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
        //        {
        //            if (row.Cells["maVaccine"].Value != null)
        //            {
        //                string maVaccine = row.Cells["maVaccine"].Value.ToString();
        //                DateTime ngaySX = (DateTime)row.Cells["ngaySanXuat"].Value;
        //                DateTime hanSD = (DateTime)row.Cells["hanSuDung"].Value;
        //                decimal giaNhap = decimal.Parse(row.Cells["giaNhap"].Value.ToString());
        //                int soLuong = int.Parse(row.Cells["soLuongVaccine"].Value.ToString());
        //                string dvt = row.Cells["donViTinh"].Value.ToString();
        //                decimal giaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString());

        //                ThongTinChiTietVaccineDTO thongTinChiTietVaccineDTO = new ThongTinChiTietVaccineDTO
        //                {
        //                    MaVaccine = row.Cells["maVaccine"].Value.ToString(),
        //                    MaLo = row.Cells["maLo"].Value.ToString(),
        //                    GiaBan = decimal.Parse(row.Cells["giaBan"].Value.ToString()),
        //                    SoLuongTon = int.Parse(row.Cells["soLuongVaccine"].Value.ToString()),
        //                    DonViTinh = row.Cells["donViTinh"].Value.ToString()
        //                };

        //                // Thêm thông tin chi tiết vaccine
        //                thongTinChiTietVacXinBUL.ThemCTVaccine(thongTinChiTietVaccineDTO);
        //            }
        //        }

        //        MessageBox.Show(result.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        clearData();
        //        dgv_DSLoVaccine.Rows.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show(result.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (dgv_DSLoVaccine.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm vaccine vào danh sách");
                return;
            }

            LoVaccineDTO loVaccineDTO = new LoVaccineDTO()
            {
                MaLo = txt_SoLo.Text,
                NgaySanXuat = dtp_NgaySX.Value,
                HanSuDung = dtp_HanSuDung.Value,
                GiaNhap = decimal.Parse(txt_GiaNhap.Text, NumberStyles.Currency, CultureInfo.CurrentCulture),
                SoLuongVaccine = int.Parse(txt_SoLuongVaccine.Text)
            };

            (bool isSuccess, string message) result = loVaccineBUL.themLoVaccine(loVaccineDTO); // Gọi BUS

            if (result.isSuccess)
            {
                foreach (DataGridViewRow row in dgv_DSLoVaccine.Rows)
                {
                    if (row.Cells["maVaccine"].Value != null)
                    {
                        string maVaccine = row.Cells["maVaccine"].Value.ToString();
                        DateTime ngaySX = (DateTime)row.Cells["ngaySanXuat"].Value;
                        DateTime hanSD = (DateTime)row.Cells["hanSuDung"].Value;
                        decimal giaNhap = decimal.Parse(row.Cells["giaNhap"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                        int soLuong = int.Parse(row.Cells["soLuongVaccine"].Value.ToString());
                        string dvt = row.Cells["donViTinh"].Value.ToString();

                        string giaBanString = row.Cells["giaBan"].Value.ToString().Replace(".", "").Trim();
                        decimal giaBan = decimal.Parse(giaBanString);

                        ThongTinChiTietVaccineDTO thongTinChiTietVaccineDTO = new ThongTinChiTietVaccineDTO
                        {
                            MaVaccine = row.Cells["maVaccine"].Value.ToString(),
                            MaLo = row.Cells["maLo"].Value.ToString(),
                            GiaBan = giaBan,
                            SoLuongTon = int.Parse(row.Cells["soLuongVaccine"].Value.ToString()),
                            DonViTinh = row.Cells["donViTinh"].Value.ToString()
                        };

                        // Thêm thông tin chi tiết vaccine
                        thongTinChiTietVacXinBUL.ThemCTVaccine(thongTinChiTietVaccineDTO);
                    }
                }

                MessageBox.Show(result.message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                dgv_DSLoVaccine.Rows.Clear();
            }
            else
            {
                MessageBox.Show(result.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            if (kiemTraDuLieu() == false)
            {
                return;
            }

            if (kiemTraNgayThang() == false)
            {
                return;
            }

            if (dgv_DSLoVaccine.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    dgv_DSLoVaccine.SelectedRows[0].Cells["maLo"].Value = txt_SoLo.Text;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["maVaccine"].Value = cbo_TenVaccine.SelectedValue.ToString();
                    dgv_DSLoVaccine.SelectedRows[0].Cells["ngaySanXuat"].Value = dtp_NgaySX.Value;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["hanSuDung"].Value = dtp_HanSuDung.Value;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["giaNhap"].Value = txt_GiaNhap.Text;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["soLuongVaccine"].Value = txt_SoLuongVaccine.Text;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["donViTinh"].Value = cbo_DVT.Text;
                    dgv_DSLoVaccine.SelectedRows[0].Cells["giaBan"].Value = txt_GiaBan.Text;
                }
            }
        }

        private void btn_Huy_Click(object sender, System.EventArgs e)
        {
            flag = 0;
            clearData();
            enbaleButton(true);
            dgv_DSLoVaccine.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, System.EventArgs e)
        {
            if (dgv_DSLoVaccine.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgv_DSLoVaccine.Rows.RemoveAt(dgv_DSLoVaccine.SelectedRows[0].Index);
                }
            }
        }

        //txt_GiaBan = txt_GiaNhap + 10%
        private void txt_GiaNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txt_GiaNhap.Text))
                {
                    if (decimal.TryParse(txt_GiaNhap.Text, out decimal giaNhap))
                    {
                        decimal vatRate = 0.05m; // 5% VAT as a decimal
                        decimal giaBan = giaNhap + (giaNhap * vatRate);
                        txt_GiaBan.Text = giaBan.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số!");
                    }
                }

                // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true;
            }
        }

        private void btn_TaoMoi_Click(object sender, System.EventArgs e)
        {
            txt_SoLo.Text = loVaccineBUL.taoMaLoVaccine();
        }

        private void btn_XemDSLo_Click(object sender, EventArgs e)
        {
            frm_XemDSLoVaccine frm = new frm_XemDSLoVaccine();
            frm.Show();
        }
    }
}

