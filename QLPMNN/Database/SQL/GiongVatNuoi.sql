USE PMQLNN;
GO

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

-- Dữ liệu mẫu
INSERT INTO GiongVatNuoiBaoTon (TenGiong, LoaiVatNuoi, MoTa, TinhTrang, DiaDiemBaoTon)
VALUES (N'Lợn Móng Cái', N'Lợn', N'Giống lợn địa phương quý hiếm', N'Nguy cấp', N'Hải Phòng, Quảng Ninh');

INSERT INTO GiongVatNuoiCamXuatKhau (TenGiong, LoaiVatNuoi, LyDoCam, NgayBanHanh, CoQuanBanHanh)
VALUES (N'Gà Đông Tảo', N'Gia cầm', N'Giống quý hiếm cần bảo tồn trong nước', '2020-01-01', N'Bộ Nông nghiệp và PTNT');
GO
