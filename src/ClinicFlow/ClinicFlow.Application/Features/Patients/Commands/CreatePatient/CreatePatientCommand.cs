using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommand : IRequest<Result<PatientDto>>
{
    public CreatePatientDto PatientDto { get; set; }

    public CreatePatientCommand(CreatePatientDto patientDto)
    {
        PatientDto = patientDto;
    }
}
