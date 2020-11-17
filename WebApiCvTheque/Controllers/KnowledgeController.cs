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
    public class KnowledgeController : ApiController
    {
        readonly KnowledgeRepository _knowledgeRepo = new KnowledgeRepository();
        // GET api/Knowledge
        public IEnumerable<KnowledgeApp> Get()
        {
            List<KnowledgeApp> KnowledgeApp = new List<KnowledgeApp>();

            foreach(Knowledge item in _knowledgeRepo.GetAll())
            {
                KnowledgeApp.Add(Mapper.MapToEntity(item));
            }
            return KnowledgeApp;
        }

        // GET api/Knowledge
        [Route("api/Knowledge/GetByUserId/{Id}")]
        public IEnumerable<KnowledgeApp> GetByUserId(int id)
        {
            List<KnowledgeApp> KnowledgeApp = new List<KnowledgeApp>();

            foreach (Knowledge item in _knowledgeRepo.GetKnowledgeByUser(id))
            {
                KnowledgeApp.Add(Mapper.MapToEntity(item));
            }
            return KnowledgeApp;
        }

        // GET api/Knowledge/GetByName/Name
        [Route("api/Knowledge/GetByName/{Name}")]
        public KnowledgeApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_knowledgeRepo.GetByName(Name));
        }

        // GET api/Knowledge/5
        public KnowledgeApp Get(int id)
        {
            return Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
        }

        // POST api/Knowledge
        public void Post(KnowledgeApp KnowledgeApp)
        {
            Knowledge l = Mapper.MapToEntity(KnowledgeApp);
            _knowledgeRepo.Create(l);
        }

        [Route("api/Knowledge/CreateKnowledgeDevelopper")]
        [HttpPost]
        public void CreateKnowledgeDevelopper(KnowledgeApp KnowledgeApp)
        {
            Knowledge l = Mapper.MapToEntity(KnowledgeApp);
            _knowledgeRepo.CreateKnowledgeDevelopper(l);
        }

        // PUT api/Knowledge/5
        public void Put(int id, KnowledgeApp KnowledgeApp)
        {
            Knowledge l = Mapper.MapToEntity(KnowledgeApp);
            _knowledgeRepo.Update(id, l);
        }

        // PUT api/Knowledge/5
        [Route("api/Knowledge/updateKnowledgeDevelopper/{Id}")]
        [HttpPut]
        public void updateKnowledgeDevelopper(int id, KnowledgeApp KnowledgeApp)
        {
            Knowledge l = Mapper.MapToEntity(KnowledgeApp);
            _knowledgeRepo.updateKnowledgeDevelopper(id, l);
        }

        // DELETE api/Knowledge/5
        public void Delete(int id)
        {
            _knowledgeRepo.Delete(id);
        }
    }
}
