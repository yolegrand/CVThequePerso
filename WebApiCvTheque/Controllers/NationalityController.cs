using CvTheque.Core.Models;
using CvTheque.Data.DataRepositories;
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
    public class NationalityController : ApiController
    {
        readonly NationalityRepository _nationalityRepo = new NationalityRepository();
        // GET: api/Nationality
        public IEnumerable<NationalityApp> Get()
        {
            List<NationalityApp> NationalityApp = new List<NationalityApp>();

            foreach (Nationality item in _nationalityRepo.GetAll())
            {
                NationalityApp.Add(Mapper.MapToEntity(item));
            }
            return NationalityApp;
        }

        // GET api/Level/GetByName/Name
        [Route("api/Nationality/GetByName/{Name}")]
        public NationalityApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_nationalityRepo.GetByName(Name));
        }

        // GET: api/Nationality/5
        public NationalityApp Get(int id)
        {
            return Mapper.MapToEntity(_nationalityRepo.GetOne(id));
        }

        // POST: api/Nationality
        public void Post(NationalityApp NationalityApp)
        {
            Nationality n = Mapper.MapToEntity(NationalityApp);
            _nationalityRepo.Create(n);
        }

        // PUT: api/Nationality/5
        public void Put(int id, NationalityApp NationalityApp)
        {
            Nationality n = Mapper.MapToEntity(NationalityApp);
            _nationalityRepo.Update(id, n);
        }

        // DELETE api/Nationality/5
        public void Delete(int id)
        {
            _nationalityRepo.Delete(id);
        }
    }
}
