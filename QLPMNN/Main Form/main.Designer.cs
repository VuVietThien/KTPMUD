namespace QLPMNN
{
    partial class main
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
            this.btnNguonGen = new Button();
            this.btnGiongVatNuoi = new Button();
            this.btnThucAn = new Button();
            this.btnLogout = new Button();
            this.pnlRight = new Panel();
            this.lblHeader = new Label();
            this.grpThongTin = new GroupBox();
            this.lblNameCaption = new Label(); this.lblName = new Label();
            this.lblEmailCaption = new Label(); this.lblEmail = new Label();
            this.lblStatusCaption = new Label(); this.lblStatus = new Label();
            this.lblDateCaption = new Label(); this.lblCreatedDate = new Label();
            this.grpNhom = new GroupBox();
            this.lblNhomCaption = new Label(); this.lblNhom = new Label();
            this.lblNhomIDCaption = new Label(); this.lblNhomID = new Label();
            this.lblNhomSLCaption = new Label(); this.lblNhomSL = new Label();
            this.btnTaoNhom = new Button();
            this.btnSuaNhom = new Button();
            this.btnXoaNhom = new Button();
            this.grpThanhVien = new GroupBox();
            this.dgvThanhvien = new DataGridView();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // pnlLeft
            this.pnlLeft.BackColor = Color.FromArgb(27, 94, 32);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Width = 200;
            this.pnlLeft.Padding = new Padding(10);

            this.lblTitleLeft.Text = "QLCNN";
            this.lblTitleLeft.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitleLeft.ForeColor = Color.White;
            this.lblTitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitleLeft.Dock = DockStyle.Top;
            this.lblTitleLeft.Height = 60;

            void AddNavBtn(Button btn, string text, int top, EventHandler handler)
            {
                btn.Text = text;
                btn.Font = new Font("Segoe UI", 10);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(46, 125, 50);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(102, 187, 106);
                btn.Location = new Point(10, top);
                btn.Size = new Size(180, 42);
                btn.Cursor = Cursors.Hand;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(5, 0, 0, 0);
                btn.Click += handler;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(102, 187, 106);
                btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(46, 125, 50);
            }

            AddNavBtn(btnNguonGen, "🌱 Nguồn Gen", 80, btnNguonGen_Click);
            AddNavBtn(btnGiongVatNuoi, "🐄 Giống Vật Nuôi", 132, btnGiongVatNuoi_Click);
            AddNavBtn(btnThucAn, "🌾 Thức ăn chăn nuôi", 184, btnThucAn_Click);

            btnLogout.Text = "⏻ Đăng xuất";
            btnLogout.Font = new Font("Segoe UI", 10);
            btnLogout.ForeColor = Color.White;
            btnLogout.BackColor = Color.Firebrick;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Location = new Point(10, 560);
            btnLogout.Size = new Size(180, 42);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += btnLogout_Click;

            this.pnlLeft.Controls.AddRange(new Control[] {
                lblTitleLeft, btnNguonGen, btnGiongVatNuoi, btnThucAn, btnLogout
            });

            // pnlRight
            this.pnlRight.BackColor = Color.FromArgb(241, 248, 233);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Padding = new Padding(15);

            this.lblHeader.Text = "THÔNG TIN TÀI KHOẢN";
            this.lblHeader.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.FromArgb(46, 125, 50);
            this.lblHeader.Dock = DockStyle.Top;
            this.lblHeader.Height = 45;

            // grpThongTin
            this.grpThongTin.Text = "Thông tin cá nhân";
            this.grpThongTin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpThongTin.Location = new Point(15, 60);
            this.grpThongTin.Size = new Size(500, 160);

            void AddInfoRow(Label caption, Label value, string captionText, int top)
            {
                caption.Text = captionText;
                caption.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                caption.Location = new Point(10, top);
                caption.Size = new Size(130, 22);
                value.Font = new Font("Segoe UI", 9);
                value.Location = new Point(145, top);
                value.Size = new Size(340, 22);
                value.Text = "";
                this.grpThongTin.Controls.AddRange(new Control[] { caption, value });
            }
            AddInfoRow(lblNameCaption, lblName, "Tên đăng nhập:", 28);
            AddInfoRow(lblEmailCaption, lblEmail, "Email:", 55);
            AddInfoRow(lblStatusCaption, lblStatus, "Trạng thái:", 82);
            AddInfoRow(lblDateCaption, lblCreatedDate, "Ngày tạo:", 109);

            // grpNhom
            this.grpNhom.Text = "Thông tin nhóm";
            this.grpNhom.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpNhom.Location = new Point(15, 230);
            this.grpNhom.Size = new Size(500, 130);

            void AddNhomRow(Label caption, Label value, string captionText, int top)
            {
                caption.Text = captionText;
                caption.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                caption.Location = new Point(10, top);
                caption.Size = new Size(130, 22);
                value.Font = new Font("Segoe UI", 9);
                value.Location = new Point(145, top);
                value.Size = new Size(200, 22);
                value.Text = "";
                this.grpNhom.Controls.AddRange(new Control[] { caption, value });
            }
            AddNhomRow(lblNhomCaption, lblNhom, "Tên nhóm:", 28);
            AddNhomRow(lblNhomIDCaption, lblNhomID, "Mã nhóm:", 55);
            AddNhomRow(lblNhomSLCaption, lblNhomSL, "Số thành viên:", 82);

            void StyleBtn(Button btn, string text, int left, Color bg)
            {
                btn.Text = text; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.BackColor = bg; btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(left, 100); btn.Size = new Size(110, 28);
                btn.Cursor = Cursors.Hand;
            }
            StyleBtn(btnTaoNhom, "Tạo nhóm", 355, Color.SeaGreen);
            StyleBtn(btnSuaNhom, "Sửa nhóm", 355, Color.DarkOrange);
            StyleBtn(btnXoaNhom, "Xóa nhóm", 355, Color.Firebrick);
            btnTaoNhom.Click += btnTaoNhom_Click;
            btnSuaNhom.Click += btnSuaNhom_Click;
            btnXoaNhom.Click += btnXoaNhom_Click;
            this.grpNhom.Controls.AddRange(new Control[] { btnTaoNhom, btnSuaNhom, btnXoaNhom });

            // grpThanhVien
            this.grpThanhVien.Text = "Danh sách thành viên nhóm";
            this.grpThanhVien.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpThanhVien.Location = new Point(15, 370);
            this.grpThanhVien.Size = new Size(500, 230);

            this.dgvThanhvien.Dock = DockStyle.Fill;
            this.dgvThanhvien.ReadOnly = true;
            this.dgvThanhvien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvThanhvien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThanhvien.BackgroundColor = Color.White;
            this.dgvThanhvien.BorderStyle = BorderStyle.None;
            this.grpThanhVien.Controls.Add(dgvThanhvien);

            this.pnlRight.Controls.AddRange(new Control[] {
                lblHeader, grpThongTin, grpNhom, grpThanhVien
            });

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 640);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "QLCNN - Dashboard";
            this.MinimumSize = new Size(800, 600);
            this.Load += main_Load;

            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlLeft, pnlRight;
        private Label lblTitleLeft, lblHeader;
        private Button btnNguonGen, btnGiongVatNuoi, btnThucAn, btnLogout;
        private GroupBox grpThongTin, grpNhom, grpThanhVien;
        private Label lblNameCaption, lblName, lblEmailCaption, lblEmail;
        private Label lblStatusCaption, lblStatus, lblDateCaption, lblCreatedDate;
        private Label lblNhomCaption, lblNhom, lblNhomIDCaption, lblNhomID, lblNhomSLCaption, lblNhomSL;
        private Button btnTaoNhom, btnSuaNhom, btnXoaNhom;
        private DataGridView dgvThanhvien;
    }
}
