-- Chạy file này để tạo toàn bộ database từ đầu
-- Thứ tự: CreateDatabase → QuanTriHeThong → NguonGen → GiongVatNuoi

USE master;
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PMQLNN')
BEGIN
    ALTER DATABASE PMQLNN SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PMQLNN;
END
GO
CREATE DATABASE PMQLNN;
GO
USE PMQLNN;
GO

-- ===================== QUAN TRI HE THONG =====================
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(200)
);
INSERT INTO Roles VALUES (1, N'Admin', N'Quản trị viên hệ thống');
INSERT INTO Roles VALUES (2, N'User', N'Người dùng thường');
GO

CREATE TABLE Nhom (
    Nhom_ID INT PRIMARY KEY IDENTITY(1,1),
    Ten_nhom NVARCHAR(100) NOT NULL,
    So_luong INT DEFAULT 0,
    UserID INT NULL
);
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    RoleID INT NOT NULL DEFAULT 2,
    Status NVARCHAR(20) DEFAULT 'active',
    CreatedDate DATETIME DEFAULT GETDATE(),
    Nhom_ID INT NULL,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    CONSTRAINT FK_Users_Nhom FOREIGN KEY (Nhom_ID) REFERENCES Nhom(Nhom_ID)
);
GO

ALTER TABLE Nhom ADD CONSTRAINT FK_Nhom_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);
GO

