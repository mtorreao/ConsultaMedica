using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultaMedica.Data.Models
{
    public class Patient : BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public char Sex { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
