using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<CreateDoctorDTO, Doctor>();
        CreateMap<Doctor, UpdateDoctorDTO>();
        CreateMap<Doctor, ReadDoctor>()
            .ForMember(doctorDto => doctorDto.address , 
                opt => opt.MapFrom(doctor => doctor.address));
        CreateMap<UpdateDoctorDTO, Doctor>();
    }
}