using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Assets.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private DoctorContext _context;
    private IMapper _mapper;

    public PatientController(DoctorContext context, IMapper imapper)
    {
        _context = context;
        _mapper = imapper;
    }
    
    /// <summary> Adiciona um filme ao banco de dados </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult registerPatient([FromBody] CreatePatient dto)
    {
        Patient patient = _mapper.Map<Patient>(dto);
        patient.active = 1;
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverPatientById), new { id = patient.id }, patient);
    }
    
    /// <summary> Busca a lista inteira de pacientes </summary>
    [HttpGet]
    public IEnumerable<ReadPatient> recoverPatient([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadPatient>>(_context.Patients.Skip(skip).Take(take).ToList());

    }

    /// <summary> Busca a lista inteira de pacientes ativos  </summary>
    [HttpGet("/Patient/State")]
    public IActionResult recoverPatientActive()
    {
        var activePatients =  _context.Patients.Where(d => d.active == 1);
        var result =  _mapper.Map<List<ReadPatient>>(activePatients.ToList());
        return (result != null ? Ok(result) : NotFound());
    }

    /// <summary> Busca um paciente por um {id} </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult recoverPatientById(long id)
    {
        var result = _context.Patients.FirstOrDefault(patient => patient.id == id);
        return (result != null ? Ok(_mapper.Map<ReadPatient>(result)) : NotFound());
    }   

    /// <summary> Atualiza dados do paciente por um {id} </summary>
    [HttpPut("{id}")]
    public IActionResult updatePatient(int id, [FromQuery] UpdatePatient dto)
    {
        Patient patient = _context.Patients.FirstOrDefault(patient => patient.id == id);
        if (patient == null) return NotFound();
        _mapper.Map(dto, patient);
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza o estado para ativo do paciente por um {id} </summary>
    [HttpPut("/Patient/State/{id}")]
    public IActionResult updateActivePatient(int id)
    {
        Patient patient = _context.Patients.FirstOrDefault(patient => patient.id == id);
        if (patient == null) return NotFound();
        patient.active = 1;
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza dados do paciente por um {id} </summary>
    [HttpPatch("{id}")]
    public IActionResult updatePatchPatient(int id, JsonPatchDocument<UpdatePatient> patch)
    {
        Patient patient = _context.Patients.FirstOrDefault(dct => dct.id == id);
        if (patient == null) return NotFound();
        
        var toUpdatePatient = _mapper.Map<UpdatePatient>(patient);
        patch.ApplyTo(toUpdatePatient, ModelState);
        if (!TryValidateModel(toUpdatePatient)) return ValidationProblem(ModelState);
    
        _mapper.Map(toUpdatePatient, patient);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Deleta definitivamente o paciente do {id} escolhido </summary>
    [HttpDelete("{id}")]
    public IActionResult removePatient(int id)
    {
        Patient patient = _context.Patients.FirstOrDefault(dct => dct.id == id);
        if (patient == null) return NotFound();
        _context.Remove(patient);
        _context.SaveChanges();
        return NoContent();
    }

    // /// <summary> Inativa o paciente do {id} escolhido (deleção lógica) </summary>
    // [HttpDelete("/Patient/State/{id}")]
    // public IActionResult removeLogical(int id)
    // {
    //     Patient patient = _context.Patients.FirstOrDefault(dct => dct.id == id);
    //     if (patient == null) return NotFound();
    //     patient.active = 0;
    //     _context.SaveChanges();
    //     return NoContent();
    // }
}