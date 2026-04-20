using ClinicFlow.Domain.Common;
using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities;

public class Patient : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public DateOnly DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public string? Address { get; private set; }
    public string? BloodType { get; private set; }
    public string? EmergencyContactName { get; private set; }
    public string? EmergencyContactPhone { get; private set; }

    public User User { get; private set; } = null!;

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
    public ICollection<MedicalRecord> MedicalRecords { get; private set; } = new List<MedicalRecord>();

    private Patient() { }

    public static Patient Create(
        Guid userId,
        string phone,
        DateOnly dateOfBirth,
        Gender gender,
        string? address = null,
        string? bloodType = null)
    {
        return new Patient
        {
            UserId = userId,
            Phone = phone,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            Address = address,
            BloodType = bloodType
        };
    }

    public void Update(
        string phone,
        string? address,
        string? emergencyName,
        string? emergencyPhone)
    {
        Phone = phone;
        Address = address;
        EmergencyContactName = emergencyName;
        EmergencyContactPhone = emergencyPhone;

        SetUpdatedAt();
    }
}