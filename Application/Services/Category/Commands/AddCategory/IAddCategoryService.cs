using Application.Common.DTO;
using Application.Common.Interfaces;
using Application.Services.Category.Queries.GetCategories;
using Domain.Entities;
using Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Commands.AddCategory
{
    public interface IAddCategoryService
    {
        ResultDto<AddCategoryResultDto> Execute(string categoryName, int parentId);
    }
    public class AddCategoryService : IAddCategoryService
    {
        private readonly IStoreDbContext _context;
        public AddCategoryService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<AddCategoryResultDto> Execute(string categoryName, int parentId)
        {
            try
            {
                Domain.Entities.Category category = new Domain.Entities.Category()
                {
                    Name = categoryName,
                    ParentId = parentId,
                };

                _context.Categories.Add(category);
                _context.SaveChanges();

                return new ResultDto<AddCategoryResultDto>
                {
                    Result = new AddCategoryResultDto
                    {
                        CategoryId = category.Id,
                    },
                    IsSuccess = true,
                    Message = "با موفقیت اضافه شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto<AddCategoryResultDto>
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "خطا در برنامه "
                };
            }
        }
    }
    public class AddCategoryResultDto
    {
        public int CategoryId { get; set; }
    }
}
