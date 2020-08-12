using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.api.Models
{
    public class BasicInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
