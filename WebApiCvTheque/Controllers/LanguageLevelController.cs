using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
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
    public class LanguageLevelController : ApiController
    {
        readonly LanguageLevelRepository _levelRepo = new LanguageLevelRepository();
        // GET api/LanguageLevel
        public IEnumerable<LanguageLevelApp> Get()
        {
            List<LanguageLevelApp> levelApp = new List<LanguageLevelApp>();

            foreach(LanguageLevel item in _levelRepo.GetAll())
            {
                levelApp.Add(Mapper.MapToEntity(item));
            }
            return levelApp;
        }

        // GET api/LanguageLevel/GetByName/Name
        [Route("api/LanguageLevel/GetByName/{Name}")]
        public LanguageLevelApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_levelRepo.GetByName(Name));
        }

        // GET api/LanguageLevel/5
        public LanguageLevelApp Get(int id)
        {
            return Mapper.MapToEntity(_levelRepo.GetOne(id));
        }

        // POST api/LanguageLevel
        public void Post(LanguageLevelApp levelApp)
        {
            LanguageLevel l = Mapper.MapToEntity(levelApp);
            _levelRepo.Create(l);
        }

        // PUT api/LanguageLevel/5
        public void Put(int id, LanguageLevelApp levelApp)
        {
            LanguageLevel l = Mapper.MapToEntity(levelApp);
            _levelRepo.Update(id, l);
        }

        // DELETE api/LanguageLevel/5
        public void Delete(int id)
        {
            _levelRepo.Delete(id);
        }
    }
}
