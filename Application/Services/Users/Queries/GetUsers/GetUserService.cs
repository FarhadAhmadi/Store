using Application.Common.DTO;
using Application.Common.Interfaces;
using Application.Common.Pagination;
using Common.PasswordHasher;
using Domain.Entities.User;

namespace Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IStoreDbContext _context;
        public GetUserService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultGetUsersDto Execute(string searchKey)
        {
            var result = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                result = result.Where(e => e.FullName.Contains(searchKey) || e.Email.Contains(searchKey));
            }
            int rowCount = 0;
            var users =  result.ToPaged(1, 20, out rowCount)
                .Select(e => new GetUsersDto
                {
                    BirthdayDate = e.BirthdayDate,
                    Email = e.Email,
                    FullName = e.FullName,
                    Password = e.Password,
                    PhoneNumber = e.PhoneNumber,
                    Id = e.Id,
                    IsRemove = e.IsRemove,
                    IsActive = e.IsActive,
                }).ToList();

            return new ResultGetUsersDto
            {
                RowCount = rowCount,
                Users = users 
            };
        }
    }
    public class ResultGetUsersDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int RowCount { get; set; }
    }
    public class GetUsersDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Password { get; set; }
        public bool IsRemove { get; set; }
        public bool IsActive { get; set; }
    }
}