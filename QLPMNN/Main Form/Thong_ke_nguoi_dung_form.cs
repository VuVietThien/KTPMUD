using QLPMNN.Database;

namespace QLPMNN
{
    public partial class Thong_ke_nguoi_dung_form : Form
    {
        public Thong_ke_nguoi_dung_form()
        {
            InitializeComponent();
        }

        private void Thong_ke_nguoi_dung_form_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var dtRole = DatabaseConnection.ExecuteQuery(
                @"SELECT r.RoleName, COUNT(u.UserID) as SoLuong
                  FROM Roles r LEFT JOIN Users u ON u.RoleID = r.RoleID
                  GROUP BY r.RoleID, r.RoleName");
            dgvRole.DataSource = dtRole;
            if (dgvRole.Columns.Contains("RoleName")) dgvRole.Columns["RoleName"]!.HeaderText = "Vai trò";
            if (dgvRole.Columns.Contains("SoLuong")) dgvRole.Columns["SoLuong"]!.HeaderText = "Số lượng";

            var dtStatus = DatabaseConnection.ExecuteQuery(
                @"SELECT Status, COUNT(*) as SoLuong FROM Users GROUP BY Status");
            dgvStatus.DataSource = dtStatus;
            if (dgvStatus.Columns.Contains("Status")) dgvStatus.Columns["Status"]!.HeaderText = "Trạng thái";
            if (dgvStatus.Columns.Contains("SoLuong")) dgvStatus.Columns["SoLuong"]!.HeaderText = "Số lượng";

            var total = DatabaseConnection.ExecuteScalar("SELECT COUNT(*) FROM Users");
            var active = DatabaseConnection.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Status='active'");
            var nhom = DatabaseConnection.ExecuteScalar("SELECT COUNT(*) FROM Nhom");
            lblTotal.Text = $"Tổng số user: {total}";
            lblActive.Text = $"Đang hoạt động: {active}";
            lblNhom.Text = $"Số nhóm: {nhom}";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
