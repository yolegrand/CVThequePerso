using CVTheque.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.client.ViewModels
{
    public class ViewReturnUser
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public IEnumerable<RoleApi> Roles { get; set; }
    }
}
