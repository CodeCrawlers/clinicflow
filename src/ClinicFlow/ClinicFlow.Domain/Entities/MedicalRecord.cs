using ClinicFlow.Domain.Common;

namespace ClinicFlow.Domain.Entities;

public class MedicalRecord : BaseEntity
{
    public Guid AppointmentId { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public string Diagnosis { get; private set; } = string.Empty;
    public string? Prescription { get; private set; }
    public string? Notes { get; private set; }

    public Appointment Appointment { get; private set; } = null!;
    public Patient Patient { get; private set; } = null!;
    public Doctor Doctor { get; private set; } = null!;

    private MedicalRecord() { }

    public static MedicalRecord Create(
        Guid appointmentId,
        Guid patientId,
        Guid doctorId,
        string diagnosis,
        string? prescription = null,
        string? notes = null)
    {
        return new MedicalRecord
        {
            AppointmentId = appointmentId,
            PatientId = patientId,
            DoctorId = doctorId,
            Diagnosis = diagnosis,
            Prescription = prescription,
            Notes = notes
        };
    }
}