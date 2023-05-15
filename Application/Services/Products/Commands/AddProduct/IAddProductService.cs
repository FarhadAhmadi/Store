using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Services.Products.Commands.AddProduct
{
    public interface IAddProductService
    {
        ResultDto<Product> Execute(RequsetAddProductDto requset);
    }
    public class AddProductService : IAddProductService
    {
        private readonly IStoreDbContext _context;

        public AddProductService(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto<Product> Execute(RequsetAddProductDto requset)
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
                    Description = requset.Description,

                    InsertTime = DateTime.Now,
                    IsActive = true,
                    IsRemove = false,
                    RemoveTime = null,
                    UpdateTime = null,
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                return new ResultDto<Product>
                {
                    IsSuccess = true,
                    Message = "",
                    Result = product
                };
            }
            catch (Exception)
            {
                return new ResultDto<Product>
                {
                    IsSuccess = false,
                    Message = "خطا در ثبت کالا",
                    Result = null
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
        public string Description { get; set; }
    }
}
