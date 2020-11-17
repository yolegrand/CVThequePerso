using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Data.DataRepositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCvTheque.Models;
using WebApiCvTheque.Services;

namespace WebApiCvTheque.Controllers
{
    [BasicAuthentification(Realm: "MIKE8")]
    public class SectorController : ApiController
    {
        readonly SectorRepository _sectorRepo = new SectorRepository();
        // GET api/Sector
        public IEnumerable<SectorApp> Get()
        {
            List<SectorApp> SectorApp = new List<SectorApp>();

            foreach(Sector item in _sectorRepo.GetAll())
            {
                SectorApp.Add(Mapper.MapToEntity(item));
            }
            return SectorApp;
        }

        // GET api/Sector/GetByName/Name
        [Route("api/Sector/GetByName/{Name}")]
        public SectorApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_sectorRepo.GetByName(Name));
        }

        // GET api/Sector/5
        public SectorApp Get(int id)
        {
            return Mapper.MapToEntity(_sectorRepo.GetOne(id));
        }

        // POST api/Sector
        public void Post(SectorApp SectorApp)
        {
            Sector l = Mapper.MapToEntity(SectorApp);
            _sectorRepo.Create(l);
        }

        // PUT api/Sector/5
        public void Put(int id, SectorApp SectorApp)
        {
            Sector l = Mapper.MapToEntity(SectorApp);
            _sectorRepo.Update(id, l);
        }

        // DELETE api/Sector/5
        public void Delete(int id)
        {
            _sectorRepo.Delete(id);
        }
    }
}
