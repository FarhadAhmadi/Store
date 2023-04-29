using Application.Common.DTO;
using Application.Common.Interfaces;
using Application.Services.Category.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Queries.GetParentCategory
{
    public interface IGetParentCategoryService
    {
        ResultDto<List<GetParentCategoryDto>> Execute();
    }

    public class GetParentCategoryService : IGetParentCategoryService
    {
        private readonly IStoreDbContext _context;
        public GetParentCategoryService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetParentCategoryDto>> Execute()
        {
            var result = _context.Categories
                .Select(e => new GetParentCategoryDto
                {
                    Id = e.Id,
                    Name = e.Name
                });

            return new ResultDto<List<GetParentCategoryDto>>
            {
                Result = result.ToList(),
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class GetParentCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}