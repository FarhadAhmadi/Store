using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserInRole : BaseEntity
    {
        public virtual User? User { get; set; }
        public int UserId { get; set; }

        public virtual Role? Role { get; set; }
        public int RoleId { get; set; }
    }
}