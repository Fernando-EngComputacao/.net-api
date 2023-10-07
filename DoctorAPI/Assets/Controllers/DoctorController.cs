using System.Data.Entity;
using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private DoctorContext _context;
    private IMapper _mapper;

    public DoctorController(DoctorContext context, IMapper imapper)
    {
        _context = context;
        _mapper = imapper;
    }
    
    [HttpPost]
    public IActionResult registerDoctor([FromBody] CreateDoctorDTO dto)
    {
        Doctor doctor = _mapper.Map<Doctor>(dto);
        doctor.active = 1 ;
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverDoctorById), new { id = doctor.id }, doctor);
    }

    [HttpGet]
    public IEnumerable<UpdateDoctorDTO> recoverDoctor([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var doctors = _context.Doctors.Skip(skip).Take(take);
        var result = doctors.Select(doctor => _mapper.Map<UpdateDoctorDTO>(doctor));
        return result.ToList();

    }

    [HttpGet("/Doctor/State")]
    public IActionResult recoverDoctorActive()
    {
        var activeDoctors =  _context.Doctors.Where(d => d.active == 1);
        var result = activeDoctors.Select(d => _mapper.Map<UpdateDoctorDTO>(d));
        return (result != null ? Ok(result) : NotFound());
    }

    [HttpGet("{id}")]
    public IActionResult recoverDoctorById(long id)
    {
        var result = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        return (result != null ? Ok(result) : NotFound());
    }

    [HttpPut("{id}")]
    public IActionResult updateDoctor(int id, [FromQuery] UpdateDoctorDTO dto)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        if (doctor == null) return NotFound();
        _mapper.Map(dto, doctor);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult updatePatchDoctor(int id, JsonPatchDocument<UpdateDoctorDTO> patch)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(dct => dct.id == id);
        if (doctor == null) return NotFound();
        
        var toUpdateDoctor = _mapper.Map<UpdateDoctorDTO>(doctor);
        patch.ApplyTo(toUpdateDoctor, ModelState);
        if (!TryValidateModel(toUpdateDoctor)) return ValidationProblem(ModelState);
    
        _mapper.Map(toUpdateDoctor, doctor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult removeDoctor(int id)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(dct => dct.id == id);
        if (doctor == null) return NotFound();
        _context.Remove(doctor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("/Doctor/State/{id}")]
    public IActionResult removeLogical(int id)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(dct => dct.id == id);
        if (doctor == null) return NotFound();
        doctor.active = 0;
        _context.SaveChanges();
        return NoContent();
    }
}