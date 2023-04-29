using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(int userId);
    }
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IStoreDbContext _context;
        public RemoveCategoryService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int userId)
        {
            try
            {
                var result = _context.Categories.Find(userId);
                result.IsRemove = true;
                result.RemoveTime = DateTime.Now;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "با موفقیت حذف شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا در برنامه "
                };
            }
        }
    }
}
