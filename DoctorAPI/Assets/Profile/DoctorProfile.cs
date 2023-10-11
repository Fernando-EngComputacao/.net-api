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
        CreateMap<Doctor, ReadNameDoctor>();
        CreateMap<Doctor, ReadDoctor>()
            .ForMember(desc => desc.address, 
                opt=> opt.MapFrom(src => src.address));
        CreateMap<UpdateDoctorDTO, Doctor>();
    }
}