using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Shared.ViewModels;

namespace ConsultaMedica.Logic.Services
{
    public class ExamService : BaseService<ExamViewModel, Exam>
    {
        public ExamService() : base(new ExamRepository(new Data.Contexts.ConsultaMedicaContext()))
        {
        }
    }
}
