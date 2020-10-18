using ConsultaMedica.Logic;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientService service;

        public PatientController()
        {
            service = new PatientService();
        }

        public ActionResult Index()
        {
            return View(service.GetPatients());
        }
    }
}