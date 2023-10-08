using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;

namespace DoctorAPI.Assets.profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddress, Address>();
        CreateMap<Address, ReadAddress>();
        CreateMap<UpdateAddress, Address>();
    }
}