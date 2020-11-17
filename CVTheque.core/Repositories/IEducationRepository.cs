﻿using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvTheque.Core.Repositories
{
    public interface IEducationRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        T GetByName(string Name);
        IEnumerable<ViewEducation> GetEducation(int Id);
    }
}