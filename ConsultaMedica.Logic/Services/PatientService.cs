
using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Shared;
using ConsultaMedica.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsultaMedica.Logic
{
    public class PatientService : IService<PatientModel>
    {
        private readonly GenericRepository<Patient> repository;
        private readonly ConsultaMedicaContext context;
        private bool isDisposed = false;

        public PatientService()
        {
            context = new ConsultaMedicaContext();
            repository = new PatientRepository(context);
        }

        public void Add(PatientModel model)
        {
            repository.Insert(new Patient { Name = model.Name, BirthDate = model.BirthDate, CPF = model.CPF, Email = model.Email, Phone = model.Phone, Sex = model.Sex });
            repository.Save();
        }

        public void Update(PatientModel model)
        {
            var dataModel = new Patient
            {
                ID = model.ID,
                CPF = model.CPF,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Name = model.Name,
                Phone = model.Phone,
                Sex = model.Sex
            };
            repository.Update(dataModel);
            repository.Save();
        }

        public void Remove(int id)
        {
            repository.Delete(id);
            repository.Save();
        }

        public List<PatientModel> List(string orderBy = null, string searchString = null)
        {
            var patients = repository.List();

            if (orderBy != null)
            {
                patients = orderBy switch
                {
                    "name_desc" => patients.OrderByDescending(s => s.Name),
                    _ => patients.OrderBy(s => s.Name),
                };
            }

            if (searchString != null)
            {
                var regex = new Regex(searchString, RegexOptions.IgnoreCase);
                patients = patients.Where(p => regex.IsMatch(p.CPF) || regex.IsMatch(p.Name));
            }

            return patients.Select(d => new PatientModel { ID = d.ID, CPF = d.CPF, Email = d.Email, Name = d.Name, BirthDate = d.BirthDate, Phone = d.Phone, Sex = d.Sex }).ToList();
        }

        public PatientModel FindById(int id)
        {
            var dataModel = repository.GetByID(id);
            return new PatientModel
            {
                CPF = dataModel.CPF,
                Email = dataModel.Email,
                BirthDate = dataModel.BirthDate,
                Name = dataModel.Name,
                Phone = dataModel.Phone,
                Sex = dataModel.Sex
            };
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
                context.Dispose();
            }

            isDisposed = true;
        }
    }
}
