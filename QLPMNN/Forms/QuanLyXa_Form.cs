using System.Data.SqlClient;
using QLPMNN.Database;
using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN.Forms
{
    public class QuanLyXa_Form : Form
    {
        private string _selectedMa = "";

        public QuanLyXa_Form()
        {
            InitializeComponent();
        }

        private void QuanLyXa_Form_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadData();
        }

        private void LoadTinh()
        {
            var dt = DatabaseConnection.ExecuteQuery("SELECT MaTinh, TenTinh FROM DonViHanhChinhTinh ORDER BY TenTinh");
            cmbTinh.DataSource = dt;
            cmbTinh.DisplayMember = "TenTinh";
            cmbTinh.ValueMember = "MaTinh";
            cmbTinh.SelectedIndex = -1;
        }

        private void LoadData()
        {
            var dt = DatabaseConnection.ExecuteQuery(
                @"SELECT x.MaXa, x.TenXa, x.MaTinh, t.TenTinh, x.GhiChu
                  FROM DonViHanhChinhXa x JOIN DonViHanhChinhTinh t ON x.MaTinh = t.MaTinh
                  ORDER BY x.MaTinh, x.MaXa");
            dgvXa.DataSource = dt;
            if (dgvXa.Columns.Contains("MaXa")) dgvXa.Columns["MaXa"]!.HeaderText = "Mã Xã";
            if (dgvXa.Columns.Contains("TenXa")) dgvXa.Columns["TenXa"]!.HeaderText = "Tên Xã";
            if (dgvXa.Columns.Contains("MaTinh")) dgvXa.Columns["MaTinh"]!.Visible = false;
            if (dgvXa.Columns.Contains("TenTinh")) dgvXa.Columns["TenTinh"]!.HeaderText = "Thuộc Tỉnh";
            if (dgvXa.Columns.Contains("GhiChu")) dgvXa.Columns["GhiChu"]!.HeaderText = "Ghi Chú";
        }

        private void dgvXa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvXa.Rows[e.RowIndex];
            _selectedMa = row.Cells["MaXa"].Value?.ToString() ?? "";
            txtMaXa.Text = _selectedMa;
            txtTenXa.Text = row.Cells["TenXa"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            string maTinh = row.Cells["MaTinh"].Value?.ToString() ?? "";
            
            if (cmbTinh.DataSource is System.Data.DataTable dt)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i]["MaTinh"].ToString() == maTinh)
                    {
                        cmbTinh.SelectedIndex = i;
                        break;
                    }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaXa.Text) || string.IsNullOrWhiteSpace(txtTenXa.Text) || cmbTinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Xã, Tên Xã và chọn Tỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DatabaseConnection.ExecuteNonQuery(
                    "INSERT INTO DonViHanhChinhXa VALUES(@Ma, @Ten, @MaTinh, @GhiChu)",
                    new SqlParameter[] {
                        new("@Ma", txtMaXa.Text.Trim()),
                        new("@Ten", txtTenXa.Text.Trim()),
                        new("@MaTinh", cmbTinh.SelectedValue!.ToString()!),
                        new("@GhiChu", txtGhiChu.Text.Trim())
                    });
                UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Thêm xã: {txtMaXa.Text}");
                LoadData(); ClearInputs();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa) || cmbTinh.SelectedValue == null) return;
            DatabaseConnection.ExecuteNonQuery(
                "UPDATE DonViHanhChinhXa SET TenXa=@Ten, MaTinh=@MaTinh, GhiChu=@GhiChu WHERE MaXa=@Ma",
                new SqlParameter[] {
                    new("@Ten", txtTenXa.Text.Trim()),
                    new("@MaTinh", cmbTinh.SelectedValue!.ToString()!),
                    new("@GhiChu", txtGhiChu.Text.Trim()),
                    new("@Ma", _selectedMa)
                });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Sửa xã: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMa)) return;
            if (MessageBox.Show($"Xóa xã '{_selectedMa}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DatabaseConnection.ExecuteNonQuery("DELETE FROM DonViHanhChinhXa WHERE MaXa=@Ma",
                new[] { new SqlParameter("@Ma", _selectedMa) });
            UserService.LogAccess(CurrentSession.CurrentUser!.UserID, $"Xóa xã: {_selectedMa}");
            LoadData(); ClearInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadData(); return; }
            dgvXa.DataSource = DatabaseConnection.ExecuteQuery(
                @"SELECT x.MaXa, x.TenXa, x.MaTinh, t.TenTinh, x.GhiChu
                  FROM DonViHanhChinhXa x JOIN DonViHanhChinhTinh t ON x.MaTinh = t.MaTinh
                  WHERE x.MaXa LIKE @kw OR x.TenXa LIKE @kw OR t.TenTinh LIKE @kw",
                new[] { new SqlParameter("@kw", $"%{kw}%") });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }
        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearInputs()
        {
            _selectedMa = ""; txtMaXa.Clear(); txtTenXa.Clear(); txtGhiChu.Clear();
            txtTimKiem.Clear(); cmbTinh.SelectedIndex = -1;
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
            this.lblMaXa = new Label(); this.txtMaXa = new TextBox();
            this.lblTenXa = new Label(); this.txtTenXa = new TextBox();
            this.lblTinh = new Label(); this.cmbTinh = new ComboBox();
            this.lblGhiChu = new Label(); this.txtGhiChu = new TextBox();
            this.pnlToolbar = new Panel();
            this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button(); this.btnThem = new Button();
            this.btnSua = new Button(); this.btnXoa = new Button();
            this.btnLamMoi = new Button(); this.btnBack = new Button();
            this.dgvXa = new DataGridView();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 55;
            this.lblTitle.Text = "QUẢN LÝ ĐƠN VỊ HÀNH CHÍNH XÃ";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(lblTitle);

            this.pnlInput.BackColor = Color.White;
            this.pnlInput.Dock = DockStyle.Top; this.pnlInput.Height = 75;
            this.pnlInput.Padding = new Padding(10, 8, 10, 8);

            void AddField(Label lbl, Control ctrl, string caption, int left, int width)
            {
                lbl.Text = caption; lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl.Location = new Point(left, 10); lbl.Size = new Size(width, 18);
                ctrl.Font = new Font("Segoe UI", 10);
                ctrl.Location = new Point(left, 30); ctrl.Size = new Size(width, 28);
                if (ctrl is TextBox txt) txt.BorderStyle = BorderStyle.FixedSingle;
                if (ctrl is ComboBox cmb) { cmb.DropDownStyle = ComboBoxStyle.DropDownList; cmb.FlatStyle = FlatStyle.Flat; }
                this.pnlInput.Controls.AddRange(new Control[] { lbl, ctrl });
            }
            AddField(lblMaXa, txtMaXa, "Mã Xã *", 10, 100);
            AddField(lblTenXa, txtTenXa, "Tên Xã *", 120, 260);
            AddField(lblTinh, cmbTinh, "Thuộc Tỉnh *", 390, 220);
            AddField(lblGhiChu, txtGhiChu, "Ghi Chú", 620, 280);

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

            this.dgvXa.Dock = DockStyle.Fill;
            this.dgvXa.ReadOnly = true;
            this.dgvXa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvXa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXa.BackgroundColor = Color.White;
            this.dgvXa.BorderStyle = BorderStyle.None;
            this.dgvXa.RowHeadersVisible = false;
            this.dgvXa.AllowUserToAddRows = false;
            this.dgvXa.CellClick += dgvXa_CellClick;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 580);
            this.Controls.Add(dgvXa);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Xã";
            this.Load += QuanLyXa_Form_Load;
            this.ResumeLayout(false);
        }

        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblMaXa, lblTenXa, lblTinh, lblGhiChu;
        private TextBox txtMaXa, txtTenXa, txtGhiChu, txtTimKiem;
        private ComboBox cmbTinh;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgvXa;
        #endregion
    }
}
