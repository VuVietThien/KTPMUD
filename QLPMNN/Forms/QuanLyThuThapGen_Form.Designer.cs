namespace QLPMNN.Forms
{
    partial class QuanLyThuThapGen_Form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel(); this.lblTitle = new Label();
            this.pnlInput = new Panel();
            this.lblMa = new Label(); this.txtMa = new TextBox();
            this.lblTen = new Label(); this.txtTen = new TextBox();
            this.lblDiaChi = new Label(); this.txtDiaChi = new TextBox();
            this.lblSDT = new Label(); this.txtSDT = new TextBox();
            this.lblEmail = new Label(); this.txtEmail = new TextBox();
            this.lblNguoiDaiDien = new Label(); this.txtNguoiDaiDien = new TextBox();
            this.lblGhiChu = new Label(); this.txtGhiChu = new TextBox();
            this.pnlToolbar = new Panel(); this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button(); this.btnThem = new Button();
            this.btnSua = new Button(); this.btnXoa = new Button();
            this.btnLamMoi = new Button(); this.btnBack = new Button();
            this.dgv = new DataGridView();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 55;
            this.lblTitle.Text = "QUẢN LÝ TỔ CHỨC THU THẬP GEN";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White; this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(lblTitle);

            this.pnlInput.BackColor = Color.White;
            this.pnlInput.Dock = DockStyle.Top; this.pnlInput.Height = 120;

            void F(Label l, TextBox t, string cap, int x, int y, int w)
            {
                l.Text = cap; l.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                l.Location = new Point(x, y); l.Size = new Size(w, 18);
                t.Font = new Font("Segoe UI", 10); t.BorderStyle = BorderStyle.FixedSingle;
                t.Location = new Point(x, y + 20); t.Size = new Size(w, 28);
                pnlInput.Controls.AddRange(new Control[] { l, t });
            }
            F(lblMa, txtMa, "Mã *", 10, 8, 110);
            F(lblTen, txtTen, "Tên tổ chức *", 130, 8, 260);
            F(lblDiaChi, txtDiaChi, "Địa chỉ", 400, 8, 220);
            F(lblSDT, txtSDT, "SĐT", 630, 8, 130);
            F(lblEmail, txtEmail, "Email", 10, 68, 200);
            F(lblNguoiDaiDien, txtNguoiDaiDien, "Người đại diện", 220, 68, 200);
            F(lblGhiChu, txtGhiChu, "Ghi chú", 430, 68, 340);

            this.pnlToolbar.BackColor = Color.FromArgb(241, 248, 233);
            this.pnlToolbar.Dock = DockStyle.Top; this.pnlToolbar.Height = 45;
            this.txtTimKiem.Location = new Point(10, 8); this.txtTimKiem.Size = new Size(220, 28);
            this.txtTimKiem.Font = new Font("Segoe UI", 10); this.txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";

            void B(Button b, string t, int x, Color c, EventHandler h)
            {
                b.Text = t; b.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                b.BackColor = c; b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
                b.Location = new Point(x, 8); b.Size = new Size(80, 28);
                b.Cursor = Cursors.Hand; b.Click += h;
            }
            B(btnTimKiem, "🔍 Tìm", 240, Color.SteelBlue, btnTimKiem_Click);
            B(btnThem, "➕ Thêm", 335, Color.SeaGreen, btnThem_Click);
            B(btnSua, "✏ Sửa", 425, Color.DarkOrange, btnSua_Click);
            B(btnXoa, "🗑 Xóa", 515, Color.Firebrick, btnXoa_Click);
            B(btnLamMoi, "🔄 Mới", 605, Color.Gray, btnLamMoi_Click);
            B(btnBack, "← Quay lại", 700, Color.DimGray, btnBack_Click);
            this.pnlToolbar.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack });

            this.dgv.Dock = DockStyle.Fill; this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = Color.White; this.dgv.BorderStyle = BorderStyle.None;
            this.dgv.RowHeadersVisible = false; this.dgv.AllowUserToAddRows = false;
            this.dgv.CellClick += dgv_CellClick;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(dgv); this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlInput); this.Controls.Add(pnlHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thu thập Gen";
            this.Load += Form_Load;
            this.ResumeLayout(false);
        }

        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblMa, lblTen, lblDiaChi, lblSDT, lblEmail, lblNguoiDaiDien, lblGhiChu;
        private TextBox txtMa, txtTen, txtDiaChi, txtSDT, txtEmail, txtNguoiDaiDien, txtGhiChu, txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgv;
    }
}
