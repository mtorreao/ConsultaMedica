using ConsultaMedica.Logic;
using ConsultaMedica.Shared.Models;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class PatientController : BaseController<PatientModel>
    {
        public PatientController() : base(new PatientService()) { }

    }
}