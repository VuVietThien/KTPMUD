using QLPMNN.Services;
using QLPMNN.Session;

namespace QLPMNN
{
    public partial class Nguon_gen_form : Form
    {
        public Nguon_gen_form()
        {
            InitializeComponent();
        }

        private void OpenForm(Form frm)
        {
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnTinh_Click(object sender, EventArgs e) => OpenForm(new Forms.QuanLyTinh_Form());
        private void btnXa_Click(object sender, EventArgs e) => OpenForm(new Forms.QuanLyXa_Form());
        private void btnThuThapGen_Click(object sender, EventArgs e) => OpenForm(new Forms.QuanLyThuThapGen_Form());
        private void btnBaoTonGen_Click(object sender, EventArgs e) => OpenForm(new Forms.QuanLyBaoTonGen_Form());
        private void btnKhaiThacGen_Click(object sender, EventArgs e) => OpenForm(new Forms.QuanLyKhaiThacGen_Form());
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
