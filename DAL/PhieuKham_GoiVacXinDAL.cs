using System;

namespace DAL
{
    public class PhieuKham_GoiVacXinDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public PhieuKham_GoiVacXinDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public bool InsertPhieuKhamGoiVacXin(string maGoi, string maPhieuKham, string ghiChu, string moTa, int mui, decimal giaBan, decimal thanhTien)
        {
            try
            {
                // Tạo một thực thể mới của bảng PhieuKham_GoiVacXin
                PhieuKham_GoiVacXin newPhieu = new PhieuKham_GoiVacXin
                {
                    maGoi = maGoi,
                    maPhieuKham = maPhieuKham,
                    ghiChu = ghiChu,
                    moTa = moTa,
                    mui = mui,
                    giaBan = giaBan,
                    thanhTien = thanhTien
                };

                // Thêm thực thể vào cơ sở dữ liệu
                db.PhieuKham_GoiVacXins.InsertOnSubmit(newPhieu);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Ghi chi tiết lỗi vào log hoặc console
                Console.WriteLine($"Error in InsertPhieuKhamGoiVacXin: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
