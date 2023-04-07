using Application.Common.DTO;
using Application.Common.Interfaces;
using Common.PasswordHasher;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands.AddUser
{
    public interface IAddUserService
    {
        ResultDto<ResultAddUserDto> Execute(RequestAddUserDto request);
    }
    public class AddUserService : IAddUserService
    {
        private readonly IStoreDbContext _context;
        public AddUserService(IStoreDbContext context)
        {
            _context = context;
        }
        ResultDto<ResultAddUserDto> IAddUserService.Execute(RequestAddUserDto request)
        {
            try
            {
                if (request.FullName == null && request.Email == null/*&& request.BirthdayDate == null*/&& request.PhoneNumber == null&& request.Password == null&& request.RePassword == null )
                {
                    return new ResultDto<ResultAddUserDto>
                    {
                        Result = null,
                        Message = "تمام موارد را پر کنید",
                        Success = true
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultAddUserDto>
                    {
                        Result = null,
                        Message = "رمز عبور با تکرار آن برابر نیست",
                        Success = true
                    };
                }
                    
                









                User user = new User
                {
                    BirthdayDate = DateTime.Now,
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,

                    InsertTime = DateTime.Now,
                    IsActive = true,
                    IsRemove = false,
                    RemoveTime = null,
                    UpdateTime = null
                };


                List<UserInRole> roleList = new List<UserInRole>();

                foreach (var item in request.Role)
                {
                    var result = _context.Roles.Find(item.RoleId);
                    roleList.Add(new UserInRole
                    {
                        RoleId = item.RoleId,
                        Role = result,
                        User = user,
                        UserId = user.Id,
                    });
                }


                user.userInRoles = roleList;
                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultAddUserDto>
                {
                    Result = new ResultAddUserDto
                    {
                        UserId = user.Id
                    },
                    Message = "ثبت نام با موفقیت انجام شد",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultAddUserDto>
                {
                    Result = new ResultAddUserDto
                    {
                        UserId = 0
                    },
                    Message = "ناموفق",
                    Success = false
                };
            }
        }
    }     
   
    public class RequestAddUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RoleInAddUser> Role { get; set; }
    }

    public class RoleInAddUser
    {
        public int RoleId { get; set; }
    }

    public class ResultAddUserDto
    {
        public int UserId { get; set; }
    }
}