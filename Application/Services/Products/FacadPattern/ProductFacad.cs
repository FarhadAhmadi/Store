using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Commands.AddProductFeature;
using Application.Services.Products.Commands.AddProductPrice;
using Application.Services.Products.Queries.GetProducts;
using Application.Services.Users.Commands.ChangeUserStatus;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IStoreDbContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacad(IStoreDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IAddProductService _AddProductService;
        public IAddProductService AddProductService
        {
            get { return _AddProductService = _AddProductService ?? new AddProductService(_context); }
        }

        private IGetProductsService _GetProductsService;
        public IGetProductsService GetProductsService
        {
            get { return _GetProductsService = _GetProductsService ?? new GetProductsService(_context); }
        }

        private IAddProductPriceService _AddProductPriceService;
        public IAddProductPriceService AddProductPriceService
        {
            get { return _AddProductPriceService = _AddProductPriceService ?? new AddProductPriceService(_context); }
        }

        private IAddProductFeatureServcie _AddProductFeatureServcie;
        public IAddProductFeatureServcie AddProductFeatureServcie
        {
            get { return _AddProductFeatureServcie = _AddProductFeatureServcie ?? new AddProductFeatureServcie(_context); }
        }
    }
}
