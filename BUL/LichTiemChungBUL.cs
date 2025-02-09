using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace BUL
{
    public class LichTiemChungBUL
    {
        LichTiemChungDAL lichTiemChungDAL;


        public LichTiemChungBUL()
        {
            lichTiemChungDAL = new LichTiemChungDAL();
        }
        //public DataTable LayTatCaLichTiemChung()
        //{
        //    return lichTiemChungDAL.LayTatCaLichTiemChung();
        //}
        public DataTable LayTatCaLichTiem()
        {
            return lichTiemChungDAL.LayTatCaLichTiem();
        }
        public DataTable LayTatCaLichSuTiem()
        {
            return lichTiemChungDAL.LayTatCaLichSuTiem();
        }
        public List<LichTiemChungInfo> GetLichTiemChung(string maLichTiemChung)
        {
            // Gọi phương thức getLichTiemChung từ DAL và trả về danh sách
            return lichTiemChungDAL.getLichTiemChung(maLichTiemChung);
        }
        public string GetMaVaccineByMaTiemChung(string maTiemChung)
        {
            return lichTiemChungDAL.GetMaVaccineByMaTiemChung(maTiemChung);
        }

        public List<LichTiemChungDTO> GetLichTiemChungTheoMaKH(string maKhachHang)
        {
            return lichTiemChungDAL.getLichTiemChungTheoMaKH(maKhachHang);
        }

        public bool ThemLichTiemChung(LichTiemChungDTO lichtiemchung)
        {
            return lichTiemChungDAL.themLichTiemChung(lichtiemchung);
        }


        private string GenerateMaLichTiemChung()
        {
            int maxMaLtc = lichTiemChungDAL.GetMaxMaLichTiemChung();
            int newMaLtc = maxMaLtc + 1;
            return "LTC" + newMaLtc.ToString().PadLeft(3, '0');
        }

        //public List<LichTiemChungDTO> GetLichTiemChungTheoMaKH(string maKhachHang)
        //{
        //    return lichTiemChungDAL.getLichTiemChungTheoMaKH(maKhachHang);
        //}

        //public void SaveLichTiemChung(LichTiemChungDTO lichtiemChung)
        //{
        //    LichTiemChung lichTiemChung = new LichTiemChung
        //    {
        //        maLichTiemChung = GenerateMaLichTiemChung(),
        //        mui = lichtiemChung.Mui,
        //        ngayHen = lichtiemChung.NgayHen,
        //        ghiChu = lichtiemChung.GhiChu,
        //        maNhanVien = lichtiemChung.MaNhanVien,
        //        maKhachHang = lichtiemChung.MaKhachHang,
        //        maVaccine = lichtiemChung.MaVaccine,
        //        trangThai = lichtiemChung.TrangThai
        //    };

        //    lichTiemChungDAL.SaveLichTiemChung(lichTiemChung);
        //}


        public int GetMaxMaPhieuDangKy()
        {
            return lichTiemChungDAL.GetMaxMaLichTiemChung();
        }
        //public LichTiemChungDTO GetLichTiemChungTheoCombo(string maVaccine)
        //{
        //    return lichTiemChungDAL.GetLichTiemByVaccine(maVaccine);
        //}

        public int GetSoMuiTiem(string maLichTiemChung)
        {
            return lichTiemChungDAL.GetSoMuiTiem(maLichTiemChung);
        }
        public bool KiemTraLichSuTiemChungHopLe(string maLichTiemChung, int soMuiHienTai, string maKhachHang)
        {
            // Gọi phương thức từ DAL để kiểm tra lịch sử tiêm chủng hợp lệ
            return lichTiemChungDAL.KiemTraLichSuTiemChungHopLe(maLichTiemChung, soMuiHienTai, maKhachHang);
        }
        public string GetMaKhachHangByMaLichTiemChung(string maLichTiemChung)
        {
            return lichTiemChungDAL.GetMaKhachHangByMaLichTiemChung(maLichTiemChung);
        }
        public bool KiemTraMuiTruocDaTiem(string maKhachHang, int soMuiHienTai)
        {
            return lichTiemChungDAL.KiemTraMuiTruocDaTiem(maKhachHang, soMuiHienTai);
        }


        public DataTable LayTatCaLichHen()
        {
            return lichTiemChungDAL.LayTatCaLichHen();
        }
        public DataTable LayTatCaLichHenTheoTenKhachHang(string tenKhachHang)
        {
            return lichTiemChungDAL.LayTatCaLichHenTheoTenKhachHang(tenKhachHang);
        }
        public DataTable LayTatCaLichHenTheoNgayHen(DateTime ngayHen)
        {
            try
            {
                return lichTiemChungDAL.LayTatCaLichHenTheoNgayHen(ngayHen);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần hoặc throw lại lỗi
                throw new Exception("Lỗi khi lấy lịch hẹn theo ngày hẹn: " + ex.Message);
            }
        }
        public void NhacHenQuaEmail()
        {
            List<(LichTiemChungDTO, LichSuTiemChungDTO)> danhSach = lichTiemChungDAL.LayLichHenVaLichSu();

            foreach ((LichTiemChungDTO lichTiemChung, LichSuTiemChungDTO lichSuTiemChung) in danhSach)
            {
                // Lấy thông tin email từ KhachHangDTO (giả sử đã liên kết với MaKhachHang)
                string emailKhachHang = lichTiemChungDAL.LayEmailTheoMaKhachHang(lichTiemChung.MaKhachHang);

                if (string.IsNullOrEmpty(emailKhachHang))
                {
                    Console.WriteLine($"Không tìm thấy email cho khách hàng: {lichTiemChung.MaKhachHang}");
                    continue;
                }

                // Lấy thông tin vaccine và số mũi từ cơ sở dữ liệu theo mã lịch tiêm chủng
                string tenVaccine = lichTiemChungDAL.LayTenVaccineTheoMaLich(lichTiemChung.MaLichTiemChung);
                int soMui = lichTiemChungDAL.LaySoMuiTheoMaLich(lichTiemChung.MaLichTiemChung);

                DateTime ngayNhacHen;

                // Logic tính toán ngày nhắc hẹn
                if (lichSuTiemChung != null && lichTiemChung.NgayHen == lichSuTiemChung.NgayTiem)
                {
                    ngayNhacHen = lichTiemChung.NgayHen.AddMonths(1);
                }
                else if (lichSuTiemChung != null && lichTiemChung.NgayHen < lichSuTiemChung.NgayTiem)
                {
                    ngayNhacHen = lichSuTiemChung.NgayTiem.AddMonths(1);
                }
                else
                {
                    ngayNhacHen = lichTiemChung.NgayHen.AddMonths(1);
                }

                DateTime ngayGuiEmail = ngayNhacHen.AddDays(-7);

                // Gửi email nếu ngày gửi email là hôm nay
                if (DateTime.Now.Date == ngayGuiEmail.Date)
                {
                    GuiEmail(lichTiemChung.HoTen, emailKhachHang, ngayNhacHen, tenVaccine, soMui);
                }
            }
        }

        public void GuiEmail(string hoTen, string emailKhachHang, DateTime ngayNhacHen, string tenVaccine, int mui)
        {
            using (MailMessage mail = new MailMessage())
            {
                // Địa chỉ email người gửi
                mail.From = new MailAddress("trisssouvenirshop.contact@gmail.com");

                // Địa chỉ email người nhận
                mail.To.Add(emailKhachHang);

                // Tiêu đề email
                mail.Subject = "🔴[VNVC - NHẮC HẸN TIÊM CHỦNG]";

                // Nội dung email với thông tin vaccine và số mũi
                mail.Body = string.Format(
                    "Xin chào Quý khách <b>{0}</b>,<br>Lịch tiêm chủng của bạn là vào ngày <b>{1}</b>.<br>Vaccine: {2}<br>Mũi: {3}.<br>Xin hãy chuẩn bị đúng lịch hẹn.<br>Cảm ơn Quý khách!<br><hr></hr><b>Trung tâm Tiêm chủng VNVC Tân Phú 2</b><br>Đ/c: 476 Lũy Bán Bích, Phường Hòa Thạnh, Quận Tân Phú, TPHCM<br>SĐT: 028 7102 6595",
                    hoTen,
                    ngayNhacHen.ToString("dd/MM/yyyy"),
                    tenVaccine,
                    mui
                );

                // Set IsBodyHtml to true to enable HTML content
                mail.IsBodyHtml = true;

                // Cấu hình SMTP của Gmail
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("trisssouvenirshop.contact@gmail.com", "ysnd dbop bqxr sgyy");
                    smtpClient.EnableSsl = true;

                    try
                    {
                        // Gửi email
                        smtpClient.Send(mail);
                        Console.WriteLine("Email đã được gửi thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu có
                        Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
                    }
                }
            }
        }

        public string LayEmailTheoMaKhachHang(string maKhachHang)
        {
            return lichTiemChungDAL.LayEmailTheoMaKhachHang(maKhachHang);
        }

        public string LayTenVaccineTheoMaLich(string maLich)
        {
            if (string.IsNullOrEmpty(maLich))
            {
                throw new ArgumentException("Mã lịch không hợp lệ.");
            }

            // Gọi hàm DAL để lấy tên vaccine
            return lichTiemChungDAL.LayTenVaccineTheoMaLich(maLich);
        }

        // Lấy số mũi theo mã lịch
        public int LaySoMuiTheoMaLich(string maLich)
        {
            if (string.IsNullOrEmpty(maLich))
            {
                throw new ArgumentException("Mã lịch không hợp lệ.");
            }

            // Gọi hàm DAL để lấy số mũi
            return lichTiemChungDAL.LaySoMuiTheoMaLich(maLich);
        }
    }
}
