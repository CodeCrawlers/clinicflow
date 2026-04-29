using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Queries.GetPatients;

public class GetPatientsQuery : IRequest<Result<IEnumerable<PatientDto>>>
{
}
