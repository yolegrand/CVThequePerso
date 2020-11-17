using CvTheque.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.ViewModels
{
    public class ViewExperience
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public IEnumerable<Function> Functions { get; set; }
    }
}
