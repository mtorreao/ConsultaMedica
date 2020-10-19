using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;

namespace ConsultaMedica.Data.Repositories
{
    public class ExamRepository : BaseRepository<Exam>
    {
        public ExamRepository(ConsultaMedicaContext context) : base(context)
        {
        }
    }
}
