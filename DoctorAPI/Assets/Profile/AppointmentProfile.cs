using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<CreateAppointment, Appointment>();
        CreateMap<Appointment, UpdateAppointment>();
        CreateMap<Appointment, ReadAppointment>()
            .ForMember(dest => dest.doctor, opt => opt.MapFrom(src => src.doctor))
            .ForMember(dest => dest.patient, opt => opt.MapFrom(src => src.patient));
        CreateMap<Appointment, ReadNameAppointment>()
            .ForMember(dest => dest.doctor, opt => opt.MapFrom(src => src.doctor))
            .ForMember(dest => dest.patient, opt => opt.MapFrom(src => src.patient));
        CreateMap<UpdateAppointment, Appointment>();
    }
}