CREATE TABLE UserRoles (
    UserRoleID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

CREATE TABLE LichSuTruyCap (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    Time DATETIME DEFAULT GETDATE(),
    Action NVARCHAR(200),
    UserID INT,
    CONSTRAINT FK_LichSuTruyCap_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

CREATE TABLE DonViHanhChinhTinh (
    MaTinh VARCHAR(10) PRIMARY KEY,
    TenTinh NVARCHAR(100) NOT NULL,
    GhiChu NVARCHAR(200)
);
GO

CREATE TABLE DonViHanhChinhXa (
    MaXa VARCHAR(10) PRIMARY KEY,
    TenXa NVARCHAR(100) NOT NULL,
    MaTinh VARCHAR(10) NOT NULL,
    GhiChu NVARCHAR(200),
    CONSTRAINT FK_Xa_Tinh FOREIGN KEY (MaTinh) REFERENCES DonViHanhChinhTinh(MaTinh) ON DELETE CASCADE
);
GO

-- ===================== NGUON GEN =====================
CREATE TABLE ToChucThuThapGen (
    MaThuThap VARCHAR(20) PRIMARY KEY,
    TenToChuc NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    NguoiDaiDien NVARCHAR(100),
    GhiChu NVARCHAR(500)
);
GO

CREATE TABLE ToChucBaoTonGen (
    MaBaoTon VARCHAR(20) PRIMARY KEY,
    TenToChuc NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    NguoiDaiDien NVARCHAR(100),
    GhiChu NVARCHAR(500)
);
GO

CREATE TABLE ToChucKhaiThacGen (
    MaKhaiThac VARCHAR(20) PRIMARY KEY,
    TenToChuc NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    NguoiDaiDien NVARCHAR(100),
    GhiChu NVARCHAR(500)
);
GO

CREATE TABLE ThucAnChanNuoi (
    MaThucAn VARCHAR(20) PRIMARY KEY,
    TenThucAn NVARCHAR(200) NOT NULL,
    LoaiThucAn NVARCHAR(100),
    ThanhPhan NVARCHAR(500),
    HamLuongDinhDuong NVARCHAR(200),
    DonViTinh NVARCHAR(50),
    GiaThamKhao DECIMAL(18,2),
    NhaCungCap NVARCHAR(200),
    GhiChu NVARCHAR(500)
);
GO

-- ===================== GIONG VAT NUOI =====================
CREATE TABLE ToChucSanXuatTinhPhoi (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenToChuc NVARCHAR(200) NOT NULL,
    LoaiHinh NVARCHAR(100),
    LoaiSanPham NVARCHAR(100),
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSoThue VARCHAR(20),
    GiayPhepKinhDoanh NVARCHAR(100),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE ToChucSanXuatConGiong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenToChuc NVARCHAR(200) NOT NULL,
    LoaiHinh NVARCHAR(100),
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSoThue VARCHAR(20),
    GiayPhepKinhDoanh NVARCHAR(100),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE ToChucSoHuuDucGiong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenToChuc NVARCHAR(200) NOT NULL,
    LoaiHinh NVARCHAR(100),
    LoaiDucGiong NVARCHAR(100),
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSoThue VARCHAR(20),
    GiayPhepKinhDoanh NVARCHAR(100),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE ToChucMuaBan (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenToChuc NVARCHAR(200) NOT NULL,
    LoaiHinh NVARCHAR(100),
    LoaiSanPham NVARCHAR(100),
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSoThue VARCHAR(20),
    GiayPhepKinhDoanh NVARCHAR(100),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE CoSoKhaoNghiem (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenCoSo NVARCHAR(200) NOT NULL,
    LoaiKhaoNghiem NVARCHAR(100),
    DiaChi NVARCHAR(300),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSoThue VARCHAR(20),
    GiayPhepKinhDoanh NVARCHAR(100),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE GiongVatNuoiBaoTon (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenGiong NVARCHAR(200) NOT NULL,
    LoaiVatNuoi NVARCHAR(100),
    MoTa NVARCHAR(500),
    TinhTrang NVARCHAR(100),
    DiaDiemBaoTon NVARCHAR(300),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

CREATE TABLE GiongVatNuoiCamXuatKhau (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenGiong NVARCHAR(200) NOT NULL,
    LoaiVatNuoi NVARCHAR(100),
    LyDoCam NVARCHAR(500),
    NgayBanHanh DATETIME,
    CoQuanBanHanh NVARCHAR(200),
    GhiChu NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- ===================== DU LIEU MAU =====================
INSERT INTO Users (Username, Password, Email, RoleID, Status)
VALUES ('admin', 'admin123', 'admin@qlpmnn.vn', 1, 'active');

INSERT INTO Users (Username, Password, Email, RoleID, Status)
VALUES ('user1', 'user123', 'user1@qlpmnn.vn', 2, 'active');
GO

INSERT INTO DonViHanhChinhTinh VALUES ('T01', N'Tỉnh Ninh Bình', N'');
INSERT INTO DonViHanhChinhTinh VALUES ('T02', N'Tỉnh Hải Phòng', N'');
INSERT INTO DonViHanhChinhTinh VALUES ('T03', N'Tỉnh Thái Nguyên', N'');

INSERT INTO DonViHanhChinhXa VALUES ('X001', N'Xã Thanh Lâm', 'T01', N'');
INSERT INTO DonViHanhChinhXa VALUES ('X002', N'Xã Thanh Liêm', 'T02', N'');
INSERT INTO DonViHanhChinhXa VALUES ('X003', N'Xã Lý Nhân', 'T03', N'');
GO

INSERT INTO ToChucThuThapGen VALUES ('TTG001', N'Trung tâm Thu thập Gen Ba Vì', N'Ba Vì, Hà Nội', '0243123456', 'ttg001@email.vn', N'Nguyễn Văn A', N'');
INSERT INTO ToChucBaoTonGen VALUES ('BTG001', N'Trại Bảo tồn Gen Động vật', N'Chương Mỹ, Hà Nội', '0243234567', 'btg001@email.vn', N'Trần Thị B', N'');
INSERT INTO ToChucKhaiThacGen VALUES ('KTG001', N'Công ty Khai thác Gen Nông nghiệp', N'Đan Phượng, Hà Nội', '0243345678', 'ktg001@email.vn', N'Lê Văn C', N'');
INSERT INTO ThucAnChanNuoi VALUES ('TA001', N'Cám hỗn hợp cho lợn', N'Thức ăn hỗn hợp', N'Ngô, đậu tương, cám gạo', N'Protein 18%, Béo 4%', 'Kg', 15000, N'Công ty CP', N'');
GO

INSERT INTO GiongVatNuoiBaoTon (TenGiong, LoaiVatNuoi, MoTa, TinhTrang, DiaDiemBaoTon)
VALUES (N'Lợn Móng Cái', N'Lợn', N'Giống lợn địa phương quý hiếm', N'Nguy cấp', N'Hải Phòng, Quảng Ninh');

INSERT INTO GiongVatNuoiCamXuatKhau (TenGiong, LoaiVatNuoi, LyDoCam, NgayBanHanh, CoQuanBanHanh)
VALUES (N'Gà Đông Tảo', N'Gia cầm', N'Giống quý hiếm cần bảo tồn trong nước', '2020-01-01', N'Bộ Nông nghiệp và PTNT');
GO
