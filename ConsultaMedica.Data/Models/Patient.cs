using System;
using System.Collections.Generic;

namespace ConsultaMedica.Data.Models
{
    public class Patient : BaseModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
