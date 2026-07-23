using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class ToChucSanXuatConGiongService
    {
        public static DataTable GetAll()
        {
            return DatabaseConnection.ExecuteQuery("SELECT * FROM ToChucSanXuatConGiong WHERE IsActive=1 ORDER BY ID DESC");
        }

        public static bool Add(ToChucSanXuatConGiong t)
        {
            var sql = @"INSERT INTO ToChucSanXuatConGiong (TenToChuc,LoaiHinh,DiaChi,SoDienThoai,Email,MaSoThue,GiayPhepKinhDoanh,GhiChu)
                        VALUES (@Ten,@LoaiHinh,@DiaChi,@SDT,@Email,@MST,@GPKD,@GhiChu)";
            return DatabaseConnection.ExecuteNonQuery(sql, Params(t)) > 0;
        }

        public static bool Update(ToChucSanXuatConGiong t)
        {
            var sql = @"UPDATE ToChucSanXuatConGiong SET TenToChuc=@Ten,LoaiHinh=@LoaiHinh,
                        DiaChi=@DiaChi,SoDienThoai=@SDT,Email=@Email,MaSoThue=@MST,GiayPhepKinhDoanh=@GPKD,GhiChu=@GhiChu
                        WHERE ID=@ID";
            var p = Params(t).Concat(new[] { new SqlParameter("@ID", t.ID) }).ToArray();
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "UPDATE ToChucSanXuatConGiong SET IsActive=0 WHERE ID=@id",
                new[] { new SqlParameter("@id", id) }) > 0;
        }

        public static DataTable Search(string keyword)
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM ToChucSanXuatConGiong WHERE IsActive=1 AND (TenToChuc LIKE @kw OR DiaChi LIKE @kw) ORDER BY ID DESC",
                new[] { new SqlParameter("@kw", $"%{keyword}%") });
        }

        private static SqlParameter[] Params(ToChucSanXuatConGiong t) => new[]
        {
            new SqlParameter("@Ten", t.TenToChuc),
            new SqlParameter("@LoaiHinh", (object?)t.LoaiHinh ?? DBNull.Value),
            new SqlParameter("@DiaChi", (object?)t.DiaChi ?? DBNull.Value),
            new SqlParameter("@SDT", (object?)t.SoDienThoai ?? DBNull.Value),
            new SqlParameter("@Email", (object?)t.Email ?? DBNull.Value),
            new SqlParameter("@MST", (object?)t.MaSoThue ?? DBNull.Value),
            new SqlParameter("@GPKD", (object?)t.GiayPhepKinhDoanh ?? DBNull.Value),
            new SqlParameter("@GhiChu", (object?)t.GhiChu ?? DBNull.Value)
        };
    }
}
