using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Models;

namespace QLPMNN.Services
{
    public static class UserService
    {
        public static User? Authenticate(string username, string password)
        {
            var sql = @"SELECT u.UserID, u.Username, u.Password, u.Email, u.RoleID, u.Status, u.CreatedDate, u.Nhom_ID, r.RoleName
                        FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
                        WHERE u.Username = @Username AND u.Password = @Password AND u.Status = 'active'";
            var p = new SqlParameter[] {
                new("@Username", username),
                new("@Password", password)
            };
            var dt = DatabaseConnection.ExecuteQuery(sql, p);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return MapUser(row);
        }

        public static List<User> GetAll()
        {
            var sql = @"SELECT u.UserID, u.Username, u.Password, u.Email, u.RoleID, u.Status, u.CreatedDate, u.Nhom_ID, r.RoleName, n.Ten_nhom
                        FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
                        LEFT JOIN Nhom n ON u.Nhom_ID = n.Nhom_ID
                        ORDER BY u.UserID DESC";
            var dt = DatabaseConnection.ExecuteQuery(sql);
            return dt.Rows.Cast<DataRow>().Select(MapUserFull).ToList();
        }

        public static User? GetById(int id)
        {
            var sql = @"SELECT u.UserID, u.Username, u.Password, u.Email, u.RoleID, u.Status, u.CreatedDate, u.Nhom_ID, r.RoleName, n.Ten_nhom
                        FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
                        LEFT JOIN Nhom n ON u.Nhom_ID = n.Nhom_ID
                        WHERE u.UserID = @ID";
            var dt = DatabaseConnection.ExecuteQuery(sql, new[] { new SqlParameter("@ID", id) });
            return dt.Rows.Count > 0 ? MapUserFull(dt.Rows[0]) : null;
        }

