using CvTheque.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.ViewModels
{
    public class ViewEducation
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
