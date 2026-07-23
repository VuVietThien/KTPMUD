using QLPMNN.Models;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class ToChucSoHuuDucGiongManagementForm : Form
    {
        private int _selectedId = 0;
        public ToChucSoHuuDucGiongManagementForm() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = ToChucSoHuuDucGiongService.GetAll();
            var map = new Dictionary<string, string> {
                ["ID"]="ID",["TenToChuc"]="Tên tổ chức",["LoaiHinh"]="Loại hình",["LoaiDucGiong"]="Loại đực giống",
                ["DiaChi"]="Địa chỉ",["SoDienThoai"]="SĐT",["Email"]="Email",
                ["MaSoThue"]="MST",["GiayPhepKinhDoanh"]="GP KD",["GhiChu"]="Ghi chú"
            };
            foreach (var kv in map) if (dgv.Columns.Contains(kv.Key)) dgv.Columns[kv.Key]!.HeaderText = kv.Value;
            if (dgv.Columns.Contains("IsActive")) dgv.Columns["IsActive"]!.Visible = false;
            if (dgv.Columns.Contains("CreatedDate")) dgv.Columns["CreatedDate"]!.Visible = false;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["ID"].Value);
            txtTen.Text = row.Cells["TenToChuc"].Value?.ToString();
            txtLoaiHinh.Text = row.Cells["LoaiHinh"].Value?.ToString();
            txtLoaiDucGiong.Text = row.Cells["LoaiDucGiong"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtMST.Text = row.Cells["MaSoThue"].Value?.ToString();
            txtGPKD.Text = row.Cells["GiayPhepKinhDoanh"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private ToChucSoHuuDucGiong GetEntity() => new() {
            ID=_selectedId, TenToChuc=txtTen.Text.Trim(), LoaiHinh=txtLoaiHinh.Text.Trim(),
            LoaiDucGiong=txtLoaiDucGiong.Text.Trim(), DiaChi=txtDiaChi.Text.Trim(),
            SoDienThoai=txtSDT.Text.Trim(), Email=txtEmail.Text.Trim(),
            MaSoThue=txtMST.Text.Trim(), GiayPhepKinhDoanh=txtGPKD.Text.Trim(), GhiChu=txtGhiChu.Text.Trim()
        };

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageBox.Show("Vui lòng nhập Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ToChucSoHuuDucGiongService.Add(GetEntity());
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm TC Sở hữu Đực Giống: {txtTen.Text}");
            LoadData(); ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            ToChucSoHuuDucGiongService.Update(GetEntity());
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa TC Sở hữu Đực Giống ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            if (MessageBox.Show("Xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            ToChucSoHuuDucGiongService.Delete(_selectedId);
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa TC Sở hữu Đực Giống ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            dgv.DataSource = string.IsNullOrEmpty(kw) ? ToChucSoHuuDucGiongService.GetAll() : ToChucSoHuuDucGiongService.Search(kw);
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearInputs()
        {
            _selectedId = 0; txtTen.Clear(); txtLoaiHinh.Clear(); txtLoaiDucGiong.Clear(); txtDiaChi.Clear();
            txtSDT.Clear(); txtEmail.Clear(); txtMST.Clear(); txtGPKD.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
        }
    }
}
