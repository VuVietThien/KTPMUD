using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class QuanLyKhaiThacGen_Form : Form
    {
        private string _selectedMa = "";

        public QuanLyKhaiThacGen_Form() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = DatabaseConnection.ExecuteQuery("SELECT * FROM ToChucKhaiThacGen ORDER BY MaKhaiThac");
            var map = new Dictionary<string, string> {
                ["MaKhaiThac"]="Mã",["TenToChuc"]="Tên tổ chức",["DiaChi"]="Địa chỉ",
                ["SoDienThoai"]="SĐT",["Email"]="Email",["NguoiDaiDien"]="Người đại diện",["GhiChu"]="Ghi chú"
            };
            foreach (var kv in map) if (dgv.Columns.Contains(kv.Key)) dgv.Columns[kv.Key]!.HeaderText = kv.Value;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv.Rows[e.RowIndex];
            _selectedMa = row.Cells["MaKhaiThac"].Value?.ToString() ?? "";
            txtMa.Text = _selectedMa; txtTen.Text = row.Cells["TenToChuc"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString(); txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString(); txtNguoiDaiDien.Text = row.Cells["NguoiDaiDien"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            { MessageBox.Show("Vui lòng nhập Mã và Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                DatabaseConnection.ExecuteNonQuery("INSERT INTO ToChucKhaiThacGen VALUES(@Ma,@Ten,@DC,@SDT,@Email,@NDD,@GhiChu)", GetParams());
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm khai thác gen: {txtMa.Text}");
                LoadData(); ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            DatabaseConnection.ExecuteNonQuery(
                "UPDATE ToChucKhaiThacGen SET TenToChuc=@Ten,DiaChi=@DC,SoDienThoai=@SDT,Email=@Email,NguoiDaiDien=@NDD,GhiChu=@GhiChu WHERE MaKhaiThac=@Ma",
                GetParams());
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa khai thác gen: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            if (MessageBox.Show($"Xóa '{_selectedMa}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DatabaseConnection.ExecuteNonQuery("DELETE FROM ToChucKhaiThacGen WHERE MaKhaiThac=@Ma", new[] { new SqlParameter("@Ma", _selectedMa) });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa khai thác gen: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadData(); return; }
            dgv.DataSource = DatabaseConnection.ExecuteQuery(
                "SELECT * FROM ToChucKhaiThacGen WHERE MaKhaiThac LIKE @kw OR TenToChuc LIKE @kw ORDER BY MaKhaiThac",
                new[] { new SqlParameter("@kw", $"%{kw}%") });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private SqlParameter[] GetParams() => new[]
        {
            new SqlParameter("@Ma", txtMa.Text.Trim()), new SqlParameter("@Ten", txtTen.Text.Trim()),
            new SqlParameter("@DC", txtDiaChi.Text.Trim()), new SqlParameter("@SDT", txtSDT.Text.Trim()),
            new SqlParameter("@Email", txtEmail.Text.Trim()), new SqlParameter("@NDD", txtNguoiDaiDien.Text.Trim()),
            new SqlParameter("@GhiChu", txtGhiChu.Text.Trim())
        };

        private void ClearInputs()
        {
            _selectedMa = ""; txtMa.Clear(); txtTen.Clear(); txtDiaChi.Clear();
            txtSDT.Clear(); txtEmail.Clear(); txtNguoiDaiDien.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
        }
    }
}
