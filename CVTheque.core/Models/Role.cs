using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.core.Models
{
    public class Role : BasicInformation
    {
        //public Role()
        //{
        //    UserRoles = new List<UserRole>();
        //}
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
