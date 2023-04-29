using Application.Common.DTO;
using Application.Common.Interfaces;
using Common.PasswordHasher;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(RequestUserloginDto request);
    }
    public class UserLoginService : IUserLoginService
    {
        private readonly IStoreDbContext _context;
        public UserLoginService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(RequestUserloginDto request)
        {


            if (request.email == null && request.password == null)
            {
                return new ResultDto<ResultUserloginDto>
                {
                    Result = null,
                    Message = "ایمیل و رمز عبور را وارد کنید",
                    IsSuccess = false
                };
            }



            var user = _context.Users
                        .Include(p => p.userInRoles)
                        .ThenInclude(p => p.Role)
                        .Where(p => p.Email.Equals(request.email))
                        .FirstOrDefault();


            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>
                {
                    Result = null,
                    Message = "کاربری با این ایمیل در فروشگاه ثبت نام نکرده است",
                    IsSuccess = false
                };
            }



            if (user.Password != request.password)
            {
                return new ResultDto<ResultUserloginDto>
                {
                    Result = null,
                    Message = "رمز وارد شده اشتباه است",
                    IsSuccess = false
                };
            }

            List<string> roles = new List<string>();
            foreach (var item in user.userInRoles)
            {
                roles.Add(item.Role.RoleName);
            }

            return new ResultDto<ResultUserloginDto>
            {
                Result = new ResultUserloginDto
                {
                    Name = user.FullName,
                    Roles = roles,
                    UserId = user.Id,
                },
                Message = "ورود با موفقیت انجام شد",
                IsSuccess = true
            };
        }
    }

    public class RequestUserloginDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public List<string> Roles { get; set; }
        public string Name { get; set; }
    }

}
