using Application.Common.DTO;
using Application.Common.Interfaces;
using Common.PasswordHasher;

namespace Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IStoreDbContext _context;
        public GetUserService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto<List<UsersDto>> Execute()
        {
            var result = _context.Users.Select( e => new UsersDto
            {
                BirthdayDate =  e.BirthdayDate,
                Email = e.Email,
                FullName = e.FullName,
                Password = e.Password,
                PhoneNumber = e.PhoneNumber,
                Id = e.Id,
                InsertTime = e.InsertTime,
                IsRemove = e.IsRemove,
                RemoveTime = e.RemoveTime,
                UpdateTime = e.UpdateTime   ,
                IsActive = e.IsActive,
            }).ToList();            

            return new ResultDto<List<UsersDto>>
            {
                Result = result,
                Message = "",
                Success = true
            };
        }
    }
}
