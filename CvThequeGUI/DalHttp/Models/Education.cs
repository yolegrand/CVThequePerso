using DalHttp.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalHttp.core.Models
{
    public class Education
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int EducationLevel { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public IEnumerable<ViewUser> Users { get; set; }
        public IEnumerable<EducationLevel> EducationLevels { get; set; }
    }
}