using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public class ExcelExport
    {
        private QL_TiemChungDataContext qldoanhthu;
        private const string TMP_ROW = "TMP";

        public ExcelExport(QL_TiemChungDataContext context)
        {
            qldoanhthu = context;
        }
        public void ExportDoanhThu(List<DoanhThuDTO> doanhThuList, ref string fileName, bool isPrintPreview)
        {
            // Kiểm tra danh sách doanhThuList có dữ liệu không
            if (doanhThuList == null || doanhThuList.Count == 0)
            {
                throw new InvalidOperationException("Danh sách doanh thu không có dữ liệu.");
            }

            // Lấy tháng và năm từ danh sách doanh thu (sử dụng tháng và năm của hóa đơn đầu tiên)
            int month = doanhThuList.FirstOrDefault()?.NgayLap?.Month ?? DateTime.Now.Month;
            int year = doanhThuList.FirstOrDefault()?.NgayLap?.Year ?? DateTime.Now.Year;
            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "DoanhThu.xlsx");

            // Xây dựng dictionary để thay thế các từ khóa với dữ liệu thực tế
            Dictionary<string, string> replacer = new Dictionary<string, string>
    {
        { "%HoaDon.STT", doanhThuList.FirstOrDefault()?.STT.ToString() ?? "Không có thông tin" },
        { "%HoaDon.MAHOADON", doanhThuList.FirstOrDefault()?.MaHD ?? "Không có thông tin" },
        { "%HoaDon.NGAYLAP", doanhThuList.FirstOrDefault()?.NgayLap?.ToString("dd/MM/yyyy") ?? "Không có thông tin" },
        { "%HoaDon.TIENTRA", doanhThuList.FirstOrDefault()?.TienTra?.ToString("0,0.00") ?? "Không có thông tin" },
        { "%HoaDon.TIENTHUA", doanhThuList.FirstOrDefault()?.TienThua?.ToString("0,0.00") ?? "Không có thông tin" },
        { "%HoaDon.TONGTIEN", doanhThuList.FirstOrDefault()?.TongTien?.ToString("0,0.00") ?? "Không có thông tin" },
        { "%HoaDon.PHƯƠNGTHUC", doanhThuList.FirstOrDefault()?.PhuongThucThanhToan ?? "Không có thông tin" },
        { "%HoaDon.NOIDUNG", doanhThuList.FirstOrDefault()?.NoiDung ?? "Không có thông tin" },
        { "%THANG", month.ToString() },
        { "%NAM", year.ToString() }
    };

            // Tải file mẫu từ đường dẫn
            using (MemoryStream stream = LoadTemplate(relativePath))
            {
                if (stream != null)
                {
                    // Khởi tạo Excel Engine và mở workbook
                    using (ExcelEngine engine = new ExcelEngine())
                    {
                        IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
                        IWorksheet workSheet = workBook.Worksheets[0];

                        // Áp dụng các giá trị thay thế vào worksheet
                        foreach (KeyValuePair<string, string> repl in replacer)
                        {
                            string key = repl.Key ?? "";
                            string value = repl.Value ?? "";
                            Replace(workSheet, key, value);
                        }

                        // Thêm từng dòng chi tiết hóa đơn vào worksheet
                        int startRow = 9; // Ví dụ: bắt đầu từ hàng thứ 3
                        int colSTT = 1, colMaHD = 2, colNgayLap = 3, colTienTra = 4, colTienThua = 5, colTongTien = 6, colPTThanhToan = 7;

                        foreach (DoanhThuDTO item in doanhThuList)
                        {
                            workSheet[startRow, colSTT].Text = item.STT.ToString(); // Thêm số thứ tự
                            workSheet[startRow, colMaHD].Text = item.MaHD;
                            workSheet[startRow, colNgayLap].Text = item.NgayLap?.ToString("dd/MM/yyyy") ?? "";
                            workSheet[startRow, colTienTra].Text = item.TienTra?.ToString("0,0.00");
                            workSheet[startRow, colTienThua].Text = item.TienThua?.ToString("0,0.00");
                            workSheet[startRow, colTongTien].Text = item.TongTien?.ToString("0,0.00");
                            workSheet[startRow, colPTThanhToan].Text = item.PhuongThucThanhToan;
                            startRow++;
                        }

                        // Tính tổng các cột và thay thế vào các ô tương ứng
                        workSheet[20, 4].Text = $"Tổng tiền trả: {doanhThuList.Sum(d => d.TienTra)?.ToString("0,0.00")}";
                        workSheet[21, 4].Text = $"Tổng tiền thừa: {doanhThuList.Sum(d => d.TienThua)?.ToString("0,0.00")}";
                        workSheet[22, 4].Text = $"Tổng tiền: {doanhThuList.Sum(d => d.TongTien)?.ToString("0,0.00")}";

                        // Lưu file Excel
                        string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", $"DoanhThu_export_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx");
                        workBook.SaveAs(outputPath);
                        fileName = outputPath;

                        // Mở file Excel nếu yêu cầu
                        if (isPrintPreview)
                        {
                            System.Diagnostics.Process.Start(outputPath);
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException("Không tìm thấy file mẫu Excel.");
                }
            }
        }


        private MemoryStream LoadTemplate(string filePath)
        {
            try
            {
                byte[] templateBytes = File.ReadAllBytes(filePath);
                return new MemoryStream(templateBytes);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"Không thể tải template: {ex.Message}");
            }
        }

        private void Replace(IWorksheet worksheet, string key, string value)
        {
            // Thay thế từ khóa trong toàn bộ worksheet
            worksheet.Replace(key, value);
        }

    }
}
