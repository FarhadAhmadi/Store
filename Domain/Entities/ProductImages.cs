using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImages : BaseEntity
    {
        public string ImageName { get; set; }
        public string Src { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
