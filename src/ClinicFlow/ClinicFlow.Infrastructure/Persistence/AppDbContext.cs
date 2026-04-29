using ClinicFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClinicFlow.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    // Explicit interface implementations to satisfy IAppDbContext (interface now exposes DbSet<T>)
    DbSet<User> Application.Common.Interfaces.IAppDbContext.Users => Users;
    DbSet<Patient> Application.Common.Interfaces.IAppDbContext.Patients => Patients;
    DbSet<Doctor> Application.Common.Interfaces.IAppDbContext.Doctors => Doctors;
    DbSet<Appointment> Application.Common.Interfaces.IAppDbContext.Appointments => Appointments;
    DbSet<MedicalRecord> Application.Common.Interfaces.IAppDbContext.MedicalRecords => MedicalRecords;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
