using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultaMedica.Shared.Models
{
    public class PatientModel : BaseModel
    {
        [Required(), DisplayName("Nome"), StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(), StringLength(14, MinimumLength = 14)]
        public string CPF { get; set; }
        [Required(), DisplayName("Data Nascimento")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Sexo")]
        public char Sex { get; set; }
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
