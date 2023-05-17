using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.ChangeProductStatus
{
    public interface IChangeProductStatusService
    {
        ResultDto Execute(int productId);
    }
    public class ChangeProductStatusService : IChangeProductStatusService
    {
        private readonly IStoreDbContext _context;
        public ChangeProductStatusService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int productId)
        {
            try
            {
                var result = _context.Products.Find(productId);
                result.IsActive = !result.IsActive;

                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا در تغییر وضعیت"
                };
            }
        }
    }
}
