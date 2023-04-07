using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public Category Father { get; set; }
        public int FatherId { get; set; }

        public ICollection<Category> child { get; set;}
    }
}
