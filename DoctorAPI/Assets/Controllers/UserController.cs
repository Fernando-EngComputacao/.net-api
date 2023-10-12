using AutoMapper;
using DoctorAPI.Assets.profiles;
using DoctorAPI.Assets.service;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> createUser(CreateUser dto)
    {
        return Ok(await _service.createUser(dto));
    }
    
}