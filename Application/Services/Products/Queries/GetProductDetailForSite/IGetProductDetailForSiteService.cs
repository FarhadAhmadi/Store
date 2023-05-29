using Application.Common.DTO;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<GetProductDetailForSiteRequestDto> Execute(int productId);
    }
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IStoreDbContext _context;
        public GetProductDetailForSiteService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<GetProductDetailForSiteRequestDto> Execute(int productId)
        {
            try
            {
                    //.Join(_context.ProductPrices, product => product.Id, price => price.ProductId, (product, price) => new { product, price })
                    //.Join(_context.ProductFeatures, product => product.product.Id, feature => feature.ProductId, (product, feature) => new { product, feature })
                    //.Join(_context.ProductImages, product => product.product.product.Id, image => image.ProductId, (product, image) => new { product, image })

               //var result = _context.Products
               //     .Where(product => product.Id == productId)
               //     .Select(result => new GetProductDetailForSiteRequestDto
               //     {
               //         Id = result.Id,
               //         Name = result.ProductName,
               //         Brand = result.Brand,
               //         Count = result.Count,
               //         Description = result.Description,
               //         Price = int.Parse(_context.ProductPrices.FirstOrDefault(price => price.ProductId == productId).Price),

               //         Features = new List<GetProductFeatureDto>
               //         {
               //             new GetProductFeatureDto
               //             {
               //                 Key = _context.ProductFeatures.Where(f => f.ProductId == productId).Select(f => f.Key).ToString(),
               //                 Value = _context.ProductFeatures.Where(f => f.ProductId == productId).Select(f => f.value).ToString(),
               //             }
               //         },
               //         Images = new List<GetProductImageDto>
               //         {
               //             new GetProductImageDto
               //             {
               //                 Src = _context.ProductImages.Where(i => i.ProductId == productId).Select(i => i.Src).ToString()
               //             }
               //         },

               //     }).ToList();

                var result = _context.Products
                    .Where(product => product.Id == productId)
                    .Include(product => product.ProductImages)
                    .Include(product => product.ProductPrices)
                    .Include(product => product.ProductFeatures)
                    .First();


                return new ResultDto<GetProductDetailForSiteRequestDto>
                {
                    IsSuccess = true,
                    Message = "",
                    Result = new GetProductDetailForSiteRequestDto
                    {
                        Id = result.Id,
                        Name = result.ProductName,
                        Brand = result.Brand,
                        Count = result.Count,
                        Description = result.Description,
                        Price = int.Parse(result.ProductPrices.First().Price),
                        Features = result.ProductFeatures.Select(f => new GetProductFeatureDto
                        {
                            Key = f.Key,
                            Value = f.value
                        }).ToList(),
                        Images = result.ProductImages.Select(i => new GetProductImageDto
                        {
                            Src = i.Src,
                        }).ToList(),
                    }
                };
            }
            catch (Exception)
            {
                return new ResultDto<GetProductDetailForSiteRequestDto>
                {
                    IsSuccess = false,
                    Message = "",
                    Result = null
                };
            }
        }
    }
    public class GetProductDetailForSiteRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetProductFeatureDto> Features { get; set; }
        public List<GetProductImageDto> Images { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Brand { get; set; }
    }
    public class GetProductImageDto
    {
        public string Src { get; set; }
    }
    public class GetProductFeatureDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
