namespace QLPMNN.Forms
{
    partial class AccessHistoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            pnlHeader=new Panel(); lblTitle=new Label(); pnlFilter=new Panel();
            lblUsername=new Label(); txtUsername=new TextBox();
            lblAction=new Label(); txtAction=new TextBox();
            chkFrom=new CheckBox(); dtpFrom=new DateTimePicker();
            chkTo=new CheckBox(); dtpTo=new DateTimePicker();
            btnTimKiem=new Button(); btnLamMoi=new Button(); btnClose=new Button();
            dgv=new DataGridView();
            SuspendLayout();

            pnlHeader.BackColor=Color.FromArgb(46, 125, 50); pnlHeader.Dock=DockStyle.Top; pnlHeader.Height=55;
            lblTitle.Text="LỊCH SỬ TRUY CẬP HỆ THỐNG"; lblTitle.Font=new Font("Segoe UI",13,FontStyle.Bold);
            lblTitle.ForeColor=Color.White; lblTitle.TextAlign=ContentAlignment.MiddleCenter; lblTitle.Dock=DockStyle.Fill;
            pnlHeader.Controls.Add(lblTitle);

            pnlFilter.BackColor=Color.White; pnlFilter.Dock=DockStyle.Top; pnlFilter.Height=80;

            lblUsername.Text="Người dùng:"; lblUsername.Font=new Font("Segoe UI",9,FontStyle.Bold);
            lblUsername.Location=new Point(10,10); lblUsername.Size=new Size(90,18);
            txtUsername.Location=new Point(10,30); txtUsername.Size=new Size(160,28);
            txtUsername.Font=new Font("Segoe UI",10); txtUsername.BorderStyle=BorderStyle.FixedSingle;

            lblAction.Text="Hành động:"; lblAction.Font=new Font("Segoe UI",9,FontStyle.Bold);
            lblAction.Location=new Point(180,10); lblAction.Size=new Size(90,18);
            txtAction.Location=new Point(180,30); txtAction.Size=new Size(200,28);
            txtAction.Font=new Font("Segoe UI",10); txtAction.BorderStyle=BorderStyle.FixedSingle;

            chkFrom.Text="Từ ngày:"; chkFrom.Font=new Font("Segoe UI",9,FontStyle.Bold);
            chkFrom.Location=new Point(395,12); chkFrom.Size=new Size(80,18);
            chkFrom.CheckedChanged += (s,e) => dtpFrom.Enabled = chkFrom.Checked;
            dtpFrom.Location=new Point(395,30); dtpFrom.Size=new Size(140,28);
            dtpFrom.Font=new Font("Segoe UI",10); dtpFrom.Enabled=false;
            dtpFrom.Value=DateTime.Today.AddDays(-30);

            chkTo.Text="Đến ngày:"; chkTo.Font=new Font("Segoe UI",9,FontStyle.Bold);
            chkTo.Location=new Point(545,12); chkTo.Size=new Size(85,18);
            chkTo.CheckedChanged += (s,e) => dtpTo.Enabled = chkTo.Checked;
            dtpTo.Location=new Point(545,30); dtpTo.Size=new Size(140,28);
            dtpTo.Font=new Font("Segoe UI",10); dtpTo.Enabled=false;

            void B(Button b, string t, int x, Color c, EventHandler h) {
                b.Text=t; b.Font=new Font("Segoe UI",9,FontStyle.Bold); b.BackColor=c; b.ForeColor=Color.White;
                b.FlatStyle=FlatStyle.Flat; b.FlatAppearance.BorderSize=0; b.Location=new Point(x,30); b.Size=new Size(90,28); b.Cursor=Cursors.Hand; b.Click+=h;
            }
            B(btnTimKiem,"🔍 Tìm kiếm",700,Color.SteelBlue,btnTimKiem_Click);
            B(btnLamMoi,"🔄 Làm mới",800,Color.Gray,btnLamMoi_Click);
            B(btnClose,"✖ Đóng",900,Color.DimGray,btnClose_Click);

            pnlFilter.Controls.AddRange(new Control[] { lblUsername,txtUsername,lblAction,txtAction,chkFrom,dtpFrom,chkTo,dtpTo,btnTimKiem,btnLamMoi,btnClose });

            dgv.Dock=DockStyle.Fill; dgv.ReadOnly=true; dgv.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor=Color.White;
            dgv.BorderStyle=BorderStyle.None; dgv.RowHeadersVisible=false; dgv.AllowUserToAddRows=false;

            AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(1100,600);
            Controls.Add(dgv); Controls.Add(pnlFilter); Controls.Add(pnlHeader);
            StartPosition=FormStartPosition.CenterParent; Text="Lịch sử truy cập"; Load+=Form_Load; ResumeLayout(false);
        }
        private Panel pnlHeader, pnlFilter;
        private Label lblTitle, lblUsername, lblAction;
        private TextBox txtUsername, txtAction;
        private CheckBox chkFrom, chkTo;
        private DateTimePicker dtpFrom, dtpTo;
        private Button btnTimKiem, btnLamMoi, btnClose;
        private DataGridView dgv;
    }
}
