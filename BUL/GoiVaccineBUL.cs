using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class GoiVaccineBUL
    {
        private readonly DAL.GoiVaccineDAL goiVaccineDAL;

        public GoiVaccineBUL()
        {
            goiVaccineDAL = new DAL.GoiVaccineDAL();
        }

        public List<DTO.GoiVaccineDTO> LayDanhSachGoiVaccines()
        {
            List<DTO.GoiVaccineDTO> danhSachGoiVaccine = goiVaccineDAL.LayDanhSachGoiVaccines();
            return danhSachGoiVaccine;
        }
        public int GetMaxMaGoi()
        {
            return goiVaccineDAL.getMaxMaGoi();
        }
        public void LuuGoiVaccine(DTO.GoiVaccineDTO goiVaccineDto)
        {
            goiVaccineDAL.LuuGoiVaccine(goiVaccineDto);
        }
        public List<GoiVaccineDTO> getGoiVaccine()
        {
            List<GoiVaccineDTO> list = new List<GoiVaccineDTO>();

            DataTable dt = goiVaccineDAL.getGoiVaccin();  // Lấy dữ liệu từ DAL (Data Access Layer)
            foreach (DataRow dr in dt.Rows)
            {
                // Khởi tạo đối tượng GoiVaccineDTO và ánh xạ các giá trị từ DataRow
                GoiVaccineDTO goiVaccine = new GoiVaccineDTO
                {
                    MaGoi = dr["maGoi"].ToString(),
                    TenGoi = dr["tenGoi"].ToString(),
                    ThoiHanSuDung = dr["thoiHanSuDung"] != DBNull.Value ? Convert.ToDateTime(dr["thoiHanSuDung"]) : (DateTime?)null,
                    trangThai = dr["trangThai"] != DBNull.Value ? Convert.ToInt32(dr["trangThai"]) : (int?)null,
                    MaKhuyenMai = dr["maKhuyenMai"].ToString(),
                    TongTienGoi = dr["tongTienGoi"] != DBNull.Value ? Convert.ToDecimal(dr["tongTienGoi"]) : (decimal?)null
                };

                // Thêm đối tượng vào danh sách
                list.Add(goiVaccine);
            }

            return list;
        }
        public DataTable GetVaccinesForGoi(string maGoi)
        {
            DAL.GoiVaccineDAL goiVaccineDAL = new DAL.GoiVaccineDAL();
            return goiVaccineDAL.GetVaccinesForGoi(maGoi);
        }
    }
}
