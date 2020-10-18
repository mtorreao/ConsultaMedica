using ConsultaMedica.Shared;
using ConsultaMedica.Shared.Models;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class BaseController<T> : Controller where T : BaseModel
    {
        protected IService<T> Service { get; set; }

        public BaseController(IService<T> service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(Service.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PatientModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Service.Add(model);
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = Service.FindById(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T model)
        {
            var id = model.ID;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = Service.FindById(id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "LastName", "FirstMidName", "EnrollmentDate" }))
            {
                try
                {
                    Service.Update(model);

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = Service.FindById(id.Value);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var model = Service.FindById(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Service.Remove(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}