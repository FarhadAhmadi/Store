using Application.Services.Category.Commands.AddCategory;
using Application.Services.Category.Commands.AddCategoryPicture;
using Application.Services.Category.Commands.EditCategory;
using Application.Services.Category.Commands.RemoveCategory;
using Application.Services.Category.Queries.GetCategories;
using Application.Services.Category.Queries.GetParentCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Facad
{
    public interface ICategoryFacad
    {
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetParentCategoryService GetParentCategoryService { get; }
        IAddCategoryService AddCategoryService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        IEditCategoryService EditCategoryService { get; }
        IAddCategoryPictureService AddCategoryPictureService { get; }
        
    }
}