        public static bool Register(string username, string password, string? email)
        {
            if (IsUsernameExists(username)) return false;
            var sql = "INSERT INTO Users (Username, Password, Email, RoleID, Status) VALUES (@Username, @Password, @Email, 2, 'active')";
            var p = new SqlParameter[] {
                new("@Username", username),
                new("@Password", password),
                new("@Email", (object?)email ?? DBNull.Value)
            };
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Add(User u)
        {
            var sql = "INSERT INTO Users (Username, Password, Email, RoleID, Status) VALUES (@Username, @Password, @Email, @RoleID, @Status)";
            var p = new SqlParameter[] {
                new("@Username", u.Username),
                new("@Password", u.Password),
                new("@Email", (object?)u.Email ?? DBNull.Value),
                new("@RoleID", u.RoleID),
                new("@Status", u.Status)
            };
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Update(User u)
        {
            var sql = "UPDATE Users SET Password=@Password, Email=@Email, RoleID=@RoleID, Status=@Status WHERE UserID=@UserID";
            var p = new SqlParameter[] {
                new("@Password", u.Password),
                new("@Email", (object?)u.Email ?? DBNull.Value),
                new("@RoleID", u.RoleID),
                new("@Status", u.Status),
                new("@UserID", u.UserID)
            };
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery("DELETE FROM Users WHERE UserID=@ID",
                new[] { new SqlParameter("@ID", id) }) > 0;
        }

        public static List<User> Search(string keyword)
        {
            var sql = @"SELECT u.UserID, u.Username, u.Password, u.Email, u.RoleID, u.Status, u.CreatedDate, u.Nhom_ID, r.RoleName, n.Ten_nhom
                        FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
                        LEFT JOIN Nhom n ON u.Nhom_ID = n.Nhom_ID
                        WHERE u.Username LIKE @kw OR u.Email LIKE @kw";
            var dt = DatabaseConnection.ExecuteQuery(sql, new[] { new SqlParameter("@kw", $"%{keyword}%") });
            return dt.Rows.Cast<DataRow>().Select(MapUserFull).ToList();
        }

        public static bool IsUsernameExists(string username)
        {
            var result = DatabaseConnection.ExecuteScalar(
                "SELECT COUNT(1) FROM Users WHERE Username=@u",
                new[] { new SqlParameter("@u", username) });
            return Convert.ToInt32(result) > 0;
        }

        public static bool ResetPassword(string username, string email, string newPassword)
        {
            var sql = "UPDATE Users SET Password=@pwd WHERE Username=@u AND Email=@e";
            var p = new SqlParameter[] {
                new("@pwd", newPassword),
                new("@u", username),
                new("@e", email)
            };
            return DatabaseConnection.ExecuteNonQuery(sql, p) > 0;
        }

        public static void LogAccess(int userId, string action)
        {
            try
            {
                DatabaseConnection.ExecuteNonQuery(
                    "INSERT INTO LichSuTruyCap (Action, UserID) VALUES (@a, @u)",
                    new[] { new SqlParameter("@a", action), new SqlParameter("@u", userId) });
            }
            catch { }
        }

        public static List<Nhom> GetAllNhom()
        {
            var dt = DatabaseConnection.ExecuteQuery("SELECT * FROM Nhom ORDER BY Nhom_ID");
            return dt.Rows.Cast<DataRow>().Select(r => new Nhom
            {
                Nhom_ID = Convert.ToInt32(r["Nhom_ID"]),
                Ten_nhom = r["Ten_nhom"].ToString()!,
                So_luong = r.IsNull("So_luong") ? 0 : Convert.ToInt32(r["So_luong"]),
                UserID = r.IsNull("UserID") ? null : Convert.ToInt32(r["UserID"])
            }).ToList();
        }

        public static Nhom? GetNhomByUser(int userId)
        {
            var sql = "SELECT n.* FROM Nhom n JOIN Users u ON u.Nhom_ID = n.Nhom_ID WHERE u.UserID = @uid";
            var dt = DatabaseConnection.ExecuteQuery(sql, new[] { new SqlParameter("@uid", userId) });
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Nhom
            {
                Nhom_ID = Convert.ToInt32(r["Nhom_ID"]),
                Ten_nhom = r["Ten_nhom"].ToString()!,
                So_luong = r.IsNull("So_luong") ? 0 : Convert.ToInt32(r["So_luong"])
            };
        }

        public static List<User> GetThanhVienNhom(int nhomId)
        {
            var sql = "SELECT u.UserID, u.Username, u.Email, u.Status FROM Users u WHERE u.Nhom_ID = @nid";
            var dt = DatabaseConnection.ExecuteQuery(sql, new[] { new SqlParameter("@nid", nhomId) });
            return dt.Rows.Cast<DataRow>().Select(r => new User
            {
                UserID = Convert.ToInt32(r["UserID"]),
                Username = r["Username"].ToString()!,
                Email = r.IsNull("Email") ? null : r["Email"].ToString(),
                Status = r["Status"].ToString()!
            }).ToList();
        }

        public static bool TaoNhom(string tenNhom, int userId)
        {
            DatabaseConnection.ExecuteNonQuery(
                "INSERT INTO Nhom (Ten_nhom, So_luong, UserID) VALUES (@ten, 1, @uid)",
                new[] { new SqlParameter("@ten", tenNhom), new SqlParameter("@uid", userId) });
            var nhomId = Convert.ToInt32(DatabaseConnection.ExecuteScalar("SELECT MAX(Nhom_ID) FROM Nhom"));
            DatabaseConnection.ExecuteNonQuery("UPDATE Users SET Nhom_ID=@nid WHERE UserID=@uid",
                new[] { new SqlParameter("@nid", nhomId), new SqlParameter("@uid", userId) });
            return true;
        }

        public static bool SuaNhom(int nhomId, string tenNhom)
        {
            return DatabaseConnection.ExecuteNonQuery("UPDATE Nhom SET Ten_nhom=@ten WHERE Nhom_ID=@nid",
                new[] { new SqlParameter("@ten", tenNhom), new SqlParameter("@nid", nhomId) }) > 0;
        }

        public static bool XoaNhom(int nhomId)
        {
            DatabaseConnection.ExecuteNonQuery("UPDATE Users SET Nhom_ID=NULL WHERE Nhom_ID=@nid",
                new[] { new SqlParameter("@nid", nhomId) });
            return DatabaseConnection.ExecuteNonQuery("DELETE FROM Nhom WHERE Nhom_ID=@nid",
                new[] { new SqlParameter("@nid", nhomId) }) > 0;
        }

        private static User MapUser(DataRow r) => new()
        {
            UserID = Convert.ToInt32(r["UserID"]),
            Username = r["Username"].ToString()!,
            Password = r["Password"].ToString()!,
            Email = r.Table.Columns.Contains("Email") && !r.IsNull("Email") ? r["Email"].ToString() : null,
            RoleID = Convert.ToInt32(r["RoleID"]),
            Status = r["Status"].ToString()!,
            CreatedDate = r.IsNull("CreatedDate") ? DateTime.Now : Convert.ToDateTime(r["CreatedDate"]),
            Nhom_ID = r.IsNull("Nhom_ID") ? null : Convert.ToInt32(r["Nhom_ID"]),
            RoleName = r.Table.Columns.Contains("RoleName") ? r["RoleName"].ToString() : null
        };

        private static User MapUserFull(DataRow r)
        {
            var u = MapUser(r);
            if (r.Table.Columns.Contains("Ten_nhom") && !r.IsNull("Ten_nhom"))
                u.TenNhom = r["Ten_nhom"].ToString();
            return u;
        }
    }
}
