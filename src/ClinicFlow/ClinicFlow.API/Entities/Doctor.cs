using ClinicFlow.Domain.Common;

namespace ClinicFlow.Domain.Entities;

public class Doctor : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Specialty { get; private set; } = string.Empty;
    public string LicenseNumber { get; private set; } = string.Empty;
    public string? Bio { get; private set; }
    public TimeOnly AvailableFrom { get; private set; }
    public TimeOnly AvailableTo { get; private set; }
    public bool IsActive { get; private set; } = true;

    public User User { get; private set; } = null!;

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    private Doctor() { }

    public static Doctor Create(
        Guid userId,
        string specialty,
        string licenseNumber,
        TimeOnly availableFrom,
        TimeOnly availableTo,
        string? bio = null)
    {
        return new Doctor
        {
            UserId = userId,
            Specialty = specialty,
            LicenseNumber = licenseNumber,
            Bio = bio,
            AvailableFrom = availableFrom,
            AvailableTo = availableTo
        };
    }
}