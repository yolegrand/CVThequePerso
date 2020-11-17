using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalHttp.core.Models
{
    public class Knowledge : InfoBase
    {
        public int KnowledgeTypeId { get; set; }
        public string KnowledgeTypes { get; set; }
    }
}