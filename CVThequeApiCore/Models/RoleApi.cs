using CVTheque.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.api.Models
{
    public class RoleApi : BasicInformation
    {
        public RoleApi()
        {
            this.UserRoles = new HashSet<UserRole>();
        }
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
