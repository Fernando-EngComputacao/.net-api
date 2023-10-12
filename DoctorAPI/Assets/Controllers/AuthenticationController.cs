
using DoctorAPI.Assets.service;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController :  ControllerBase
{
    private UserService _service;

    public AuthenticationController(UserService service)
    {
        _service = service;
    }

    /// <summary> Autentica um usuário (login) </summary>
    [HttpPost]
    public async Task<IActionResult> login(Authentication auth)
    {
        return Ok(await _service.login(auth));
    }
}