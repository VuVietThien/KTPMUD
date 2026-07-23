namespace QLPMNN
{
    partial class Quan_ly_nguoi_dung_form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLeft = new Panel();
            this.lblTitleLeft = new Label();
            this.lblAdmin = new Label();
            this.btnNguonGen = new Button();
            this.btnGiongVatNuoi = new Button();
            this.btnLichSu = new Button();
            this.btnThongKe = new Button();
            this.btnLogout = new Button();
            this.pnlRight = new Panel();
            this.pnlToolbar = new Panel();
            this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.dgvUsers = new DataGridView();
            this.lblHeader = new Label();
            this.SuspendLayout();

            // pnlLeft
            this.pnlLeft.BackColor = Color.FromArgb(27, 94, 32);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Width = 200;

            this.lblTitleLeft.Text = "QLCNN\nADMIN";
            this.lblTitleLeft.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitleLeft.ForeColor = Color.White;
            this.lblTitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitleLeft.Dock = DockStyle.Top;
            this.lblTitleLeft.Height = 70;

            this.lblAdmin.Text = "";
            this.lblAdmin.Font = new Font("Segoe UI", 9);
            this.lblAdmin.ForeColor = Color.LightCyan;
            this.lblAdmin.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAdmin.Dock = DockStyle.Top;
            this.lblAdmin.Height = 30;

            void AddNavBtn(Button btn, string text, int top, EventHandler handler)
            {
                btn.Text = text; btn.Font = new Font("Segoe UI", 10);
                btn.ForeColor = Color.White; btn.BackColor = Color.FromArgb(46, 125, 50);
                btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderColor = Color.FromArgb(102, 187, 106);
                btn.Location = new Point(10, top); btn.Size = new Size(180, 42);
                btn.Cursor = Cursors.Hand; btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(5, 0, 0, 0); btn.Click += handler;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(102, 187, 106);
                btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(46, 125, 50);
            }

            AddNavBtn(btnNguonGen, "🌱 Nguồn Gen", 120, btnNguonGen_Click);
            AddNavBtn(btnGiongVatNuoi, "🐄 Giống Vật Nuôi", 172, btnGiongVatNuoi_Click);
            AddNavBtn(btnLichSu, "📋 Lịch sử truy cập", 224, btnLichSu_Click);
            AddNavBtn(btnThongKe, "📊 Thống kê", 276, btnThongKe_Click);

            btnLogout.Text = "⏻ Đăng xuất";
            btnLogout.Font = new Font("Segoe UI", 10);
            btnLogout.ForeColor = Color.White; btnLogout.BackColor = Color.Firebrick;
            btnLogout.FlatStyle = FlatStyle.Flat; btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Location = new Point(10, 560); btnLogout.Size = new Size(180, 42);
            btnLogout.Cursor = Cursors.Hand; btnLogout.Click += btnLogout_Click;

            this.pnlLeft.Controls.AddRange(new Control[] {
                lblTitleLeft, lblAdmin, btnNguonGen, btnGiongVatNuoi, btnLichSu, btnThongKe, btnLogout
            });

            // pnlRight
            this.pnlRight.BackColor = Color.FromArgb(241, 248, 233);
            this.pnlRight.Dock = DockStyle.Fill;

            this.lblHeader.Text = "QUẢN LÝ NGƯỜI DÙNG";
            this.lblHeader.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.FromArgb(46, 125, 50);
            this.lblHeader.Dock = DockStyle.Top;
            this.lblHeader.Height = 45;
            this.lblHeader.Padding = new Padding(10, 0, 0, 0);

            // pnlToolbar
            this.pnlToolbar.Dock = DockStyle.Top;
            this.pnlToolbar.Height = 50;
            this.pnlToolbar.BackColor = Color.White;
            this.pnlToolbar.Padding = new Padding(10, 8, 10, 8);

            this.txtTimKiem.Location = new Point(10, 12);
            this.txtTimKiem.Size = new Size(250, 28);
            this.txtTimKiem.Font = new Font("Segoe UI", 10);
            this.txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";

            void AddToolBtn(Button btn, string text, int left, Color bg, EventHandler handler)
            {
                btn.Text = text; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.BackColor = bg; btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(left, 10); btn.Size = new Size(90, 30);
                btn.Cursor = Cursors.Hand; btn.Click += handler;
            }

            AddToolBtn(btnTimKiem, "🔍 Tìm", 270, Color.SteelBlue, btnTimKiem_Click);
            AddToolBtn(btnThem, "➕ Thêm", 375, Color.SeaGreen, btnThem_Click);
            AddToolBtn(btnSua, "✏ Sửa", 475, Color.DarkOrange, btnSua_Click);
            AddToolBtn(btnXoa, "🗑 Xóa", 575, Color.Firebrick, btnXoa_Click);

            this.pnlToolbar.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem, btnThem, btnSua, btnXoa });

            // dgvUsers
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.AllowUserToAddRows = false;

            this.pnlRight.Controls.Add(dgvUsers);
            this.pnlRight.Controls.Add(pnlToolbar);
            this.pnlRight.Controls.Add(lblHeader);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1100, 660);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "QLCNN - Quản trị hệ thống";
            this.MinimumSize = new Size(900, 600);
            this.Load += Quan_ly_nguoi_dung_form_Load;
            this.ResumeLayout(false);
        }

        private Panel pnlLeft, pnlRight, pnlToolbar;
        private Label lblTitleLeft, lblAdmin, lblHeader;
        private Button btnNguonGen, btnGiongVatNuoi, btnLichSu, btnThongKe, btnLogout;
        private TextBox txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa;
        private DataGridView dgvUsers;
    }
}
