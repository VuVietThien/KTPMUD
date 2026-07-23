using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            var user = CurrentSession.CurrentUser!;
            lblName.Text = user.Username;
            lblEmail.Text = user.Email ?? "(chưa có)";
            lblStatus.Text = user.Status == "active" ? "Hoạt động" : "Không hoạt động";
            lblStatus.ForeColor = user.Status == "active" ? Color.Green : Color.Red;
            lblCreatedDate.Text = user.CreatedDate.ToString("dd/MM/yyyy HH:mm");

            var nhom = UserService.GetNhomByUser(user.UserID);
            if (nhom != null)
            {
                lblNhom.Text = nhom.Ten_nhom;
                lblNhomID.Text = nhom.Nhom_ID.ToString();
                lblNhomSL.Text = nhom.So_luong.ToString();
                btnTaoNhom.Visible = false;
                btnSuaNhom.Visible = true;
                btnXoaNhom.Visible = true;
                LoadThanhVien(nhom.Nhom_ID);
            }
            else
            {
                lblNhom.Text = "(chưa có nhóm)";
                lblNhomID.Text = "";
                lblNhomSL.Text = "0";
                btnTaoNhom.Visible = true;
                btnSuaNhom.Visible = false;
                btnXoaNhom.Visible = false;
                dgvThanhvien.DataSource = null;
            }
        }

        private void LoadThanhVien(int nhomId)
        {
            var list = UserService.GetThanhVienNhom(nhomId);
            dgvThanhvien.DataSource = list;
            if (dgvThanhvien.Columns.Contains("UserID")) dgvThanhvien.Columns["UserID"]!.HeaderText = "ID";
            if (dgvThanhvien.Columns.Contains("Username")) dgvThanhvien.Columns["Username"]!.HeaderText = "Tên tài khoản";
            if (dgvThanhvien.Columns.Contains("Email")) dgvThanhvien.Columns["Email"]!.HeaderText = "Email";
            if (dgvThanhvien.Columns.Contains("Status")) dgvThanhvien.Columns["Status"]!.HeaderText = "Trạng thái";
        }

        private void btnNguonGen_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Nguon_gen_form();
            frm.ShowDialog();
            this.Show();
        }

        private void btnGiongVatNuoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Giong_vat_nuoi_form();
            frm.ShowDialog();
            this.Show();
        }

        private void btnThucAn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Forms.QuanLyThucAn_Form();
            frm.ShowDialog();
            this.Show();
        }

        private void btnTaoNhom_Click(object sender, EventArgs e)
        {
            string? tenNhom = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên nhóm:", "Tạo nhóm mới", "");
            if (string.IsNullOrWhiteSpace(tenNhom)) return;
            UserService.TaoNhom(tenNhom, CurrentSession.CurrentUser!.UserID);
            CurrentSession.CurrentUser = UserService.GetById(CurrentSession.CurrentUser.UserID);
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Tạo nhóm: {tenNhom}");
            LoadUserInfo();
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            var nhom = UserService.GetNhomByUser(CurrentSession.CurrentUser!.UserID);
            if (nhom == null) return;
            string? tenNhom = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên nhóm mới:", "Chỉnh sửa nhóm", nhom.Ten_nhom);
            if (string.IsNullOrWhiteSpace(tenNhom)) return;
            UserService.SuaNhom(nhom.Nhom_ID, tenNhom);
            UserService.LogAccess(CurrentSession.CurrentUser.UserID, $"Sửa nhóm: {tenNhom}");
            LoadUserInfo();
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            var nhom = UserService.GetNhomByUser(CurrentSession.CurrentUser!.UserID);
            if (nhom == null) return;
            if (MessageBox.Show($"Xóa nhóm '{nhom.Ten_nhom}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            UserService.XoaNhom(nhom.Nhom_ID);
            UserService.LogAccess(CurrentSession.CurrentUser.UserID, $"Xóa nhóm: {nhom.Ten_nhom}");
            CurrentSession.CurrentUser = UserService.GetById(CurrentSession.CurrentUser.UserID);
            LoadUserInfo();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, "Đăng xuất");
            CurrentSession.Logout();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (CurrentSession.IsLoggedIn)
                    UserService.LogAccess(CurrentSession.CurrentUser!.UserID, "Đóng cửa sổ");
                CurrentSession.Logout();
            }
            base.OnFormClosing(e);
        }
    }
}
