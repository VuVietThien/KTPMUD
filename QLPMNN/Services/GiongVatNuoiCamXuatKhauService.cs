using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class GiongVatNuoiCamXuatKhauService
    {
        public static DataTable GetAll()
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM GiongVatNuoiCamXuatKhau WHERE IsActive=1 ORDER BY ID DESC");
        }

        public static bool Add(GiongVatNuoiCamXuatKhau g)
        {
            var sql = @"INSERT INTO GiongVatNuoiCamXuatKhau (TenGiong,LoaiVatNuoi,LyDoCam,NgayBanHanh,CoQuanBanHanh,GhiChu)
                        VALUES (@TenGiong,@LoaiVatNuoi,@LyDoCam,@NgayBanHanh,@CoQuanBanHanh,@GhiChu)";
            return DatabaseConnection.ExecuteNonQuery(sql, Params(g)) > 0;
        }

        public static bool Update(GiongVatNuoiCamXuatKhau g)
        {
            var sql = @"UPDATE GiongVatNuoiCamXuatKhau SET TenGiong=@TenGiong,LoaiVatNuoi=@LoaiVatNuoi,
                        LyDoCam=@LyDoCam,NgayBanHanh=@NgayBanHanh,CoQuanBanHanh=@CoQuanBanHanh,GhiChu=@GhiChu
                        WHERE ID=@ID";
            var p = Params(g).Concat(new[] { new SqlParameter("@ID", g.ID) }).ToArray();
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "UPDATE GiongVatNuoiCamXuatKhau SET IsActive=0 WHERE ID=@id",
                new[] { new SqlParameter("@id", id) }) > 0;
        }

        public static DataTable Search(string keyword)
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM GiongVatNuoiCamXuatKhau WHERE IsActive=1 AND (TenGiong LIKE @kw OR LoaiVatNuoi LIKE @kw OR CoQuanBanHanh LIKE @kw) ORDER BY ID DESC",
                new[] { new SqlParameter("@kw", $"%{keyword}%") });
        }

        private static SqlParameter[] Params(GiongVatNuoiCamXuatKhau g) => new[]
        {
            new SqlParameter("@TenGiong", g.TenGiong),
            new SqlParameter("@LoaiVatNuoi", (object?)g.LoaiVatNuoi ?? DBNull.Value),
            new SqlParameter("@LyDoCam", (object?)g.LyDoCam ?? DBNull.Value),
            new SqlParameter("@NgayBanHanh", (object?)g.NgayBanHanh ?? DBNull.Value),
            new SqlParameter("@CoQuanBanHanh", (object?)g.CoQuanBanHanh ?? DBNull.Value),
            new SqlParameter("@GhiChu", (object?)g.GhiChu ?? DBNull.Value)
        };
    }
}
