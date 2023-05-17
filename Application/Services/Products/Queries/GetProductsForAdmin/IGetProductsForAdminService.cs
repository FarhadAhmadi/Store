using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Queries.GetProducts
{
    public interface IGetProductsForAdminService
    {
        ResultDto<List<GetProductsDto>> Execute();
    }
    public class GetProductsForAdminService : IGetProductsForAdminService
    {
        private readonly IStoreDbContext _context;
        public GetProductsForAdminService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetProductsDto>> Execute()
        {
            try
            {
                var result = _context.Products
    .Join(_context.ProductPrices,
    product => product.Id,
    price => price.ProductId,
    (product, price) => new { product, price })








    .Select(result => new GetProductsDto
    {
        ProductId = result.product.Id,
        ProductName = result.product.ProductName,
        Brand = result.product.Brand,
        Count = result.product.Count,
        Displayed = result.product.Displayed,
        Description = result.product.Description,
        PriceId = result.price.Id,
        Price = result.price.Price,
        IsActive = result.product.IsActive,
        IsRemove = result.product.IsRemove,
        
    }).ToList();

                return new ResultDto<List<GetProductsDto>>
                {
                    Result = result,
                    IsSuccess = true,
                    Message = "",
                };

            }
            catch (Exception)
            {
                return new ResultDto<List<GetProductsDto>>
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "خطا در دریافت اطلاعات کالا",
                };
            }
        }
    }
    public class GetProductsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public bool Displayed { get; set; }
        public int PriceId { get; set; }
        public string Price { get; set; } 
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemove { get; set; }
    }
}
