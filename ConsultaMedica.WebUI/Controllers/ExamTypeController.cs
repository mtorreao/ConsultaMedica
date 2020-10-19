using ConsultaMedica.Logic.Services;
using ConsultaMedica.Shared;
using ConsultaMedica.Shared.ViewModels;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class ExamTypeController : BaseController<ExamTypeViewModel>
    {
        public ExamTypeController() : base(new ExamTypeService())
        {
        }
    }
}