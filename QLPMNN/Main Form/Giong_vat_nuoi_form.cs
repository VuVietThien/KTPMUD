namespace QLPMNN
{
    public partial class Giong_vat_nuoi_form : Form
    {
        public Giong_vat_nuoi_form()
        {
            InitializeComponent();
        }

        private void OpenForm(Form frm)
        {
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnTinhPhoi_Click(object sender, EventArgs e) => OpenForm(new Forms.ToChucSanXuatTinhPhoiManagementForm());
        private void btnConGiong_Click(object sender, EventArgs e) => OpenForm(new Forms.ToChucSanXuatConGiongManagementForm());
        private void btnDucGiong_Click(object sender, EventArgs e) => OpenForm(new Forms.ToChucSoHuuDucGiongManagementForm());
        private void btnMuaBan_Click(object sender, EventArgs e) => OpenForm(new Forms.ToChucMuaBanManagementForm());
        private void btnKhaoNghiem_Click(object sender, EventArgs e) => OpenForm(new Forms.CoSoKhaoNghiemManagementForm());
        private void btnGiongBaoTon_Click(object sender, EventArgs e) => OpenForm(new Forms.GiongVatNuoiBaoTonManagementForm());
        private void btnGiongCam_Click(object sender, EventArgs e) => OpenForm(new Forms.GiongVatNuoiCamXuatKhauManagementForm());
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
