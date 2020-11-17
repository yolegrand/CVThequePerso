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
    public class ProgramController : ApiController
    {
        readonly ProgramRepository _programRepo = new ProgramRepository();
        // GET api/Program
        public IEnumerable<ProgramApp> Get()
        {
            List<ProgramApp> ProgramApp = new List<ProgramApp>();

            foreach(Program item in _programRepo.GetAll())
            {
                ProgramApp.Add(Mapper.MapToEntity(item));
            }
            return ProgramApp;
        }

        // GET api/Program/GetByName/Name
        [Route("api/Program/GetByName/{Name}")]
        public ProgramApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_programRepo.GetByName(Name));
        }

        // GET api/Program/5
        public ProgramApp Get(int id)
        {
            return Mapper.MapToEntity(_programRepo.GetOne(id));
        }

        // POST api/Program
        public void Post(ProgramApp ProgramApp)
        {
            Program l = Mapper.MapToEntity(ProgramApp);
            _programRepo.Create(l);
        }

        [Route("api/Program/CreateProgramDevelopper")]
        [HttpPost]
        public void CreateProgramDevelopper(ProgramApp ProgramApp)
        {
            Program l = Mapper.MapToEntity(ProgramApp);
            _programRepo.CreateProgramDevelopper(l);
        }

        // PUT api/Program/5
        public void Put(int id, ProgramApp ProgramApp)
        {
            Program l = Mapper.MapToEntity(ProgramApp);
            _programRepo.Update(id, l);
        }

        // DELETE api/Program/5
        public void Delete(int id)
        {
            _programRepo.Delete(id);
        }
    }
}
