using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class AccessHistoryService
    {
        public static DataTable GetAll()
        {
            return DatabaseConnection.ExecuteQuery(
                @"SELECT l.LogID, l.Time, l.Action, l.UserID, u.Username
                  FROM LichSuTruyCap l LEFT JOIN Users u ON l.UserID = u.UserID
                  ORDER BY l.Time DESC");
        }

        public static DataTable Search(string? username, string? action, DateTime? from, DateTime? to)
        {
            var conditions = new List<string>();
            var p = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(username))
            {
                conditions.Add("u.Username LIKE @uname");
                p.Add(new SqlParameter("@uname", $"%{username}%"));
            }
            if (!string.IsNullOrWhiteSpace(action))
            {
                conditions.Add("l.Action LIKE @act");
                p.Add(new SqlParameter("@act", $"%{action}%"));
            }
            if (from.HasValue)
            {
                conditions.Add("l.Time >= @from");
                p.Add(new SqlParameter("@from", from.Value));
            }
            if (to.HasValue)
            {
                conditions.Add("l.Time <= @to");
                p.Add(new SqlParameter("@to", to.Value.AddDays(1)));
            }

            var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
            var sql = $@"SELECT l.LogID, l.Time, l.Action, l.UserID, u.Username
                         FROM LichSuTruyCap l LEFT JOIN Users u ON l.UserID = u.UserID
                         {where} ORDER BY l.Time DESC";
            return DatabaseConnection.ExecuteQuery(sql, p.ToArray());
        }
    }
}
