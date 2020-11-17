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
    public class ProgramTypeController : ApiController
    {
        readonly ProgramTypeRepository _programTypeRepo = new ProgramTypeRepository();
        // GET api/ProgramType
        public IEnumerable<ProgramTypeApp> Get()
        {
            List<ProgramTypeApp> ProgramTypeApp = new List<ProgramTypeApp>();

            foreach (ProgramType item in _programTypeRepo.GetAll())
            {
                ProgramTypeApp.Add(Mapper.MapToEntity(item));
            }
            return ProgramTypeApp;
        }

        // GET api/ProgramType/GetByName/Name
        [Route("api/ProgramType/GetByName/{Name}")]
        public ProgramTypeApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_programTypeRepo.GetByName(Name));
        }

        // GET api/ProgramType/5
        public ProgramTypeApp Get(int id)
        {
            return Mapper.MapToEntity(_programTypeRepo.GetOne(id));
        }

        // POST api/ProgramType
        public void Post(ProgramTypeApp ProgramType)
        {
            ProgramType p = Mapper.MapToEntity(ProgramType);
            _programTypeRepo.Create(p);
        }

        // PUT api/ProgramType/5
        public void Put(int id, ProgramTypeApp ProgramType)
        {
            ProgramType p = Mapper.MapToEntity(ProgramType);
            _programTypeRepo.Update(id, p);
        }

        // DELETE api/ProgramType/5
        public void Delete(int id)
        {
            _programTypeRepo.Delete(id);
        }
    }
}
