using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private static List<Doctor> listDoctors = new List<Doctor>();
    private static long id;
    
    [HttpPost]
    public void addDoctor([FromBody] RegisterDoctor doctor)
    {
        
        listDoctors.Add(doctor.convert(id++, doctor));
    }

    [HttpGet]
    public IEnumerable<Doctor> recoverDoctor()
    {
        return listDoctors;
    }

    [HttpGet("{id}")]
    public Doctor? recoverDoctorById(long id)
    {
        return listDoctors.FirstOrDefault(doctor => doctor.id == id);
    }
}

