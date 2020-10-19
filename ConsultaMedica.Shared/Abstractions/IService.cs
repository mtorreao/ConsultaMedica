using ConsultaMedica.Shared.ViewModels;
using System;
using System.Collections.Generic;

namespace ConsultaMedica.Shared
{
    public interface IService<T> : IDisposable where T : BaseViewModel
    {
        public List<T> List(string orderBy = null, string searchString = null);
        public void Add(T model);
        public void Update(T model);
        public void Remove(int id);
        public T FindById(int id);
    }
}
