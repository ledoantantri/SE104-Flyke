USE MASTER
GO

DROP DATABASE IF EXISTS FLYKE
GO

CREATE DATABASE FLYKE
GO

USE FLYKE
GO

SET DATEFORMAT DMY
GO

CREATE TABLE THAMSO
(
	TenThamSo VARCHAR(50),
	GiaTri INT
)
GO

INSERT THAMSO (TenThamSo, GiaTri) VALUES ('ThoiGianBayToiThieu', 30)
INSERT THAMSO (TenThamSo, GiaTri) VALUES ('SoSanBayTrungGianToiDa', 2)
INSERT THAMSO (TenThamSo, GiaTri) VALUES ('ThoiGianDungToiThieu', 10)
INSERT THAMSO (TenThamSo, GiaTri) VALUES ('ThoiGianDungToiDa', 20)
INSERT THAMSO (TenThamSo, GiaTri) VALUES ('ThoiGianDatVeChamNhat', 24)
INSERT THAMSO (TenThamSo, GiaTri) VALUES ('ThoiGianHuyPhieuDat', 24)
GO

CREATE TABLE QUOCGIA
(
	MaQuocGia CHAR(2) PRIMARY KEY,
	TenQuocGia NVARCHAR(100)
)
GO

INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('VN', N'Việt Nam')
INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('US', N'Mỹ')
INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('CN', N'Trung Quốc')
INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('JP', N'Nhật Bản')
INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('KR', N'Hàn Quốc')
INSERT QUOCGIA (MaQuocGia, TenQuocGia) VALUES ('TH', N'Thái Lan')
GO

CREATE TABLE SANBAY
(
	MaSanBay CHAR(3) PRIMARY KEY,
	TenSanBay NVARCHAR(100),
	DiaChi NVARCHAR(100),
	MaQuocGia CHAR(2) FOREIGN KEY REFERENCES QUOCGIA (MaQuocGia)
)

INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('SGN', N'Sân bay Quốc tế Tân Sơn Nhất', N'Quận Tân Bình, thành phố Hồ Chí Minh', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('HAN', N'Sân bay Quốc tế Nội Bài', N'Huyện Sóc Sơn, thành phố Hà Nội', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('DAD', N'Sân bay Quốc tế Đà Nẵng', N'Quận Hải Châu, thành phố Đà Nẵng', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('HPH', N'Sân bay Quốc tế Cát Bi', N'Quận Hải An, thành phố Hải Phòng', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('VCA', N'Sân bay Quốc tế Cần Thơ', N'Quận Bình Thuỷ, thành phố Cần Thơ', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('CXR', N'Sân bay Quốc tế Cam Ranh', N'Thành phố Cam Ranh, tỉnh Khánh Hoà', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('PQC', N'Sân bay Quốc tế Phú Quốc', N'Thành phố Phú Quốc, tỉnh Kiên Giang', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('HUI', N'Sân bay Quốc tế Phú Bài', N'Thị xã Hương Thuỷ, tỉnh Thừa Thiên - Huế', 'VN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('JFK', N'Sân bay Quốc tế John F. Kennedy', N'Quận Queens, thành phố New York, tiểu bang New York', 'US')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('LAX', N'Sân bay Quốc tế Los Angeles', N'Thành phố Los Angeles, tiểu bang California', 'US')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('ORD', N'Sân bay Quốc tế O Hare', N'Thành phố Chicago, tiểu bang Illinois', 'US')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('PVG', N'Sân bay Quốc tế Phố Đông Thượng Hải', N'Quận Phố Đông, thành phố Thượng Hải', 'CN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('PEK', N'Sân bay Quốc tế Thủ Đô Bắc Kinh', N'Quận Triều Dương, thành phố Bắc Kinh', 'CN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('CAN', N'Sân bay Quốc tế Bạch Vân Quảng Châu', N'Thành phố Quảng Châu, tỉnh Quảng Đông', 'CN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('CTU', N'Sân bay Quốc tế Song Lưu Thành Đô', N'Thành phố Thành Đô, tỉnh Tứ Xuyên', 'CN')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('HND', N'Sân bay Quốc tế Tokyo', N'Ota, Tokyo', 'JP')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('KIX', N'Sân bay Quốc tế Kansai', N'Izumisano, Osaka', 'JP')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('NGO', N'Sân bay Quốc tế Chubu', N'Tokoname, Aichi', 'JP')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('NRT', N'Sân bay Quốc tế Narita', N'Narita, Chiba', 'JP')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('ICN', N'Sân bay Quốc tế Incheon', N'Thành phố Incheon', 'KR')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('PUS', N'Sân bay Quốc tế Gimhae', N'Quận Gangseo, thành phố Busan', 'KR')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('BKK', N'Sân bay Quốc tế Suvarnabhumi', N'Huyện Bang Phli, tỉnh Samut Prakan', 'TH')
INSERT SANBAY (MaSanBay, TenSanBay, DiaChi, MaQuocGia) VALUES ('CNX', N'Sân bay Quốc tế Chiang Mai', N'Thành phố Chiang Mai, tỉnh Chiang Mai', 'TH')
GO

CREATE TABLE TUYENBAY
(
	MaTuyenBay CHAR(4) PRIMARY KEY,
	MaQuocGiaDi CHAR(2) FOREIGN KEY REFERENCES QUOCGIA (MaQuocGia),
	MaQuocGiaDen CHAR(2) FOREIGN KEY REFERENCES QUOCGIA (MaQuocGia)
)
GO

INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNVN', 'VN', 'VN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNUS', 'VN', 'US')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('USVN', 'US', 'VN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNCN', 'VN', 'CN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('CNVN', 'CN', 'VN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNJP', 'VN', 'JP')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('JPVN', 'JP', 'VN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNKR', 'VN', 'KR')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('KRVN', 'KR', 'VN')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('VNTH', 'VN', 'TH')
INSERT TUYENBAY (MaTuyenBay, MaQuocGiaDi, MaQuocGiaDen) VALUES ('THVN', 'TH', 'VN')
GO

CREATE TABLE HANGHANGKHONG
(
	MaHangHangKhong CHAR(2) PRIMARY KEY,
	TenHangHangKhong VARCHAR(50),
	Logo VARCHAR(100)
)
GO

INSERT HANGHANGKHONG (MaHangHangKhong, TenHangHangKhong, Logo) VALUES ('VN', 'Vietnam Airlines', '/Images/logo_VietnamAirlines.png')
INSERT HANGHANGKHONG (MaHangHangKhong, TenHangHangKhong, Logo) VALUES ('VJ', 'VietJet Air', '/Images/logo_VietJetAir.png')
INSERT HANGHANGKHONG (MaHangHangKhong, TenHangHangKhong, Logo) VALUES ('QH', 'Bamboo Airways', '/Images/logo_BambooAirways.png')
INSERT HANGHANGKHONG (MaHangHangKhong, TenHangHangKhong, Logo) VALUES ('BL', 'Pacific Airlines', '/Images/logo_PacificAirlines.png')
INSERT HANGHANGKHONG (MaHangHangKhong, TenHangHangKhong, Logo) VALUES ('VU', 'Vietravel Airlines', '/Images/logo_VietravelAirlines.png')
GO

CREATE TABLE CHUYENBAY
(
	MaChuyenBay VARCHAR(6) PRIMARY KEY,
	GiaVe MONEY,
	MaSanBayDi CHAR(3) FOREIGN KEY REFERENCES SANBAY (MaSanBay),
	MaSanBayDen CHAR(3) FOREIGN KEY REFERENCES SANBAY (MaSanBay),
	MaTuyenBay CHAR(4) FOREIGN KEY REFERENCES TUYENBAY (MaTuyenBay),
	MaHangHangKhong CHAR(2) FOREIGN KEY REFERENCES HANGHANGKHONG (MaHangHangKhong),
	NgayGio DATETIME,
	ThoiLuong INT,
	SoGheTrong INT,
	SoGheDat INT
)
GO

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN251', 20000000, 'SGN', 'LAX', 'VNUS', 'VN', '06-07-2023 21:30:00', 18, 63, 37)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN468', 7000000, 'PEK', 'HAN', 'CNVN', 'VN', '06-07-2023 21:30:00', 9, 54, 46)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN470', 6500000, 'HND', 'HPH', 'JPVN', 'VN', '06-07-2023 22:00:00', 8, 65, 35)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU106', 4000000, 'DAD', 'CNX', 'VNTH', 'VU', '07-07-2023 10:00:00', 3, 82, 18)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU107', 3500000, 'BKK', 'VCA', 'THVN', 'VU', '07-07-2023 10:00:00', 2, 73, 27)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU108', 19000000, 'ORD', 'HAN', 'USVN', 'VU', '07-07-2023 10:15:00', 19, 72, 28)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU109', 4000000, 'HUI', 'CAN', 'VNCN', 'VU', '07-07-2023 10:30:00', 2, 86, 14)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU217', 1600000, 'HAN', 'SGN', 'VNVN', 'VU', '07-07-2023 10:30:00', 2, 26, 74)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VU218', 1600000, 'SGN', 'HAN', 'VNVN', 'VU', '07-07-2023 11:30:00', 2, 32, 68)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH203', 3900000, 'HAN', 'BKK', 'VNTH', 'QH', '07-07-2023 11:30:00', 3, 77, 23)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH518', 4000000, 'PQC', 'BKK', 'VNTH', 'QH', '08-07-2023 09:00:00', 1, 74, 26)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH520', 1800000, 'SGN', 'HAN', 'VNVN', 'QH', '08-07-2023 09:30:00', 2, 19, 81)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH524', 7000000, 'VCA', 'ICN', 'VNKR', 'QH', '08-07-2023 09:30:00', 4, 56, 44)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH1025', 20000000, 'ORD', 'HAN', 'USVN', 'QH', '09-07-2023 02:15:00', 21, 52, 48)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('QH1107', 20000000, 'JFK', 'SGN', 'USVN', 'QH', '09-07-2023 02:45:00', 20, 70, 30)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VJ415', 6400000, 'HPH', 'KIX', 'VNJP', 'VJ', '09-07-2023 08:30:00', 3, 31, 69)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VJ692', 21000000, 'SGN', 'LAX', 'VNUS', 'VJ', '09-07-2023 22:00:00', 19, 57, 43)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VJ1036', 6400000, 'PUS', 'SGN', 'KRVN', 'VJ', '10-07-2023 01:30:00', 4, 64, 36)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VJ1041', 400000, 'HAN', 'DAD', 'VNVN', 'VJ', '10-07-2023 05:30:00', 1, 43, 57)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VJ1042', 600000, 'DAD', 'VCA', 'VNVN', 'VJ', '10-07-2023 07:30:00', 1, 23, 77)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('BL184', 5500000, 'HAN', 'BKK', 'VNTH', 'BL', '10-07-2023 07:30:00', 4, 80, 20)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('BL225', 1100000, 'VCA', 'DAD', 'VNVN', 'BL', '10-07-2023 08:00:00', 1, 54, 46)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('BL226', 1000000, 'HUI', 'CXR', 'VNVN', 'BL', '10-07-2023 08:30:00', 1, 60, 40)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('BL393', 17500000, 'CXR', 'JFK', 'VNUS', 'BL', '12-07-2023 22:30:00', 16, 74, 26)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('BL398', 1900000, 'HAN', 'SGN', 'VNVN', 'BL', '14-07-2023 08:30:00', 2, 16, 84)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN957', 2000000, 'HAN', 'SGN', 'VNVN', 'VN', '15-07-2023 08:00:00', 2, 12, 88)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN1002', 2000000, 'SGN', 'HAN', 'VNVN', 'VN', '15-07-2023 11:30:00', 2, 34, 66)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN1033', 10500000, 'SGN', 'PEK', 'VNCN', 'VN', '15-07-2023 21:30:00', 6, 9, 91)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN1047', 18000000, 'VCA', 'ORD', 'VNUS', 'VN', '16-07-2023 20:00:00', 20, 71, 29)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN1069', 1000000, 'HPH', 'HUI', 'VNVN', 'VN', '17-07-2023 08:00:00', 1, 11, 89)

