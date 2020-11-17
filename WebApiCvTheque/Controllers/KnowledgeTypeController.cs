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
    public class KnowledgeTypeController : ApiController
    {
        readonly KnowledgeTypeRepository _knowledgeTypeRepo = new KnowledgeTypeRepository();
        // GET api/KnowledgeType
        public IEnumerable<KnowledgeTypeApp> Get()
        {
            List<KnowledgeTypeApp> KnowledgeTypeApp = new List<KnowledgeTypeApp>();

            foreach(KnowledgeType item in _knowledgeTypeRepo.GetAll())
            {
                KnowledgeTypeApp.Add(Mapper.MapToEntity(item));
            }
            return KnowledgeTypeApp;
        }

        // GET api/KnowledgeType/GetByName/Name
        [Route("api/KnowledgeType/GetByName/{Name}")]
        public KnowledgeTypeApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_knowledgeTypeRepo.GetByName(Name));
        }

        // GET api/KnowledgeType/5
        public KnowledgeTypeApp Get(int id)
        {
            return Mapper.MapToEntity(_knowledgeTypeRepo.GetOne(id));
        }

        // POST api/KnowledgeType
        public void Post(KnowledgeTypeApp levelApp)
        {
            KnowledgeType k = Mapper.MapToEntity(levelApp);
            _knowledgeTypeRepo.Create(k);
        }

        // PUT api/KnowledgeType/5
        public void Put(int id, KnowledgeTypeApp levelApp)
        {
            KnowledgeType l = Mapper.MapToEntity(levelApp);
            _knowledgeTypeRepo.Update(id, l);
        }

        // DELETE api/KnowledgeType/5
        public void Delete(int id)
        {
            _knowledgeTypeRepo.Delete(id);
        }
    }
}
