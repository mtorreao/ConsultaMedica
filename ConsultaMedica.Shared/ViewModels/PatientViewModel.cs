using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultaMedica.Shared.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        [Required(), DisplayName("Nome"), StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(), StringLength(14, MinimumLength = 14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencher campo Data de Nascimento"),
            DisplayName("Data Nascimento"),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}"),
            DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Sexo")]
        public char Sex { get; set; }
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
