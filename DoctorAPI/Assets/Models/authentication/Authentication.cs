using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;

public class Authentication
{
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
}