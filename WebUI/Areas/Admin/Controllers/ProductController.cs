using Application.Common.Interfaces.Facad;
using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Commands.AddProductFeature;
using Application.Services.Products.Commands.AddProductPrice;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;
using System.Web;
using Application.Services.Products.Commands.AddProductPicture;
using Application.Services.Products.Commands.EditProduct;
using Application.Services.Products.Queries.GetProductPicture;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryFacad _categoryFacad;
        private readonly IProductFacad _productFacad;
        public ProductController(ICategoryFacad categoryFacad, IProductFacad productFacad)
        {
            _categoryFacad = categoryFacad;
            _productFacad = productFacad;
        }
        public IActionResult Index()
        {
            return View(_productFacad.GetProductsService.Execute());
        }
        [HttpPost]
        public IActionResult GetProductFeature(int productId)
        {
            var result = _productFacad.GetProductFeatureService.Execute(productId);
            return Json(result);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Parents = new SelectList(_categoryFacad.GetParentCategoryService.Execute().Result, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel viewModel)
        {
            var result = _productFacad.AddProductService.Execute(new RequsetAddProductDto
            {
                Brand = viewModel.Brand,
                ProductName = viewModel.ProductName,
                CategoryId = viewModel.CategoryId,
                Count = viewModel.Count,
                Displayed = true,
                Description = viewModel.Description,
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddProductPrice(AddProductPriceViewModel viewModel)
        {
            var result = _productFacad.AddProductPriceService.Execute(new RequsetAddProductPrice
            {
                Price = viewModel.Price,
                productId = viewModel.productId,
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddProductFeature([FromBody] AddProductFeatureViewModel viewModels)
        {

            List<ProductFeatureDto> productFeatures = new List<ProductFeatureDto>();

            productFeatures = viewModels.productFeatures.Select(e => new ProductFeatureDto
            {
                Key = e.Key,
                Value = e.Value,
            }).ToList();

            var result = _productFacad.AddProductFeatureServcie.Execute(new AddProductFeatureDto
            {
                productId = viewModels.productId,
                productFeatures = productFeatures
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddProductPicture(int productId)
        {
            RequestAddProductPicture request = new RequestAddProductPicture();
            List<IFormFile> image = new List<IFormFile>();
            foreach (var file in Request.Form.Files)
            {
                image.Add(file);
            }
            request.Images = image;
            request.ProductId = productId;

            var result = _productFacad.AddProductPictureService.Execute(request);
            return Json(result);
        }
        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            return Json(_productFacad.DeleteProductServcie.Execute(productId));
        }
        [HttpPost]
        public IActionResult ChangeStatus(int productId)
        {
            return Json(_productFacad.ChangeProductStatusService.Execute(productId));
        }
        [HttpPut]
        public IActionResult Edit(EditProductViewModel viewModel)
        {
            return Json(_productFacad.EditProductService.Execute(new ProductEditRequestDto
            {
                ProductName = viewModel.ProductName,
                Brand = viewModel.Brand,
                Count = viewModel.Count,
                Description = viewModel.Description,
                PriceId = viewModel.PriceId,
                Price = viewModel.Price,
                ProductId = viewModel.ProductId,
            }));
        }
        [HttpGet]
        //[Route("{productId}")]
        public IActionResult Pictures(int productId)
        
        {
            if (productId != 0)
            {
               ViewData["Pictures"] = _productFacad.GetProductPictureService.Execute(productId).ToList();
               return View();
            }
            return View();
        }
    }
}