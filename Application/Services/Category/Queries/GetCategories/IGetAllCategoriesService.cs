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
        ResultDto<List<CategoriesDto>> Execute();
    }
    public class GetAllCategoriesService : IGetAllCategoriesService 
    {
        private readonly IStoreDbContext _context;
        public GetAllCategoriesService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoriesDto>> Execute()
        {

            _context.Categories
                .Include(e => e.Parent)
                .ThenInclude(e => e.ParentId != null)
                .ToList()
                .Select(e => new CategoriesDto
                {
                    CategoryName = e.Name,
                    Id = e.Id
                });




            throw new NotImplementedException();
        }
    }

    public class CategoriesDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
