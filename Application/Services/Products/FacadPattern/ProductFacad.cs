using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Commands.AddProductFeature;
using Application.Services.Products.Commands.AddProductPicture;
using Application.Services.Products.Commands.AddProductPrice;
using Application.Services.Products.Commands.ChangeProductStatus;
using Application.Services.Products.Commands.DeleteProduct;
using Application.Services.Products.Commands.EditProduct;
using Application.Services.Products.Queries.GetProductFeature;
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

        private IAddProductPictureService _AddProductPictureService;
        public IAddProductPictureService AddProductPictureService
        {
            get { return _AddProductPictureService = _AddProductPictureService ?? new AddProductPictureService(_context, _environment); }
        }

        private IGetProductsForAdminService _GetProductsForAdminService;
        public IGetProductsForAdminService GetProductsService
        {
            get { return _GetProductsForAdminService = _GetProductsForAdminService ?? new GetProductsForAdminService(_context); }
        }

        private IGetProductFeatureService _GetProductFeatureService;
        public IGetProductFeatureService GetProductFeatureService
        {
            get { return _GetProductFeatureService = _GetProductFeatureService ?? new GetProductFeatureService(_context); }
        }

        private IDeleteProductServcie _DeleteProductServcie;
        public IDeleteProductServcie DeleteProductServcie
        {
            get { return _DeleteProductServcie = _DeleteProductServcie ?? new DeleteProductServcie(_context); }
        }
        private IChangeProductStatusService _ChangeProductStatusService;
        public IChangeProductStatusService ChangeProductStatusService
        {
            get { return _ChangeProductStatusService = _ChangeProductStatusService ?? new ChangeProductStatusService(_context); }
        }

        private IEditProductService _EditProductService;
        public IEditProductService EditProductService
        {
            get { return _EditProductService = _EditProductService ?? new EditProductService(_context); }
        }
    }
}
