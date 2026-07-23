using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class GiongVatNuoiBaoTonService
    {
        public static DataTable GetAll()
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM GiongVatNuoiBaoTon WHERE IsActive=1 ORDER BY ID DESC");
        }

        public static GiongVatNuoiBaoTon? GetById(int id)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                "SELECT * FROM GiongVatNuoiBaoTon WHERE ID=@id",
                new[] { new SqlParameter("@id", id) });
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public static bool Add(GiongVatNuoiBaoTon g)
        {
            var sql = @"INSERT INTO GiongVatNuoiBaoTon (TenGiong,LoaiVatNuoi,MoTa,TinhTrang,DiaDiemBaoTon,GhiChu)
                        VALUES (@TenGiong,@LoaiVatNuoi,@MoTa,@TinhTrang,@DiaDiemBaoTon,@GhiChu)";
            return DatabaseConnection.ExecuteNonQuery(sql, Params(g)) > 0;
        }

        public static bool Update(GiongVatNuoiBaoTon g)
        {
            var sql = @"UPDATE GiongVatNuoiBaoTon SET TenGiong=@TenGiong,LoaiVatNuoi=@LoaiVatNuoi,
                        MoTa=@MoTa,TinhTrang=@TinhTrang,DiaDiemBaoTon=@DiaDiemBaoTon,GhiChu=@GhiChu
                        WHERE ID=@ID";
            var p = Params(g).Concat(new[] { new SqlParameter("@ID", g.ID) }).ToArray();
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "UPDATE GiongVatNuoiBaoTon SET IsActive=0 WHERE ID=@id",
                new[] { new SqlParameter("@id", id) }) > 0;
        }

        public static DataTable Search(string keyword)
        {
            return DatabaseConnection.ExecuteQuery(
                "SELECT * FROM GiongVatNuoiBaoTon WHERE IsActive=1 AND (TenGiong LIKE @kw OR LoaiVatNuoi LIKE @kw OR TinhTrang LIKE @kw) ORDER BY ID DESC",
                new[] { new SqlParameter("@kw", $"%{keyword}%") });
        }

        private static SqlParameter[] Params(GiongVatNuoiBaoTon g) => new[]
        {
            new SqlParameter("@TenGiong", g.TenGiong),
            new SqlParameter("@LoaiVatNuoi", (object?)g.LoaiVatNuoi ?? DBNull.Value),
            new SqlParameter("@MoTa", (object?)g.MoTa ?? DBNull.Value),
            new SqlParameter("@TinhTrang", (object?)g.TinhTrang ?? DBNull.Value),
            new SqlParameter("@DiaDiemBaoTon", (object?)g.DiaDiemBaoTon ?? DBNull.Value),
            new SqlParameter("@GhiChu", (object?)g.GhiChu ?? DBNull.Value)
        };

        private static GiongVatNuoiBaoTon Map(DataRow r) => new()
        {
            ID = Convert.ToInt32(r["ID"]),
            TenGiong = r["TenGiong"].ToString()!,
            LoaiVatNuoi = r.IsNull("LoaiVatNuoi") ? null : r["LoaiVatNuoi"].ToString(),
            MoTa = r.IsNull("MoTa") ? null : r["MoTa"].ToString(),
            TinhTrang = r.IsNull("TinhTrang") ? null : r["TinhTrang"].ToString(),
            DiaDiemBaoTon = r.IsNull("DiaDiemBaoTon") ? null : r["DiaDiemBaoTon"].ToString(),
            GhiChu = r.IsNull("GhiChu") ? null : r["GhiChu"].ToString(),
            CreatedDate = r.IsNull("CreatedDate") ? DateTime.Now : Convert.ToDateTime(r["CreatedDate"]),
            IsActive = Convert.ToBoolean(r["IsActive"])
        };
    }
}
