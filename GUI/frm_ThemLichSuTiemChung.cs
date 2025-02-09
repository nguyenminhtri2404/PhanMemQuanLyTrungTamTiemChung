using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_ThemLichSuTiemChung : Form
    {
        private LichSuTiemChungBUL lichSuBUL;
        private VaccineBUL vaccineBUL;
        private NhanVienBUL nhanVienBUL;
        private LichTiemChungBUL lichTiemChungBUL;
        private LoVaccineBUL loVaccineBUL;
        //private LichSuTiemChungDTO lichSuTiemChung;
        //private LichTiemChungDTO selectedLichTC;
        string maLichTiemChung;
        string maVC;
        string tenNhanVien;
        string maNV;

        public frm_ThemLichSuTiemChung(string maLichTiemChung, string maVC, string tenNhanVien, string maNV)
        {
            InitializeComponent();
            lichSuBUL = new LichSuTiemChungBUL();
            vaccineBUL = new VaccineBUL();
            nhanVienBUL = new NhanVienBUL();
            lichTiemChungBUL = new LichTiemChungBUL();
            loVaccineBUL = new LoVaccineBUL();

            string maLSTC = lichSuBUL.layMaTuDong();
            txt_MaLSTC.Text = maLSTC;
            //this.lichSuTiemChung = lichSuTC;
            this.maLichTiemChung = maLichTiemChung;
            this.maVC = maVC;
            this.tenNhanVien = tenNhanVien;
            this.maNV = maNV;
            txt_maLichTC.Text = maLichTiemChung;
            txt_NhanVien.Text = tenNhanVien;
            loadDaTa();
            loadComboLoVaccine();

            //Định dạng datetimepicker dt_NgayTiem có giờ, phút, giây, ngày tháng năm ngay hiện tại
            dt_NgayTiem.Format = DateTimePickerFormat.Custom;
            dt_NgayTiem.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dt_NgayTiem.Value = DateTime.Now;
        }

        void loadComboLoVaccine()
        {
            List<LoVaccineDTO> loVaccineDTOs = loVaccineBUL.layDanhSachLoVacineTheoMaVaccine(maVC);
            cbo_LoVaccine.DataSource = loVaccineDTOs;
            cbo_LoVaccine.DisplayMember = "MaLo";
            cbo_LoVaccine.ValueMember = "MaLo";
        }

        void loadDaTa()
        {
            // Lấy danh sách lịch tiêm chung dựa trên mã lịch tiêm chung
            List<LichTiemChungInfo> lichTC = lichTiemChungBUL.GetLichTiemChung(maLichTiemChung);

            // Kiểm tra nếu danh sách không rỗng
            if (lichTC.Count > 0)
            {
                // Lấy đối tượng đầu tiên trong danh sách
                LichTiemChungInfo lichTiemChung = lichTC[0];

                // Hiển thị thông tin lên các TextBox trên form
                txt_TenKH.Text = lichTiemChung.HoTen;
                txt_TenVacxin.Text = lichTiemChung.TenVaccine; // Hiển thị tên vaccine
                txt_Mui.Text = lichTiemChung.Mui.ToString();   // Hiển thị số mũi
                txt_maLichTC.Text = lichTiemChung.MaLichTiemChung; // Hiển thị mã lịch tiêm chung
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin lịch tiêm chung.");
            }
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string maLichSuTiemChung = txt_MaLSTC.Text;
            DateTime ngayTiem = dt_NgayTiem.Value;
            string maLichTiemChung = txt_maLichTC.Text;
            string maNhanVien = maNV;
            string maLo = cbo_LoVaccine.SelectedValue.ToString();
            // Lấy mã vaccine từ lịch tiêm chủng
            string maVaccine = lichTiemChungBUL.GetMaVaccineByMaTiemChung(maLichTiemChung);
            if (string.IsNullOrEmpty(maVaccine))
            {
                MessageBox.Show("Không tìm thấy mã vaccine cho lịch tiêm chủng này.");
                return;
            }

            // Lấy mã khách hàng từ lịch tiêm chủng
            string maKhachHang = lichTiemChungBUL.GetMaKhachHangByMaLichTiemChung(maLichTiemChung);
            if (string.IsNullOrEmpty(maKhachHang))
            {
                MessageBox.Show("Không tìm thấy mã khách hàng cho lịch tiêm chủng này.");
                return;
            }

            // Lấy mã lô vaccine


            // Lấy số mũi hiện tại
            int soMuiHienTai = lichTiemChungBUL.GetSoMuiTiem(maLichTiemChung);

            // Nếu không phải mũi đầu tiên, kiểm tra lịch sử tiêm chủng hợp lệ
            if (soMuiHienTai > 1)
            {
                bool isValid = lichTiemChungBUL.KiemTraLichSuTiemChungHopLe(maLichTiemChung, soMuiHienTai, maKhachHang);

                // Nếu mũi trước đó chưa được tiêm, thông báo lỗi
                bool isMuiTruocDaTiem = lichTiemChungBUL.KiemTraMuiTruocDaTiem(maKhachHang, soMuiHienTai);
                if (!isMuiTruocDaTiem)
                {
                    MessageBox.Show(string.Format("Cần tiêm mũi {0} trước khi tiêm mũi {1}.", soMuiHienTai - 1, soMuiHienTai));
                    return;
                }
            }

            // Cập nhật số lượng tồn của vaccine theo mã lô
            bool isUpdated = vaccineBUL.UpdateSoLuongTon(maVaccine, maLo, 1);
            if (!isUpdated)
            {
                MessageBox.Show("Cập nhật số lượng tồn thất bại.");
                return;
            }

            // Thêm vào lịch sử tiêm chủng
            bool isAdded = lichSuBUL.ThemLichSuTiemChung(maLichSuTiemChung, ngayTiem, maLichTiemChung, maNhanVien);
            if (isAdded)
            {
                MessageBox.Show("Thêm lịch sử tiêm chủng thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm lịch sử tiêm chủng thất bại.");
            }
        }
    }
}
