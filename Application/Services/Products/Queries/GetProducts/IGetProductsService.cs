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
    public interface IGetProductsService
    {
       ResultDto< List<GetProductsDto>> Execute();
    }
    public class GetProductsService : IGetProductsService
    {
        private readonly IStoreDbContext _context;
        public GetProductsService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetProductsDto>> Execute()
        {

            var result = _context.Products.
                Join(_context.ProductPrices, e => e.Id, p => p.Product.Id, (e, p) => new GetProductsDto
                {
                    Price = p.Price,
                    ProductName = e.ProductName,
                    Brand = e.Brand,
                    Displayed = e.Displayed,
                }).ToList();


            return new ResultDto<List<GetProductsDto>>
            {
                Result = result,
                IsSuccess = true,
                Message = "",
            };


            throw new NotImplementedException();
        }
    }

    public class GetProductsDto
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

    }
}
