using DalHttp.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvTheque.Models
{
    public class ClientApp : ContactInformationsApp
    {
        public int SectorId { get; set; }
        public int SocietyId { get; set; }
        public IEnumerable<ViewSector> Sectors { get; set; }
        public IEnumerable<ViewSociety> Societies { get; set; }
        public IEnumerable<ViewExperience> Experiences { get; set; }
        public IEnumerable<ViewLanguage> Languages { get; set; }
        public IEnumerable<ViewKnowledge> Knowledge { get; set; }
    }
}