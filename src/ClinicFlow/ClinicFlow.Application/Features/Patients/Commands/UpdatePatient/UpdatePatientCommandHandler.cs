using AutoMapper;
using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Features.Patients.Commands.UpdatePatient;
using ClinicFlow.Application.Common.Interfaces;
using ClinicFlow.Application.Common.Models;

namespace ClinicFlow.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Result<PatientDto>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdatePatientCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<PatientDto>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = await _dbContext.Patients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (patient == null)
            {
                return Result<PatientDto>.Failure("Patient not found");
            }

            patient.Update(
                request.PatientDto.Phone,
                request.PatientDto.Address,
                request.PatientDto.EmergencyContactName,
                request.PatientDto.EmergencyContactPhone
            );

            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var patientDto = _mapper.Map<PatientDto>(patient);
            return Result<PatientDto>.Success(patientDto);
        }
        catch (Exception ex)
        {
            return Result<PatientDto>.Failure($"Error updating patient: {ex.Message}");
        }
    }
}
