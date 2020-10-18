using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ConsultaMedica.Data
{
    public static class Initializer
    {
        public static void Start()
        {
            Database.SetInitializer(new ConsultaMedicaInitializer());
        }
    }
}
