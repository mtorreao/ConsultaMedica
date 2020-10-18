using ConsultaMedica.Logic;
using ConsultaMedica.Shared.Models;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetPatients());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PatientModel());
        }

        [HttpPost]
        public ActionResult Create(PatientModel model)
        {
            service.Add(model);
            return View();
        }
    }
}