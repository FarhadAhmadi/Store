using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Category.Commands.AddCategory;
using Application.Services.Category.Commands.EditCategory;
using Application.Services.Category.Commands.RemoveCategory;
using Application.Services.Category.Queries.GetCategories;
using Application.Services.Category.Queries.GetParentCategory;
using Application.Services.Users.Commands.DeleteUser;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.FacadPattern
{
    public class CategoryFacad : ICategoryFacad
    {
        private readonly IStoreDbContext _context;
        private readonly IHostingEnvironment _environment;

        public CategoryFacad(IStoreDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IGetAllCategoriesService _GetAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get { return _GetAllCategoriesService = _GetAllCategoriesService ?? new GetAllCategoriesService(_context); }
        }

        private IGetParentCategoryService _GetParentCategoryService;
        public IGetParentCategoryService GetParentCategoryService
        {
            get { return _GetParentCategoryService = _GetParentCategoryService ?? new GetParentCategoryService(_context); }
        }

        private IAddCategoryService _AddCategoryService;
        public IAddCategoryService AddCategoryService
        {
            get { return _AddCategoryService = _AddCategoryService ?? new AddCategoryService(_context); }
        }

        private IRemoveCategoryService _RemoveCategoryService;
        public IRemoveCategoryService RemoveCategoryService
        {
            get { return _RemoveCategoryService = _RemoveCategoryService ?? new RemoveCategoryService(_context); }
        }

        private IEditCategoryService _EditCategoryService;
        public IEditCategoryService EditCategoryService
        {
            get { return _EditCategoryService = _EditCategoryService ?? new EditCategoryService(_context); }
        }
    }
}

