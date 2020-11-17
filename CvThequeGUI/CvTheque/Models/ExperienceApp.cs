using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvTheque.Models
{
    public class ExperienceApp
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
    }
}