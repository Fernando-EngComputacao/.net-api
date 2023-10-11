using AutoMapper;
using DoctorAPI.Assets.profiles;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> createUser(CreateUser dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult? result = await _userManager.CreateAsync(user, dto.password);

        if (result.Succeeded) return Ok("Created User");

        throw new ApplicationException("Faild to create a user!");
    }
}