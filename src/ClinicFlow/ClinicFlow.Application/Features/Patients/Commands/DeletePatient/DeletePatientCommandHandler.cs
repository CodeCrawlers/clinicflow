using MediatR;
using ClinicFlow.Application.Features.Patients.Commands.DeletePatient;
using ClinicFlow.Application.Common.Interfaces;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result>
{
    private readonly IAppDbContext _dbContext;

    public DeletePatientCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = await _dbContext.Patients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (patient == null)
            {
                return Result.Failure("Patient not found");
            }

            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error deleting patient: {ex.Message}");
        }
    }
}
