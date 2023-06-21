USE master
GO

CREATE DATABASE Flyke

GO
ALTER DATABASE Flyke SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC Flyke.dbo.sp_fulltext_database @action = 'enable'
end
GO
ALTER DATABASE Flyke SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE Flyke SET ANSI_NULLS OFF 
GO
ALTER DATABASE Flyke SET ANSI_PADDING OFF 
GO
ALTER DATABASE Flyke SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE Flyke SET ARITHABORT OFF 
GO
ALTER DATABASE Flyke SET AUTO_CLOSE OFF 
GO
ALTER DATABASE Flyke SET AUTO_SHRINK OFF 
GO
ALTER DATABASE Flyke SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE Flyke SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE Flyke SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE Flyke SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE Flyke SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE Flyke SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE Flyke SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE Flyke SET  ENABLE_BROKER 
GO
ALTER DATABASE Flyke SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE Flyke SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE Flyke SET TRUSTWORTHY OFF 
GO
ALTER DATABASE Flyke SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE Flyke SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE Flyke SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE Flyke SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE Flyke SET RECOVERY FULL 
GO
ALTER DATABASE Flyke SET  MULTI_USER 
GO
ALTER DATABASE Flyke SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE Flyke SET DB_CHAINING OFF 
GO
ALTER DATABASE Flyke SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE Flyke SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE Flyke SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE Flyke SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Flyke', N'ON'
GO
ALTER DATABASE Flyke SET QUERY_STORE = OFF
GO
USE Flyke
GO
/****** Object:  Table BANGTHAMSO     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE BANGTHAMSO(
	TenThamSo text NOT NULL,
	GiaTri int NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table CHUYENBAY    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE CHUYENBAY(
	MaChuyenBay varchar(10) NOT NULL,
	SanBayDi nvarchar(50) NOT NULL,
	SanBayDen nvarchar(50) NOT NULL,
	NgayKhoiHanh nvarchar(50) NOT NULL,
	ThoiGianXuatPhat nvarchar(50) NOT NULL,
	ThoiGianDuKien nvarchar(50) NOT NULL,
	MaHangMayBay varchar(10) NOT NULL,
	LoaiMayBay varchar(50) NOT NULL,
	Gia varchar(50) NULL,
PRIMARY KEY CLUSTERED 
(
	MaChuyenBay ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table CTHD     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE CTHD(
	MaCTHD varchar(10) NOT NULL,
	MaHD varchar(10) NOT NULL,
	MaVe varchar(20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	MaCTHD ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table HANGMAYBAY   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE HANGMAYBAY(
	MaHang varchar(10) NOT NULL,
	TenHang nvarchar(50) NOT NULL,
	Logo text NULL,
PRIMARY KEY CLUSTERED 
(
	MaHang ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table HANGVE  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE HANGVE(
	MaHangVe varchar(10) NOT NULL,
	TenHangVe nvarchar(50) NOT NULL,
	TyLe varchar(4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	MaHangVe ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table dbo.BaoCaoNam ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.BaoCaoNam(
	Thang varchar(3) NOT NULL,
	SoChuyenBay int NULL,
	DoanhThu varchar(50) NULL,
	Tyle varchar(50) NULL,
	Nam varchar(5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table dbo.BaoCaoThang   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.BaoCaoThang(
	MaChuyenBay varchar(50) NOT NULL,
	SoVeDaBan int NULL,
	DoanhThu varchar(50) NULL,
	TyLe varchar(50) NULL,
	Thang varchar(3) NOT NULL,
	Nam varchar(5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table HOADON  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE HOADON(
	MaHD varchar(10) NOT NULL,
	NgayLap datetime NOT NULL,
	ThanhTien int NULL,
	TinhTrang varchar(30) NULL,
	MaTK varchar(20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	MaHD ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table QuanLyHangVeChuyenBay  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE QuanLyHangVeChuyenBay(
	MaChuyenBay varchar(10) NOT NULL,
	MaHangVe varchar(10) NOT NULL,
	SoLuong varchar(4) NULL,
PRIMARY KEY CLUSTERED 
(
	MaChuyenBay ASC,
	MaHangVe ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table SANBAY  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SANBAY(
	MaSanBay varchar(10) NOT NULL,
	TenSanBay nvarchar(50) NOT NULL,
	Tinh nvarchar(50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	MaSanBay ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table SANBAYTRUNGGIAN   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SANBAYTRUNGGIAN(
	SanBayTrungGian nvarchar(50) NOT NULL,
	MaChuyenBay varchar(10) NOT NULL,
	ThoiGianDung nvarchar(50) NOT NULL,
	GhiChu nvarchar(100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table TAIKHOAN  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE TAIKHOAN(
	MaTK varchar(20) NOT NULL,
	TenDangNhap varchar(100) NOT NULL,
	MatKhau varchar(10) NOT NULL,
	Loai int NOT NULL,
	Email varchar(50) NULL,
	TenHienThi varchar(50) NULL,
PRIMARY KEY CLUSTERED 
(
	MaTK ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table VE  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE VE(
	MaVe varchar(20) NOT NULL,
	MaChuyenBay varchar(10) NOT NULL,
	SoGhe varchar(10) NOT NULL,
	MaHK varchar(10) NULL,
	TenHK nvarchar(100) NULL,
	SDT varchar(11) NULL,
	CMND varchar(9) NULL,
	TinhTrang nvarchar(20) NOT NULL,
	MaHangVe varchar(10) NOT NULL,
	GiaVe int null,
PRIMARY KEY CLUSTERED 
(
	MaVe ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'ThoiGianBayToiThieu', 30)
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'SoSanBayTrungGianToiDa', 2)
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'ThoiGianDungToiThieu', 10)
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'ThoiGianDungToiDa', 20)
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'ThoiGianChamNhatChoPhepDatVe', 24)
INSERT BANGTHAMSO (TenThamSo, GiaTri) VALUES (N'ThoiGianChamNhatChoPhepHuyVe', 24)
GO
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'QH101', N'SGN', N'HAN', N'02/04/2023', N'23:40', N'130', N'QH', N'BOEING', N'1800000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'QH001', N'SGN', N'HAN', N'02/08/2023', N'23:40', N'130', N'QH', N'BOEING', N'1800000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'QH002', N'SGN', N'HUI', N'02/08/2023', N'19:10', N'95', N'QH', N'BOEING', N'1200000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'QH003', N'HAN', N'VDO', N'02/07/2023', N'12:45', N'485', N'QH', N'BOEING', N'3800000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VJ001', N'SGN', N'HAN', N'02/07/2023', N'06:00', N'130', N'VJ', N'BOEING', N'1600000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VJ002', N'SGN', N'HAN', N'02/07/2023', N'18:00', N'130', N'VJ', N'BOEING', N'1700000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VJ003', N'HAN', N'VDO', N'02/07/2023', N'07:00', N'830', N'VJ', N'BOEING', N'3300000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VJ004', N'HAN', N'PQC', N'28/06/2023', N'18:15', N'130', N'VJ', N'BOEING', N'1400000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VJ005', N'HAN', N'PQC', N'28/06/2023', N'06:00', N'125', N'VJ', N'BOEING', N'1500000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN001', N'SGN', N'HAN', N'02/07/2023', N'05:00', N'135', N'VNA', N'BOEING', N'1900000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN002', N'SGN', N'HUI', N'02/07/2023', N'13:05', N'90', N'VNA', N'BOEING', N'1800000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN003', N'HAN', N'PQC', N'27/05/2023', N'07:35', N'120', N'VNA', N'BOEING', N'1700000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN004', N'CXR', N'DAD', N'27/05/2023', N'09:05', N'70', N'VNA', N'BOEING', N'1200000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN005', N'CXR', N'DAD', N'27/04/2023', N'09:05', N'70', N'VNA', N'BOEING', N'2200000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN006', N'HUI', N'DAD', N'23/03/2023', N'09:05', N'70', N'VNA', N'BOEING', N'2200000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN007', N'HUI', N'DAD', N'22/03/2023', N'19:05', N'70', N'VNA', N'BOEING', N'2400000')
--INSERT CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia) VALUES (N'VN008', N'HUI', N'DAD', N'22/03/2023', N'10:05', N'70', N'VNA', N'BOEING', N'2400000')

--GO
--INSERT HANGMAYBAY (MaHang, TenHang, Logo) VALUES (N'BL', N'Jetstar Pacific Airlines', N'/resources/images/logo_Jetstar.png')
--INSERT HANGMAYBAY (MaHang, TenHang, Logo) VALUES (N'QH', N'Bamboo Airways', N'/resources/images/logo_Bamboo.png')
--INSERT HANGMAYBAY (MaHang, TenHang, Logo) VALUES (N'VJ', N'Vietjet Air', N'/resources/images/logo_Vietjet.png')
--INSERT HANGMAYBAY (MaHang, TenHang, Logo) VALUES (N'VNA', N'VietNam Airlines', N'/resources/images/logo_VNA.png')
--GO
--INSERT HANGVE (MaHangVe, TenHangVe, TyLe) VALUES (N'HV229365', N'Hạng Thương gia', N'100')
--INSERT HANGVE (MaHangVe, TenHangVe, TyLe) VALUES (N'HV643717', N'Hạng Phổ thông', N'105')
--GO
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN008', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN007', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN006', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN005', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH101', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH101', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH001', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH001', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH002', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH002', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH003', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'QH003', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ001', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ001', N'HV643717', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ002', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ002', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ003', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ003', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ004', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ004', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ005', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VJ005', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN001', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN001', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN002', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN002', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN003', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN003', N'HV643717', N'18')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN004', N'HV229365', N'12')
--INSERT QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong) VALUES (N'VN004', N'HV643717', N'18')
--GO
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'CXR', N'San bay Quoc te Cam Ranh', N'Khanh Hoa')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'DAD', N'San bay Quoc te Da Nang', N'Da Nang')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'HAN', N'San bay Quoc te Noi Bai', N'Ha Noi')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'HND', N'San bay Quoc te Tokyo', N'Tokyo')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'HUI', N'San bay Quoc te Phu Bai', N'Thua Thien Hue')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'ICN', N'San bay Quoc te Incheon', N'Seoul')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'ITM', N'San bay Quoc te Osaka', N'Tokyo')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'PQC', N'San bay Quoc te Phu Quoc', N'Phu Quoc')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'SGN', N'San bay Quoc te Tan Son Nhat', N'Ho Chi Minh')
--INSERT SANBAY (MaSanBay, TenSanBay, Tinh) VALUES (N'VDO', N'San bay Quoc te Van Don', N'Quang Ninh')
--GO
--INSERT SANBAYTRUNGGIAN (SanBayTrungGian, MaChuyenBay, ThoiGianDung, GhiChu) VALUES (N'SGN', N'VJ003', N'570', N'KHONG CO')
--INSERT SANBAYTRUNGGIAN (SanBayTrungGian, MaChuyenBay, ThoiGianDung, GhiChu) VALUES (N'SGN', N'QH003', N'220', N'KHONG CO')

INSERT INTO CHUYENBAY (MaChuyenBay, SanBayDi, SanBayDen, NgayKhoiHanh, ThoiGianXuatPhat, ThoiGianDuKien, MaHangMayBay, LoaiMayBay, Gia)
VALUES ('CB001', 'Hanoi', 'Ho Chi Minh City', '2023-06-21', '08:00', '10:30', 'HMB001', 'Airbus A320', '1000000'),
       ('CB002', 'Ho Chi Minh City', 'Da Nang', '2023-06-22', '14:30', '16:15', 'HMB002', 'Boeing 737', '800000'),
       ('CB003', 'Da Nang', 'Hanoi', '2023-06-23', '09:45', '11:30', 'HMB003', 'Airbus A321', '900000');
GO

INSERT INTO CTHD (MaCTHD, MaHD, MaVe)
VALUES ('CT001', 'HD001', 'VE001'),
       ('CT002', 'HD002', 'VE002'),
       ('CT003', 'HD002', 'VE003');
GO

INSERT INTO HANGMAYBAY (MaHang, TenHang, Logo)
VALUES ('HMB001', 'Vietnam Airlines', 'logo_vna.png'),
       ('HMB002', 'Jetstar Pacific', 'logo_jetstar.png'),
       ('HMB003', 'VietJet Air', 'logo_vietjet.png');
GO

INSERT INTO HANGVE (MaHangVe, TenHangVe, TyLe)
VALUES ('HV001', 'Hạng thương gia', '30%'),
       ('HV002', 'Hạng phổ thông', '70%');
GO

INSERT INTO BaoCaoNam (Thang, SoChuyenBay, DoanhThu, Tyle, Nam)
VALUES ('01', 10, '50000000', '10%', '2022'),
       ('02', 12, '60000000', '12%', '2022'),
       ('03', 15, '75000000', '15%', '2022');
GO

INSERT INTO BaoCaoThang (MaChuyenBay, SoVeDaBan, DoanhThu, TyLe, Thang, Nam)
VALUES ('CB001', 50, '25000000', '50%', '01', '2022'),
       ('CB002', 60, '30000000', '60%', '01', '2022'),
       ('CB003', 70, '35000000', '70%', '01', '2022');
GO

INSERT INTO HOADON (MaHD, NgayLap, ThanhTien, TinhTrang, MaTK)
VALUES ('HD001', '2023-06-21', 1500000, 'Đã thanh toán', 'TK001'),
       ('HD002', '2023-06-22', 1600000, 'Chưa thanh toán', 'TK002'),
       ('HD003', '2023-06-23', 1700000, 'Chưa thanh toán', 'TK003');
GO

INSERT INTO QuanLyHangVeChuyenBay (MaChuyenBay, MaHangVe, SoLuong)
VALUES ('CB001', 'HV001', '20'),
       ('CB001', 'HV002', '100'),
       ('CB002', 'HV001', '30');
GO

INSERT INTO SANBAY (MaSanBay, TenSanBay, Tinh)
VALUES ('SB001', 'Noi Bai International Airport', 'Hanoi'),
       ('SB002', 'Tan Son Nhat International Airport', 'Ho Chi Minh City'),
       ('SB003', 'Da Nang International Airport', 'Da Nang');
GO

INSERT INTO SANBAYTRUNGGIAN (SanBayTrungGian, MaChuyenBay, ThoiGianDung, GhiChu)
VALUES ('SB002', 'CB001', '01:30', 'Đợi hành khách'),
       ('SB003', 'CB001', '02:00', 'Đổi máy bay'),
       ('SB001', 'CB002', '01:00', 'Nghỉ ngơi');
GO

INSERT TAIKHOAN (MaTK, TenDangNhap, MatKhau, Loai, Email, TenHienThi) VALUES (N'TK001', N'admin', N'admin', 1, N'ledoantantri@gmail.com', N'Admin')
INSERT TAIKHOAN (MaTK, TenDangNhap, MatKhau, Loai, Email, TenHienThi) VALUES (N'TK002', N'user1', N'user1', 2, N'user1@gmail.com', N'User 1')
GO

INSERT INTO VE (MaVe, MaChuyenBay, SoGhe, MaHK, TenHK, SDT, CMND, TinhTrang, MaHangVe, GiaVe)
VALUES ('VE001', 'CB001', 'A1', 'HK001', 'Nguyen Van A', '0912345678', '123456789', 'Đã xuất vé', 'HV001', 1000000),
       ('VE002', 'CB002', 'B2', 'HK002', 'Tran Thi B', '0987654321', '987654321', 'Chưa xuất vé', 'HV002', 800000),
       ('VE003', 'CB002', 'C3', 'HK003', 'Le Van C', '0909090909', '555555555', 'Chưa xuất vé', 'HV002', 800000);
GO

ALTER TABLE CHUYENBAY  WITH CHECK ADD FOREIGN KEY(MaHangMayBay)
REFERENCES HANGMAYBAY (MaHang)
GO
ALTER TABLE CHUYENBAY  WITH CHECK ADD FOREIGN KEY(MaHangMayBay)
REFERENCES HANGMAYBAY (MaHang)
GO
ALTER TABLE CTHD  WITH CHECK ADD FOREIGN KEY(MaHD)
REFERENCES HOADON (MaHD)
GO
ALTER TABLE CTHD  WITH CHECK ADD FOREIGN KEY(MaHD)
REFERENCES HOADON (MaHD)
GO
ALTER TABLE CTHD  WITH CHECK ADD FOREIGN KEY(MaVe)
REFERENCES VE (MaVe)
GO
ALTER TABLE CTHD  WITH CHECK ADD FOREIGN KEY(MaVe)
REFERENCES VE (MaVe)
GO
ALTER TABLE HOADON  WITH CHECK ADD FOREIGN KEY(MaTK)
REFERENCES TAIKHOAN (MaTK)
GO
ALTER TABLE HOADON  WITH CHECK ADD FOREIGN KEY(MaTK)
REFERENCES TAIKHOAN (MaTK)
GO
ALTER TABLE QuanLyHangVeChuyenBay  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE QuanLyHangVeChuyenBay  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE QuanLyHangVeChuyenBay  WITH CHECK ADD FOREIGN KEY(MaHangVe)
REFERENCES HANGVE (MaHangVe)
GO
ALTER TABLE QuanLyHangVeChuyenBay  WITH CHECK ADD FOREIGN KEY(MaHangVe)
REFERENCES HANGVE (MaHangVe)
GO
ALTER TABLE SANBAYTRUNGGIAN  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE SANBAYTRUNGGIAN  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE VE  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE VE  WITH CHECK ADD FOREIGN KEY(MaChuyenBay)
REFERENCES CHUYENBAY (MaChuyenBay)
GO
ALTER TABLE VE  WITH CHECK ADD FOREIGN KEY(MaHangVe)
REFERENCES HANGVE (MaHangVe)
GO
ALTER TABLE VE  WITH CHECK ADD FOREIGN KEY(MaHangVe)
REFERENCES HANGVE (MaHangVe)
GO
USE master
GO
ALTER DATABASE Flyke SET  READ_WRITE 
GO

