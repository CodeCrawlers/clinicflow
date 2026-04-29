using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Features.Patients.Queries.GetPatients;
using ClinicFlow.Application.Common.Interfaces;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Queries.GetPatients;

public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, Result<IEnumerable<PatientDto>>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPatientsQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<PatientDto>>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var patients = await _dbContext.Patients.ToListAsync(cancellationToken);
            var patientsDto = _mapper.Map<IEnumerable<PatientDto>>(patients);
            return Result<IEnumerable<PatientDto>>.Success(patientsDto);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<PatientDto>>.Failure($"Error retrieving patients: {ex.Message}");
        }
    }
}
