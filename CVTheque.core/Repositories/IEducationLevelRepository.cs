using CvTheque.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IEducationLevelRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<EducationLevel> GetByLinkEducation(int Id);
        T GetByName(string Name);
    }
}
