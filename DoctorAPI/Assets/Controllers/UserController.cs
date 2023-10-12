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
    
    /// <summary> Adiciona um usuário ao banco de dados </summary>
    [HttpPost]
    public async Task<IActionResult> createUser(CreateUser dto)
    {
        return Ok(await _service.createUser(dto));
    }


    /// <summary> Busca o usuário pelo CPF </summary>
    [HttpPost("/User/cpf")]
    public Task<IActionResult> getAllUsers([FromBody] ReadCpfUser cpf)
    {
        return _service.getUserByCPF(cpf);
    }

    
    /// <summary> Busca todos os usuários cadastrados no banco de dados </summary>
    [HttpGet]
    public Task<IActionResult> getAllUsers([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _service.getAllUsers(skip, take);
    }
}