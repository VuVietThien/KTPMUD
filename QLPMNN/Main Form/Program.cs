using System;
using System.Threading;
using System.Windows.Forms;

namespace QLPMNN
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Đăng ký bộ xử lý ngoại lệ cho UI thread
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            // Thiết lập bắt tất cả các ngoại lệ phát sinh trong WinForms
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Đăng ký bộ xử lý ngoại lệ cho non-UI thread
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Tự động khởi tạo database nếu chưa có hoặc thiếu bảng
            try
            {
                QLPMNN.Database.DatabaseConnection.InitializeDatabase();
            }
            catch (Exception ex)
            {
                ShowFriendlyError(ex);
                return; // Dừng chương trình nếu không khởi tạo được CSDL
            }

            Application.Run(new Login());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowFriendlyError(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ShowFriendlyError(ex);
            }
        }

        private static void ShowFriendlyError(Exception ex)
        {
            string msg = "Đã xảy ra lỗi hệ thống!\n\nChi tiết: " + ex.Message;
            
            // Gợi ý xử lý một số lỗi database phổ biến
            if (ex.Message.Contains("Invalid object name") || ex.Message.Contains("Invalid column name"))
            {
                msg += "\n\n💡 Gợi ý: Có vẻ cơ sở dữ liệu bị thiếu bảng hoặc cột. Vui lòng đảm bảo bạn đã chạy đầy đủ file SQL khởi tạo (InitDatabaseAllInOne.sql) trong SQL Server.";
            }
            else if (ex.Message.Contains("network-related or instance-specific error") || ex.Message.Contains("Cannot open database"))
            {
                msg += "\n\n💡 Gợi ý: Không thể kết nối với SQL Server. Vui lòng kiểm tra xem dịch vụ SQL Server (SQLEXPRESS) đã chạy chưa và chuỗi kết nối trong DatabaseConnection.cs đã chính xác chưa.";
            }

            MessageBox.Show(msg, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

