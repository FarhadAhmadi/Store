using Application.Common.Interfaces.Facad;
using Application.Services.Category.Commands.AddCategory;
using Application.Services.Category.Commands.AddCategoryPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryFacad _categoryFacad;
        public CategoriesController(ICategoryFacad categoryFacad)
        {
            _categoryFacad = categoryFacad;

        }
        public IActionResult Index(string searchkey)
        {
            return View(_categoryFacad.GetAllCategoriesService.Execute(searchkey));
        }

        [HttpGet]
        public IActionResult AddCategory() 
        {
            ViewBag.parents = new SelectList(_categoryFacad.GetParentCategoryService.Execute().Result, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(string categoryName , int parentId) 
        {
            var result = _categoryFacad.AddCategoryService.Execute(categoryName, parentId);
            return Json(result);
        }
        public IActionResult AddCategoryPicture(int categoryId)
        {
            AddCategoryPictureRequestDto requestDto = new AddCategoryPictureRequestDto();
            List<IFormFile> Images = new List<IFormFile>();

            foreach (var file in Request.Form.Files)
            {
                Images.Add(file);
            }
            requestDto.Images = Images;
            requestDto.CategoryId = categoryId;

            return Json(_categoryFacad.AddCategoryPictureService.Execute(requestDto));
        }

        [HttpPost]
        public IActionResult Delete(int userId)
        {
            return Json(_categoryFacad.RemoveCategoryService.Execute(userId));
        }
        public IActionResult Edit(int userId , string categoryName)
        {
            return Json(_categoryFacad.EditCategoryService.Execute(userId , categoryName));
        }
    }
}
