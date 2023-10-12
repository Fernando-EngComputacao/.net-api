using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.service;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public async Task createUser(CreateUser dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult? result = await _userManager.CreateAsync(user, dto.password);

        if (!result.Succeeded) throw new ApplicationException("Faild to create a user!");

    }
}