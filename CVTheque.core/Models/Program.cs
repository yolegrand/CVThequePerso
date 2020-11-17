using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Program : InfoBase
    {
        public int ProgramTypeId { get; set; }
        public int UserId { get; set; }
        public int LevelId { get; set; }
        public int ProgramId { get; set; }
        public IEnumerable<ViewProgramType> ProgramTypes { get; set; }
    }
}
