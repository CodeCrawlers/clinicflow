using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Queries.GetPatientById;

public class GetPatientByIdQuery : IRequest<Result<PatientDto>>
{
    public Guid Id { get; set; }

    public GetPatientByIdQuery(Guid id)
    {
        Id = id;
    }
}
