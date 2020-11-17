using CvTheque.Core.Models;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IUserRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<ViewUser> GetByLinkEducation(int Id);
        T GetByFirstName(string FirstName);
        T GetByLastName(string LastName);
        T GetByPersonalMail(string PersonalMail);
        T GetByMail(string Mail);
        T GetByPhone(int Phone);
        T GetByPersonalPhone(int PersonalPhone);
        T GetByCity(string City);
        T Check(T user);
        bool Authentification(string EMail, string Pass);
        IEnumerable<ViewUser> GetUserBySociety(int SocietyId);
        IEnumerable<ViewUser> GetDevelopperBySociety(int SocietyId);
        void CreateCv(User user);
        void CreateEducation(Education education);
        void CreateExperience(Experience experience);
    }
}
