using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace DAL
{
    public class GoiVaccineDAL
    {
        string strConn;
        QL_TiemChungDataContext db = new QL_TiemChungDataContext();
        public GoiVaccineDAL()
        {
            strConn = Settings.Default.strConn;
        }
        public List<DTO.GoiVaccineDTO> LayDanhSachGoiVaccines()
        {
            List<DTO.GoiVaccineDTO> danhSachGoiVaccine = (from gv in db.GoiVaccines
                                                          where gv.trangThai == 1
                                                          select new DTO.GoiVaccineDTO
                                                          {
                                                              MaGoi = gv.maGoi,
                                                              TenGoi = gv.tenGoi,
                                                              ThoiHanSuDung = gv.thoiHanSuDung,
                                                              trangThai = gv.trangThai,
                                                              MaKhuyenMai = gv.maKhuyenMai,
                                                              TongTienGoi = gv.tongTienGoi,
                                                              Vaccines = (from v in db.Vaccine_GoiVaccines
                                                                          where v.maGoi == gv.maGoi
                                                                          select new DTO.VaccineGoiVaccineDTO
                                                                          {
                                                                              MaGoi = v.maGoi,
                                                                              MaVaccine = v.maVaccine,
                                                                              SoLuong = v.soLuong
                                                                          }).ToList()
                                                          }).ToList();

            return danhSachGoiVaccine;
        }
        public int getMaxMaGoi()
        {
            List<string> maGoi = db.GoiVaccines
                .Select(nv => nv.maGoi)
                .ToList();
            int maxMaGoi = maGoi
                .Where(mgoi => !string.IsNullOrEmpty(mgoi) && mgoi.Length > 2)
                .Select(mgoi => int.Parse(mgoi.Substring(2)))
                .DefaultIfEmpty(0)
                .Max();
            return maxMaGoi;
        }
        //public void LuuGoiVaccine(DTO.GoiVaccineDTO goiVaccineDto)
        //{
        //    // Thêm GoiVaccine
        //    GoiVaccine goiVaccine = new GoiVaccine
        //    {
        //        maGoi = goiVaccineDto.MaGoi,
        //        tenGoi = goiVaccineDto.TenGoi,
        //        thoiHanSuDung = goiVaccineDto.ThoiHanSuDung,
        //        trangThai = goiVaccineDto.trangThai ?? 1, // Mặc định còn hàng
        //        maKhuyenMai = goiVaccineDto.MaKhuyenMai,
        //        tongTienGoi = goiVaccineDto.TongTienGoi ?? 0
        //    };

        //    db.GoiVaccines.InsertOnSubmit(goiVaccine);
        //    db.SubmitChanges();

        //    // Thêm Vaccine_GoiVaccine
        //    foreach (DTO.VaccineGoiVaccineDTO vaccine in goiVaccineDto.Vaccines)
        //    {
        //        Vaccine_GoiVaccine vaccineGoiVaccine = new Vaccine_GoiVaccine
        //        {
        //            maGoi = goiVaccineDto.MaGoi,
        //            maVaccine = vaccine.MaVaccine,
        //            soLuong = vaccine.SoLuong ?? 0
        //        };

        //        db.Vaccine_GoiVaccines.InsertOnSubmit(vaccineGoiVaccine);
        //    }

        //    db.SubmitChanges();
        //}


        public void LuuGoiVaccine(DTO.GoiVaccineDTO goiVaccineDto)
        {
            // Thêm GoiVaccine
            GoiVaccine goiVaccine = new GoiVaccine
            {
                maGoi = goiVaccineDto.MaGoi,
                tenGoi = goiVaccineDto.TenGoi,
                thoiHanSuDung = goiVaccineDto.ThoiHanSuDung,
                trangThai = goiVaccineDto.trangThai ?? 1, // Mặc định còn hàng
                maKhuyenMai = goiVaccineDto.MaKhuyenMai,
                tongTienGoi = goiVaccineDto.TongTienGoi ?? 0
            };

            db.GoiVaccines.InsertOnSubmit(goiVaccine);
            db.SubmitChanges();

            // Thêm Vaccine_GoiVaccine
            foreach (DTO.VaccineGoiVaccineDTO vaccine in goiVaccineDto.Vaccines)
            {
                Vaccine_GoiVaccine vaccineGoiVaccine = new Vaccine_GoiVaccine
                {
                    maGoi = goiVaccineDto.MaGoi,
                    maVaccine = vaccine.MaVaccine,
                    soLuong = vaccine.SoLuong ?? 0
                };

                db.Vaccine_GoiVaccines.InsertOnSubmit(vaccineGoiVaccine);
            }

            db.SubmitChanges();
        }

        public DataTable getGoiVaccin()
        {
            // Querying LoaiPhim using LINQ
            var query = from GoiVaccine in db.GoiVaccines
                        select new
                        {
                            GoiVaccine.maGoi,
                            GoiVaccine.tenGoi,
                            GoiVaccine.thoiHanSuDung,
                            GoiVaccine.trangThai,
                            GoiVaccine.maKhuyenMai,
                            GoiVaccine.tongTienGoi,
                        };

            // Converting the LINQ query results to a DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maGoi");
            dt.Columns.Add("tenGoi");
            dt.Columns.Add("thoiHanSuDung");
            dt.Columns.Add("trangThai");
            dt.Columns.Add("maKhuyenMai");
            dt.Columns.Add("tongTienGoi");
            foreach (var item in query)
            {
                dt.Rows.Add(item.maKhuyenMai, item.tenGoi, item.thoiHanSuDung, item.trangThai, item.maKhuyenMai, item.tongTienGoi);
            }

            return dt;
        }
        public DataTable GetVaccinesForGoi(string maGoi)
        {
            // Query lấy dữ liệu vaccine tương ứng với mã gói
            var query = from vaccineGoi in db.Vaccine_GoiVaccines
                        join vaccine in db.Vaccines on vaccineGoi.maVaccine equals vaccine.maVaccine
                        where vaccineGoi.maGoi == maGoi
                        select new
                        {
                            vaccineGoi.maVaccine,
                            vaccine.tenVaccine,
                            vaccineGoi.soLuong
                        };

            // Chuyển dữ liệu từ LINQ query thành DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("maVaccine");
            dt.Columns.Add("tenVaccine");
            dt.Columns.Add("soLuong");

            foreach (var item in query)
            {
                dt.Rows.Add(item.maVaccine, item.tenVaccine, item.soLuong);
            }

            return dt;
        }
    }
}
