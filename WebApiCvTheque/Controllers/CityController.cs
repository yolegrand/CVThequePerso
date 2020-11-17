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
using System.Web.Http.Cors;
using WebApiCvTheque.Models;
using WebApiCvTheque.Services;

namespace WebApiCvTheque.Controllers
{
    [BasicAuthentification(Realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CityController : ApiController
    {
        readonly CityRepository _cityRepo = new CityRepository();
        // GET api/City
        public IEnumerable<CityApp> Get()
        {
            List<CityApp> CityApp = new List<CityApp>();

            foreach(City item in _cityRepo.GetAll())
            {
               CityApp.Add(Mapper.MapToEntity(item));
            }
            return CityApp;
        }

        // GET api/City/5
        public CityApp Get(int id)
        {
            return Mapper.MapToEntity(_cityRepo.GetOne(id));
        }

        // GET api/City/GetByName/Name
        [Route("api/City/GetByName/{Name}")]
        public CityApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_cityRepo.GetByName(Name));
        }

        // POST api/City
        public void Post(CityApp CityApp)
        {
            City c = Mapper.MapToEntity(CityApp);
            _cityRepo.Create(c);
        }

        // PUT api/City/5
        public void Put(int id, CityApp CityApp)
        {
            City c = Mapper.MapToEntity(CityApp);
            _cityRepo.Update(id, c);
        }

        // DELETE api/City/5
        public void Delete(int id)
        {
            _cityRepo.Delete(id);
        }
    }
}
