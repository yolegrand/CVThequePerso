using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public int FunctionId { get; set; }
        public int KnowledgeId { get; set; }
    }
}
