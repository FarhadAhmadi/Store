using Application.Common.Interfaces.Facad;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryFacad _categoryFacad;

        public HomeController(ICategoryFacad categoryFacad)
        {
            _categoryFacad = categoryFacad;
        }

        public IActionResult Index()
        {
            return View(_categoryFacad.GetCategoryPicturesForSiteService.Execute());
        }
        public IActionResult CategoryProducts( int CategoryId)
        {
            return View(_categoryFacad.GetCategoryProductsForSiteService.Execute(CategoryId));
        }
    }
}