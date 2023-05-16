using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.AddProductFeature
{
    public interface IAddProductFeatureServcie
    {
        ResultDto Execute(AddProductFeatureDto addProductFeature);
    }
    public class AddProductFeatureServcie : IAddProductFeatureServcie
    {
        private readonly IStoreDbContext _context;

        public AddProductFeatureServcie(IStoreDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(AddProductFeatureDto addProductFeature)
        {
            try
            {


                List<ProductFeature> Features = new List<ProductFeature>();

                int productId = addProductFeature.productId;

                foreach (var item in addProductFeature.productFeatures)
                {
                    Features.Add(new ProductFeature
                    {
                        Key = item.Key,
                        value = item.Value,
                        ProductId = addProductFeature.productId,
                    });
                }


                _context.ProductFeatures.AddRange(Features);
                _context.SaveChanges();

                return new ResultDto
                {
                    Message = "",
                    IsSuccess = true,
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    Message = "خطا",
                    IsSuccess = false,
                };
            }
        }
    }
}


public class AddProductFeatureDto
{
    public List<ProductFeatureDto> productFeatures { get; set; }
    public int productId { get; set; }
}

public class ProductFeatureDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}