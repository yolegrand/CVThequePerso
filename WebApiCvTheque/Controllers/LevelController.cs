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
    public class LevelController : ApiController
    {
        readonly LevelRepository _levelRepo = new LevelRepository();
        // GET api/Level
        public IEnumerable<LevelApp> Get()
        {
            List<LevelApp> levelApp = new List<LevelApp>();

            foreach(Level item in _levelRepo.GetAll())
            {
                levelApp.Add(Mapper.MapToEntity(item));
            }
            return levelApp;
        }

        // GET api/Level/GetByName/Name
        [Route("api/Level/GetByName/{Name}")]
        public LevelApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_levelRepo.GetByName(Name));
        }

        // GET api/Level/5
        public LevelApp Get(int id)
        {
            return Mapper.MapToEntity(_levelRepo.GetOne(id));
        }

        // POST api/Level
        public void Post(LevelApp levelApp)
        {
            Level l = Mapper.MapToEntity(levelApp);
            _levelRepo.Create(l);
        }

        // PUT api/Level/5
        public void Put(int id, LevelApp levelApp)
        {
            Level l = Mapper.MapToEntity(levelApp);
            _levelRepo.Update(id, l);
        }

        // DELETE api/Level/5
        public void Delete(int id)
        {
            _levelRepo.Delete(id);
        }
    }
}
