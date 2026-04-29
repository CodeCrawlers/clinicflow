using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Application.Features.Patients.Dtos;

public class CreatePatientDto
{
    public Guid UserId { get; set; }
    public string Phone { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string? Address { get; set; }
    public string? BloodType { get; set; }
}
