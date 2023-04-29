namespace WebUI.Areas.Admin.Models
{
    public class AddUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}