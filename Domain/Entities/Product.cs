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
        public Product() { 
        }

        public string ProductName { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }
        
        public Category Category { get;}
        public int CategoryId { get; set; }
    }
}
