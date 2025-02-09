using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace GUI
{
    public class ExcelExportPhieuNhap
    {
        private const string TMP_ROW = "%TMP";
        private const string TEMPLATE_FOLDER = "Template"; // Thêm hằng số cho tên thư mục Template

        public static class Constants
        {
            public const string FILE_EXT_XLS = ".xlsx";

        }

        public bool ExportPhieuNhap(DataTable dtChiTiet, ref string fileName)
        {
            // Tạo Dictionary để thay thế các placeholder trong template
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            DataRow firstRow = dtChiTiet.Rows[0];

            //Lấy thông tin
            DateTime ngayLap = (DateTime)firstRow["ngayLap"];
            string ngay = "Ngày " + ngayLap.Day + " tháng " + ngayLap.Month + " năm " + ngayLap.Year;

            replacer.Add("%NgayThangNam", ngay);
            replacer.Add("%ngay", ngayLap.Day.ToString());
            replacer.Add("%thang", ngayLap.Month.ToString());
            replacer.Add("%nam", ngayLap.Year.ToString());
            replacer.Add("%MAPN", firstRow["maPhieu"].ToString());
            replacer.Add("%NCC", firstRow["tenNhaCungCap"].ToString());
            replacer.Add("%DiaChi", firstRow["diaChi"].ToString());
            replacer.Add("%DienThoai", firstRow["sDT"].ToString());
            replacer.Add("%TenNV", firstRow["hoTen"].ToString());



            // Tính tổng tiền
            decimal tongTien = 0;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                tongTien += Convert.ToDecimal(row["soLuongNhap"]) * Convert.ToDecimal(row["giaNhap"]);
            }
            replacer.Add("%TongTien", String.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", tongTien));

            // Đổi số thành chữ
            replacer.Add("%BangChu", ConvertNumberToWords((long)tongTien));

            // Đọc file template
            MemoryStream stream = null;
            byte[] arrayByte = new byte[0];

            // Lấy đường dẫn đến thư mục Template
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TEMPLATE_FOLDER, "PhieuNhapVaccine.xlsx");

            // Kiểm tra file template có tồn tại không
            if (File.Exists(templatePath))
            {
                arrayByte = File.ReadAllBytes(templatePath).ToArray();
                if (arrayByte.Count() > 0)
                {
                    stream = new MemoryStream(arrayByte);
                }
            }
            else
            {
                // Trả về false nếu không tìm thấy file template
                return false;
            }

            // Khởi tạo Excel Engine
            ExcelEngine engine = new ExcelEngine();
            IApplication app = engine.Excel;
            app.DefaultVersion = ExcelVersion.Excel2016;
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];

            // Thay thế các placeholder
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            if (replacer != null && replacer.Count > 0)
            {
                foreach (KeyValuePair<string, string> repl in replacer)
                {
                    Replace(workSheet, repl.Key, repl.Value);
                }
            }

            // Tạo danh sách chi tiết phiếu nhập để đổ vào template
            List<ChiTietPhieuNhapExport> ctpnSTT = new List<ChiTietPhieuNhapExport>();
            int stt = 1;

            foreach (DataRow row in dtChiTiet.Rows)
            {
                ChiTietPhieuNhapExport ct = new ChiTietPhieuNhapExport();
                ct.STT = stt++;
                ct.SOLO = row["maLo"].ToString();
                ct.MASANPHAM = row["maVaccine"].ToString();
                ct.TENSANPHAM = row["tenVaccine"].ToString();
                ct.SOLUONG = Convert.ToInt32(row["soLuongNhap"]);
                ct.DONGIA = Convert.ToDecimal(row["giaNhap"]);
                ct.THANHTIEN = ct.SOLUONG * ct.DONGIA;
                ctpnSTT.Add(ct);
            }

            // Debugging: Check the data being passed to the template markers processor
            foreach (ChiTietPhieuNhapExport item in ctpnSTT)
            {
                Console.WriteLine($"STT: {item.STT}, SOLO: {item.SOLO}, MASANPHAM: {item.MASANPHAM}, TENSANPHAM: {item.TENSANPHAM}, SOLUONG: {item.SOLUONG}, DONGIA: {item.DONGIA}, THANHTIEN: {item.THANHTIEN}");
            }

            // Đổ dữ liệu vào template
            markProcessor.AddVariable("Phieunhaphang", ctpnSTT);
            markProcessor.ApplyMarkers();

            // Xóa dòng template mẫu
            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            // Lưu file Excel
            // Lưu file Excel với tên có định dạng PhieuNhap_NgayThangNam.xlsx
            string formattedDate = ngayLap.ToString("ddMMyyyy"); // Định dạng ngày tháng năm
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PhieuNhap_" + formattedDate + Constants.FILE_EXT_XLS);
            fileName = file;

            workBook.SaveAs(file);
            workBook.Close();
            engine.Dispose();

            return true; // Trả về true nếu xuất file thành công
        }

        private void Replace(IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
        }
        private string ConvertNumberToWords(long number)
        {
            if (number == 0)
                return "Không";

            string[] unitsMap = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] tensMap = { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

            StringBuilder words = new StringBuilder();

            if ((number / 1000000000) > 0)
            {
                words.Append(ConvertNumberToWords(number / 1000000000) + " tỷ ");
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words.Append(ConvertNumberToWords(number / 1000000) + " triệu ");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words.Append(ConvertNumberToWords(number / 1000) + " nghìn ");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words.Append(ConvertNumberToWords(number / 100) + " trăm ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.Length > 0 && number < 10 && (number % 100) / 10 != 0)
                {
                    words.Append("linh ");
                }

                if (number < 10)
                {
                    words.Append(unitsMap[number]);
                }
                else if (number < 20)
                {
                    words.Append("mười ");
                    if (number % 10 != 5)
                    {
                        words.Append(unitsMap[number % 10]);
                    }
                    else
                    {
                        words.Append("lăm");
                    }
                }
                else
                {
                    words.Append(tensMap[number / 10] + " ");
                    if ((number % 10) > 0)
                    {
                        if (number % 10 != 5)
                        {
                            words.Append(unitsMap[number % 10]);
                        }
                        else
                        {
                            words.Append("lăm");
                        }
                    }
                }
            }

            string result = words.ToString().Trim();
            // Viết hoa chữ cái đầu tiên
            if (result.Length > 0)
            {
                result = char.ToUpper(result[0]) + result.Substring(1).ToLower();
            }
            return result;
        }
    }

    // Class để lưu trữ thông tin chi tiết phiếu nhập cho việc xuất Excel
    public class ChiTietPhieuNhapExport
    {
        public int STT { get; set; }
        public string SOLO { get; set; }
        public string MASANPHAM { get; set; }
        public string TENSANPHAM { get; set; }
        public int SOLUONG { get; set; }
        public decimal DONGIA { get; set; }
        public decimal THANHTIEN { get; set; }
    }
}