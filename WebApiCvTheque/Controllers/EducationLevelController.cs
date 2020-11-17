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
    public class EducationLevelController : ApiController
    {
        readonly EducationLevelRepository _levelRepo = new EducationLevelRepository();
        // GET api/EducationLevel
        public IEnumerable<EducationLevelApp> Get()
        {
            List<EducationLevelApp> levelApp = new List<EducationLevelApp>();

            foreach(EducationLevel item in _levelRepo.GetAll())
            {
                levelApp.Add(Mapper.MapToEntity(item));
            }
            return levelApp;
        }

        // GET api/EducationLevel/GetByName/Name
        [Route("api/EducationLevel/GetByName/{Name}")]
        public EducationLevelApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_levelRepo.GetByName(Name));
        }

        // GET api/EducationLevel/5
        public EducationLevelApp Get(int id)
        {
            return Mapper.MapToEntity(_levelRepo.GetOne(id));
        }

        // POST api/EducationLevel
        public void Post(EducationLevelApp levelApp)
        {
            EducationLevel l = Mapper.MapToEntity(levelApp);
            _levelRepo.Create(l);
        }

        // PUT api/EducationLevel/5
        public void Put(int id, EducationLevelApp levelApp)
        {
            EducationLevel l = Mapper.MapToEntity(levelApp);
            _levelRepo.Update(id, l);
        }

        // DELETE api/EducationLevel/5
        public void Delete(int id)
        {
            _levelRepo.Delete(id);
        }
    }
}
