using Application.Common.DTO;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.AddProductPicture
{
    public interface IAddProductPictureService
    {
        ResultDto Execute(RequestAddProductPicture request);
    }
    public class AddProductPictureService : IAddProductPictureService
    {
        private readonly IStoreDbContext _context;
        private readonly IHostingEnvironment _environment;

        public AddProductPictureService(IStoreDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddProductPicture request)
        {
            try
            {
                if (request.Images.Count > 0)
                {
                    List<ProductImages> productImages = new List<ProductImages>();
                    foreach (var iamge in request.Images)
                    {
                        var uploadResult = UploadPicture(iamge);
                        if (uploadResult.Status == true)
                        {
                            productImages.Add(new ProductImages
                            {
                                Src = uploadResult.FileNameAddress,
                                ProductId = request.ProductId,

                                InsertTime = DateTime.Now,
                                IsActive = true,
                                IsRemove = false,
                                RemoveTime = null,
                                UpdateTime = null,

                            });
                        }
                    }
                    _context.ProductImages.AddRange(productImages);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = ""
                    };
                }
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا در ثبت عکس"
                };

            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا در ثبت عکس"
                };
            }
        }

        public UploadDto UploadPicture(IFormFile file)
        {
            try
            {

                string wwwRootPath = _environment.WebRootPath;
                string fileName = file.FileName;
                string extension = Path.GetExtension(file.FileName);
                string path = Path.Combine("C:/Users/Farhad/Desktop/Store/WebUI/wwwroot/Images/Product/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

                return new UploadDto
                {
                    FileNameAddress = path,
                    Status = true
                };
            }
            catch (Exception)
            {
                return new UploadDto
                {
                    FileNameAddress = "",
                    Status = false
                };
            }
        }

    }
    public class UploadDto
    {
        public string FileNameAddress { get; set; }
        public bool Status { get; set; }
    }
    public class RequestAddProductPicture
    {
        public List<IFormFile> Images { get; set; }
        public int ProductId { get; set; }
    }
}
