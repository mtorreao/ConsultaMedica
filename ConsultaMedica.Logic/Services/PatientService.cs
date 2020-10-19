
using ConsultaMedica.Data.Contexts;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repositories;
using ConsultaMedica.Logic.Mappers;
using ConsultaMedica.Logic.Services;
using ConsultaMedica.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsultaMedica.Logic
{
    public class PatientService : BaseService<PatientViewModel, Patient>
    {
        public PatientService() : base(new PatientRepository(new ConsultaMedicaContext())) { }

        public override List<PatientViewModel> List(string orderBy = null, string searchString = null)
        {
            var models = repository.List();

            if (orderBy != null)
            {
                models = orderBy switch
                {
                    "name_desc" => models.OrderByDescending(s => s.Name),
                    _ => models.OrderBy(s => s.Name),
                };
            }

            if (searchString != null)
            {
                var regex = new Regex(searchString, RegexOptions.IgnoreCase);
                models = models.Where(p => regex.IsMatch(p.CPF) || regex.IsMatch(p.Name));
            }

            return AutoMapperConfig.mapper.ProjectTo<PatientViewModel>(models).ToList();
        }

    }
}
