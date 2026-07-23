using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN
{
    public partial class Quan_ly_nguoi_dung_form : Form
    {
        public Quan_ly_nguoi_dung_form()
        {
            InitializeComponent();
        }

        private void Quan_ly_nguoi_dung_form_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = $"Xin chào, {CurrentSession.CurrentUser?.Username}";
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = UserService.GetAll();
            dgvUsers.DataSource = users;
            SetColumns();
        }

        private void SetColumns()
        {
            if (dgvUsers.Columns.Contains("UserID")) dgvUsers.Columns["UserID"]!.HeaderText = "ID";
            if (dgvUsers.Columns.Contains("Username")) dgvUsers.Columns["Username"]!.HeaderText = "Tên đăng nhập";
            if (dgvUsers.Columns.Contains("Password")) dgvUsers.Columns["Password"]!.Visible = false;
            if (dgvUsers.Columns.Contains("Email")) dgvUsers.Columns["Email"]!.HeaderText = "Email";
            if (dgvUsers.Columns.Contains("RoleID")) dgvUsers.Columns["RoleID"]!.Visible = false;
            if (dgvUsers.Columns.Contains("RoleName")) dgvUsers.Columns["RoleName"]!.HeaderText = "Vai trò";
            if (dgvUsers.Columns.Contains("Status")) dgvUsers.Columns["Status"]!.HeaderText = "Trạng thái";
            if (dgvUsers.Columns.Contains("CreatedDate")) dgvUsers.Columns["CreatedDate"]!.HeaderText = "Ngày tạo";
            if (dgvUsers.Columns.Contains("Nhom_ID")) dgvUsers.Columns["Nhom_ID"]!.Visible = false;
            if (dgvUsers.Columns.Contains("TenNhom")) dgvUsers.Columns["TenNhom"]!.HeaderText = "Nhóm";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadUsers(); return; }
            dgvUsers.DataSource = UserService.Search(kw);
            SetColumns();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new Forms.UserEditForm();
            if (frm.ShowDialog() == DialogResult.OK) LoadUsers();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            var frm = new Forms.UserEditForm(id);
            if (frm.ShowDialog() == DialogResult.OK) LoadUsers();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            string name = dgvUsers.CurrentRow.Cells["Username"].Value?.ToString() ?? "";
            if (id == CurrentSession.CurrentUser!.UserID)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa người dùng '{name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            UserService.Delete(id);
            UserService.LogAccess(CurrentSession.CurrentUser.UserID, $"Xóa user: {name}");
            LoadUsers();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            var frm = new Forms.AccessHistoryManagementForm();
            frm.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var frm = new Thong_ke_nguoi_dung_form();
            frm.ShowDialog();
        }

        private void btnNguonGen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Nguon_gen_form().ShowDialog();
            this.Show();
        }

        private void btnGiongVatNuoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Giong_vat_nuoi_form().ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, "Đăng xuất");
            CurrentSession.Logout();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && CurrentSession.IsLoggedIn)
                CurrentSession.Logout();
            base.OnFormClosing(e);
        }
    }
}
