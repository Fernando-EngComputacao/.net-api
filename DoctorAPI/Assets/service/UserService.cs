using AutoMapper;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Identity;

namespace DoctorAPI.Assets.service;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<string> createUser(CreateUser dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult? result = await _userManager.CreateAsync(user, dto.password);

        if (!result.Succeeded) throw new ApplicationException("Faild to create a user!");

        return "User created!";
    }

    public async Task<string> login(Authentication auth)
    {
        var result = await _signInManager.PasswordSignInAsync(auth.username, auth.password, false, false);
        if (!result.Succeeded) throw new ApplicationException("User not authenticated!");

        return "User authenticated!";
    }
}