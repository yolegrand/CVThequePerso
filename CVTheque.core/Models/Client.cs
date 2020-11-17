using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Models
{
    public class Client : ContactInformations
    {
        public int SectorId { get; set; }
        public int SocietyId { get; set; }
        public IEnumerable<ViewSector> Sectors { get; set; }
        public IEnumerable<ViewSociety> Societies { get; set; }
    }
}
