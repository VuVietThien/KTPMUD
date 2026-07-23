using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class CoSoKhaoNghiemService
    {
        public static DataTable GetAll()
        {
            return DatabaseConnection.ExecuteQuery("SELECT * FROM CoSoKhaoNghiem WHERE IsActive=1 ORDER BY ID DESC");
        }

        public static bool Add(CoSoKhaoNghiem c)
        {
            var sql = @"INSERT INTO CoSoKhaoNghiem (TenCoSo,LoaiKhaoNghiem,DiaChi,SoDienThoai,Email,MaSoThue,GiayPhepKinhDoanh,GhiChu)
                        VALUES (@Ten,@LoaiKN,@DiaChi,@SDT,@Email,@MST,@GPKD,@GhiChu)";
            return DatabaseConnection.ExecuteNonQuery(sql, Params(c)) > 0;
        }

        public static bool Update(CoSoKhaoNghiem c)
        {
            var sql = @"UPDATE CoSoKhaoNghiem SET TenCoSo=@Ten,LoaiKhaoNghiem=@LoaiKN,
                        DiaChi=@DiaChi,SoDienThoai=@SDT,Email=@Email,MaSoThue=@MST,GiayPhepKinhDoanh=@GPKD,GhiChu=@GhiChu
                        WHERE ID=@ID";
            var p = Params(c).Concat(new[] { new SqlParameter("@ID", c.ID) }).ToArray();
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "UPDATE CoSoKhaoNghiem SET IsActive=0 WHERE ID=@id",
                new[] { new SqlParameter("@id", id) }) > 0;
        }

        public static DataTable Search(string keyword)
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM CoSoKhaoNghiem WHERE IsActive=1 AND (TenCoSo LIKE @kw OR LoaiKhaoNghiem LIKE @kw OR DiaChi LIKE @kw) ORDER BY ID DESC",
                new[] { new SqlParameter("@kw", $"%{keyword}%") });
        }

        private static SqlParameter[] Params(CoSoKhaoNghiem c) => new[]
        {
            new SqlParameter("@Ten", c.TenCoSo),
            new SqlParameter("@LoaiKN", (object?)c.LoaiKhaoNghiem ?? DBNull.Value),
            new SqlParameter("@DiaChi", (object?)c.DiaChi ?? DBNull.Value),
            new SqlParameter("@SDT", (object?)c.SoDienThoai ?? DBNull.Value),
            new SqlParameter("@Email", (object?)c.Email ?? DBNull.Value),
            new SqlParameter("@MST", (object?)c.MaSoThue ?? DBNull.Value),
            new SqlParameter("@GPKD", (object?)c.GiayPhepKinhDoanh ?? DBNull.Value),
            new SqlParameter("@GhiChu", (object?)c.GhiChu ?? DBNull.Value)
        };
    }
}
