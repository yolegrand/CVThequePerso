using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Data.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCvTheque.Services
{
    public class UserService
    {
        private UserRepository _repo = new UserRepository();
        public bool Authentication(string Mail, string Password)
        {
            return _repo.Authentification(Mail, Password);
        }
    }
}