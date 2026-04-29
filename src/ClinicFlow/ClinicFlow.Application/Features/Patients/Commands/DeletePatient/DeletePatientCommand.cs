using MediatR;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public DeletePatientCommand(Guid id)
    {
        Id = id;
    }
}
