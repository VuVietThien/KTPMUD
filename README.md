# QLCNN — Phần Mềm Quản Lý Chăn Nuôi Nông Nghiệp

Ứng dụng Desktop Windows Forms (.NET 8 / C#) quản lý thông tin chăn nuôi nông nghiệp cho cơ quan nhà nước cấp tỉnh/huyện.

---

## Yêu cầu hệ thống

| Thành phần | Yêu cầu |
|---|---|
| .NET SDK | 8.0 trở lên |
| SQL Server | SQL Server 2019 Express (hoặc mới hơn) |
| OS | Windows 10/11 |
| IDE (tùy chọn) | Visual Studio 2022 |

---

## Hướng dẫn cài đặt & chạy

### Bước 1 — Tạo Database

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối tới `localhost\SQLEXPRESS`
3. Mở file `Database/SQL/InitDatabaseAllInOne.sql`
4. Nhấn **F5** (hoặc Execute) để chạy toàn bộ script

> Script sẽ tự động tạo database `PMQLNN`, tất cả bảng, và dữ liệu mẫu.

### Bước 2 — Chạy ứng dụng

**Cách 1 — Dùng .NET CLI (khuyến nghị):**

```bash
cd KTPMUD/QLPMNN
dotnet run
```





**Cách 2 — Dùng Visual Studio 2022:**

1. Mở file `QLPMNN.csproj` (hoặc mở file solution `KTPMUD.slnx` ở thư mục gốc)
2. Nhấn **F5** để build và chạy

---

## Tài khoản mặc định

| Tài khoản | Mật khẩu | Vai trò |
|---|---|---|
| `admin` | `admin123` | Admin — toàn quyền |
| `user1` | `user123` | User — nghiệp vụ |

---

## Cấu trúc thư mục

```
QLPMNN/
├── Database/
│   ├── DatabaseConnection.cs       ← Lớp kết nối SQL Server
│   └── SQL/
│       ├── InitDatabaseAllInOne.sql  ← Chạy file này để tạo DB
│       ├── CreateDatabase.sql
│       ├── QuanTriHeThong.sql
│       ├── NguonGen.sql
│       └── GiongVatNuoi.sql
├── Models/                         ← POCO classes
├── Services/                       ← Business logic (static classes)
├── Session/
│   └── CurrentSession.cs           ← Lưu user đang đăng nhập
├── Main Form/                      ← Form điều hướng chính
│   ├── Program.cs
│   ├── Login.cs
│   ├── Register.cs
│   ├── ForgotPassword.cs
│   ├── main.cs                     ← Dashboard user
│   ├── Nguon_gen_form.cs           ← Menu Nguồn Gen
│   ├── Giong_vat_nuoi_form.cs      ← Menu Giống Vật Nuôi
│   ├── Quan_ly_nguoi_dung_form.cs  ← Dashboard Admin
│   └── Thong_ke_nguoi_dung_form.cs
└── Forms/                          ← Form nghiệp vụ CRUD
    ├── QuanLyTinh_Form.cs
    ├── QuanLyXa_Form.cs
    ├── QuanLyThuThapGen_Form.cs
    ├── QuanLyBaoTonGen_Form.cs
    ├── QuanLyKhaiThacGen_Form.cs
    ├── QuanLyThucAn_Form.cs
    ├── ToChucSanXuatTinhPhoiManagementForm.cs
    ├── ToChucSanXuatConGiongManagementForm.cs
    ├── ToChucSoHuuDucGiongManagementForm.cs
    ├── ToChucMuaBanManagementForm.cs
    ├── CoSoKhaoNghiemManagementForm.cs
    ├── GiongVatNuoiBaoTonManagementForm.cs
    ├── GiongVatNuoiCamXuatKhauManagementForm.cs
    ├── UserEditForm.cs
    └── AccessHistoryManagementForm.cs
```

---

## Luồng sử dụng

```
Đăng nhập
    ├── Admin  → Quản lý người dùng, phân quyền, xem log
    └── User   → Dashboard cá nhân
                    ├── Nguồn Gen
                    │     ├── Quản lý Tỉnh
                    │     ├── Quản lý Xã
                    │     ├── Tổ chức Thu thập Gen
                    │     ├── Tổ chức Bảo tồn Gen
                    │     └── Tổ chức Khai thác Gen
                    ├── Giống Vật Nuôi
                    │     ├── SX Tinh/Phôi
                    │     ├── SX Con Giống
                    │     ├── Sở hữu Đực Giống
                    │     ├── Mua Bán Giống
                    │     ├── Cơ sở Khảo Nghiệm
                    │     ├── Giống Cần Bảo Tồn
                    │     └── Giống Cấm Xuất Khẩu
                    └── Thức ăn chăn nuôi
```

---

## Lỗi thường gặp

| Lỗi | Nguyên nhân | Cách sửa |
|---|---|---|
| `Cannot open database 'PMQLNN'` | Chưa chạy SQL script hoặc SQL Server chưa khởi động | Chạy lại `InitDatabaseAllInOne.sql`; kiểm tra SQL Server service |
| `A network-related error...` | Sai tên server | Kiểm tra và sửa connection string trong `DatabaseConnection.cs` |
| Form trắng / crash khi mở | DB chưa có dữ liệu bảng | Chạy lại SQL script |
