using System.Data.Entity;
using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.service;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    public UserDBContext _context;
    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, UserDBContext context)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
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

    public async Task<IActionResult> getAllUsers([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var users = _context.UsersDB.Skip(skip).Take(take).ToList();
        var result = users.Select(user => _mapper.Map<ReadUser>(user));
        return new OkObjectResult(result);
    }
    
    public async Task<IActionResult> getUserByCPF([FromQuery] ReadCpfUser cpfRequest)
    {
        var user = _context.UsersDB.FirstOrDefault(user => user.cpf == cpfRequest.cpf);
        var result = _mapper.Map<ReadUser>(user);
        return new OkObjectResult(result);
    }

    
}