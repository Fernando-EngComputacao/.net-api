using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private static List<RegisterDoctor> listDoctors = new List<RegisterDoctor>();
    
    [HttpPost]
    public void addDoctor([FromBody] RegisterDoctor doctor)
    {
        listDoctors.Add(doctor);
        Console.WriteLine(doctor.name);
    }
    
}

