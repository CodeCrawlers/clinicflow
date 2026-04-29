using AutoMapper;
using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Features.Patients.Queries.GetPatientById;
using ClinicFlow.Application.Common.Interfaces;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Queries.GetPatientById;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<PatientDto>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<PatientDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = await _dbContext.Patients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (patient == null)
            {
                return Result<PatientDto>.Failure("Patient not found");
            }

            var patientDto = _mapper.Map<PatientDto>(patient);
            return Result<PatientDto>.Success(patientDto);
        }
        catch (Exception ex)
        {
            return Result<PatientDto>.Failure($"Error retrieving patient: {ex.Message}");
        }
    }
}
