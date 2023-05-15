using Domain.Entities;

namespace WebUI.Areas.Admin.Models
{
    public class AddProductPriceViewModel
    {
        public string Price { get; set; }
        public Product Product { get; set; }
    }
}