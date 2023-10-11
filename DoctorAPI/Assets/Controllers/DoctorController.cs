using System.Xml.Serialization;
using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.core;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    
    /// <summary> Adiciona um médico ao banco de dados </summary>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult registerDoctor([FromBody] CreateDoctorDTO dto)
    {
        Doctor doctor = _mapper.Map<Doctor>(dto);
        doctor.active = 1;
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverDoctorById), new { id = doctor.id }, doctor);
    }
    
    /// <summary> Busca a lista inteira de médicos </summary>
    [HttpGet]
    public IEnumerable<Object> recoverDoctor([FromQuery] int skip = 0, [FromQuery] int take = 10, int? addressIdURL = null)
    {
        Console.WriteLine("**ID"+addressIdURL);
        if (addressIdURL == null) return _mapper.Map<List<ReadDoctor>>(_context.Doctors.Skip(skip).Take(take).ToList());
        
        // Exemplo de como fazer busca ao DB por SQL
        return _mapper.Map<List<ReadSpecialtyDoctor>>(_context.Doctors
            .FromSqlRaw($"SELECT id, name, crm, email, telephone, specialty,addressId,active FROM doctors WHERE doctors.addressId = {addressIdURL}").ToList());
    }

    /// <summary> Busca a lista inteira de médicos ativos  </summary>
    [HttpGet("/Doctor/State")]
    public IActionResult recoverDoctorActive()
    {
        var activeDoctors =  _context.Doctors.Where(d => d.active == 1);
        var result =  _mapper.Map<List<ReadDoctor>>(activeDoctors.ToList());
        return (result != null ? Ok(result) : NotFound());
    }

    /// <summary> Busca um médico por um {id} </summary>
    [HttpGet("{id}")]
    public IActionResult recoverDoctorById(long id)
    {
        var result = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        return (result != null ? Ok(_mapper.Map<ReadDoctor>(result)) : NotFound());
    }   

    /// <summary> Atualiza dados do médico por um {id} </summary>
    [HttpPut("{id}")]
    public IActionResult updateDoctor(int id, [FromQuery] UpdateDoctorDTO dto)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        if (doctor == null) return NotFound();
        _mapper.Map(dto, doctor);
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza o estado para ativo do médico por um {id} </summary>
    [HttpPut("/Doctor/State/{id}")]
    public IActionResult updateActiveDoctor(int id)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        if (doctor == null) return NotFound();
        doctor.active = 1;
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza dados do médico por um {id} </summary>
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

    /// <summary> Deleta definitivamente o médico do {id} escolhido </summary>
    [HttpDelete("{id}")]
    public IActionResult removeDoctor(int id)
    {
        Doctor doctor = _context.Doctors.FirstOrDefault(dct => dct.id == id);
        if (doctor == null) return NotFound();
        _context.Remove(doctor);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Inativa o médico do {id} escolhido (deleção lógica) </summary>
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