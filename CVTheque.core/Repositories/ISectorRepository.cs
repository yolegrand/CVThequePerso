using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface ISectorRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<ViewSector> GetSectorByClient(int Id);
        IEnumerable<ViewSector> GetSectorByProspect(int Id);
        T GetByName(string Name);
    }
}
