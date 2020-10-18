using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Shared.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Observations { get; set; }
        public ExamType Type { get; set; }
    }
}
