using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;

namespace ConsultaMedica.Data.Repositories
{
    public class ExamTypeRepository : BaseRepository<ExamType>
    {
        public ExamTypeRepository(ConsultaMedicaContext context) : base(context)
        {
        }
    }
}