INSERT CHUYENBAY (MaChuyenBay, GiaVe, MaSanBayDi, MaSanBayDen, MaTuyenBay, MaHangHangKhong, NgayGio, ThoiLuong, SoGheTrong, SoGheDat)
VALUES ('VN1070', 500000, 'VCA', 'PQC', 'VNVN', 'VN', '17-07-2023 08:15:00', 1, 28, 72)
GO

CREATE TABLE CT_CHUYENBAY
(
	MaChuyenBay VARCHAR(6),
	MaSanBayTrungGian CHAR(3),
	ThoiGianDung INT,
	GhiChu NVARCHAR(200)

	PRIMARY KEY (MaChuyenBay, MaSanBayTrungGian),
	FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY (MaChuyenBay),
	FOREIGN KEY (MaSanBayTrungGian) REFERENCES SANBAY (MaSanBay)
)
GO

INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VN251', 'HND', 20, N'Quá cảnh 1 lần duy nhất ở Tokyo')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VU108', 'CTU', 18, N'Quá cảnh 1 lần duy nhất ở Thành Đô')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('QH524', 'CAN', 15, N'Quá cảnh 1 lần duy nhất ở Quảng Châu')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('QH1025', 'NGO', 20, N'Quá cảnh lần 1 ở Aichi')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('QH1025', 'PEK', 16, N'Quá cảnh lần 2 ở Bắc Kinh')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('QH1107', 'ICN', 18, N'Quá cảnh lần 1 ở Incheon')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('QH1107', 'CAN', 20, N'Quá cảnh lần 2 ở Quảng Châu')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VJ415', 'PVG', 15, N'Quá cảnh 1 lần duy nhất ở Thượng Hải')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VJ692', 'CAN', 17, N'Quá cảnh lần 1 ở Quảng Châu')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VJ692', 'NRT', 20, N'Quá cảnh lần 2 ở Chiba')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VJ1036', 'CAN', 16, N'Quá cảnh 1 lần duy nhất ở Quảng Châu')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('BL393', 'CTU', 18, N'Quá cảnh 1 lần duy nhất ở Thành Đô')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VN1033', 'KIX', 20, N'Quá cảnh 1 lần duy nhất ở Osaka')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VN1047', 'PUS', 18, N'Quá cảnh lần 1 ở Busan')
INSERT CT_CHUYENBAY (MaChuyenBay, MaSanBayTrungGian, ThoiGianDung, GhiChu) VALUES ('VN1047', 'HND', 15, N'Quá cảnh lần 2 ở Tokyo')
GO

