using Application.Services.Category.Queries.GetCategories;
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
    }
}
