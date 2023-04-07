using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public  class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? RemoveTime { get; set; }
        public bool IsRemove { get; set; }
        public bool IsActive { get; set; }
    }
}
