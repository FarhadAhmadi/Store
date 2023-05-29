using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Commands.AddProductFeature;
using Application.Services.Products.Commands.AddProductPicture;
using Application.Services.Products.Commands.AddProductPrice;
using Application.Services.Products.Commands.ChangeProductStatus;
using Application.Services.Products.Commands.DeleteProduct;
using Application.Services.Products.Commands.EditProduct;
using Application.Services.Products.Queries.GetProductDetailForSite;
using Application.Services.Products.Queries.GetProductFeature;
using Application.Services.Products.Queries.GetProductPicture;
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
        IGetProductsForAdminService GetProductsService { get; }
        IAddProductPriceService AddProductPriceService { get; }
        IAddProductFeatureServcie AddProductFeatureServcie { get; }
        IAddProductPictureService AddProductPictureService { get; }
        IGetProductFeatureService GetProductFeatureService { get; }
        IDeleteProductServcie DeleteProductServcie { get; }
        IChangeProductStatusService ChangeProductStatusService { get; }
        IEditProductService EditProductService { get; }
        IGetProductPictureService GetProductPictureService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
