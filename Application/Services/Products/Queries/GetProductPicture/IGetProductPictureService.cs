using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Queries.GetProductPicture
{
    public interface IGetProductPictureService
    {
        List<GetProductPictureResultDto> Execute(int productId);
    }
    public class GetProductPictureService : IGetProductPictureService
    {
        private readonly IStoreDbContext _context;
        public GetProductPictureService(IStoreDbContext context)
        {
            _context = context;
        }
        public List<GetProductPictureResultDto> Execute(int productId)
        {
            try
            {
                var result = _context.Products.
                    Join(_context.ProductImages, product => product.Id, image => image.ProductId, (product, image) => new  GetProductPictureResultDto 
                    {
                        ProductName = product.ProductName,
                        ProductId = product.Id,
                        ImageSrc = new List<GetProductPictureSrc>
                        {
                            new GetProductPictureSrc
                            {
                                ImageId = image.Id,
                                Src = image.Src,
                            }
                        }
                    }).Where(e => e.ProductId == productId).ToList();

                return result;

                //return new ResultDto<List<GetProductPictureResultDto>>
                //{
                //    IsSuccess = true,
                //    Message = "",
                //    Result = result
                //};
            }
            catch (Exception)
            {
                return new List<GetProductPictureResultDto>();
                //return new ResultDto<List<GetProductPictureResultDto>>
                //{
                //    IsSuccess = true,
                //    Message = "",
                //    Result = null
                //};
            }
        }
    }

    public class GetProductPictureResultDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<GetProductPictureSrc> ImageSrc { get; set; }
    }
    public class GetProductPictureSrc
    {
        public int ImageId { get; set; }
        public string Src { get; set; }

    }
}
