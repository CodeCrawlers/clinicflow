using ClinicFlow.Domain.Common;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Exceptions;

namespace ClinicFlow.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime ScheduledAt { get; private set; }
    public int DurationMinutes { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public string? Notes { get; private set; }

    public Patient Patient { get; private set; } = null!;
    public Doctor Doctor { get; private set; } = null!;
    public MedicalRecord? MedicalRecord { get; private set; }

    private Appointment() { }

    public static Appointment Create(
        Guid patientId,
        Guid doctorId,
        DateTime scheduledAt,
        string reason,
        int durationMinutes = 30)
    {
        if (scheduledAt < DateTime.UtcNow)
            throw new DomainException("No se puede agendar una cita en el pasado.");

        return new Appointment
        {
            PatientId = patientId,
            DoctorId = doctorId,
            ScheduledAt = scheduledAt,
            Reason = reason,
            DurationMinutes = durationMinutes,
            Status = AppointmentStatus.Scheduled
        };
    }

    public void Confirm()
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new DomainException("Solo se puede confirmar una cita en estado Scheduled.");

        Status = AppointmentStatus.Confirmed;
        SetUpdatedAt();
    }

    public void Complete(string notes)
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new DomainException("Solo se puede completar una cita confirmada.");

        Status = AppointmentStatus.Completed;
        Notes = notes;
        SetUpdatedAt();
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new DomainException("No se puede cancelar una cita completada.");

        Status = AppointmentStatus.Cancelled;
        SetUpdatedAt();
    }

    public DateTime EndsAt => ScheduledAt.AddMinutes(DurationMinutes);
}