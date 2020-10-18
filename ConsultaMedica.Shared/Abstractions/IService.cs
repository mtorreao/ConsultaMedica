using ConsultaMedica.Shared.Models;
using System.Collections.Generic;

namespace ConsultaMedica.Shared
{
    public interface IService<T> where T : BaseModel
    {
        public List<T> List();
        public void Add(T model);
        public void Update(T model);
        public void Remove(int id);
        public T FindById(int id);
    }
}
