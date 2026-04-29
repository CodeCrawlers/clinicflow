using AutoMapper;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Domain.Entities;

namespace ClinicFlow.Application.Features.Patients.Mapping;

public class PatientMappingProfile : Profile
{
    public PatientMappingProfile()
    {
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<CreatePatientDto, Patient>();
        CreateMap<UpdatePatientDto, Patient>();
    }
}
