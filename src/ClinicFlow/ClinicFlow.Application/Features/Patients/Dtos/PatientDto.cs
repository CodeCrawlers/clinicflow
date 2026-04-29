using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Application.Features.Patients.Dtos;

public class PatientDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Phone { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string? Address { get; set; }
    public string? BloodType { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
