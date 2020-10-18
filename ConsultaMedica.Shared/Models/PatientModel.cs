using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Shared.Models
{
    public class PatientModel
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
