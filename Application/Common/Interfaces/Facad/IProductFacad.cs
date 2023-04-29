using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Facad
{
    public interface IProductFacad
    {
        IAddProductService AddProductService { get; }
        IGetProductsService GetProductsService { get; }
    }
}
