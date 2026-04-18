using Microsoft.EntityFrameworkCore;
using ClinicFlow.Domain;

namespace ClinicFlow.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}