USE PMQLNN;
GO

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

-- Dữ liệu mẫu
INSERT INTO ToChucThuThapGen VALUES ('TTG001', N'Trung tâm Thu thập Gen Ba Vì', N'Ba Vì, Hà Nội', '0243123456', 'ttg001@email.vn', N'Nguyễn Văn A', N'');
INSERT INTO ToChucBaoTonGen VALUES ('BTG001', N'Trại Bảo tồn Gen Động vật', N'Chương Mỹ, Hà Nội', '0243234567', 'btg001@email.vn', N'Trần Thị B', N'');
INSERT INTO ToChucKhaiThacGen VALUES ('KTG001', N'Công ty Khai thác Gen Nông nghiệp', N'Đan Phượng, Hà Nội', '0243345678', 'ktg001@email.vn', N'Lê Văn C', N'');
INSERT INTO ThucAnChanNuoi VALUES ('TA001', N'Cám hỗn hợp cho lợn', N'Thức ăn hỗn hợp', N'Ngô, đậu tương, cám gạo', N'Protein 18%, Béo 4%', 'Kg', 15000, N'Công ty CP', N'');
GO
