using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryImages : BaseEntity
    {
        public string Src { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
