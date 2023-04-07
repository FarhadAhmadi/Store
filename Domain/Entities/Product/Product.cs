using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<Category> Categories { get;}
    }
}
