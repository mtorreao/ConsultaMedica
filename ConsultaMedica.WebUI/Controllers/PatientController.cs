using ConsultaMedica.Logic;
using ConsultaMedica.Shared.ViewModels;
using System;
using System.Web.Mvc;

namespace ConsultaMedica.WebUI.Controllers
{
    public class PatientController : BaseController<PatientViewModel>
    {
        public PatientController() : base(new PatientService()) { }

    }
}