using ConsultaMedica.Logic;
using ConsultaMedica.Shared.Models;
using System.Data;
using System.Net;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Add(model);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError(string.Empty, ex);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = service.GetById(id.Value);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
    }
}