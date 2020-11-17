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
    public class FunctionController : ApiController
    {
        readonly FunctionRepository _functionRepo = new FunctionRepository();
        // GET api/Function
        public IEnumerable<FunctionApp> Get()
        {
            List<FunctionApp> FunctionApp = new List<FunctionApp>();

            foreach(Function item in _functionRepo.GetAll())
            {
                FunctionApp.Add(Mapper.MapToEntity(item));
            }
            return FunctionApp;
        }

        // GET api/Function/GetByName/Name
        [Route("api/Function/GetByName/{Name}")]
        public FunctionApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_functionRepo.GetByName(Name));
        }

        // GET api/Function/5
        public FunctionApp Get(int id)
        {
            return Mapper.MapToEntity(_functionRepo.GetOne(id));
        }

        // POST api/Function
        public void Post(FunctionApp levelApp)
        {
            Function l = Mapper.MapToEntity(levelApp);
            _functionRepo.Create(l);
        }

        // PUT api/Function/5
        public void Put(int id, FunctionApp levelApp)
        {
            Function l = Mapper.MapToEntity(levelApp);
            _functionRepo.Update(id, l);
        }

        // DELETE api/Function/5
        public void Delete(int id)
        {
            _functionRepo.Delete(id);
        }
    }
}
