using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Count { get; set; }
        public bool Displayed { get; set; }
        public int? ViewCount { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        //category foreign key
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
