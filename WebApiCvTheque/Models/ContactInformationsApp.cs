using CvTheque.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCvTheque.Models
{
    public class ContactInformationsApp : InfoBase
    {
        public string Contact { get; set; }
        public string City { get; set; }
    }
}
