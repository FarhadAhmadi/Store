using Application.Common.DTO;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Commands.DeleteProduct
{
    public interface IDeleteProductServcie
    {
        ResultDto Execute(int productId);
    }
    public class DeleteProductServcie : IDeleteProductServcie
    {
        private readonly IStoreDbContext _context;
        public DeleteProductServcie(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int productId)
        {
            try
            {
                var result = _context.Products.Find(productId);
                result.IsRemove = true;
                result.RemoveTime = DateTime.Now;

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
                    Message = "خطا در حذف کالا"
                };
            }
        }
    }
}
