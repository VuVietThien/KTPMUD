using QLPMNN.Models;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly int _userId;
        private User? _user;

        public UserEditForm(int userId = 0)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin (1)");
            cmbRole.Items.Add("User (2)");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("active");
            cmbStatus.Items.Add("inactive");

            if (_userId > 0)
            {
                this.Text = "Sửa người dùng";
                lblTitle.Text = "CHỈNH SỬA NGƯỜI DÙNG";
                _user = UserService.GetById(_userId);
                if (_user != null)
                {
                    txtUsername.Text = _user.Username;
                    txtUsername.ReadOnly = true;
                    txtPassword.Text = _user.Password;
                    txtEmail.Text = _user.Email;
                    cmbRole.SelectedIndex = _user.RoleID - 1;
                    cmbStatus.SelectedItem = _user.Status;
                }
            }
            else
            {
                this.Text = "Thêm người dùng";
                lblTitle.Text = "THÊM NGƯỜI DÙNG MỚI";
                cmbRole.SelectedIndex = 1;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = cmbRole.SelectedIndex + 1;
            string status = cmbStatus.SelectedItem?.ToString() ?? "active";

            if (_userId == 0)
            {
                bool ok = UserService.Add(new User {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Email = txtEmail.Text.Trim(),
                    RoleID = roleId,
                    Status = status
                });
                if (!ok)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm user: {txtUsername.Text}");
            }
            else
            {
                UserService.Update(new User {
                    UserID = _userId,
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Email = txtEmail.Text.Trim(),
                    RoleID = roleId,
                    Status = status
                });
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa user: {txtUsername.Text}");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
