namespace WebUI.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}