using System.Data;
using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public class QuanLyTinh_Form : Form
    {
        private string _selectedMa = "";

        public QuanLyTinh_Form()
        {
            InitializeComponent();
        }

        private void QuanLyTinh_Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            var dt = DatabaseConnection.ExecuteQuery("SELECT MaTinh, TenTinh, GhiChu FROM DonViHanhChinhTinh ORDER BY MaTinh");
            dgvTinh.DataSource = dt;
            dgvTinh.Columns["MaTinh"]!.HeaderText = "Mã Tỉnh";
            dgvTinh.Columns["TenTinh"]!.HeaderText = "Tên Tỉnh";
            dgvTinh.Columns["GhiChu"]!.HeaderText = "Ghi Chú";
        }

        private void dgvTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTinh.Rows[e.RowIndex];
            _selectedMa = row.Cells["MaTinh"].Value?.ToString() ?? "";
            txtMaTinh.Text = _selectedMa;
            txtTenTinh.Text = row.Cells["TenTinh"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTinh.Text) || string.IsNullOrWhiteSpace(txtTenTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên tỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sql = "INSERT INTO DonViHanhChinhTinh VALUES(@Ma, @Ten, @GhiChu)";
            var p = new SqlParameter[] {
                new("@Ma", txtMaTinh.Text.Trim()),
                new("@Ten", txtTenTinh.Text.Trim()),
                new("@GhiChu", txtGhiChu.Text.Trim())
            };
            try
            {
                DatabaseConnection.ExecuteNonQuery(sql, p);
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm tỉnh: {txtMaTinh.Text}");
                LoadData(); ClearInputs();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa))
            {
                MessageBox.Show("Vui lòng chọn tỉnh cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sql = "UPDATE DonViHanhChinhTinh SET TenTinh=@Ten, GhiChu=@GhiChu WHERE MaTinh=@Ma";
            var p = new SqlParameter[] {
                new("@Ten", txtTenTinh.Text.Trim()),
                new("@GhiChu", txtGhiChu.Text.Trim()),
                new("@Ma", _selectedMa)
            };
            DatabaseConnection.ExecuteNonQuery(sql, p);
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa tỉnh: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            if (MessageBox.Show($"Xóa tỉnh '{_selectedMa}'? Các xã thuộc tỉnh này cũng sẽ bị xóa!", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DatabaseConnection.ExecuteNonQuery("DELETE FROM DonViHanhChinhTinh WHERE MaTinh=@Ma",
                new[] { new SqlParameter("@Ma", _selectedMa) });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa tỉnh: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadData(); return; }
            dgvTinh.DataSource = DatabaseConnection.ExecuteQuery(
                "SELECT * FROM DonViHanhChinhTinh WHERE MaTinh LIKE @kw OR TenTinh LIKE @kw ORDER BY MaTinh",
                new[] { new SqlParameter("@kw", $"%{kw}%") });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearInputs()
        {
            _selectedMa = "";
            txtMaTinh.Clear(); txtTenTinh.Clear(); txtGhiChu.Clear(); txtTimKiem.Clear();
        }

        #region Windows Form Designer generated code
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlInput = new Panel();
            this.lblMaTinh = new Label(); this.txtMaTinh = new TextBox();
            this.lblTenTinh = new Label(); this.txtTenTinh = new TextBox();
            this.lblGhiChu = new Label(); this.txtGhiChu = new TextBox();
            this.pnlToolbar = new Panel();
            this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button(); this.btnThem = new Button();
            this.btnSua = new Button(); this.btnXoa = new Button();
            this.btnLamMoi = new Button(); this.btnBack = new Button();
            this.dgvTinh = new DataGridView();
            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 55;
            this.lblTitle.Text = "QUẢN LÝ ĐƠN VỊ HÀNH CHÍNH TỈNH";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(lblTitle);

            // Input panel
            this.pnlInput.BackColor = Color.White;
            this.pnlInput.Dock = DockStyle.Top; this.pnlInput.Height = 115;
            this.pnlInput.Padding = new Padding(10, 8, 10, 8);

            void AddField(Label lbl, TextBox txt, string caption, int left, int width)
            {
                lbl.Text = caption; lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl.Location = new Point(left, 10); lbl.Size = new Size(width, 18);
                txt.Font = new Font("Segoe UI", 10); txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Location = new Point(left, 30); txt.Size = new Size(width, 28);
                this.pnlInput.Controls.AddRange(new Control[] { lbl, txt });
            }
            AddField(lblMaTinh, txtMaTinh, "Mã Tỉnh *", 10, 120);
            AddField(lblTenTinh, txtTenTinh, "Tên Tỉnh *", 145, 280);
            
            this.lblGhiChu.Text = "Ghi Chú"; this.lblGhiChu.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblGhiChu.Location = new Point(440, 10); this.lblGhiChu.Size = new Size(200, 18);
            this.txtGhiChu.Font = new Font("Segoe UI", 10); this.txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            this.txtGhiChu.Location = new Point(440, 30); this.txtGhiChu.Size = new Size(400, 28);
            this.pnlInput.Controls.AddRange(new Control[] { lblGhiChu, txtGhiChu });

            // Toolbar
            this.pnlToolbar.BackColor = Color.FromArgb(241, 248, 233);
            this.pnlToolbar.Dock = DockStyle.Top; this.pnlToolbar.Height = 45;

            this.txtTimKiem.Location = new Point(10, 8); this.txtTimKiem.Size = new Size(220, 28);
            this.txtTimKiem.Font = new Font("Segoe UI", 10); this.txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";

            void AddBtn(Button btn, string text, int left, Color bg, EventHandler handler)
            {
                btn.Text = text; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.BackColor = bg; btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(left, 8); btn.Size = new Size(80, 28);
                btn.Cursor = Cursors.Hand; btn.Click += handler;
            }
            AddBtn(btnTimKiem, "🔍 Tìm", 240, Color.SteelBlue, btnTimKiem_Click);
            AddBtn(btnThem, "➕ Thêm", 335, Color.SeaGreen, btnThem_Click);
            AddBtn(btnSua, "✏ Sửa", 425, Color.DarkOrange, btnSua_Click);
            AddBtn(btnXoa, "🗑 Xóa", 515, Color.Firebrick, btnXoa_Click);
            AddBtn(btnLamMoi, "🔄 Mới", 605, Color.Gray, btnLamMoi_Click);
            AddBtn(btnBack, "← Quay lại", 700, Color.DimGray, btnBack_Click);

            this.pnlToolbar.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack });

            // DataGridView
            this.dgvTinh.Dock = DockStyle.Fill;
            this.dgvTinh.ReadOnly = true;
            this.dgvTinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTinh.BackgroundColor = Color.White;
            this.dgvTinh.BorderStyle = BorderStyle.None;
            this.dgvTinh.RowHeadersVisible = false;
            this.dgvTinh.AllowUserToAddRows = false;
            this.dgvTinh.CellClick += dgvTinh_CellClick;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(dgvTinh);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Tỉnh";
            this.Load += QuanLyTinh_Form_Load;
            this.ResumeLayout(false);
        }

        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblMaTinh, lblTenTinh, lblGhiChu;
        private TextBox txtMaTinh, txtTenTinh, txtGhiChu, txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgvTinh;
        #endregion
    }
}
