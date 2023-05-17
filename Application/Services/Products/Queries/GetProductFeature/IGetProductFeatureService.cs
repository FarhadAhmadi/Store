using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Queries.GetProductFeature
{
    public interface IGetProductFeatureService
    {
        ResultDto<List<GetProductFeatureDto>> Execute(int productId);
    }
    public class GetProductFeatureService : IGetProductFeatureService
    {
        private readonly IStoreDbContext _context;
        public GetProductFeatureService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetProductFeatureDto>> Execute(int productId)
        {
            try
            {
                var result = _context.ProductFeatures
                    .Where(feature => feature.ProductId == productId)
                    .Select(e => new GetProductFeatureDto
                    {
                        Key = e.Key,
                        Value = e.value
                    }).ToList();

                return new ResultDto<List<GetProductFeatureDto>>
                {
                    Result = result,
                    IsSuccess = true,
                    Message = ""
                };
            }
            catch (Exception)
            {
                return new ResultDto<List<GetProductFeatureDto>>
                {
                    Result = null,
                    IsSuccess = false,
                    Message = ""
                };
            }
        }
    }

    public class GetProductFeatureDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
