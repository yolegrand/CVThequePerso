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
    public class ExperienceController : ApiController
    {
        readonly ExperienceRepository _experienceRepo = new ExperienceRepository();
        // GET api/Experience
        public IEnumerable<ExperienceApp> Get()
        {
            List<ExperienceApp> ExperienceApp = new List<ExperienceApp>();

            foreach(Experience item in _experienceRepo.GetAll())
            {
                ExperienceApp.Add(Mapper.MapToEntity(item));
            }
            return ExperienceApp;
        }

        // GET api/Experience/5
        public ExperienceApp Get(int id)
        {
            return Mapper.MapToEntity(_experienceRepo.GetOne(id));
        }

        // POST api/Experience
        public void Post(ExperienceApp ExperienceApp)
        {
            Experience l = Mapper.MapToEntity(ExperienceApp);
            _experienceRepo.Create(l);
        }

        
        // PUT api/Experience/5
        public void Put(int id, ExperienceApp ExperienceApp)
        {
            Experience l = Mapper.MapToEntity(ExperienceApp);
            _experienceRepo.Update(id, l);
        }

        // DELETE api/Experience/5
        public void Delete(int id)
        {
            _experienceRepo.Delete(id);
        }
    }
}
