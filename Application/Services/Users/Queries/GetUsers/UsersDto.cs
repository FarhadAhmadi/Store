namespace Application.Services.Users.Queries.GetUsers
{
    public class UsersDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? RemoveTime { get; set; }
        public bool IsRemove { get; set; }
        public bool IsActive { get; set; }

    }
}
