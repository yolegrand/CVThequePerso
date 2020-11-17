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
    public class ProspectController : ApiController
    {
        readonly ProspectRepository _prospectRepo = new ProspectRepository();
        // GET api/Prospect
        public IEnumerable<ProspectApp> Get()
        {
            List<ProspectApp> ProspectApp = new List<ProspectApp>();

            foreach(Prospect item in _prospectRepo.GetAll())
            {
                ProspectApp.Add(Mapper.MapToEntity(item));
            }
            return ProspectApp;
        }

        // GET api/Prospect/GetByName/Name
        [Route("api/Prospect/GetByName/{Name}")]
        public ProspectApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_prospectRepo.GetByName(Name));
        }

        // GET api/Prospect/GetByName/Name
        [Route("api/Prospect/GetByContact/{Name}")]
        public ProspectApp GetByContact(string Name)
        {
            return Mapper.MapToEntity(_prospectRepo.GetByContact(Name));
        }

        // GET api/Prospect/5
        public ProspectApp Get(int id)
        {
            return Mapper.MapToEntity(_prospectRepo.GetOne(id));
        }

        // POST api/Prospect
        public void Post(ProspectApp ProspectApp)
        {
            Prospect l = Mapper.MapToEntity(ProspectApp);
            _prospectRepo.Create(l);
        }

        // PUT api/Prospect/5
        public void Put(int id, ProspectApp ProspectApp)
        {
            Prospect l = Mapper.MapToEntity(ProspectApp);
            _prospectRepo.Update(id, l);
        }

        // DELETE api/Prospect/5
        public void Delete(int id)
        {
            _prospectRepo.Delete(id);
        }
    }
}
