using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvTheque.Models
{
    public class KnowledgeApp : InfoBase
    {
        public int KnowledgeTypeId { get; set; }
        public string KnowledgeTypes { get; set; }
    }
}