using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands.ChangeUserStatus
{
    public interface IChangeUserStatusService
    {
        ResultDto Execute(int userId);
    }
    public class ChangeUserStatusService : IChangeUserStatusService
    {
        private readonly IStoreDbContext _context;
        public ChangeUserStatusService(IStoreDbContext context)
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
                   IsSuccess =false,
                   Message = " کاربر یافت نشد "
                };
            }
            else
            {
                result.IsActive= !result.IsActive;
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "وضعیت کاربر تغییر یافت"
                };
            }
        }
    }
}