using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class DoanhThuBUL
    {
        private DoanhThuDAL _doanhThuDAL;

        public DoanhThuBUL(QL_TiemChungDataContext context)
        {
            _doanhThuDAL = new DoanhThuDAL(context);
        }

        public List<DoanhThuDTO> GetDoanhThuByMonth(int month, int year)
        {
            List<HoaDonInfDTO> hoaDons = _doanhThuDAL.GetHoaDonByMonth(month, year);
            List<DoanhThuDTO> doanhThuDTOList = new List<DoanhThuDTO>();

            int stt = 1;
            foreach (HoaDonInfDTO hoaDon in hoaDons)
            {
                DoanhThuDTO doanhThuDTO = new DoanhThuDTO(hoaDon, stt);
                doanhThuDTOList.Add(doanhThuDTO);
                stt++;
            }

            return doanhThuDTOList;
        }
        public DataTable GetHoaDonReport(int month, int year)
        {

            DataTable hoaDonTable = _doanhThuDAL.GetHoaDonDataTable(month, year);
            return hoaDonTable;
        }
    }
}
