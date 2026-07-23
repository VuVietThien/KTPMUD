using System.Data;
using System.Data.SqlClient;

namespace QLPMNN.Database
{
    public static class DatabaseConnection
    {
        private const string ConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=PMQLNN;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static void InitializeDatabase()
        {
            // 1. Kiểm tra xem CSDL và bảng đã tồn tại chưa
            bool dbAndTableExist = false;
            try
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = new SqlCommand("SELECT COUNT(*) FROM sys.tables WHERE name = 'DonViHanhChinhTinh'", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    dbAndTableExist = true;
                }
            }
            catch
            {
                // Lỗi kết nối hoặc không có DB/bảng
            }

            if (dbAndTableExist) return;

            // 2. Chạy script khởi tạo CSDL
            try
            {
                // Đọc file script SQL
                string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "SQL", "InitDatabaseAllInOne.sql");
                if (!System.IO.File.Exists(scriptPath))
                {
                    scriptPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Database", "SQL", "InitDatabaseAllInOne.sql");
                }

                if (!System.IO.File.Exists(scriptPath))
                {
                    throw new System.IO.FileNotFoundException("Không tìm thấy file script khởi tạo InitDatabaseAllInOne.sql");
                }

                string script = System.IO.File.ReadAllText(scriptPath, System.Text.Encoding.UTF8);
                
                // Tách các lệnh SQL theo từ khóa GO (bao gồm cả trường hợp có khoảng trắng)
                var regex = new System.Text.RegularExpressions.Regex(@"^\s*GO\s*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);
                string[] commands = regex.Split(script);

                // Kết nối tới database master để chạy toàn bộ script (script tự chuyển sang PMQLNN khi cần)
                var builder = new SqlConnectionStringBuilder(ConnectionString)
                {
                    InitialCatalog = "master"
                };

                using var conn = new SqlConnection(builder.ConnectionString);
                conn.Open();
                
                foreach (string commandText in commands)
                {
                    if (string.IsNullOrWhiteSpace(commandText)) continue;
                    using var cmd = new SqlCommand(commandText, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Tự động khởi tạo Cơ sở dữ liệu thất bại! Hãy chắc chắn SQL Server (SQLEXPRESS) đang hoạt động.\nChi tiết lỗi: " + ex.Message, ex);
            }
        }

        public static DataTable ExecuteQuery(string sql, SqlParameter[]? parameters = null)
        {
            var dt = new DataTable();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            using var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string sql, SqlParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }
}
