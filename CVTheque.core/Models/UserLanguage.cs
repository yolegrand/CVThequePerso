using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class UserLanguage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }
    }
}
