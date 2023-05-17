using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.EditProduct
{
    public interface IEditProductService
    {
        ResultDto Execute(ProductEditRequestDto request);
    }
    public class EditProductService : IEditProductService
    {
        private readonly IStoreDbContext _context;
        public EditProductService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(ProductEditRequestDto request)
        {
            try
            {
                var product = _context.Products.Find(request.ProductId);

                product.ProductName = request.ProductName;
                product.Brand = request.Brand;
                product.Description = request.Description;
                product.Count = request.Count;
                product.UpdateTime = DateTime.Now;

                var price = _context.ProductPrices.Find(request.PriceId);

                price.Price = request.Price;
                price.UpdateTime = DateTime.Now;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا در ویرایش کالا"
                };
            }
        }
    }

    public class ProductEditRequestDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int PriceId { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

    }
}