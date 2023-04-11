using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Category.Queries.GetCategories;
using Application.Services.Users.Commands.ChangeUserStatus;
using Application.Services.Users.Commands.DeleteUser;
using Microsoft.Extensions.Hosting;
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

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService 
        {
            get { return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context); }
        }
    }
}
