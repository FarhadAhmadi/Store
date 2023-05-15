using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Stack<string> productFeaturesStack = new Stack<string>();

            productFeaturesStack.Push("1");
            productFeaturesStack.Push("2");
            productFeaturesStack.Push("3");

            var x = productFeaturesStack.Pop();
            var y = productFeaturesStack.Pop();


            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}