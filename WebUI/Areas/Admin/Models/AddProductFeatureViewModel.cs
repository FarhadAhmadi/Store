using Domain.Entities;

namespace WebUI.Areas.Admin.Models
{
    public class AddProductFeatureViewModel
    {
        public List<ProductFeatureViewModel> productFeatures { get; set; }
        public int productId { get; set; }
    }
    public class ProductFeatureViewModel 
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}