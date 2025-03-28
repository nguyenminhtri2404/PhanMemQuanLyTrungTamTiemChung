USE [DoAn_QLTTTiemChung2]
GO
/****** Object:  Table [dbo].[CauHoiSangLoc]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoiSangLoc](
	[maCauHoi] [char](10) NOT NULL,
	[noiDung] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maCauHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[maChucVu] [char](10) NOT NULL,
	[tenChucVu] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PhieuNhap]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PhieuNhap](
	[maPhieu] [char](10) NOT NULL,
	[maLo] [char](10) NOT NULL,
	[soLuongNhap] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieu] ASC,
	[maLo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucManHinh]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucManHinh](
	[maManHinh] [char](10) NOT NULL,
	[tenManHinh] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DapAn]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DapAn](
	[maDapAn] [char](10) NOT NULL,
	[luaChon] [nvarchar](10) NOT NULL,
	[maPhieuKham] [char](10) NOT NULL,
	[maCauHoi] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maDapAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoiVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoiVaccine](
	[maGoi] [char](10) NOT NULL,
	[tenGoi] [nvarchar](255) NULL,
	[thoiHanSuDung] [date] NULL,
	[trangThai] [int] NULL,
	[maKhuyenMai] [char](10) NULL,
	[tongTienGoi] [decimal](18, 2) NULL,
 CONSTRAINT [PK__GoiVacci__2D87A9A0C150BAE0] PRIMARY KEY CLUSTERED 
(
	[maGoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[maHoaDon] [char](10) NOT NULL,
	[ngayLap] [date] NULL,
	[tienTra] [decimal](18, 2) NULL,
	[tienThua] [decimal](18, 2) NULL,
	[tongTien] [decimal](18, 2) NULL,
	[phuongThucThanhToan] [nvarchar](30) NULL,
	[kieuThanhToan] [nvarchar](20) NULL,
	[trangThai] [int] NULL,
	[noiDung] [nvarchar](100) NULL,
	[maPhieuKham] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeHoachTiemChung]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoachTiemChung](
	[maKeHoach] [char](10) NOT NULL,
	[tenKeHoach] [nvarchar](100) NOT NULL,
	[maPhongNgua] [char](10) NOT NULL,
	[maVaccine] [char](10) NOT NULL,
	[soMui] [int] NOT NULL,
	[thoiGianGiuaMui] [int] NULL,
	[ghiChu] [nvarchar](255) NULL,
	[trangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maKeHoach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[maKhachHang] [char](10) NOT NULL,
	[hoTen] [nvarchar](50) NOT NULL,
	[gioiTinh] [nvarchar](10) NULL,
	[ngaySinh] [date] NULL,
	[diaChi] [nvarchar](100) NULL,
	[sDT] [varchar](10) NULL,
	[email] [nvarchar](30) NULL,
	[tinhTrang] [nvarchar](100) NULL,
	[maNguoiGiamHo] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[maKhuyenMai] [char](10) NOT NULL,
	[tenKhuyenMai] [nvarchar](100) NULL,
	[phanTramKhuyenMai] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[maKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSuTiemChung]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuTiemChung](
	[maLichSuTiemChung] [char](10) NOT NULL,
	[ngayTiem] [datetime] NULL,
	[maLichTiemChung] [char](10) NULL,
	[maNhanVien] [char](10) NULL,
 CONSTRAINT [PK__LichSuTi__7A6D68F1F320B687] PRIMARY KEY CLUSTERED 
(
	[maLichSuTiemChung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichTiemChung]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichTiemChung](
	[maLichTiemChung] [char](10) NOT NULL,
	[maKeHoach] [char](10) NOT NULL,
	[maKhachHang] [char](10) NOT NULL,
	[maNhanVien] [char](10) NOT NULL,
	[ngayHen] [date] NOT NULL,
	[mui] [int] NOT NULL,
	[trangThai] [int] NULL,
	[ghiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maLichTiemChung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiTiemChung]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTiemChung](
	[maLoaiTiemChung] [char](10) NOT NULL,
	[tenLoaiTiemChung] [nvarchar](100) NULL,
	[trangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maLoaiTiemChung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiVaccine](
	[maLoai] [char](10) NOT NULL,
	[tenLoai] [nvarchar](100) NULL,
	[moTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoVaccine](
	[maLo] [char](10) NOT NULL,
	[ngaySanXuat] [date] NULL,
	[hanSuDung] [date] NULL,
	[giaNhap] [decimal](18, 2) NULL,
	[soLuongVaccine] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maLo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiGiamHo]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiGiamHo](
	[maNguoiGiamHo] [char](10) NOT NULL,
	[hoTen] [nvarchar](50) NOT NULL,
	[gioiTinh] [nvarchar](10) NULL,
	[ngaySinh] [date] NULL,
	[diaChi] [nvarchar](100) NULL,
	[sDT] [varchar](10) NULL,
	[email] [nvarchar](30) NULL,
	[quanHe] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maNguoiGiamHo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[maNhaCungCap] [char](10) NOT NULL,
	[tenNhaCungCap] [nvarchar](100) NULL,
	[diaChi] [nvarchar](100) NULL,
	[sDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNhanVien] [char](10) NOT NULL,
	[hoTen] [nvarchar](50) NOT NULL,
	[gioiTinh] [nvarchar](10) NULL,
	[ngaySinh] [date] NULL,
	[diaChi] [nvarchar](100) NULL,
	[sDT] [varchar](10) NULL,
	[email] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien_ChucVu]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_ChucVu](
	[tenDangNhap] [char](30) NOT NULL,
	[maChucVu] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tenDangNhap] ASC,
	[maChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[maManHinh] [char](10) NOT NULL,
	[maChucVu] [char](10) NOT NULL,
	[coQuyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maManHinh] ASC,
	[maChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKham_GoiVacXin]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKham_GoiVacXin](
	[maGoi] [char](10) NOT NULL,
	[maPhieuKham] [char](10) NOT NULL,
	[ghiChu] [nvarchar](100) NULL,
	[moTa] [nvarchar](100) NULL,
	[mui] [int] NULL,
	[giaBan] [decimal](18, 2) NULL,
	[thanhTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[maGoi] ASC,
	[maPhieuKham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKham_VacXin]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKham_VacXin](
	[maVaccine] [char](10) NOT NULL,
	[maPhieuKham] [char](10) NOT NULL,
	[ghiChu] [nvarchar](100) NULL,
	[ketLuan] [nvarchar](100) NULL,
	[mui] [int] NULL,
	[giaBan] [decimal](18, 2) NULL,
	[thanhTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[maVaccine] ASC,
	[maPhieuKham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKhamSangLoc]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKhamSangLoc](
	[maPhieuKham] [char](10) NOT NULL,
	[chieuCao] [nvarchar](30) NULL,
	[canNang] [nvarchar](30) NULL,
	[thanNhiet] [nvarchar](10) NULL,
	[trangThai] [int] NULL,
	[maNhanVien] [char](10) NULL,
	[maPhieuDangKy] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieuKham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[maPhieu] [char](10) NOT NULL,
	[ngayLap] [date] NOT NULL,
	[maNhaCungCap] [char](10) NULL,
	[maNhanVien] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTheoDoi]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTheoDoi](
	[maPhieuTheoDoi] [char](10) NOT NULL,
	[thoiGianTiem] [datetime] NULL,
	[tinhTrangSauTiem] [nvarchar](100) NULL,
	[lan] [int] NULL,
	[ghiChu] [nvarchar](50) NULL,
	[maNhanVien] [char](10) NULL,
	[maHoaDon] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieuTheoDoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongNgua]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongNgua](
	[maPhongNgua] [char](10) NOT NULL,
	[tenBenh] [nvarchar](100) NOT NULL,
	[moTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhongNgua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[maNhanVien] [char](10) NULL,
	[tenDangNhap] [char](30) NOT NULL,
	[matKhau] [nvarchar](64) NULL,
	[hoatDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[tenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinDangKy]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDangKy](
	[maPhieuDangKy] [char](10) NOT NULL,
	[hinhThucTiem] [nvarchar](30) NULL,
	[ngayDangKy] [date] NULL,
	[ghiChu] [nvarchar](255) NULL,
	[trangThai] [int] NULL,
	[maNhanVien] [char](10) NULL,
	[maKhachHang] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieuDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TT_CTVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TT_CTVaccine](
	[maVaccine] [char](10) NOT NULL,
	[maLo] [char](10) NOT NULL,
	[giaBan] [decimal](18, 2) NULL,
	[soLuongTon] [int] NULL,
	[donViTinh] [nvarchar](10) NULL,
 CONSTRAINT [PK_TT_CTVaccine] PRIMARY KEY CLUSTERED 
(
	[maVaccine] ASC,
	[maLo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccine](
	[maVaccine] [char](10) NOT NULL,
	[tenVaccine] [nvarchar](100) NOT NULL,
	[nguonGoc] [nvarchar](50) NULL,
	[lieuLuong] [nvarchar](10) NULL,
	[tinhTrang] [int] NULL,
	[maLoai] [char](10) NULL,
	[maLoaiTiemChung] [char](10) NULL,
	[maPhongNgua] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maVaccine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccine_GoiVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccine_GoiVaccine](
	[maGoi] [char](10) NOT NULL,
	[maVaccine] [char](10) NOT NULL,
	[soLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maGoi] ASC,
	[maVaccine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH001     ', N'Bạn có bất kỳ triệu chứng nào như sốt, ho, hoặc khó thở không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH002     ', N'Bạn có tiền sử dị ứng với bất kỳ loại vaccine nào không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH003     ', N'Bạn có bị bệnh mãn tính nào không? Ví dụ: tiểu đường, bệnh tim, hoặc hen suyễn?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH004     ', N'Bạn có từng gặp phản ứng nghiêm trọng sau khi tiêm vaccine trước đây không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH005     ', N'Bạn có sử dụng bất kỳ loại thuốc nào có thể ảnh hưởng đến vaccine không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH006     ', N'Bạn có hiện đang mang thai hoặc dự định mang thai trong thời gian tới không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH007     ', N'Bạn có từng bị nhiễm virus như COVID-19 trong thời gian gần đây không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH008     ', N'Bạn có gặp phải bất kỳ triệu chứng nào khác không liên quan đến tiêm vaccine?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH009     ', N'Bạn có từng phải nhập viện vì lý do sức khỏe trong 6 tháng qua không?')
INSERT [dbo].[CauHoiSangLoc] ([maCauHoi], [noiDung]) VALUES (N'CH010     ', N'Bạn có biết rõ về loại vaccine mà bạn sắp tiêm không?')
GO
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV000     ', N'Quản lý')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV001     ', N'Lễ tân')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV002     ', N'Bác sĩ')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV003     ', N'Thu ngân')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV004     ', N'Y tá')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV005     ', N'Điều dưỡng')
INSERT [dbo].[ChucVu] ([maChucVu], [tenChucVu]) VALUES (N'CV006     ', N'Nhân viên quản lý vaccine')
GO
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH001     ', N'frm_DangyTiemChung')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH002     ', N'frm_KhamSangLoc')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH003     ', N'frm_ThanhToan')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH004     ', N'frm_ThucHienTiemChung')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH005     ', N'frm_NhacHen')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH006     ', N'frm_TheoDoiSauTiem')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH007     ', N'frm_QuanLyTaiNguyen')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH008     ', N'frm_QuanLyKho')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH009     ', N'frm_QuanLyNhanVien')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH010     ', N'frm_QuanLyTaiKhoan')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH011     ', N'frm_ThongKe')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH012     ', N'frm_QLNhaCungCap')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH013     ', N'frm_QLVaccine')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH014     ', N'frm_QLLoaiVaccine')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH015     ', N'frm_QLLoaiTiemChung')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH016     ', N'frm_QLNhaCungCap')
INSERT [dbo].[DanhMucManHinh] ([maManHinh], [tenManHinh]) VALUES (N'MH017     ', N'frm_QLKhuyenMai')
GO
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA001     ', N'Không', N'PK001     ', N'CH001     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA002     ', N'Không', N'PK001     ', N'CH002     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA003     ', N'Có', N'PK001     ', N'CH003     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA004     ', N'Không', N'PK001     ', N'CH004     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA005     ', N'Không', N'PK001     ', N'CH005     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA006     ', N'Không', N'PK001     ', N'CH006     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA007     ', N'Không', N'PK001     ', N'CH007     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA008     ', N'Không', N'PK001     ', N'CH008     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA009     ', N'Không', N'PK001     ', N'CH009     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA010     ', N'Không', N'PK001     ', N'CH010     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA011     ', N'Không', N'PK002     ', N'CH001     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA012     ', N'Không', N'PK002     ', N'CH002     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA013     ', N'Không', N'PK002     ', N'CH003     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA014     ', N'Không', N'PK002     ', N'CH004     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA015     ', N'Không', N'PK002     ', N'CH005     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA016     ', N'Không', N'PK002     ', N'CH006     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA017     ', N'Không', N'PK002     ', N'CH007     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA018     ', N'Không', N'PK002     ', N'CH008     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA019     ', N'Không', N'PK002     ', N'CH009     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA020     ', N'Không', N'PK002     ', N'CH010     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA021     ', N'Không', N'PK002     ', N'CH001     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA022     ', N'Có', N'PK002     ', N'CH002     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA023     ', N'Không', N'PK002     ', N'CH003     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA024     ', N'Không', N'PK002     ', N'CH004     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA025     ', N'Không', N'PK002     ', N'CH005     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA026     ', N'Không', N'PK002     ', N'CH006     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA027     ', N'Không', N'PK002     ', N'CH007     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA028     ', N'Không', N'PK002     ', N'CH008     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA029     ', N'Không', N'PK002     ', N'CH009     ')
INSERT [dbo].[DapAn] ([maDapAn], [luaChon], [maPhieuKham], [maCauHoi]) VALUES (N'DA030     ', N'Không', N'PK002     ', N'CH010     ')
GO
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC001   ', N'Tiêm Phòng Sởi - MMR II', N'PB001     ', N'VAC02     ', 2, 30, N'Kế hoạch tiêm phòng sởi, sử dụng vaccine MMR II', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC002   ', N'Tiêm Phòng Sởi - ProQuad', N'PB001     ', N'VAC13     ', 2, 30, N'Kế hoạch tiêm phòng sởi, sử dụng vaccine ProQuad', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC003   ', N'Tiêm Phòng Viêm Gan B - Engerix-B', N'PB002     ', N'VAC04     ', 3, 30, N'Kế hoạch tiêm phòng viêm gan B, sử dụng vaccine Engerix-B', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC004   ', N'Tiêm Phòng Viêm Gan B - Heplisav-B', N'PB002     ', N'VAC14     ', 3, 30, N'Kế hoạch tiêm phòng viêm gan B, sử dụng vaccine Heplisav-B', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC005   ', N'Tiêm Phòng Bạch Hầu - IPOL', N'PB003     ', N'VAC05     ', 3, 30, N'Kế hoạch tiêm phòng bạch hầu, sử dụng vaccine IPOL', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC006   ', N'Tiêm Phòng Bạch Hầu - DTAP', N'PB003     ', N'VAC15     ', 3, 30, N'Kế hoạch tiêm phòng bạch hầu, sử dụng vaccine DTAP', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC007   ', N'Tiêm Phòng Uốn Ván - Pentaxim', N'PB004     ', N'VAC06     ', 3, 30, N'Kế hoạch tiêm phòng uốn ván, sử dụng vaccine Pentaxim', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC008   ', N'Tiêm Phòng Uốn Ván - IPOL', N'PB004     ', N'VAC05     ', 3, 30, N'Kế hoạch tiêm phòng uốn ván, sử dụng vaccine IPOL', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC009   ', N'Tiêm Phòng Cúm - Influvac', N'PB005     ', N'VAC01     ', 1, 0, N'Kế hoạch tiêm phòng cúm, sử dụng vaccine Influvac', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC010   ', N'Tiêm Phòng Cúm - Fluarix', N'PB005     ', N'VAC17     ', 1, 0, N'Kế hoạch tiêm phòng cúm, sử dụng vaccine Fluarix', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC011   ', N'Tiêm Phòng Rubella - Varivax', N'PB006     ', N'VAC03     ', 2, 30, N'Kế hoạch tiêm phòng rubella, sử dụng vaccine Varivax', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC012   ', N'Tiêm Phòng Rubella - MMRV', N'PB006     ', N'VAC12     ', 2, 30, N'Kế hoạch tiêm phòng rubella, sử dụng vaccine MMRV', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC013   ', N'Tiêm Phòng Viêm Phổi - Prevenar 13', N'PB007     ', N'VAC09     ', 3, 60, N'Kế hoạch tiêm phòng viêm phổi, sử dụng vaccine Prevenar 13', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC014   ', N'Tiêm Phòng Viêm Phổi - Tetavax', N'PB007     ', N'VAC08     ', 3, 60, N'Kế hoạch tiêm phòng viêm phổi, sử dụng vaccine Tetavax', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC015   ', N'Tiêm Phòng Tả - Dengvaxia', N'PB008     ', N'VAC10     ', 2, 30, N'Kế hoạch tiêm phòng tả, sử dụng vaccine Dengvaxia', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC016   ', N'Tiêm Phòng Tả - Vivotif', N'PB008     ', N'VAC16     ', 2, 30, N'Kế hoạch tiêm phòng tả, sử dụng vaccine Vivotif', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC017   ', N'Tiêm Phòng Dại - Comirnaty', N'PB009     ', N'VAC18     ', 3, 30, N'Kế hoạch tiêm phòng dại, sử dụng vaccine Comirnaty', 1)
INSERT [dbo].[KeHoachTiemChung] ([maKeHoach], [tenKeHoach], [maPhongNgua], [maVaccine], [soMui], [thoiGianGiuaMui], [ghiChu], [trangThai]) VALUES (N'KHTC018   ', N'Tiêm Phòng HPV - Gardasil', N'PB010     ', N'VAC20     ', 3, 60, N'Kế hoạch tiêm phòng HPV, sử dụng vaccine Gardasil', 1)
GO
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH001     ', N'Nguyễn Thị Lan', N'Nữ', CAST(N'1990-03-12' AS Date), N'Hà Nội', N'0912345678', N'lan.nguyen@email.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH002     ', N'Nguyễn Minh Hùng', N'Nam', CAST(N'1985-07-22' AS Date), N'Hồ Chí Minh', N'0908765432', N'mhung@email.com', NULL, N'NGH001    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH003     ', N'Vũ Thị Mai', N'Nữ', CAST(N'2000-01-14' AS Date), N'Đà Nẵng', N'0922334455', N'mai.vu@email.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH004     ', N'Nguyễn Đình Huy', N'Nam', CAST(N'1992-08-05' AS Date), N'Bình Dương', N'0933445566', N'nguyenminhtri42k3@gmail.com', NULL, N'NGH002    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH005     ', N'Hoàng Minh Phúc', N'Nam', CAST(N'1987-02-28' AS Date), N'Hải Phòng', N'0944556677', N'phuc.hoang@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH006     ', N'Nguyễn Thiên Kim', N'Nữ', CAST(N'1995-12-20' AS Date), N'Thừa Thiên Huế', N'0955667788', N'kim.nguyen@email.com', NULL, N'NGH003    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH007     ', N'Hoàng Ngọc Lan', N'Nữ', CAST(N'1998-05-03' AS Date), N'Bắc Ninh', N'0966778899', N'lan.hoang@email.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH008     ', N'Phạm Trung Kiên', N'Nam', CAST(N'1991-11-17' AS Date), N'Tiền Giang', N'0977889900', N'kien.pham@email.com', NULL, N'NGH004    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH009     ', N'Trần Thuý An', N'Nữ', CAST(N'1989-04-10' AS Date), N'Hồ Chí Minh', N'0988990011', N'an.tran@email.com', NULL, N'NGH005    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH010     ', N'Nguyễn Hoàng Bảo', N'Nam', CAST(N'2002-06-15' AS Date), N'Vĩnh Long', N'0999001122', N'bao.nguyen@email.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH011     ', N'Trần Văn Bé', N'Nam', CAST(N'2006-03-02' AS Date), N'Hồ Chí Minh', N'032608202', N'vanbe@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH012     ', N'Nguyễn Minh', N'Nam', CAST(N'2019-02-06' AS Date), N'Hồ Chí Minh', N'0326081202', N'minhminh@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH013     ', N'Trần Văn Thời', N'Nam', CAST(N'1988-12-26' AS Date), N'Hồ Chí Minh', N'0326081789', N'minhtri2k3.info@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH014     ', N'Nguyễn Hà Anh', N'Nữ', CAST(N'1988-12-26' AS Date), N'Hồ Chí Minh', N'0385748951', N'haanh@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH015     ', N'Nguyễn Hoàng Thái', N'Nam', CAST(N'2020-01-28' AS Date), N'Hồ Chí Minh', N'0685474123', N'hthai@gmail.com', NULL, N'NGH008    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH016     ', N'Nguyễn Anh Tú', N'Nam', CAST(N'2011-03-03' AS Date), N'Hồ Chí Minh', N'0785412369', N'anhtu@gmail.com', NULL, N'NGH008    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH017     ', N'Nguyễn Phương Anh', N'Nữ', CAST(N'2002-10-29' AS Date), N'Bến Tre', N'0694512301', N'panh@gmail.com', NULL, NULL)
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH018     ', N'Trần Anh Hào', N'Nam', CAST(N'2019-06-12' AS Date), N'Hồ Chí Minh', N'0326081303', N'anhaooo@gmail.com', NULL, N'NGH006    ')
INSERT [dbo].[KhachHang] ([maKhachHang], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [tinhTrang], [maNguoiGiamHo]) VALUES (N'KH019     ', N'Trần Quang Tính', N'Nam', CAST(N'2020-01-28' AS Date), N'Hồ Chí Minh', N'0369854123', N'qhao@gmail.com', NULL, N'NGH009    ')
GO
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM001     ', N'Khuyến Mãi gói vắc-xin 10%', CAST(0.10 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM002     ', N'Khuyến Mãi gói vắc-xin 15%', CAST(0.15 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM003     ', N'Khuyến Mãi gói vắc-xin 20%', CAST(0.20 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM004     ', N'Khuyến Mãi gói vắc-xin 25%', CAST(0.25 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM005     ', N'Khuyến Mãi gói vắc-xin 30%', CAST(0.30 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM006     ', N'Khuyến Mãi gói vắc-xin 35%', CAST(0.35 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM007     ', N'Khuyến Mãi gói vắc-xin 40%', CAST(0.40 AS Decimal(18, 2)))
INSERT [dbo].[KhuyenMai] ([maKhuyenMai], [tenKhuyenMai], [phanTramKhuyenMai]) VALUES (N'KM008     ', N'Khuyến Mãi gói vắc-xin 50%', CAST(0.50 AS Decimal(18, 2)))
GO
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC01     ', N'Tiêm chủng cơ bản', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC02     ', N'Tiêm chủng mở rộng', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC03     ', N'Tiêm phòng cúm', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC04     ', N'Tiêm phòng sởi', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC05     ', N'Tiêm phòng viêm gan', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC06     ', N'Tiêm phòng thủy đậu', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC07     ', N'Tiêm phòng bại liệt', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC08     ', N'Tiêm phòng ho gà', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC09     ', N'Tiêm phòng rubella', 1)
INSERT [dbo].[LoaiTiemChung] ([maLoaiTiemChung], [tenLoaiTiemChung], [trangThai]) VALUES (N'LTC10     ', N'Tiêm phòng uốn ván', 1)
GO
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV001     ', N'Vaccine Sởi', N'Vaccine phòng ngừa bệnh sởi, một bệnh truyền nhiễm nguy hiểm.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV002     ', N'Vaccine Viêm Gan B', N'Vaccine phòng ngừa viêm gan B do virus gây ra, có thể dẫn đến xơ gan và ung thư gan.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV003     ', N'Vaccine Bạch Hầu', N'Vaccine phòng ngừa bệnh bạch hầu, một bệnh nhiễm trùng nặng có thể gây tử vong.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV004     ', N'Vaccine Uốn Ván', N'Vaccine phòng ngừa bệnh uốn ván, một bệnh nhiễm trùng gây co thắt cơ bắp và có thể ảnh hưởng đến các cơ quan nội tạng.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV005     ', N'Vaccine Cúm', N'Vaccine phòng ngừa bệnh cúm, một bệnh nhiễm trùng đường hô hấp gây sốt, ho và mệt mỏi.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV006     ', N'Vaccine Rubella', N'Vaccine phòng ngừa bệnh Rubella, đặc biệt quan trọng đối với phụ nữ mang thai.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV007     ', N'Vaccine Viêm Phổi', N'Vaccine phòng ngừa viêm phổi do vi khuẩn hoặc virus gây ra, đặc biệt ở trẻ em và người già.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV008     ', N'Vaccine Tả', N'Vaccine phòng ngừa bệnh tả, một bệnh nhiễm trùng đường tiêu hóa gây tiêu chảy và mất nước nghiêm trọng.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV009     ', N'Vaccine Dại', N'Vaccine phòng ngừa bệnh dại do virus lây qua vết cắn của động vật bị nhiễm bệnh.')
INSERT [dbo].[LoaiVaccine] ([maLoai], [tenLoai], [moTa]) VALUES (N'LV010     ', N'Vaccine HPV', N'Vaccine phòng ngừa virus HPV, nguyên nhân chính gây ung thư cổ tử cung ở phụ nữ.')
GO
INSERT [dbo].[LoVaccine] ([maLo], [ngaySanXuat], [hanSuDung], [giaNhap], [soLuongVaccine]) VALUES (N'L01       ', CAST(N'2024-12-16' AS Date), CAST(N'2025-11-13' AS Date), CAST(1048000.00 AS Decimal(18, 2)), 150)
GO
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH001    ', N'Nguyễn Minh Dũng', N'Nam', CAST(N'1980-02-15' AS Date), N'Hà Nội', N'0901234567', N'ngh.dung@email.com', N'Cha')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH002    ', N'Nguyễn Hữu Dương', N'Nam', CAST(N'1990-04-22' AS Date), N'Hồ Chí Minh', N'0907654321', N'ngh.duong@email.com', N'Anh')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH003    ', N'Nguyễn Minh Đoàn', N'Nam', CAST(N'1968-11-10' AS Date), N'Đà Nẵng', N'0912345678', N'ngh.duc@email.com', N'Cha')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH004    ', N'Hoàng Thị Linh', N'Nữ', CAST(N'1974-03-14' AS Date), N'Hải Phòng', N'0922334455', N'ngh.linh@email.com', N'Mẹ')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH005    ', N'Nguyễn Hồng Nam', N'Nam', CAST(N'1985-07-19' AS Date), N'Bắc Ninh', N'0933445566', N'ngh.nam@email.com', N'Anh')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH006    ', N'Trần Văn Dung', N'Nam', CAST(N'1989-11-16' AS Date), N'Hồ Chí Minh', N'0326081303', N'vdung@gmail.com', N'Cha')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH007    ', N'Nguyễn Văn Hải', N'Nam', CAST(N'1990-02-01' AS Date), N'Hồ Chí Minh', N'0326081303', N'vanhaii@gmail.com', N'Cha')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH008    ', N'Nguyễn Thanh Lam', N'Nữ', CAST(N'1989-01-02' AS Date), N'Hồ Chí Minh', N'0987451258', N'lamm@gmail.com', N'Mẹ')
INSERT [dbo].[NguoiGiamHo] ([maNguoiGiamHo], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email], [quanHe]) VALUES (N'NGH009    ', N'Trần Quang Hào', N'Nam', CAST(N'1989-01-13' AS Date), N'Hồ Chí Minh', N'0369854123', N'qhao@gmail.com', N'Cha')
GO
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC001    ', N'Công ty Dược Phẩm Hoàng Gia', N'Quận 1, TP.HCM', N'0901234567')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC002    ', N'Công ty TNHH Dược Phẩm Bình Minh', N'Quận 1, TP.HCM', N'0912345678')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC003    ', N'Công ty Cổ Phần Dược Phẩm Sài Gòn', N'Quận 3, TP.HCM', N'0923456789')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC004    ', N'Công ty TNHH Dược Phẩm Trường An', N'Quận Phú Nhuận, TP.HCM', N'0934567890')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC005    ', N'Công ty Cổ Phần Y Tế Hòa Bình', N'Quận 10, TP.HCM', N'0945678901')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC006    ', N'Tập Đoàn Dược Phẩm Vimedimex', N'Quận Tân Bình, TP.HCM', N'0956789012')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC007    ', N'Công ty TNHH Dược Phẩm Minh Châu', N'Quận Bình Thạnh, TP.HCM', N'0967890123')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC008    ', N'Công ty Dược Phẩm Long An', N'Tân An, Long An', N'0978901234')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC009    ', N'Công ty TNHH Dược Phẩm Thăng Long', N'Quận 10, TP.HCM', N'0989012345')
INSERT [dbo].[NhaCungCap] ([maNhaCungCap], [tenNhaCungCap], [diaChi], [sDT]) VALUES (N'NCC010    ', N'Công ty Cổ Phần Dược Phẩm Mekophar', N'Quận 3, TP.HCM', N'0990123456')
GO
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV000     ', N'Admin', N'N/A', CAST(N'2024-11-24' AS Date), N'HCM', N'0326081303', NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV001     ', N'Nguyễn Văn Khải', N'Nam', CAST(N'1985-01-15' AS Date), N'Số 123, Đường Trần Hưng Đạo, Quận 1, TP.HCM', N'0123456789', N'nguyenkhai@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV002     ', N'Trần Thị Hương', N'Nữ', CAST(N'1990-02-20' AS Date), N'Số 456, Đường Nguyễn Huệ, Quận 2, TP.HCM', N'0987654321', N'tranhuong@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV003     ', N'Lê Văn Bình', N'Nam', CAST(N'1992-03-10' AS Date), N'Số 789, Đường Lê Văn Sĩ, Quận 3, TP.HCM', N'0123456780', N'levanbinh@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV004     ', N'Phạm Thị Ngọc', N'Nữ', CAST(N'1988-04-25' AS Date), N'Số 321, Đường Đinh Tiên Hoàng, Quận 4, TP.HCM', N'0987654312', N'phamngoc@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV005     ', N'Nguyễn Minh Tuấn', N'Nam', CAST(N'1995-05-30' AS Date), N'Số 654, Đường Võ Văn Tần, Quận 5, TP.HCM', N'0123456790', N'nguyenminhtuan@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV006     ', N'Trần Văn An', N'Nam', CAST(N'1987-06-15' AS Date), N'Số 987, Đường Nguyễn Thái Bình, Quận 6, TP.HCM', N'0987654320', N'tranvanan@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV007     ', N'Lê Thị Hòa', N'Nữ', CAST(N'1993-07-10' AS Date), N'Số 135, Đường Hai Bà Trưng, Quận 7, TP.HCM', N'0123456781', N'lehoaa@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV008     ', N'Phạm Văn Long', N'Nam', CAST(N'1989-08-05' AS Date), N'Số 246, Đường Trường Chinh, Quận 8, TP.HCM', N'0987654311', N'phamvanlong@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV009     ', N'Nguyễn Thị Tuyết', N'Nữ', CAST(N'1991-09-20' AS Date), N'Số 357, Đường Hoàng Sa, Quận 9, TP.HCM', N'0123456782', N'nguyenthituyet@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV010     ', N'Trần Văn Hải', N'Nam', CAST(N'1994-10-12' AS Date), N'Số 468, Đường Nguyễn Văn Cừ, Quận 10, TP.HCM', N'0987654300', N'tranvanhai@example.com')
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [sDT], [email]) VALUES (N'NV011     ', N'Nguyễn Anh Luân', N'Nam', CAST(N'1988-12-26' AS Date), N'HCM', N'0326081746', N'luan@gmail.com')
GO
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'admin                         ', N'CV000     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'lethihoa                      ', N'CV001     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'levanbinh                     ', N'CV002     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'lunee                         ', N'CV000     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'nguyenminhtuan                ', N'CV002     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'nguyenthituyet                ', N'CV003     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'nguyenvankhai                 ', N'CV002     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'phamthingoc                   ', N'CV004     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'tranthihuong                  ', N'CV005     ')
INSERT [dbo].[NhanVien_ChucVu] ([tenDangNhap], [maChucVu]) VALUES (N'tranvanan                     ', N'CV006     ')
GO
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH001     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH001     ', N'CV001     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH001     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH002     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH002     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH003     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH003     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH003     ', N'CV003     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH004     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH004     ', N'CV004     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH005     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH005     ', N'CV004     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH006     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH006     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH006     ', N'CV005     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH007     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH007     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH007     ', N'CV006     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH008     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH008     ', N'CV006     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH009     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH010     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH011     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH011     ', N'CV001     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH012     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH012     ', N'CV002     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH012     ', N'CV006     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH013     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH013     ', N'CV002     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH013     ', N'CV006     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH014     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH014     ', N'CV006     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH015     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH015     ', N'CV006     ', 0)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH016     ', N'CV000     ', 1)
INSERT [dbo].[PhanQuyen] ([maManHinh], [maChucVu], [coQuyen]) VALUES (N'MH017     ', N'CV000     ', 1)
GO
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB001     ', N'Tiêm Phòng Sởi', N'Phòng ngừa bệnh sởi, một bệnh truyền nhiễm nguy hiểm.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB002     ', N'Tiêm Phòng Viêm Gan B', N'Phòng ngừa bệnh viêm gan B do virus gây ra, có thể dẫn đến xơ gan và ung thư gan.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB003     ', N'Tiêm Phòng Bạch Hầu', N'Phòng ngừa bệnh bạch hầu, một bệnh nhiễm trùng nặng có thể gây tử vong.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB004     ', N'Tiêm Phòng Uốn Ván', N'Phòng ngừa bệnh uốn ván, một bệnh nhiễm trùng gây co thắt cơ bắp và có thể ảnh hưởng đến các cơ quan nội tạng.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB005     ', N'Tiêm Phòng Cúm', N'Phòng ngừa bệnh cúm, một bệnh nhiễm trùng đường hô hấp gây sốt, ho và mệt mỏi.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB006     ', N'Tiêm Phòng Rubella', N'Phòng ngừa bệnh Rubella, đặc biệt quan trọng đối với phụ nữ mang thai.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB007     ', N'Tiêm Phòng Viêm Phổi', N'Phòng ngừa viêm phổi do vi khuẩn hoặc virus gây ra, đặc biệt ở trẻ em và người già.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB008     ', N'Tiêm Phòng Tả', N'Phòng ngừa bệnh tả, một bệnh nhiễm trùng đường tiêu hóa gây tiêu chảy và mất nước nghiêm trọng.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB009     ', N'Tiêm Phòng Dại', N'Phòng ngừa bệnh dại do virus lây qua vết cắn của động vật bị nhiễm bệnh.')
INSERT [dbo].[PhongNgua] ([maPhongNgua], [tenBenh], [moTa]) VALUES (N'PB010     ', N'Tiêm Phòng HPV', N'Phòng ngừa virus HPV, nguyên nhân chính gây ung thư cổ tử cung ở phụ nữ.')
GO
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV000     ', N'admin                         ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV007     ', N'lethihoa                      ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV003     ', N'levanbinh                     ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV011     ', N'lunee                         ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV005     ', N'nguyenminhtuan                ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV009     ', N'nguyenthituyet                ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV001     ', N'nguyenvankhai                 ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV004     ', N'phamthingoc                   ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV008     ', N'phamvanlong                   ', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV002     ', N'tranthihuong                  ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV006     ', N'tranvanan                     ', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
INSERT [dbo].[TaiKhoan] ([maNhanVien], [tenDangNhap], [matKhau], [hoatDong]) VALUES (N'NV010     ', N'tranvanhai                    ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 1)
GO
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC01     ', N'Pentaxim', N'Pháp', N'0.5ml', 1, N'LV004     ', N'LTC01     ', N'PB005     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC02     ', N'Infanrix Hexa', N'Bỉ', N'0.5ml', 1, N'LV002     ', N'LTC01     ', N'PB001     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC03     ', N'Hexaxim', N'Pháp', N'0.5ml', 1, N'LV003     ', N'LTC01     ', N'PB006     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC04     ', N'Gene Hbvax', N'Việt Nam', N'1.0ml', 1, N'LV002     ', N'LTC01     ', N'PB002     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC05     ', N'Heberbiovac', N'Cuba', N'0.5ml', 1, N'LV002     ', N'LTC01     ', N'PB003     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC06     ', N'MMR II', N'Mỹ', N'0.5ml', 1, N'LV001     ', N'LTC02     ', N'PB004     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC07     ', N'Priorix', N'Bỉ', N'0.5ml', 1, N'LV001     ', N'LTC02     ', N'PB006     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC08     ', N'MVVac', N'Việt Nam', N'0.5ml', 1, N'LV001     ', N'LTC02     ', N'PB007     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC09     ', N'Vaxigrip Tetra', N'Pháp', N'0.5ml', 1, N'LV005     ', N'LTC01     ', N'PB007     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC10     ', N'Influvac Tetra', N'Hà Lan', N'0.5ml', 1, N'LV005     ', N'LTC02     ', N'PB008     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC11     ', N'Vaxigrip', N'Pháp', N'0.5ml', 1, N'LV005     ', N'LTC03     ', N'PB005     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC12     ', N'Ivacflu-S', N'Việt Nam', N'0.5ml', 1, N'LV005     ', N'LTC03     ', N'PB001     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC13     ', N'Abhayrab', N'Ấn Độ', N'0.5ml', 1, N'LV009     ', N'LTC01     ', N'PB001     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC14     ', N'Adacel', N'Canada', N'1.0ml', 1, N'LV004     ', N'LTC02     ', N'PB002     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC15     ', N'Boostrix', N'Bỉ', N'0.5ml', 1, N'LV004     ', N'LTC02     ', N'PB004     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC16     ', N'Vivotif', N'Mỹ', N'1.0ml', 1, N'LV008     ', N'LTC10     ', N'PB008     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC17     ', N'Fluarix', N'Bỉ', N'0.5ml', 1, N'LV005     ', N'LTC03     ', N'PB005     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC18     ', N'Tetraxim', N'Pháp', N'0.3ml', 1, N'LV003     ', N'LTC01     ', N'PB009     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC19     ', N'Twinrix', N'Bỉ', N'0.1ml', 1, N'LV002     ', N'LTC01     ', N'PB003     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC20     ', N'Havax', N'Việt Nam', N'0.5ml', 1, N'LV002     ', N'LTC01     ', N'PB010     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC21     ', N'Covid 19', N'VN', N'0.5 ml', 0, N'LV001     ', N'LTC01     ', N'PB002     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC22     ', N'Pentaxim', N'Pháp', N'0.5 ml', 0, N'LV003     ', N'LTC02     ', N'PB003     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC23     ', N'Pentaxim', N'Pháp', N'0.5 ml', 0, N'LV002     ', N'LTC02     ', N'PB003     ')
INSERT [dbo].[Vaccine] ([maVaccine], [tenVaccine], [nguonGoc], [lieuLuong], [tinhTrang], [maLoai], [maLoaiTiemChung], [maPhongNgua]) VALUES (N'VAC24     ', N'Pentaxim', N'Pháp', N'0.5 ml', 0, N'LV003     ', N'LTC01     ', N'PB003     ')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_email]    Script Date: 12/17/2024 12:56:13 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ_email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_sDT]    Script Date: 12/17/2024 12:56:13 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ_sDT] UNIQUE NONCLUSTERED 
(
	[sDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CT_PhieuNhap]  WITH CHECK ADD FOREIGN KEY([maPhieu])
REFERENCES [dbo].[PhieuNhap] ([maPhieu])
GO
ALTER TABLE [dbo].[CT_PhieuNhap]  WITH CHECK ADD FOREIGN KEY([maLo])
REFERENCES [dbo].[LoVaccine] ([maLo])
GO
ALTER TABLE [dbo].[DapAn]  WITH CHECK ADD FOREIGN KEY([maCauHoi])
REFERENCES [dbo].[CauHoiSangLoc] ([maCauHoi])
GO
ALTER TABLE [dbo].[GoiVaccine]  WITH CHECK ADD  CONSTRAINT [FK__GoiVaccin__maKhu__73BA3083] FOREIGN KEY([maKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([maKhuyenMai])
GO
ALTER TABLE [dbo].[GoiVaccine] CHECK CONSTRAINT [FK__GoiVaccin__maKhu__73BA3083]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([maPhieuKham])
REFERENCES [dbo].[PhieuKhamSangLoc] ([maPhieuKham])
GO
ALTER TABLE [dbo].[KeHoachTiemChung]  WITH CHECK ADD FOREIGN KEY([maPhongNgua])
REFERENCES [dbo].[PhongNgua] ([maPhongNgua])
GO
ALTER TABLE [dbo].[KeHoachTiemChung]  WITH CHECK ADD FOREIGN KEY([maVaccine])
REFERENCES [dbo].[Vaccine] ([maVaccine])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([maNguoiGiamHo])
REFERENCES [dbo].[NguoiGiamHo] ([maNguoiGiamHo])
GO
ALTER TABLE [dbo].[LichSuTiemChung]  WITH CHECK ADD  CONSTRAINT [FK__LichSuTie__maLic__787EE5A0] FOREIGN KEY([maLichTiemChung])
REFERENCES [dbo].[LichTiemChung] ([maLichTiemChung])
GO
ALTER TABLE [dbo].[LichSuTiemChung] CHECK CONSTRAINT [FK__LichSuTie__maLic__787EE5A0]
GO
ALTER TABLE [dbo].[LichSuTiemChung]  WITH CHECK ADD  CONSTRAINT [FK__LichSuTie__maNha__797309D9] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[LichSuTiemChung] CHECK CONSTRAINT [FK__LichSuTie__maNha__797309D9]
GO
ALTER TABLE [dbo].[LichTiemChung]  WITH CHECK ADD FOREIGN KEY([maKeHoach])
REFERENCES [dbo].[KeHoachTiemChung] ([maKeHoach])
GO
ALTER TABLE [dbo].[LichTiemChung]  WITH CHECK ADD FOREIGN KEY([maKhachHang])
REFERENCES [dbo].[KhachHang] ([maKhachHang])
GO
ALTER TABLE [dbo].[LichTiemChung]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD FOREIGN KEY([maChucVu])
REFERENCES [dbo].[ChucVu] ([maChucVu])
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD FOREIGN KEY([tenDangNhap])
REFERENCES [dbo].[TaiKhoan] ([tenDangNhap])
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD FOREIGN KEY([maChucVu])
REFERENCES [dbo].[ChucVu] ([maChucVu])
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD FOREIGN KEY([maManHinh])
REFERENCES [dbo].[DanhMucManHinh] ([maManHinh])
GO
ALTER TABLE [dbo].[PhieuKham_GoiVacXin]  WITH CHECK ADD  CONSTRAINT [FK__PhieuKham__maGoi__01142BA1] FOREIGN KEY([maGoi])
REFERENCES [dbo].[GoiVaccine] ([maGoi])
GO
ALTER TABLE [dbo].[PhieuKham_GoiVacXin] CHECK CONSTRAINT [FK__PhieuKham__maGoi__01142BA1]
GO
ALTER TABLE [dbo].[PhieuKham_GoiVacXin]  WITH CHECK ADD FOREIGN KEY([maPhieuKham])
REFERENCES [dbo].[PhieuKhamSangLoc] ([maPhieuKham])
GO
ALTER TABLE [dbo].[PhieuKham_VacXin]  WITH CHECK ADD FOREIGN KEY([maPhieuKham])
REFERENCES [dbo].[PhieuKhamSangLoc] ([maPhieuKham])
GO
ALTER TABLE [dbo].[PhieuKham_VacXin]  WITH CHECK ADD FOREIGN KEY([maVaccine])
REFERENCES [dbo].[Vaccine] ([maVaccine])
GO
ALTER TABLE [dbo].[PhieuKhamSangLoc]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[PhieuKhamSangLoc]  WITH CHECK ADD FOREIGN KEY([maPhieuDangKy])
REFERENCES [dbo].[ThongTinDangKy] ([maPhieuDangKy])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD FOREIGN KEY([maNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([maNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[PhieuTheoDoi]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[ThongTinDangKy]  WITH CHECK ADD FOREIGN KEY([maKhachHang])
REFERENCES [dbo].[KhachHang] ([maKhachHang])
GO
ALTER TABLE [dbo].[ThongTinDangKy]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[TT_CTVaccine]  WITH CHECK ADD  CONSTRAINT [FK__TT_CTVacc__maVac__0D7A0286] FOREIGN KEY([maVaccine])
REFERENCES [dbo].[Vaccine] ([maVaccine])
GO
ALTER TABLE [dbo].[TT_CTVaccine] CHECK CONSTRAINT [FK__TT_CTVacc__maVac__0D7A0286]
GO
ALTER TABLE [dbo].[TT_CTVaccine]  WITH CHECK ADD  CONSTRAINT [FK__TT_CTVacci__maLo__0E6E26BF] FOREIGN KEY([maLo])
REFERENCES [dbo].[LoVaccine] ([maLo])
GO
ALTER TABLE [dbo].[TT_CTVaccine] CHECK CONSTRAINT [FK__TT_CTVacci__maLo__0E6E26BF]
GO
ALTER TABLE [dbo].[Vaccine]  WITH CHECK ADD FOREIGN KEY([maLoai])
REFERENCES [dbo].[LoaiVaccine] ([maLoai])
GO
ALTER TABLE [dbo].[Vaccine]  WITH CHECK ADD FOREIGN KEY([maLoaiTiemChung])
REFERENCES [dbo].[LoaiTiemChung] ([maLoaiTiemChung])
GO
ALTER TABLE [dbo].[Vaccine]  WITH CHECK ADD FOREIGN KEY([maPhongNgua])
REFERENCES [dbo].[PhongNgua] ([maPhongNgua])
GO
ALTER TABLE [dbo].[Vaccine_GoiVaccine]  WITH CHECK ADD  CONSTRAINT [FK__Vaccine_G__maGoi__123EB7A3] FOREIGN KEY([maGoi])
REFERENCES [dbo].[GoiVaccine] ([maGoi])
GO
ALTER TABLE [dbo].[Vaccine_GoiVaccine] CHECK CONSTRAINT [FK__Vaccine_G__maGoi__123EB7A3]
GO
ALTER TABLE [dbo].[Vaccine_GoiVaccine]  WITH CHECK ADD FOREIGN KEY([maVaccine])
REFERENCES [dbo].[Vaccine] ([maVaccine])
GO
ALTER TABLE [dbo].[LoVaccine]  WITH CHECK ADD  CONSTRAINT [chk_GiaNhap] CHECK  (([giaNhap]>(0)))
GO
ALTER TABLE [dbo].[LoVaccine] CHECK CONSTRAINT [chk_GiaNhap]
GO
ALTER TABLE [dbo].[LoVaccine]  WITH CHECK ADD  CONSTRAINT [chk_SoLuongVaccine] CHECK  (([soLuongVaccine]>(0)))
GO
ALTER TABLE [dbo].[LoVaccine] CHECK CONSTRAINT [chk_SoLuongVaccine]
GO
/****** Object:  Trigger [dbo].[Trig_CheckNgaySanXuatHanSuDung]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Trig_CheckNgaySanXuatHanSuDung]
ON [dbo].[LoVaccine]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra dữ liệu trong bảng inserted
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE ngaySanXuat > GETDATE() 
           OR hanSuDung <= GETDATE()
           OR ngaySanXuat >= hanSuDung
    )
    BEGIN
        -- Nếu phát hiện vi phạm, trả về lỗi và hủy giao dịch
        RAISERROR ('Dữ liệu không hợp lệ: ngaySanXuat phải nhỏ hơn hoặc bằng ngày hiện tại, hanSuDung phải lớn hơn ngày hiện tại và ngaySanXuat phải nhỏ hơn hanSuDung.', 16, 1);
        ROLLBACK;
    END
END;
GO
ALTER TABLE [dbo].[LoVaccine] ENABLE TRIGGER [Trig_CheckNgaySanXuatHanSuDung]
GO
/****** Object:  Trigger [dbo].[Trig_KiemTraVaccine]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Trig_KiemTraVaccine]
ON [dbo].[PhieuKham_VacXin]
AFTER INSERT
AS
BEGIN
    DECLARE @maPhieuKham CHAR(10);
    DECLARE @maKhachHang CHAR(10);

    -- Lấy mã phiếu khám từ bảng PhieuKham_VacXin
    SELECT @maPhieuKham = maPhieuKham FROM inserted;

    -- Lấy mã khách hàng liên quan đến phiếu khám
    SELECT @maKhachHang = maKhachHang
    FROM LichTiemChung
    WHERE maLichTiemChung = (SELECT maLichTiemChung FROM PhieuKhamSangLoc WHERE maPhieuKham = @maPhieuKham);

    -- Kiểm tra số lượng vaccine mà khách hàng đã mua trong phiếu khám này
    DECLARE @soLuongVaccine INT;
    SELECT @soLuongVaccine = COUNT(*) 
    FROM PhieuKham_VacXin
    WHERE maPhieuKham = @maPhieuKham
    AND maVaccine IN (SELECT maVaccine FROM PhieuKham_VacXin WHERE maPhieuKham = @maPhieuKham);

    -- Kiểm tra nếu khách hàng đã mua hơn 5 vaccine
    IF @soLuongVaccine > 5
    BEGIN
        RAISERROR('Khách hàng chỉ được mua tối đa 5 vaccine cho mỗi hóa đơn!', 16, 1);
        ROLLBACK;
    END
END;
GO
ALTER TABLE [dbo].[PhieuKham_VacXin] ENABLE TRIGGER [Trig_KiemTraVaccine]
GO
/****** Object:  Trigger [dbo].[trg_UpdatePackageTotal]    Script Date: 12/17/2024 12:56:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdatePackageTotal]
ON [dbo].[Vaccine_GoiVaccine]
AFTER INSERT
AS
BEGIN
    DECLARE @maGoi CHAR(10), @maVaccine CHAR(10), @soLuong INT, @giaBan DECIMAL(18, 2);
    SELECT @maGoi = maGoi, @maVaccine = maVaccine, @soLuong = soLuong FROM inserted;
    
    SELECT @giaBan = giaBan FROM TT_CTVaccine WHERE maVaccine = @maVaccine;
    
    UPDATE GoiVaccine
    SET tongTienGoi = tongTienGoi + (@giaBan * @soLuong)
    WHERE maGoi = @maGoi;
END;
GO
ALTER TABLE [dbo].[Vaccine_GoiVaccine] ENABLE TRIGGER [trg_UpdatePackageTotal]
GO
