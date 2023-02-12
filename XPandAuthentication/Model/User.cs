namespace XPandAuthentication.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; } 
        public string Email { get; set; }
        public int CaptainID { get; set; }
    }
}
