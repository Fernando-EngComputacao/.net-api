using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class RegisterDoctor
{
    [Required(ErrorMessage = "The name is mandatory.")]
    public string name { get; set; }

    [Required]
    [MaxLength(7)][MinLength(4)]

public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    [Required]
    public string specialty { get; set; }
    [Required]
    public Address address { get; set; }
}