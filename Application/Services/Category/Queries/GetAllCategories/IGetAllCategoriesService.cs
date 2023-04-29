using Application.Common.DTO;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Queries.GetCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(string searchkey);
    }
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IStoreDbContext _context;
        public GetAllCategoriesService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoriesDto>> Execute(string searchkey)
        {

            var categoryResult = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(searchkey))
            {
                categoryResult = categoryResult.Where(e => e.Name.Contains(searchkey) || e.Parent.Name.Contains(searchkey));
            }

            var result = categoryResult.Select(e => new CategoriesDto
            {
                Id = e.Id,
                CategoryName = e.Name,
                ParentName = e.Parent.Name,
            }).ToList();

            //var result = _context.Categories
            //    .Select(e => new CategoriesDto
            //    {
            //        Id = e.Id,
            //        CategoryName = e.Name,
            //        ParentName = e.Parent.Name,
            //    }).ToList();

            foreach (var item in result)
            {
                if (item.ParentName == null)
                {
                    item.ParentName = "---";
                }
            }
            

            return new ResultDto<List<CategoriesDto>>
            {
                Result = result,
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class CategoriesDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ParentName { get; set; }
    }
}
