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
    public class EducationController : ApiController
    {
        private readonly EducationRepository _educationRepo = new EducationRepository();
        // GET api/Education
        public IEnumerable<EducationApp> Get()
        {
            List<EducationApp> ExperienceApp = new List<EducationApp>();

            foreach(Education Item in _educationRepo.GetAll())
            {
                ExperienceApp.Add(Mapper.MapToEntity(Item));
            }
            return ExperienceApp;
        }

        // GET api/Education/GetByName/Name
        [Route("api/Education/GetByName/{Name}")]
        public EducationApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_educationRepo.GetByName(Name));
        }

        // GET api/Education/5
        public EducationApp Get(int id)
        {
            return Mapper.MapToEntity(_educationRepo.GetOne(id));
        }

        // POST api/Education
        public void Post(EducationApp EducationApp)
        {
            Education l = Mapper.MapToEntity(EducationApp);
            _educationRepo.Create(l);
        }

        // PUT api/Education/5
        public void Put(int id, EducationApp EducationApp)
        {
            Education l = Mapper.MapToEntity(EducationApp);
            _educationRepo.Update(id, l);
        }

        [Route("api/Education/updateEducationDevelopper/{Id}")]
        [HttpPut]
        public void updateEducationDevelopper(int id, EducationApp EducationApp)
        {
            Education l = Mapper.MapToEntity(EducationApp);
            _educationRepo.updateEducationDevelopper(id, l);
        }

        // DELETE api/Education/5
        public void Delete(int id)
        {
            _educationRepo.Delete(id);
        }
    }
}
