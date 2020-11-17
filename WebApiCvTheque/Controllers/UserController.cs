using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Core.ViewModels;
using CvTheque.Data.DataRepositories;
using CvTheque.Data.DataRepositoties;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiCvTheque.Models;
using WebApiCvTheque.Services;

namespace WebApiCvTheque.Controllers
{
    [BasicAuthentification(Realm: "MIKE8")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        readonly UserRepository _userRepo = new UserRepository();
        // GET api/User
        public IEnumerable<UserApp> Get()
        {
            List<UserApp> UserApp = new List<UserApp>();

            foreach(User item in _userRepo.GetAll())
            {
                UserApp.Add(Mapper.MapToEntity(item));
            }
            return UserApp;
        }

        // GET api/User/GetUserBySociety/5
        [Route("api/User/GetUserBySociety/{SocietyId}")]
        [HttpGet]
        public IEnumerable<UserApp> GetBySociety(int SocietyId)
        {
            List<UserApp> UserApp = new List<UserApp>();

            foreach (ViewUser item in _userRepo.GetUserBySociety(SocietyId))
            {
                UserApp.Add(Mapper.MapToViewEntity(item));
            }
            return UserApp;
        }

        // GET api/User/GetDevelopperBySociety/5
        [Route("api/User/GetDevelopperBySociety/{SocietyId}")]
        [HttpGet]
        public IEnumerable<UserApp> GetDevelopperBySociety(int SocietyId)
        {
            List<UserApp> UserApp = new List<UserApp>();

            foreach (ViewUser item in _userRepo.GetDevelopperBySociety(SocietyId))
            {
                UserApp.Add(Mapper.MapToViewEntity(item));
            }
            return UserApp;
        }


        // GET api/User/GetByFirstName/FirstName
        [Route("api/User/GetByFirstName/{FirstName}")]
        public UserApp GetByFirstName(string FirstName)
        {
            return Mapper.MapToEntity(_userRepo.GetByFirstName(FirstName));
        }

        // GET api/User/GetByLastName/LastName
        [Route("api/User/GetByLastName/{LastName}")]
        public UserApp GetByLastName(string LastName)
        {
            return Mapper.MapToEntity(_userRepo.GetByLastName(LastName));
        }

        // GET api/User/GetByCity/City
        [Route("api/User/GetByCity/{City}")]
        public UserApp GetByCity(string City)
        {
            return Mapper.MapToEntity(_userRepo.GetByCity(City));
        }

        // GET api/User/GetByMail/Mail
        [Route("api/User/GetByMail/{Mail}")]
        public UserApp GetByMail(string Mail)
        {
            return Mapper.MapToEntity(_userRepo.GetByMail(Mail));
        }

        // GET api/User/GetByPersonalMail/PersonalMail
        [Route("api/User/GetByPersonalMail/{PersonalMail}")]
        public UserApp GetByPersonalMail(string Mail)
        {
            return Mapper.MapToEntity(_userRepo.GetByPersonalMail(Mail));
        }

        // GET api/User/GetByPersonalPhone/Phone
        [Route("api/User/GetByPersonalPhone/{Phone}")]
        public UserApp GetByPersonalPhone(int Phone)
        {
            return Mapper.MapToEntity(_userRepo.GetByPersonalPhone(Phone));
        }

        // GET api/User/GetByPhone/Phone
        [Route("api/User/GetByPhone/{Phone}")]
        public UserApp GetByPhone(int Phone)
        {
            return Mapper.MapToEntity(_userRepo.GetByPhone(Phone));
        }

        // GET api/User/Authentification
        [Route("api/User/Authentification")]
        [HttpPost]
        public bool Authentification(User u)
        {
            return _userRepo.Authentification(u.Mail, u.Password);
        }

        // GET api/User/Check
        [Route("api/User/Check")]
        [HttpPost]
        public UserApp Check(User u)
        {
            return Mapper.MapToEntity(_userRepo.Check(u));
        }

        // GET api/User/5
        public UserApp Get(int id)
        {
            return Mapper.MapToEntity(_userRepo.GetOne(id));
        }

        // POST api/User
        public void Post(UserApp UserApp)
        {
            User l = Mapper.MapToEntity(UserApp);
            _userRepo.Create(l);
        }

        // GET api/User/CreateCv
        [Route("api/User/CreateCv")]
        [HttpPost]
        public void CreateCv(UserApp UserApp)
        {
            User l = Mapper.MapToEntity(UserApp);
            _userRepo.CreateCv(l);
        }

        // GET api/User/CreateEducation
        [Route("api/User/CreateEducation")]
        [HttpPost]
        public void CreateEducation(EducationApp EducationApp)
        {
            Education educ = Mapper.MapToEntity(EducationApp);
            _userRepo.CreateEducation(educ);
        }

        // GET api/User/CreateExperience
        [Route("api/User/CreateExperience")]
        [HttpPost]
        public void CreateExperience(ExperienceApp ExperienceApp)
        {
            Experience exp = Mapper.MapToEntity(ExperienceApp);
            _userRepo.CreateExperience(exp);
        }

        // PUT api/User/5
        public void Put(int id, UserApp UserApp)
        {
            User l = Mapper.MapToEntity(UserApp);
            _userRepo.Update(id, l);
        }

        // DELETE api/User/5
        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }
    }
}
