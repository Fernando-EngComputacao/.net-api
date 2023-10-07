using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private static List<Doctor> listDoctors = new List<Doctor>();
    private static int idDoctor;
    private static int idAddress;
        
    [HttpPost]
    public IActionResult registerDoctor([FromBody] RegisterDoctor doctor)
    {
        var item = doctor.convertToDoctor(idDoctor++, idAddress++, doctor);
        listDoctors.Add(item);
        return CreatedAtAction(nameof(recoverDoctorById), new { id = item.id }, item);
    }

    [HttpGet]
    public IEnumerable<Doctor> recoverDoctor([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return listDoctors.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult recoverDoctorById(long id)
    {
        var result = listDoctors.FirstOrDefault(doctor => doctor.id == id);
        return (result != null ? Ok(result) : NotFound());
    }
}

