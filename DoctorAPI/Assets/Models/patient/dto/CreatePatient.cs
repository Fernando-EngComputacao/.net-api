using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class CreatePatient
{
    [Required]
    public string name { get; set; }
    public string birth { get; set; }
    public string telephone { get; set; }
    public string email { get; set; }
    public int addressId { get; set; } 
    
}