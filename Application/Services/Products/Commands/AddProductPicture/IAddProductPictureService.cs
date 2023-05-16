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
                        //var uploadResult = UploadFile(iamge);
                        //productImages.Add(new ProductImages
                        //{
                        //    Src = uploadResult.FileNameAddress,
                        //    ProductId = request.ProductId,

                        //    InsertTime = DateTime.Now,
                        //    IsActive = true,
                        //    IsRemove = false,
                        //    RemoveTime = null,
                        //    UpdateTime = null,

                        //});
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

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
            
                string folder = $@"\images\ProductImages\";
                var uploadsRootFolder =  Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
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
