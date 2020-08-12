using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.core.ViewModels
{
    public class ViewReturnUser
    {
        public string Username { get; set; }
        public IEnumerable<string> Role { get; set; }
        public string Token { get; set; }
    }
}
