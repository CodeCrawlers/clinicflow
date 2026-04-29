using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicFlow.Domain.Entities;

namespace ClinicFlow.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Patient> Patients { get; }
        DbSet<Doctor> Doctors { get; }
        DbSet<Appointment> Appointments { get; }
        DbSet<MedicalRecord> MedicalRecords { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
