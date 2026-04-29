namespace ClinicFlow.Application.Features.Patients.Dtos;

public class UpdatePatientDto
{
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
}
