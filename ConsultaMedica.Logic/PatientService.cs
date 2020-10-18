
using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaMedica.Logic
{
    public class PatientService
    {
        private readonly GenericRepository<Patient> repository;
        private readonly ConsultaMedicaContext context;
        public PatientService()
        {
            context = new ConsultaMedicaContext();
            repository = new PatientRepository(context);
        }
        public List<PatientModel> GetPatients()
        {
            var patients = repository.List();
            var sql = patients.ToString();
            return patients.Select(d => new PatientModel { CPF = d.CPF, Email = d.Email, Name = d.Name, BirthDate = d.BirthDate, Phone = d.Phone, Sex = d.Sex }).ToList();
        }

        public void Add(PatientModel model)
        {
            repository.Insert(new Patient { Name = model.Name, BirthDate = model.BirthDate, CPF = model.CPF, Email = model.Email, Phone = model.Phone, Sex = model.Sex });
            context.SaveChanges();
        }

        public PatientModel GetById(int id)
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
    }
}
