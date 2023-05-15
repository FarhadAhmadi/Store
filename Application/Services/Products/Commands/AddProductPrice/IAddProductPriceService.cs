using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.AddProductPrice
{
    public interface IAddProductPriceService
    {
        ResultDto Execute(RequsetAddProductPrice requset);
    }
    public class AddProductPriceService : IAddProductPriceService
    {
        private readonly IStoreDbContext _context;

        public AddProductPriceService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequsetAddProductPrice requset)
        {

            try
            {
                ProductPrice productPrice = new ProductPrice()
                {
                    ProductId = requset.Product.Id,
                    Price = requset.Price,
                    InsertTime = DateTime.Now,
                    IsActive = true,
                    IsRemove = false,
                    RemoveTime = null,
                    UpdateTime = null,
                };

                _context.ProductPrices.Add(productPrice);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = ""
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا"
                };
            }
        }
    }
    public class RequsetAddProductPrice
    {
        public Product Product { get; set; }
        public string Price { get; set; }
    }
}
