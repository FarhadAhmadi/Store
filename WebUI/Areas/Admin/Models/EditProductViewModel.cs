namespace WebUI.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int PriceId { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}