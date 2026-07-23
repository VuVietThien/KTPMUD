using QLPMNN.Services;

namespace QLPMNN.Forms
{
    public partial class AccessHistoryManagementForm : Form
    {
        public AccessHistoryManagementForm() { InitializeComponent(); }
        private void Form_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgv.DataSource = AccessHistoryService.GetAll();
            SetHeaders();
        }

        private void SetHeaders()
        {
            var map = new Dictionary<string, string> {
                ["LogID"]="ID",["Time"]="Thời gian",["Action"]="Hành động",
                ["UserID"]="UserID",["Username"]="Tên người dùng"
            };
            foreach (var kv in map) if (dgv.Columns.Contains(kv.Key)) dgv.Columns[kv.Key]!.HeaderText = kv.Value;
            if (dgv.Columns.Contains("UserID")) dgv.Columns["UserID"]!.Visible = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string action = txtAction.Text.Trim();
            DateTime? from = chkFrom.Checked ? dtpFrom.Value.Date : null;
            DateTime? to = chkTo.Checked ? dtpTo.Value.Date : null;
            dgv.DataSource = AccessHistoryService.Search(username, action, from, to);
            SetHeaders();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtUsername.Clear(); txtAction.Clear();
            chkFrom.Checked = false; chkTo.Checked = false;
            dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today;
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
