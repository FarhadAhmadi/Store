using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands.DeleteUser
{
    public interface IDeleteUserService
    {
        ResultDto Execute(int userId);
    }
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IStoreDbContext _context;
        public DeleteUserService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int userId)
        {
            var result = _context.Users.Find(userId);
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
                result.IsRemove = true;
                result.RemoveTime = DateTime.Now;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "کاربر حذف شد"
                };
            }
        }
    }
}