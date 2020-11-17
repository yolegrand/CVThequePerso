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
    public class LanguageController : ApiController
    {
        readonly LanguageRepository _languageRepo = new LanguageRepository();
        // GET api/Language
        public IEnumerable<LanguageApp> Get()
        {
            List<LanguageApp> LanguageApp = new List<LanguageApp>();

            foreach(Language item in _languageRepo.GetAll())
            {
                LanguageApp.Add(Mapper.MapToEntity(item));
            }
            return LanguageApp;
        }

        // GET api/Language/GetByName/Name
        [Route("api/Language/GetByName/{Name}")]
        public LanguageApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_languageRepo.GetByName(Name));
        }

        // GET api/Language/5
        public LanguageApp Get(int id)
        {
            return Mapper.MapToEntity(_languageRepo.GetOne(id));
        }

        // POST api/Language
        public void Post(LanguageApp LanguageApp)
        {
            Language l = Mapper.MapToEntity(LanguageApp);
            _languageRepo.Create(l);
        }

        // POST api/LanguageDevelopper
        [Route("api/Language/CreateLanguageDevelopper")]
        [HttpPost]
        public void CreateLanguageDevelopper(LanguageApp LanguageApp)
        {
            Language l = Mapper.MapToEntity(LanguageApp);
            _languageRepo.CreateLanguageDevelopper(l);
        }

        

        // PUT api/Language/5
        public void Put(int id, LanguageApp LanguageApp)
        {
            Language l = Mapper.MapToEntity(LanguageApp);
            _languageRepo.Update(id, l);
        }

        // DELETE api/Language/5
        public void Delete(int id)
        {
            _languageRepo.Delete(id);
        }
    }
}
