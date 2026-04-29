using AutoMapper;
using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Features.Patients.Commands.CreatePatient;
using ClinicFlow.Application.Common.Interfaces;
using ClinicFlow.Application.Common.Models;
using ClinicFlow.Domain.Entities;

namespace ClinicFlow.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientDto>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreatePatientCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<PatientDto>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = Patient.Create(
                request.PatientDto.UserId,
                request.PatientDto.Phone,
                request.PatientDto.DateOfBirth,
                request.PatientDto.Gender,
                request.PatientDto.Address,
                request.PatientDto.BloodType
            );

            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var patientDto = _mapper.Map<PatientDto>(patient);
            return Result<PatientDto>.Success(patientDto);
        }
        catch (Exception ex)
        {
            return Result<PatientDto>.Failure($"Error creating patient: {ex.Message}");
        }
    }
}
