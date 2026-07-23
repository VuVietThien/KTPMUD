using QLPMNN.Models;

namespace QLPMNN.Session
{
    public static class CurrentSession
    {
        public static User? CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsAdmin => CurrentUser?.RoleID == 1;

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
