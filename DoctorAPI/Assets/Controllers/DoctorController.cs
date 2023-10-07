﻿using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
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
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverDoctorById), new { id = doctor.id }, doctor);
    }

    [HttpGet]
    public IEnumerable<Doctor> recoverDoctor([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Doctors.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult recoverDoctorById(long id)
    {
        var result = _context.Doctors.FirstOrDefault(doctor => doctor.id == id);
        return (result != null ? Ok(result) : NotFound());
    }
}