CREATE TABLE HANHKHACH
(
	MaHanhKhach INT PRIMARY KEY IDENTITY,
	HoTen NVARCHAR(100),
	CCCD VARCHAR(50) UNIQUE,
	NgaySinh DATE,
	SDT VARCHAR(10),
	QuocTich NVARCHAR(50)
)
GO

INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Hà Nguyên Quân', '1234567790', '01-12-1962', '0123456789', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Đoàn Chính Thuần', '1234567890', '02-01-1977', '0123456788', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Sử Hoả Long', '1234567891', '03-11-1959', '0123456787', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Sử Hồng Thạch', '1234567892', '04-02-1980', '0123456786', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Dương Tuyết Di', '1234567893', '05-10-1982', '0123456785', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Lý Thu Thuỷ', '1234567894', '06-03-2001', '0123456784', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Thẩm Mạn Quyên', '1234567895', '07-09-1993', '0123456783', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Mộc Kiếm Bình', '1234567896', '08-04-1981', '0123456782', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Mộc Kiếm Thanh', '1234567897', '09-08-1984', '0123456781', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Chung Linh', '1234567898', '10-05-2000', '0123456780', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Trình Dao Gia', '1234567899', '11-07-1995', '0123456799', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Mạc Thanh Cốc', '1234567880', '12-01-1992', '0123456779', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Hồng Lăng Ba', '1234567870', '13-06-1986', '0123456769', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Tạ Tử Kỳ', '1234567860', '14-07-1989', '0123456759', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Lục Triển Nguyên', '1234567850', '15-05-1997', '0123456749', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Mã Ngọc', '1234567840', '16-08-1985', '0123456739', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Nguyễn Tinh Trúc', '1234567830', '17-04-1988', '0123456729', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Đinh Mẫn Quân', '1234567820', '18-09-1983', '0123456719', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Giang Văn Băng', '1234567810', '19-03-1999', '0123456709', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Tần Hồng Miên', '1234567800', '20-06-2002', '0123456989', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Phương Tư Dao', '1234567490', '21-02-1969', '0123456889', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Tô Thuyên', '1234567390', '31-05-1988', '0123456689', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Tăng Đình Đình', '1234567690', '27-02-1996', '0123456589', N'Việt Nam')
INSERT HANHKHACH (HoTen, CCCD, NgaySinh, SDT, QuocTich) VALUES (N'Đường Tuyết Liên', '1234567590', '29-10-1989', '0123456489', N'Việt Nam')
GO

