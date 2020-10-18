using ConsultaMedica.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsultaMedica.Data
{
    public class ConsultaMedicaContext : DbContext
    {
        public ConsultaMedicaContext() : base("ConsultaMedicaContext") { }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
