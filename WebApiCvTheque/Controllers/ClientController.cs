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
    public class ClientController : ApiController
    {
        readonly ClientRepository _ClientRepo = new ClientRepository();
        // GET api/Client
        public IEnumerable<ClientApp> Get()
        {
            List<ClientApp> ClientApp = new List<ClientApp>();

            foreach(Client item in _ClientRepo.GetAll())
            {
                ClientApp.Add(Mapper.MapToEntity(item));
            }
            return ClientApp;
        }

        // GET api/Client/GetByName/Name
        [Route("api/Client/GetByName/{Name}")]
        public ClientApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_ClientRepo.GetByName(Name));
        }

        // GET api/Client/5
        public ClientApp Get(int id)
        {
            return Mapper.MapToEntity(_ClientRepo.GetOne(id));
        }

        // POST api/Client
        public void Post(ClientApp ClientApp)
        {
            Client l = Mapper.MapToEntity(ClientApp);
            _ClientRepo.Create(l);
        }

        // PUT api/Client/5
        public void Put(int id, ClientApp ClientApp)
        {
            Client l = Mapper.MapToEntity(ClientApp);
            _ClientRepo.Update(id, l);
        }

        // DELETE api/Client/5
        public void Delete(int id)
        {
            _ClientRepo.Delete(id);
        }
    }
}
