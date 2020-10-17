using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Transfer
{
    public class Patient
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
