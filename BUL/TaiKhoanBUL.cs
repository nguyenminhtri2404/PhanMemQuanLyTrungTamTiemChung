using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class TaiKhoanBUL
    {
        TaiKhoanDAL taiKhoanDAL;
        public TaiKhoanBUL()
        {
            taiKhoanDAL = new TaiKhoanDAL();
        }

        //public bool kiemTraDangNhap(TaiKhoanDTO taiKhoanDTO)
        //{
        //    return taiKhoanDAL.kiemTraDangNhap(taiKhoanDTO);
        //}

        //public string kiemTraDangNhap(TaiKhoanDTO taiKhoanDTO)
        //{
        //    return taiKhoanDAL.kiemTraDangNhap(taiKhoanDTO);
        //}

        public DataTable layDanhSachTaiKhoan()
        {
            return taiKhoanDAL.layDanhSachTaiKhoan();
        }

        public bool themTaiKhoan(TaiKhoanDTO taiKhoanDTO)
        {
            // Hash the password before passing it to the DAL layer
            taiKhoanDTO.MatKhau = HashPassword(taiKhoanDTO.MatKhau);
            return taiKhoanDAL.themTaiKhoan(taiKhoanDTO);
        }

        private string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool suaTaiKhoan(TaiKhoanDTO taiKhoanDTO)
        {
            // Hash the default password "1"
            taiKhoanDTO.MatKhau = HashPassword("1");
            return taiKhoanDAL.suaTaiKhoan(taiKhoanDTO);
        }

        public bool xoaTaiKhoan(string tenDangNhap)
        {
            return taiKhoanDAL.xoaTaiKhoan(tenDangNhap);
        }

        public bool KiemTraMatKhauCu(string tenDangNhap, string matKhau)
        {
            string hashedPassword = HashPassword(matKhau);
            return taiKhoanDAL.KiemTraMatKhauCu(tenDangNhap, hashedPassword);
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string hashedPassword = HashPassword(matKhauMoi);
            return taiKhoanDAL.DoiMatKhau(tenDangNhap, hashedPassword);
        }

        public string kiemTraDangNhap(TaiKhoanDTO taiKhoanDTO)
        {
            taiKhoanDTO.MatKhau = HashPassword(taiKhoanDTO.MatKhau);
            return taiKhoanDAL.kiemTraDangNhap(taiKhoanDTO);
        }
    }
}
