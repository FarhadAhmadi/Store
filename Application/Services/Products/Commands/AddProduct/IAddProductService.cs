using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Services.Products.Commands.AddProduct
{
    public interface IAddProductService
    {
        ResultDto Execute(RequsetAddProductDto requset);
    }
    public class AddProductService : IAddProductService
    {
        private readonly IStoreDbContext _context;

        public AddProductService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequsetAddProductDto requset)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = requset.ProductName,
                    Brand = requset.Brand,
                    Count = requset.Count,
                    Displayed = requset.Displayed,
                    CategoryId = requset.CategoryId,
                    InsertTime = DateTime.Now,
                    IsActive = true,
                    IsRemove = false,
                    RemoveTime = null,
                    UpdateTime = null,
                    Description = requset.Description,
                };

                ProductPrice price = new ProductPrice()
                {
                    Price = requset.Price,
                    //ProductId = product.Id,
                    Product = product,
                    InsertTime = DateTime.Now,
                    IsActive = true,
                    IsRemove = false,
                    RemoveTime = null,
                    UpdateTime = null,
                };

                _context.Products.Add(product);
                _context.ProductPrices.Add(price);
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
                    Message = "خطا در ثبت کالا"
                };
            }
        }

    }

    public class RequsetAddProductDto
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
