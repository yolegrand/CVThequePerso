using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Language : InfoBase
    {
        public int LanguageLevelId { get; set; }
        public int LanguageId { get; set; }
        public int UserId { get; set; }
    }
}
