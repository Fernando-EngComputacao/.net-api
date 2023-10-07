using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;

public class Doctor
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required(ErrorMessage = "The name is mandatory.")]
    public string name { get; set; }
    [Required]
    [MaxLength(7)][MinLength(4)]
    public string crm { get; set; }
    public string email { get; set; }
    [Required]
    public string specialty { get; set; }
    public string telephone { get; set; }
    [Required]
    public int active { get; set; }
    
    // [Required]
    // public Address address { get; set; }
    
    public Doctor(){}
}