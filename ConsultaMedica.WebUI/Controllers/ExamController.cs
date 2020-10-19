using ConsultaMedica.Logic.Services;
using ConsultaMedica.Shared.ViewModels;

namespace ConsultaMedica.WebUI.Controllers
{
    public class ExamController : BaseController<ExamViewModel>
    {
        public ExamController() : base(new ExamService())
        {
        }

    }
}