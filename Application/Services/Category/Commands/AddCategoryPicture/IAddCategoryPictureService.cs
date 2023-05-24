using Application.Common.DTO;
using Application.Common.Interfaces;
using Application.Services.Products.Commands.AddProductPicture;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category.Commands.AddCategoryPicture
{
    public interface IAddCategoryPictureService
    {
        ResultDto Execute(AddCategoryPictureRequestDto request); 
    }
    public class AddCategoryPictureService : IAddCategoryPictureService
    {
        private readonly IStoreDbContext _context;
        private readonly IHostingEnvironment _environment;
        public AddCategoryPictureService(IStoreDbContext context , IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(AddCategoryPictureRequestDto request)
        {
            try
            {
                List<CategoryImages> images = new List<CategoryImages>();

                foreach (var image in request.Images)
                {
                    var uploadResult = UploadPicture(image);

                    if (uploadResult.Status)
                    {
                        string src = uploadResult.FileNameAddress;

                        images.Add(new CategoryImages
                        {
                            Src = src,
                            CategoryId = request.CategoryId,

                            InsertTime = DateTime.Now,
                            IsActive = true,
                            IsRemove = false,
                            RemoveTime = null,
                            UpdateTime = null,
                        });
                    }
                }
                _context.CategoryImages.AddRange(images);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نا موفق در ثبت عکس"
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
                string path = Path.Combine("C:/Users/Farhad/Desktop/Store/WebUI/wwwroot/Images/Category/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

                return new UploadDto
                {
                    FileNameAddress = "/Images/Category/" + fileName,
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

    public class AddCategoryPictureRequestDto
    {
        public List<IFormFile> Images { get; set; }
        public int CategoryId { get; set; }
    }

}
