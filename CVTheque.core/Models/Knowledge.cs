using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Knowledge : InfoBase
    {
        public int KnowledgeTypeId { get; set; }
        public int UserId { get; set; }
        public int UserKnowledgeId { get; set; }
        public int LevelId { get; set; }
        public int KnowledgeId { get; set; }
        public IEnumerable<ViewKnowledgeType> KnowledgeTypes { get; set; }
        public string Level { get; set; }
    }
}
