using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommand : IRequest<Result<PatientDto>>
{
    public Guid Id { get; set; }
    public UpdatePatientDto PatientDto { get; set; }

    public UpdatePatientCommand(Guid id, UpdatePatientDto patientDto)
    {
        Id = id;
        PatientDto = patientDto;
    }
}
