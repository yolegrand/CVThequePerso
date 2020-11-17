using System;
using System.Collections.Generic;
using System.Text;

namespace DalHttp.core.ViewModels
{
    public class ViewEducation
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string EducationLevel { get; set; }
    }
}
