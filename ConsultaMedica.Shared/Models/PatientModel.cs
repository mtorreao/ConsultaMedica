using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Shared.Models
{
    public class PatientModel : BaseModel
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        [DisplayName("Data Nascimento")]
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
