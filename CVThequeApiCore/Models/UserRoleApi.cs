using CVTheque.api.Migrations;
using CVTheque.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.api.Models
{
    public class UserRoleApi
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public core.Models.User user { get; set; }
        public Role role { get; set; }
    }
}
