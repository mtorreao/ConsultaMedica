using ConsultaMedica.Logic;
using ConsultaMedica.Shared.Models;
using System;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class PatientController : BaseController<PatientModel>
    {
        public PatientController() : base(new PatientService()) { }

    }
}