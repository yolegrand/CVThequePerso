using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Data.DataRepositories;
using CvTheque.Data.DataRepositoties;
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
    public class SocietyController : ApiController
    {
        readonly SocietyRepository _societyRepo = new SocietyRepository();
        // GET api/Society
        public IEnumerable<SocietyApp> Get()
        {
            List<SocietyApp> SocietyApp = new List<SocietyApp>();

            foreach(Society item in _societyRepo.GetAll())
            {
                SocietyApp.Add(Mapper.MapToEntity(item));
            }
            return SocietyApp;
        }

        // GET api/Society/GetSocietyByUserName/Name
        [Route("api/Society/GetSocietyByUserName/{Name}")]
        public IEnumerable<SocietyApp> GetSocietyByUserName(string Name)
        {
            List<SocietyApp> SocietyApp = new List<SocietyApp>();

            foreach (Society item in _societyRepo.GetSocietyByUserName(Name))
            {
                SocietyApp.Add(Mapper.MapToEntity(item));
            }
            return SocietyApp;
        }

        // GET api/Society/GetByName/Name
        [Route("api/Society/GetByName/{Name}")]
        public SocietyApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_societyRepo.GetByName(Name));
        }

        // GET api/Society/5
        public SocietyApp Get(int id)
        {
            return Mapper.MapToEntity(_societyRepo.GetOne(id));
        }

        // POST api/Society
        public void Post(SocietyApp SocietyApp)
        {
            Society l = Mapper.MapToEntity(SocietyApp);
            _societyRepo.Create(l);
        }

        // PUT api/Society/5
        public void Put(int id, SocietyApp SocietyApp)
        {
            Society l = Mapper.MapToEntity(SocietyApp);
            _societyRepo.Update(id, l);
        }

        // DELETE api/Society/5
        public void Delete(int id)
        {
            _societyRepo.Delete(id);
        }
    }
}
