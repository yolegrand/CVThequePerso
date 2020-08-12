using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.core.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User user { get; set; }
        public Role role { get; set; }
    }
}
