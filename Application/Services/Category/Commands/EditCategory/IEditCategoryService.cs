using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Commands.EditCategory
{
    public interface IEditCategoryService
    {
        ResultDto Execute(int userId, string CategoryName);
    }
    public class EditCategoryService : IEditCategoryService
    {
        private readonly IStoreDbContext _context;
        public EditCategoryService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int userId, string CategoryName)
        {
            try
            {
                var result = _context.Categories.Find(userId);
                result.Name = CategoryName;
                result.UpdateTime = DateTime.Now;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "با موفقیت ویرایش شد"
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
