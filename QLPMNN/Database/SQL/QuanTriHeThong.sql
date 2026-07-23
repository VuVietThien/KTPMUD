USE PMQLNN;
GO

-- Roles
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(200)
);
INSERT INTO Roles VALUES (1, N'Admin', N'Quản trị viên hệ thống');
INSERT INTO Roles VALUES (2, N'User', N'Người dùng thường');
GO

-- Nhom (tạo trước, chưa có FK tới Users)
CREATE TABLE Nhom (
    Nhom_ID INT PRIMARY KEY IDENTITY(1,1),
    Ten_nhom NVARCHAR(100) NOT NULL,
    So_luong INT DEFAULT 0,
    UserID INT NULL
);
GO

-- Users
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

-- Thêm FK Nhom → Users sau khi Users đã tạo
ALTER TABLE Nhom ADD CONSTRAINT FK_Nhom_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);
GO

-- UserRoles (mapping dự phòng)
CREATE TABLE UserRoles (
    UserRoleID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

-- LichSuTruyCap
CREATE TABLE LichSuTruyCap (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    Time DATETIME DEFAULT GETDATE(),
    Action NVARCHAR(200),
    UserID INT,
    CONSTRAINT FK_LichSuTruyCap_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- DonViHanhChinhTinh
CREATE TABLE DonViHanhChinhTinh (
    MaTinh VARCHAR(10) PRIMARY KEY,
    TenTinh NVARCHAR(100) NOT NULL,
    GhiChu NVARCHAR(200)
);
GO

-- DonViHanhChinhXa
CREATE TABLE DonViHanhChinhXa (
    MaXa VARCHAR(10) PRIMARY KEY,
    TenXa NVARCHAR(100) NOT NULL,
    MaTinh VARCHAR(10) NOT NULL,
    GhiChu NVARCHAR(200),
    CONSTRAINT FK_Xa_Tinh FOREIGN KEY (MaTinh) REFERENCES DonViHanhChinhTinh(MaTinh) ON DELETE CASCADE
);
GO

-- Tài khoản admin mặc định
INSERT INTO Users (Username, Password, Email, RoleID, Status)
VALUES ('admin', 'admin123', 'admin@qlcnn.vn', 1, 'active');
GO

-- Dữ liệu mẫu tỉnh
INSERT INTO DonViHanhChinhTinh VALUES ('T01', N'Tỉnh Ninh Bình', N'');
INSERT INTO DonViHanhChinhTinh VALUES ('T02', N'Tỉnh Hải Phòng', N'');
INSERT INTO DonViHanhChinhTinh VALUES ('T03', N'Tỉnh Thái Nguyên', N'');
GO

INSERT INTO DonViHanhChinhXa VALUES ('X001', N'Xã Thanh Lâm', 'T01', N'');
INSERT INTO DonViHanhChinhXa VALUES ('X002', N'Xã Thanh Liêm', 'T02', N'');
INSERT INTO DonViHanhChinhXa VALUES ('X003', N'Xã Lý Nhân', 'T03', N'');
GO
