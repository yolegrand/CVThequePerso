using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Education
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int EducationLevel { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public IEnumerable<ViewUser> Users { get; set; }
        public IEnumerable<EducationLevel> EducationLevels { get; set; }
        public string Level { get; set; }
    }
}
