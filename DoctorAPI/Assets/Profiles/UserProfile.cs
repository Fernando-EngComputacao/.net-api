using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUser, User>();
    }
}