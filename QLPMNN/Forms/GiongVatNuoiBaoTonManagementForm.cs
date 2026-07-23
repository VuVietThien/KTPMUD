using QLPMNN.Models;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public partial class GiongVatNuoiBaoTonManagementForm : Form
    {
        private int _selectedId = 0;

        public GiongVatNuoiBaoTonManagementForm() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = GiongVatNuoiBaoTonService.GetAll();
            SetHeaders();
        }

        private void SetHeaders()
        {
            var map = new Dictionary<string, string> {
                ["ID"]="ID",["TenGiong"]="Tên giống",["LoaiVatNuoi"]="Loại vật nuôi",
                ["MoTa"]="Mô tả",["TinhTrang"]="Tình trạng",["DiaDiemBaoTon"]="Địa điểm BT",
                ["GhiChu"]="Ghi chú",["CreatedDate"]="Ngày tạo",["IsActive"]="Hoạt động"
            };
            foreach (var kv in map) if (dgv.Columns.Contains(kv.Key)) dgv.Columns[kv.Key]!.HeaderText = kv.Value;
            if (dgv.Columns.Contains("IsActive")) dgv.Columns["IsActive"]!.Visible = false;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["ID"].Value);
            txtTen.Text = row.Cells["TenGiong"].Value?.ToString();
            txtLoai.Text = row.Cells["LoaiVatNuoi"].Value?.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
            txtTinhTrang.Text = row.Cells["TinhTrang"].Value?.ToString();
            txtDiaDiem.Text = row.Cells["DiaDiemBaoTon"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            { MessageBox.Show("Vui lòng nhập Tên giống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            GiongVatNuoiBaoTonService.Add(new GiongVatNuoiBaoTon {
                TenGiong = txtTen.Text.Trim(), LoaiVatNuoi = txtLoai.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(), TinhTrang = txtTinhTrang.Text.Trim(),
                DiaDiemBaoTon = txtDiaDiem.Text.Trim(), GhiChu = txtGhiChu.Text.Trim()
            });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm giống bảo tồn: {txtTen.Text}");
            LoadData(); ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            GiongVatNuoiBaoTonService.Update(new GiongVatNuoiBaoTon {
                ID = _selectedId, TenGiong = txtTen.Text.Trim(), LoaiVatNuoi = txtLoai.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(), TinhTrang = txtTinhTrang.Text.Trim(),
                DiaDiemBaoTon = txtDiaDiem.Text.Trim(), GhiChu = txtGhiChu.Text.Trim()
            });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa giống bảo tồn ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            if (MessageBox.Show("Xóa giống này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            GiongVatNuoiBaoTonService.Delete(_selectedId);
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa giống bảo tồn ID={_selectedId}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            dgv.DataSource = string.IsNullOrEmpty(kw) ? GiongVatNuoiBaoTonService.GetAll() : GiongVatNuoiBaoTonService.Search(kw);
            SetHeaders();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearInputs()
        {
            _selectedId = 0; txtTen.Clear(); txtLoai.Clear(); txtMoTa.Clear();
            txtTinhTrang.Clear(); txtDiaDiem.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
        }
    }
}
