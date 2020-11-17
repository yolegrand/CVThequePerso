using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IExperienceRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<ViewExperience> GetExperience(int Id);
    }
}
