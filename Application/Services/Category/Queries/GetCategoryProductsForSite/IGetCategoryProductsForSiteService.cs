using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Queries.GetCategoryProductsForSite
{
    public interface IGetCategoryProductsForSiteService
    {
        ResultDto<List<GetCategoryProductsResultDto>> Execute(int CategoryId);
    }
    public class GetCategoryProductsForSiteService : IGetCategoryProductsForSiteService
    {
        private readonly IStoreDbContext _context;
        public GetCategoryProductsForSiteService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetCategoryProductsResultDto>> Execute(int CategoryId)
        {
            try
            {
                List<GetSubCategoriesDto> subCategories = GetSubCategories(CategoryId);
                List<int> subCategoryIds = subCategories.Select(subCategory => subCategory.CategoryId).ToList();

                List<GetCategoryProductsResultDto> products = new List<GetCategoryProductsResultDto>();

                //var result = _context.Products
                //     .Where(product => subCategoryIds.Contains(product.CategoryId))
                //     .Join(_context.ProductPrices, Product => Product.Id, Price => Price.ProductId, (product, price) => new { product, price })
                //     .Join(_context.ProductImages, product => product.product.Id, Image => Image.ProductId, (product, Image) => new { product, Image })
                //     .GroupBy(e => e.Image.ProductId)
                //     .Select(result => new GetCategoryProductsResultDto
                //     {
                //         ImageSrc = result.Image.Src,
                //         ProductId = result.product.product.Id,
                //         ProductName = result.product.product.ProductName,
                //         productPrice = int.Parse(result.product.price.Price),
                //     });

                //products.AddRange(result);



                products = _context.Products
                    .Where(product => subCategoryIds.Contains(product.CategoryId))
                    .Select(product => new GetCategoryProductsResultDto
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        productPrice = Convert.ToInt32(_context.ProductPrices.FirstOrDefault(productPrice => productPrice.ProductId == product.Id).Price),
                        ImageSrc = _context.ProductImages.FirstOrDefault(productImage => productImage.ProductId == product.Id).Src
                    }).ToList();

                return new ResultDto<List<GetCategoryProductsResultDto>>
                {
                    IsSuccess = true,
                    Message = "",
                    Result = products
                };
            }
            catch (Exception)
            {
                return new ResultDto<List<GetCategoryProductsResultDto>>
                {
                    IsSuccess = false,
                    Message = "",
                    Result = null
                };
            }
        }
        public List<GetSubCategoriesDto> GetSubCategories(int categoryId)
        {
            var result = _context.Categories
                    .Where(e => e.ParentId == categoryId)
                    .Select(e => new GetSubCategoriesDto
                    {
                        CategoryId = e.Id,
                        CategoryName = e.Name,
                        ParentId = e.ParentId.Value
                    }).ToList();
            return result;
        }
    }

    public class GetSubCategoriesDto
    {
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string CategoryName { get; set; }
    }

    public class GetCategoryProductsResultDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int productPrice { get; set; }
        public string ImageSrc { get; set; }
    }
}