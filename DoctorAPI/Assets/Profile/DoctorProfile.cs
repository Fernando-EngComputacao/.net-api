using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<CreateDoctorDTO, Doctor>();
        CreateMap<UpdateDoctorDTO, Doctor>();
    }
}