using Application.Common.Interfaces.Facad;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int productId)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(productId));
        }
    }
}
