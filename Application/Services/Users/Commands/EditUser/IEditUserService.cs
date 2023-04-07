using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(EditUserDto editUserDto);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IStoreDbContext _context;
        public EditUserService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto Execute(EditUserDto editUserDto)
        {
            var result = _context.Users.Find(editUserDto.Id);
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            else
            {
                result.Password = editUserDto.Password;
                result.PhoneNumber = editUserDto.PhoneNumber;
                result.FullName = editUserDto.UserName;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "ویرایش انجام شد"
                };

            }
        }
    }

    public class EditUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
