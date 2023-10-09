using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<CreatePatient, Patient>();
        CreateMap<Patient, UpdatePatient>();
        CreateMap<Patient, ReadPatient>()
            .ForMember(patientDTO => patientDTO.address , 
                opt => opt.MapFrom(patient => patient.address));
        CreateMap<UpdatePatient, Patient>();
    }
}