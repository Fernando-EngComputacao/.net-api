using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class CreateDoctorDTO
{
    public string name { get; set; }
    [Required]
    [MaxLength(7)][MinLength(4)]
    public string crm { get; set; }
    public string email { get; set; }
    [Required]
    public string specialty { get; set; }
    public string telephone { get; set; }
    public Address address { get; set; }
}