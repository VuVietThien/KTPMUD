using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = UserService.Authenticate(username, password);
            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentSession.CurrentUser = user;
            UserService.LogAccess(user.UserID, $"Đăng nhập hệ thống");

            this.Hide();
            if (CurrentSession.IsAdmin)
            {
                var adminForm = new Quan_ly_nguoi_dung_form();
                adminForm.ShowDialog();
            }
            else
            {
                var mainForm = new main();
                mainForm.ShowDialog();
            }
            this.Show();
            CurrentSession.Logout();
            txtPassword.Clear();
            txtUsername.Clear();
            txtUsername.Focus();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var frm = new Register();
            frm.ShowDialog();
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            var frm = new ForgotPassword();
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(sender, e);
        }
    }
}
