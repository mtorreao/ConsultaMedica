﻿using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;

namespace ConsultaMedica.Data.Repositories
{
    public class PatientRepository : BaseRepository<Patient>
    {
        public PatientRepository(ConsultaMedicaContext context) : base(context)
        {
        }
    }
}
