using CvTheque.Core.Models;
using CvTheque.Data.DataRepositories;
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
    public class RoleController : ApiController
    {
        readonly RoleRepository _roleRepo = new RoleRepository();
    // GET api/Role
    public IEnumerable<RoleApp> Get()
        {
            List<RoleApp> CityApp = new List<RoleApp>();

            foreach (Role item in _roleRepo.GetAll())
            {
                CityApp.Add(Mapper.MapToEntity(item));
            }
            return CityApp;
        }

        // GET api/Role/5
        public RoleApp Get(int id)
        {
            return Mapper.MapToEntity(_roleRepo.GetOne(id));
        }

        // GET api/Role/GetByName/Name
        [Route("api/Role/GetByName/{Name}")]
        public RoleApp GetByName(string Name)
        {
            return Mapper.MapToEntity(_roleRepo.GetByName(Name));
        }

        // POST api/Role
        public void Post(RoleApp RoleApp)
        {
            Role c = Mapper.MapToEntity(RoleApp);
            _roleRepo.Create(c);
        }

        // PUT api/Role/5
        public void Put(int id, RoleApp RoleApp)
        {
        Role c = Mapper.MapToEntity(RoleApp);
            _roleRepo.Update(id, c);
        }

        // DELETE api/Role/5
        public void Delete(int id)
        {
            _roleRepo.Delete(id);
        }
    }
}