using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class QuanLyThucAn_Form : Form
    {
        private string _selectedMa = "";

        public QuanLyThucAn_Form() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = DatabaseConnection.ExecuteQuery("SELECT * FROM ThucAnChanNuoi ORDER BY MaThucAn");
            var map = new Dictionary<string, string> {
                ["MaThucAn"]="Mã",["TenThucAn"]="Tên thức ăn",["LoaiThucAn"]="Loại",
                ["ThanhPhan"]="Thành phần",["HamLuongDinhDuong"]="Hàm lượng DD",
                ["DonViTinh"]="ĐVT",["GiaThamKhao"]="Giá tham khảo",["NhaCungCap"]="Nhà cung cấp",["GhiChu"]="Ghi chú"
            };
            foreach (var kv in map) if (dgv.Columns.Contains(kv.Key)) dgv.Columns[kv.Key]!.HeaderText = kv.Value;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv.Rows[e.RowIndex];
            _selectedMa = row.Cells["MaThucAn"].Value?.ToString() ?? "";
            txtMa.Text = _selectedMa;
            txtTen.Text = row.Cells["TenThucAn"].Value?.ToString();
            txtLoai.Text = row.Cells["LoaiThucAn"].Value?.ToString();
            txtThanhPhan.Text = row.Cells["ThanhPhan"].Value?.ToString();
            txtHamLuong.Text = row.Cells["HamLuongDinhDuong"].Value?.ToString();
            txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString();
            txtGia.Text = row.Cells["GiaThamKhao"].Value?.ToString();
            txtNhaCungCap.Text = row.Cells["NhaCungCap"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            { MessageBox.Show("Vui lòng nhập Mã và Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                decimal gia = decimal.TryParse(txtGia.Text, out var g) ? g : 0;
                DatabaseConnection.ExecuteNonQuery(
                    "INSERT INTO ThucAnChanNuoi VALUES(@Ma,@Ten,@Loai,@TP,@HL,@DVT,@Gia,@NCC,@GhiChu)",
                    GetParams(gia));
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm thức ăn: {txtMa.Text}");
                LoadData(); ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            decimal gia = decimal.TryParse(txtGia.Text, out var g) ? g : 0;
            DatabaseConnection.ExecuteNonQuery(
                "UPDATE ThucAnChanNuoi SET TenThucAn=@Ten,LoaiThucAn=@Loai,ThanhPhan=@TP,HamLuongDinhDuong=@HL,DonViTinh=@DVT,GiaThamKhao=@Gia,NhaCungCap=@NCC,GhiChu=@GhiChu WHERE MaThucAn=@Ma",
                GetParams(gia));
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa thức ăn: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            if (MessageBox.Show($"Xóa '{_selectedMa}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DatabaseConnection.ExecuteNonQuery("DELETE FROM ThucAnChanNuoi WHERE MaThucAn=@Ma", new[] { new SqlParameter("@Ma", _selectedMa) });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa thức ăn: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadData(); return; }
            dgv.DataSource = DatabaseConnection.ExecuteQuery(
                "SELECT * FROM ThucAnChanNuoi WHERE MaThucAn LIKE @kw OR TenThucAn LIKE @kw OR LoaiThucAn LIKE @kw",
                new[] { new SqlParameter("@kw", $"%{kw}%") });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private SqlParameter[] GetParams(decimal gia) => new[]
        {
            new SqlParameter("@Ma", txtMa.Text.Trim()), new SqlParameter("@Ten", txtTen.Text.Trim()),
            new SqlParameter("@Loai", txtLoai.Text.Trim()), new SqlParameter("@TP", txtThanhPhan.Text.Trim()),
            new SqlParameter("@HL", txtHamLuong.Text.Trim()), new SqlParameter("@DVT", txtDonViTinh.Text.Trim()),
            new SqlParameter("@Gia", gia), new SqlParameter("@NCC", txtNhaCungCap.Text.Trim()),
            new SqlParameter("@GhiChu", txtGhiChu.Text.Trim())
        };

        private void ClearInputs()
        {
            _selectedMa = ""; txtMa.Clear(); txtTen.Clear(); txtLoai.Clear(); txtThanhPhan.Clear();
            txtHamLuong.Clear(); txtDonViTinh.Clear(); txtGia.Clear(); txtNhaCungCap.Clear();
            txtGhiChu.Clear(); txtTimKiem.Clear();
        }
    }
}
