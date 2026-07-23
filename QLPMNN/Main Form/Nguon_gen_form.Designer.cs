namespace QLPMNN
{
    partial class Nguon_gen_form
    {
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
            this.pnlButtons = new Panel();
            this.btnTinh = new Button();
            this.btnXa = new Button();
            this.btnThuThapGen = new Button();
            this.btnBaoTonGen = new Button();
            this.btnKhaiThacGen = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.lblTitle.Text = "QUẢN LÝ NGUỒN GEN";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(lblTitle);

            this.pnlButtons.Dock = DockStyle.Fill;
            this.pnlButtons.BackColor = Color.FromArgb(241, 248, 233);
            this.pnlButtons.Padding = new Padding(60, 40, 60, 40);

            void AddMenuBtn(Button btn, string text, int top, EventHandler handler)
            {
                btn.Text = text;
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btn.BackColor = Color.FromArgb(46, 125, 50);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(60, top);
                btn.Size = new Size(560, 55);
                btn.Cursor = Cursors.Hand;
                btn.Click += handler;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(102, 187, 106);
                btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(46, 125, 50);
                this.pnlButtons.Controls.Add(btn);
            }

            AddMenuBtn(btnTinh, "🗺  Quản lý Đơn vị hành chính Tỉnh", 40, btnTinh_Click);
            AddMenuBtn(btnXa, "📍  Quản lý Đơn vị hành chính Xã", 110, btnXa_Click);
            AddMenuBtn(btnThuThapGen, "🔬  Tổ chức Thu thập Gen", 180, btnThuThapGen_Click);
            AddMenuBtn(btnBaoTonGen, "🌿  Tổ chức Bảo tồn Gen", 250, btnBaoTonGen_Click);
            AddMenuBtn(btnKhaiThacGen, "⛏  Tổ chức Khai thác Gen", 320, btnKhaiThacGen_Click);

            this.btnBack.Text = "← Quay lại";
            this.btnBack.Font = new Font("Segoe UI", 10);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Location = new Point(60, 400);
            this.btnBack.Size = new Size(130, 36);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;
            this.pnlButtons.Controls.Add(btnBack);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(680, 560);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nguồn Gen";
            this.ResumeLayout(false);
        }

        private Panel pnlHeader, pnlButtons;
        private Label lblTitle;
        private Button btnTinh, btnXa, btnThuThapGen, btnBaoTonGen, btnKhaiThacGen, btnBack;
    }
}
