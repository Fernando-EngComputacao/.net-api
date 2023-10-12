using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Assets.Security.Authorization;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.Controllers;

[ApiController]
[Route("[controller]")]
[RequireAuthentication]
[Authorize(Policy = "standard")]
public class AppointmentController : ControllerBase
{
    private DoctorContext _context;
    private IMapper _mapper;

    public AppointmentController(DoctorContext context, IMapper imapper)
    {
        _context = context;
        _mapper = imapper;
    }
    
    /// <summary> Adiciona uma consulta ao banco de dados </summary>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult registerAppointment([FromBody] CreateAppointment dto)
    {
        Appointment appointment = _mapper.Map<Appointment>(dto);
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverAppointmentById), new { id = appointment.id }, appointment);
    }
    
    /// <summary> Busca a lista inteira da consultas com dados do médico e paciente resumidos</summary>
    [HttpGet]
    public IEnumerable<ReadNameAppointment> recoverAppointment([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadNameAppointment>>(_context.Appointments.Skip(skip).Take(take).ToList());

    }
    
    /// <summary> Busca a lista inteira da consultas com todos os dados do médico e paciente </summary>
    [HttpGet("/Appointment/all")]
    public IEnumerable<ReadAppointment> recoverAppointmentAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadAppointment>>(_context.Appointments.Skip(skip).Take(take).ToList());

    }
    
    
    /// <summary> Busca uma consulta por um {id} </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult recoverAppointmentById(long id)
    {
        var result = _context.Appointments.FirstOrDefault(appointment => appointment.id == id);
        return (result != null ? Ok(_mapper.Map<ReadAppointment>(result)) : NotFound());
    }   

    /// <summary> Atualiza dados da consulta por um {id} </summary>
    [HttpPut("{id}")]
    public IActionResult updateAppointment(int id, [FromQuery] UpdateAppointment dto)
    {
        Appointment appointment = _context.Appointments.FirstOrDefault(appointment => appointment.id == id);
        if (appointment == null) return NotFound();
        _mapper.Map(dto, appointment);
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza o estado para ativo da consulta por um {id} </summary>
    [HttpPut("/Appointment/State/{id}")]
    public IActionResult updateActiveAppointment(int id)
    {
        Appointment appointment = _context.Appointments.FirstOrDefault(appointment => appointment.id == id);
        if (appointment == null) return NotFound();
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza dados da consulta por um {id} </summary>
    [HttpPatch("{id}")]
    public IActionResult updatePatchAppointment(int id, JsonPatchDocument<UpdateAppointment> patch)
    {
        Appointment appointment = _context.Appointments.FirstOrDefault(dct => dct.id == id);
        if (appointment == null) return NotFound();
        
        var toUpdateAppointment = _mapper.Map<UpdateAppointment>(appointment);
        patch.ApplyTo(toUpdateAppointment, ModelState);
        if (!TryValidateModel(toUpdateAppointment)) return ValidationProblem(ModelState);
    
        _mapper.Map(toUpdateAppointment, appointment);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Deleta definitivamente a consulta do {id} escolhido </summary>
    [HttpDelete("{id}")]
    public IActionResult removeAppointment(int id)
    {
        Appointment appointment = _context.Appointments.FirstOrDefault(dct => dct.id == id);
        if (appointment == null) return NotFound();
        _context.Remove(appointment);
        _context.SaveChanges();
        return NoContent();
    }
    
}