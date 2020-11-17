using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCvTheque.Models
{
    public class LanguageApp : InfoBase
    {
        public int LanguageLevelId { get; set; }
        public int LanguageId { get; set; }
        public int UserId { get; set; }
    }
}