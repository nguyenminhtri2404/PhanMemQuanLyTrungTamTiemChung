using System.Collections.Generic;

namespace DTO
{
    public class CauHoiSangLocDTO
    {
        public string MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public List<DapAnDTO> DapAns { get; set; }
    }

}
