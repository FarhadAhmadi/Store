using Application.Common.Interfaces.Facad;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryFacad _facad;
        public IActionResult Index()
        {
            return View();
        }
    }
}
