using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Shared.Models
{
    public class PatientModel : BaseModel
    {
        [DisplayName("Nome"), StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(14, MinimumLength = 14)]
        public string CPF { get; set; }
        [DisplayName("Data Nascimento")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Sexo")]
        public char Sex { get; set; }
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
