namespace ClinicFlow.API.Contracts.Patients;

public class UpdatePatientRequest
{
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
}