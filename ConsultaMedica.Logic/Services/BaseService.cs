using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Logic.Mappers;
using ConsultaMedica.Shared;
using ConsultaMedica.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaMedica.Logic.Services
{
    public abstract class BaseService<T, A> : IService<T> where T : BaseViewModel where A : BaseModel
    {
        private bool isDisposed = false;

        protected readonly BaseRepository<A> repository;

        protected BaseService(BaseRepository<A> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(T model)
        {
            var objToSave = AutoMapperConfig.mapper.Map<A>(model);
            repository.Insert(objToSave);
            repository.Save();
        }

        public virtual T FindById(int id)
        {
            var dataModel = repository.GetByID(id);
            return AutoMapperConfig.mapper.Map<T>(dataModel);
        }

        public virtual List<T> List(string orderBy = null, string searchString = null)
        {
            var models = repository.List();
            return AutoMapperConfig.mapper.ProjectTo<T>(models).ToList();
        }

        public virtual void Remove(int id)
        {
            repository.Delete(id);
            repository.Save();
        }

        public virtual void Update(T model)
        {
            var dataModel = AutoMapperConfig.mapper.Map<A>(model);
            repository.Update(dataModel);
            repository.Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                repository.Dispose();
            }

            isDisposed = true;
        }
    }
}
