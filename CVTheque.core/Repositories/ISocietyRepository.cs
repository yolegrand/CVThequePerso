using CvTheque.Core.Models;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface ISocietyRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<ViewSociety> GetSocietyByClient(int Id);
        IEnumerable<ViewSociety> GetSocietyByProspect(int Id);
        IEnumerable<ViewSociety> GetSocietyByUser(int Id);
        IEnumerable<Society> GetSocietyByUserName(string Name);
        T GetByName(string Name);
    }
}
