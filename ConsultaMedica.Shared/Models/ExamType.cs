﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Shared.Models
{
    public class ExamType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
