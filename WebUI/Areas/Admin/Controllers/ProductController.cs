using Application.Common.Interfaces.Facad;
using Application.Services.Products.Commands.AddProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryFacad _categoryFacad;
        private readonly IProductFacad _productFacad;
        public ProductController(ICategoryFacad categoryFacad , IProductFacad productFacad)
        {
            _categoryFacad = categoryFacad;
            _productFacad = productFacad;
        }
        public IActionResult Index()
        {
            return View(_productFacad.GetProductsService.Execute());
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
                Price = viewModel.Price,
            });

            return Json(result);
        }
    }
}
