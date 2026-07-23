namespace QLPMNN.Forms
{
    partial class ToChucMuaBanManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            pnlHeader=new Panel(); lblTitle=new Label(); pnlInput=new Panel();
            lblTen=new Label(); txtTen=new TextBox(); lblLoaiHinh=new Label(); txtLoaiHinh=new TextBox();
            lblLoaiSP=new Label(); txtLoaiSP=new TextBox(); lblDiaChi=new Label(); txtDiaChi=new TextBox();
            lblSDT=new Label(); txtSDT=new TextBox(); lblEmail=new Label(); txtEmail=new TextBox();
            lblMST=new Label(); txtMST=new TextBox(); lblGPKD=new Label(); txtGPKD=new TextBox();
            lblGhiChu=new Label(); txtGhiChu=new TextBox();
            pnlToolbar=new Panel(); txtTimKiem=new TextBox();
            btnTimKiem=new Button(); btnThem=new Button(); btnSua=new Button(); btnXoa=new Button();
            btnLamMoi=new Button(); btnBack=new Button(); dgv=new DataGridView();
            SuspendLayout();

            pnlHeader.BackColor=Color.FromArgb(46, 125, 50); pnlHeader.Dock=DockStyle.Top; pnlHeader.Height=55;
            lblTitle.Text="TỔ CHỨC MUA BÁN GIỐNG"; lblTitle.Font=new Font("Segoe UI",13,FontStyle.Bold);
            lblTitle.ForeColor=Color.White; lblTitle.TextAlign=ContentAlignment.MiddleCenter; lblTitle.Dock=DockStyle.Fill;
            pnlHeader.Controls.Add(lblTitle);

            pnlInput.BackColor=Color.White; pnlInput.Dock=DockStyle.Top; pnlInput.Height=130;
            void F(Label l, TextBox t, string cap, int x, int y, int w) {
                l.Text=cap; l.Font=new Font("Segoe UI",9,FontStyle.Bold); l.Location=new Point(x,y); l.Size=new Size(w,18);
                t.Font=new Font("Segoe UI",10); t.BorderStyle=BorderStyle.FixedSingle; t.Location=new Point(x,y+20); t.Size=new Size(w,28);
                pnlInput.Controls.AddRange(new Control[] { l, t });
            }
            F(lblTen,txtTen,"Tên tổ chức *",10,5,250); F(lblLoaiHinh,txtLoaiHinh,"Loại hình",270,5,160);
            F(lblLoaiSP,txtLoaiSP,"Loại sản phẩm",440,5,160); F(lblDiaChi,txtDiaChi,"Địa chỉ",610,5,260);
            F(lblSDT,txtSDT,"SĐT",10,68,130); F(lblEmail,txtEmail,"Email",150,68,200);
            F(lblMST,txtMST,"Mã số thuế",360,68,140); F(lblGPKD,txtGPKD,"GP Kinh doanh",510,68,160);
            F(lblGhiChu,txtGhiChu,"Ghi chú",680,68,200);

            pnlToolbar.BackColor=Color.FromArgb(241, 248, 233); pnlToolbar.Dock=DockStyle.Top; pnlToolbar.Height=45;
            txtTimKiem.Location=new Point(10,8); txtTimKiem.Size=new Size(220,28);
            txtTimKiem.Font=new Font("Segoe UI",10); txtTimKiem.BorderStyle=BorderStyle.FixedSingle; txtTimKiem.PlaceholderText="Tìm kiếm...";
            void B(Button b, string t, int x, Color c, EventHandler h) {
                b.Text=t; b.Font=new Font("Segoe UI",9,FontStyle.Bold); b.BackColor=c; b.ForeColor=Color.White;
                b.FlatStyle=FlatStyle.Flat; b.FlatAppearance.BorderSize=0; b.Location=new Point(x,8); b.Size=new Size(80,28); b.Cursor=Cursors.Hand; b.Click+=h;
            }
            B(btnTimKiem,"🔍 Tìm",240,Color.SteelBlue,btnTimKiem_Click); B(btnThem,"➕ Thêm",335,Color.SeaGreen,btnThem_Click);
            B(btnSua,"✏ Sửa",425,Color.DarkOrange,btnSua_Click); B(btnXoa,"🗑 Xóa",515,Color.Firebrick,btnXoa_Click);
            B(btnLamMoi,"🔄 Mới",605,Color.Gray,btnLamMoi_Click); B(btnBack,"← Quay lại",700,Color.DimGray,btnBack_Click);
            pnlToolbar.Controls.AddRange(new Control[] { txtTimKiem,btnTimKiem,btnThem,btnSua,btnXoa,btnLamMoi,btnBack });

            dgv.Dock=DockStyle.Fill; dgv.ReadOnly=true; dgv.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor=Color.White;
            dgv.BorderStyle=BorderStyle.None; dgv.RowHeadersVisible=false; dgv.AllowUserToAddRows=false;
            dgv.CellClick+=dgv_CellClick;

            AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(1200,600);
            Controls.Add(dgv); Controls.Add(pnlToolbar); Controls.Add(pnlInput); Controls.Add(pnlHeader);
            StartPosition=FormStartPosition.CenterScreen; Text="Tổ chức Mua Bán Giống"; Load+=Form_Load; ResumeLayout(false);
        }
        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblTen, lblLoaiHinh, lblLoaiSP, lblDiaChi, lblSDT, lblEmail, lblMST, lblGPKD, lblGhiChu;
        private TextBox txtTen, txtLoaiHinh, txtLoaiSP, txtDiaChi, txtSDT, txtEmail, txtMST, txtGPKD, txtGhiChu, txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgv;
    }
}
