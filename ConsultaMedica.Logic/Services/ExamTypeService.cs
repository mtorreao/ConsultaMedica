using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Shared.ViewModels;

namespace ConsultaMedica.Logic.Services
{
    public class ExamTypeService : BaseService<ExamTypeViewModel, ExamType>
    {
        public ExamTypeService() : base(new ExamTypeRepository(new ConsultaMedicaContext()))
        {
        }
    }
}
