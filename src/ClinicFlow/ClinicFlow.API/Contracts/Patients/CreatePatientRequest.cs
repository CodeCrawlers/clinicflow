using ClinicFlow.Domain.Enums;

namespace ClinicFlow.API.Contracts.Patients;

public class CreatePatientRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }

    public string? Address { get; set; }
    public string? BloodType { get; set; }
}