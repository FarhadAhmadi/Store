using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> Children { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
