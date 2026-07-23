namespace QLPMNN.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Email { get; set; }
        public int RoleID { get; set; }
        public string Status { get; set; } = "active";
        public DateTime CreatedDate { get; set; }
        public int? Nhom_ID { get; set; }
        public string? RoleName { get; set; }
        public string? TenNhom { get; set; }
    }
}
