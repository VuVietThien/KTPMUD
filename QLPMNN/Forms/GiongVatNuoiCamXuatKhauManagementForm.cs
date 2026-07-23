using QLPMNN.Models;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class GiongVatNuoiCamXuatKhauManagementForm : Form
    {
        private int _selectedId = 0;

        public GiongVatNuoiCamXuatKhauManagementForm() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = GiongVatNuoiCamXuatKhauService.GetAll();
            var map = new Dictionary<string, string> {
                ["ID"]="ID",["TenGiong"]="Tên giống",["LoaiVatNuoi"]="Loại vật nuôi",
                ["LyDoCam"]="Lý do cấm",["NgayBanHanh"]="Ngày ban hành",
                ["CoQuanBanHanh"]="Cơ quan ban hành",["GhiChu"]="Ghi chú"
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
            txtTen.Text = row.Cells["TenGiong"].Value?.ToString();
            txtLoai.Text = row.Cells["LoaiVatNuoi"].Value?.ToString();
            txtLyDo.Text = row.Cells["LyDoCam"].Value?.ToString();
            if (row.Cells["NgayBanHanh"].Value != DBNull.Value && row.Cells["NgayBanHanh"].Value != null)
                dtpNgayBanHanh.Value = Convert.ToDateTime(row.Cells["NgayBanHanh"].Value);
            txtCoQuan.Text = row.Cells["CoQuanBanHanh"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            { MessageBox.Show("Vui lòng nhập Tên giống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            GiongVatNuoiCamXuatKhauService.Add(new GiongVatNuoiCamXuatKhau {
                TenGiong = txtTen.Text.Trim(), LoaiVatNuoi = txtLoai.Text.Trim(),
                LyDoCam = txtLyDo.Text.Trim(), NgayBanHanh = chkNgay.Checked ? dtpNgayBanHanh.Value : null,
                CoQuanBanHanh = txtCoQuan.Text.Trim(), GhiChu = txtGhiChu.Text.Trim()
            });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm giống cấm XK: {txtTen.Text}");
            LoadData(); ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            GiongVatNuoiCamXuatKhauService.Update(new GiongVatNuoiCamXuatKhau {
                ID = _selectedId, TenGiong = txtTen.Text.Trim(), LoaiVatNuoi = txtLoai.Text.Trim(),
                LyDoCam = txtLyDo.Text.Trim(), NgayBanHanh = chkNgay.Checked ? dtpNgayBanHanh.Value : null,
                CoQuanBanHanh = txtCoQuan.Text.Trim(), GhiChu = txtGhiChu.Text.Trim()
            });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa giống cấm XK ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            if (MessageBox.Show("Xóa giống này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            GiongVatNuoiCamXuatKhauService.Delete(_selectedId);
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa giống cấm XK ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            dgv.DataSource = string.IsNullOrEmpty(kw) ? GiongVatNuoiCamXuatKhauService.GetAll() : GiongVatNuoiCamXuatKhauService.Search(kw);
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearInputs()
        {
            _selectedId = 0; txtTen.Clear(); txtLoai.Clear(); txtLyDo.Clear();
            txtCoQuan.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
            chkNgay.Checked = false; dtpNgayBanHanh.Value = DateTime.Today;
        }
    }
}
