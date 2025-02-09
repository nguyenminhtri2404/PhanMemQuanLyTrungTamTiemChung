using System;
using System.Linq;

namespace DAL
{
    public class PhieuKham_VaccineDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public PhieuKham_VaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public void AddVaccineToPhieuKham(string maVaccine, string maPhieuKham, string ghiChu, string ketLuan, int mui, decimal giaBan)
        {
            try
            {
                // Kiểm tra xem bản ghi đã tồn tại chưa
                PhieuKham_VacXin existingRecord = db.PhieuKham_VacXins
                    .FirstOrDefault(p => p.maVaccine == maVaccine && p.maPhieuKham == maPhieuKham);

                if (existingRecord != null)
                {
                    // Nếu bản ghi đã tồn tại, cập nhật thông tin
                    existingRecord.ghiChu = ghiChu;
                    existingRecord.ketLuan = ketLuan;
                    existingRecord.mui = mui;
                    existingRecord.giaBan = giaBan;
                    existingRecord.thanhTien = mui * giaBan;  // Tính lại thanh tiền

                    db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
                else
                {
                    // Nếu bản ghi chưa tồn tại, thêm mới
                    PhieuKham_VacXin newRecord = new PhieuKham_VacXin
                    {
                        maVaccine = maVaccine,
                        maPhieuKham = maPhieuKham,
                        ghiChu = ghiChu,
                        ketLuan = ketLuan,
                        mui = mui,
                        giaBan = giaBan,
                        thanhTien = mui * giaBan  // Tính thanh tiền
                    };

                    db.PhieuKham_VacXins.InsertOnSubmit(newRecord);
                    db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Lỗi khi lưu thông tin vắc xin: " + ex.Message);
            }
        }
    }
}