CREATE TABLE HANGVE
(
	MaHangVe INT PRIMARY KEY IDENTITY,
	TenHangVe NVARCHAR(20),
	TiLeTinhDonGia FLOAT
)
GO

INSERT HANGVE (TenHangVe, TiLeTinhDonGia) VALUES (N'Hạng 1', 1.05)
INSERT HANGVE (TenHangVe, TiLeTinhDonGia) VALUES (N'Hạng 2', 1)
GO

CREATE TABLE CT_HANGVE
(
	MaCT_HangVe INT PRIMARY KEY IDENTITY,
	MaChuyenBay VARCHAR(6) FOREIGN KEY REFERENCES CHUYENBAY (MaChuyenBay),
	MaHangVe INT FOREIGN KEY REFERENCES HANGVE (MaHangVe),
	SoLuongGhe INT,
	SoGheTrong INT,
	SoGheDat INT
)
GO

INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN251', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN251', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN468', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN468', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN470', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN470', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU106', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU106', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU107', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU107', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU108', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU108', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU109', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU109', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU217', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU217', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU218', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VU218', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH203', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH203', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH518', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH518', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH520', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH520', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH524', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH524', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH1025', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH1025', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH1107', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('QH1107', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ415', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ415', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ692', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ692', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1036', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1036', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1041', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1041', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1042', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VJ1042', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL184', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL184', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL225', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL225', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL226', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL226', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL393', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL393', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL398', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('BL398', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN957', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN957', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1002', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1002', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1033', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1033', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1047', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1047', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1069', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1069', 2, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1070', 1, 50, 50, 0)
INSERT CT_HANGVE (MaChuyenBay, MaHangVe, SoLuongGhe, SoGheTrong, SoGheDat) VALUES ('VN1070', 2, 50, 50, 0)
GO

CREATE TABLE VE
(
	MaVe INT PRIMARY KEY IDENTITY,
	MaHanhKhach INT FOREIGN KEY REFERENCES HANHKHACH (MaHanhKhach),
	MaCT_HangVe INT FOREIGN KEY REFERENCES CT_HANGVE (MaCT_HangVe),
	GiaTien MONEY
)
GO

INSERT VE (MaHanhKhach, MaCT_HangVe, GiaTien) VALUES (1, 1, 20000000)
INSERT VE (MaHanhKhach, MaCT_HangVe, GiaTien) VALUES (2, 3, 7000000)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (3, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (4, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (5, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (6, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (7, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (8, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (9, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (10, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (11, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (12, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (13, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (14, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (15, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (16, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (17, 3)
INSERT VE (MaHanhKhach, MaCT_HangVe) VALUES (18, 3)
GO

CREATE TABLE PHIEUDATCHO
(
	MaPhieuDat INT PRIMARY KEY IDENTITY,
	MaHanhKhach INT FOREIGN KEY REFERENCES HANHKHACH (MaHanhKhach),
	MaCT_HangVe INT FOREIGN KEY REFERENCES CT_HANGVE (MaCT_HangVe),
	NgayXuatVe DATETIME,
	GiaTien MONEY,
	TinhTrang BIT
)
GO

INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, GiaTien, TinhTrang) VALUES (3, 1, '02-07-2023', 21000000, 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, GiaTien, TinhTrang) VALUES (4, 2, '03-07-2023', 20000000, 1)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (5, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (6, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (7, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (8, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (9, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (10, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (11, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (12, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (13, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (14, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (15, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (16, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (17, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (18, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (19, 1, '03-07-2023', 0)
INSERT PHIEUDATCHO (MaHanhKhach, MaCT_HangVe, NgayXuatVe, TinhTrang) VALUES (20, 1, '03-07-2023', 0)
GO

CREATE TABLE BAOCAODOANHTHUNAM
(
	Nam INT PRIMARY KEY,
	TongDoanhThu MONEY
)
GO

CREATE TABLE CT_BCDT_NAM
(
	Thang INT,
	Nam INT,
	SoChuyenBay INT,
	DoanhThu MONEY,
	TiLe FLOAT

	PRIMARY KEY (Thang, Nam),
	FOREIGN KEY (Nam) REFERENCES BAOCAODOANHTHUNAM (Nam)
)
GO

CREATE TABLE CT_BCDT_THANG
(
	MaChuyenBay VARCHAR(6) PRIMARY KEY,
	Thang INT,
	Nam INT,
	SoVe INT,
	DoanhThu MONEY,
	TiLe FLOAT

	FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY (MaChuyenBay),
	FOREIGN KEY (Thang, Nam) REFERENCES CT_BCDT_NAM (Thang, Nam)
)
GO

CREATE TABLE NHOMNGUOIDUNG
(
	MaNhom INT PRIMARY KEY IDENTITY,
	TenNhom NVARCHAR(50)
)
GO

INSERT NHOMNGUOIDUNG (TenNhom) VALUES (N'Admin')
INSERT NHOMNGUOIDUNG (TenNhom) VALUES (N'Nhân viên')
GO

CREATE TABLE CHUCNANG
(
	MaChucNang INT PRIMARY KEY IDENTITY,
	TenChucNang NVARCHAR(100),
	TenManHinhDuocLoad NVARCHAR(100)
)
GO

CREATE TABLE PHANQUYEN
(
	MaNhom INT,
	MaChucNang INT,

	PRIMARY KEY (MaNhom, MaChucNang),
	FOREIGN KEY (MaNhom) REFERENCES NHOMNGUOIDUNG (MaNhom),
	FOREIGN KEY (MaChucNang) REFERENCES CHUCNANG (MaChucNang)
)
GO

CREATE TABLE NGUOIDUNG
(
	TenDangNhap VARCHAR(30) PRIMARY KEY,
	MatKhau VARCHAR(30),
	MaNhom INT FOREIGN KEY REFERENCES NHOMNGUOIDUNG (MaNhom),
	Email VARCHAR(50),
	TenHienThi NVARCHAR(50)
)
GO

INSERT NGUOIDUNG (TenDangNhap, MatKhau, MaNhom, Email, TenHienThi) VALUES ('admin', 'admin', 1, 'ledoantantri@gmail.com', N'Admin')
INSERT NGUOIDUNG (TenDangNhap, MatKhau, MaNhom, Email, TenHienThi) VALUES ('nhanvien1', 'nv1', 2, 'nhanvien1@gmail.com', N'Nhân viên 1')
GO