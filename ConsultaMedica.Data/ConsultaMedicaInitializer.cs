using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ConsultaMedica.Data
{
    public class ConsultaMedicaInitializer : DropCreateDatabaseAlways<ConsultaMedicaContext>
    {
        protected override void Seed(ConsultaMedicaContext context)
        {
            var examTypes = new List<ExamType> {
                new ExamType { Name = "Hemograma", Description = "Descricao do tipo de exame Hemograma" },
                new ExamType { Name = "Raio X", Description = "Descricao do tipo de exame Raio X" },
            };
            context.ExamTypes.AddRange(examTypes);
            context.SaveChanges();

            var patients = new List<Patient> {
                new Patient { CPF = "100.000.000-00", Name = "Alex Salvador", BirthDate = DateTime.Parse("2001-01-01"), Email = "alex@gmail.com", Phone = "(81) 9 8232-2313", Sex = 'M' },
                new Patient { CPF = "200.000.000-00", Name = "Rafaela Garrucha", BirthDate = DateTime.Parse("1989-12-25"), Email = "rafaela@gmail.com", Phone = "(55) 9 8743-6643", Sex = 'F' },
                new Patient { CPF = "300.000.000-00", Name = "Elisandro Dias", BirthDate = DateTime.Parse("1991-03-13"), Email = "elisandro@hotmail.com", Phone = "(51) 9 0394-3189", Sex = 'M' },
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();

            var exams = new List<Exam> {
                new Exam { Name = "Nome do exame 1", ExamTypeID = examTypes[0].ID, ExamType = examTypes[0], Observations = "Observacoes do exame 1" },
                new Exam { Name = "Nome do exame 2", ExamTypeID = examTypes[1].ID, ExamType = examTypes[1], Observations = "Observacoes do exame 2" },
            };
            context.Exams.AddRange(exams);
            context.SaveChanges();
        }
    }
}
