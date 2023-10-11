using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class CreateUser
{
    [Required] 
    public string username { get; set; }
    
    [Required] 
    public DateTime birth { get; set; }
    
    [Required] 
    [DataType(DataType.Password)]
    public string password { get; set; }
    
    [Required]
    [Compare("password")]
    public string rePassword { get; set; }
}