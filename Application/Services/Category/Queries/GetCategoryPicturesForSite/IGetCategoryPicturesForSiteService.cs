using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Queries.GetCategoryPicturesForSite
{
    public interface IGetCategoryPicturesForSiteService
    {
        ResultDto<List<GetCategoryPicturesForSiteResultDto>> Execute();
    }
    public class GetCategoryPicturesForSiteService : IGetCategoryPicturesForSiteService
    {
        private readonly IStoreDbContext _context;
        public GetCategoryPicturesForSiteService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetCategoryPicturesForSiteResultDto>> Execute()
        {
            try
            {
                var result = _context.Categories
                    .Join(_context.CategoryImages, cat => cat.Id, img => img.CategoryId, (cat, img) => new GetCategoryPicturesForSiteResultDto
                    {
                        CategoryId = cat.Id,
                        CategoryName = cat.Name,
                        Src = img.Src,
                    }).ToList();

                return new ResultDto<List<GetCategoryPicturesForSiteResultDto>>
                {
                    IsSuccess = true,
                    Message = "",
                    Result = result,
                };
            }
            catch (Exception)
            {
                return new ResultDto<List<GetCategoryPicturesForSiteResultDto>>
                {
                    IsSuccess = true,
                    Message = "",
                    Result = null
                };
            }
        }
    }

    public class GetCategoryPicturesForSiteResultDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Src { get; set; }
    }
}
