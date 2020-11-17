using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class UserKnowledge
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int KnowledgeId { get; set; }
        public int LevelId { get; set; }
    }
}
