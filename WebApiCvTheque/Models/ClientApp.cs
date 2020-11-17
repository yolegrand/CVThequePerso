using CvTheque.Core.Models;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCvTheque.Models
{
    public class ClientApp : ContactInformationsApp
    {
        public int SectorId { get; set; }
        public int SocietyId { get; set; }
        public IEnumerable<ViewSector> Sectors { get; set; }
        public IEnumerable<ViewSociety> Society { get; set; }
    }
}