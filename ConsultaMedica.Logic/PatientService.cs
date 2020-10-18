
using ConsultaMedica.Data;
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
    }
}
