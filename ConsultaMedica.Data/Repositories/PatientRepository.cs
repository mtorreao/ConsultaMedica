using ConsultaMedica.Data.Models;

namespace ConsultaMedica.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>
    {
        public PatientRepository(ConsultaMedicaContext context) : base(context)
        {
        }
    }
}
