using AutoMapper;
using DoctorAPI.Assets.data;
using DoctorAPI.Assets.Security.Authorization;
using DoctorAPI.Models;
using DoctorAPI.Models.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AddressAPI.Controllers;

[ApiController]
[Route("[controller]")]
[RequireAuthentication]
[Authorize(Policy = "standard")]
public class AddressController : ControllerBase
{
    private DoctorContext _context;
    private IMapper _mapper;
    
    
    public AddressController(DoctorContext context, IMapper imapper)
    {
        _context = context;
        _mapper = imapper;
    }
    
    /// <summary> Adiciona um endereço ao banco de dados </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult registerAddress([FromBody] CreateAddress dto)
    {
        Address address = _mapper.Map<Address>(dto);
        address.active = 1 ;
        _context.Address.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(recoverAddressById), new { id = address.id }, address);
    }
    
    /// <summary> Busca a lista inteira de endereços </summary>
    [HttpGet]
    public IEnumerable<UpdateAddress> recoverAddress([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var address = _context.Address.Skip(skip).Take(take);
        var result = address.Select(address => _mapper.Map<UpdateAddress>(address));
        return result.ToList();

    }

    /// <summary> Busca a lista inteira de endereços ativos   </summary>
    [HttpGet("/Address/State")]
    public IActionResult recoverAddressActive()
    {
        var activeAddress =  _context.Address.Where(d => d.active == 1);
        var result = activeAddress.Select(d => _mapper.Map<UpdateAddress>(d));
        return (result != null ? Ok(result) : NotFound());
    }

    /// <summary> Busca um endereço por um {id} </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult recoverAddressById(long id)
    {
        var result = _context.Address.FirstOrDefault(address => address.id == id);
        return (result != null ? Ok(_mapper.Map<ReadAddress>(result)) : NotFound());
    }   

    /// <summary> Atualiza dados do endereço por um {id} </summary>
    [HttpPut("{id}")]
    public IActionResult updateAddress(int id, [FromQuery] UpdateAddress dto)
    {
        Address address = _context.Address.FirstOrDefault(address => address.id == id);
        if (address == null) return NotFound();
        _mapper.Map(dto, address);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Atualiza para ativo o estado do endereço por um {id} </summary>
    [HttpPut("/Address/State/{id}")]
    public IActionResult updateToActiveAddress(int id)
    {
        var address = _context.Address.FirstOrDefault(doctors => doctors.id == id);
        if (address == null) return NotFound();
        address.active = 1;
        _context.SaveChanges();
        return NoContent();
    }
    
    /// <summary> Atualiza dados do endereço por um {id} </summary>
    [HttpPatch("{id}")]
    public IActionResult updatePatchAddress(int id, JsonPatchDocument<UpdateAddress> patch)
    {
        Address address = _context.Address.FirstOrDefault(dct => dct.id == id);
        if (address == null) return NotFound();
        
        var toUpdateAddress = _mapper.Map<UpdateAddress>(address);
        patch.ApplyTo(toUpdateAddress, ModelState);
        if (!TryValidateModel(toUpdateAddress)) return ValidationProblem(ModelState);
    
        _mapper.Map(toUpdateAddress, address);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Deleta definitivamente o endereço do {id} escolhido </summary>
    [HttpDelete("{id}")]
    public IActionResult removeAddress(int id)
    {
        Address address = _context.Address.FirstOrDefault(dct => dct.id == id);
        if (address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary> Inativa o endereço do {id} escolhido (deleção lógica) </summary>
    [HttpDelete("/Address/State/{id}")]
    public IActionResult removeLogical(int id)
    {
        Address address = _context.Address.FirstOrDefault(dct => dct.id == id);
        if (address == null) return NotFound();
        address.active = 0;
        _context.SaveChanges();
        return NoContent();
    }
    
}