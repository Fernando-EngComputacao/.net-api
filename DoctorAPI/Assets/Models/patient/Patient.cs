using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;

public class Patient
{
    [Key]
    [Required]
    public int id { get; set; }
    public string name { get; set; }
    public string birth { get; set; }
    public string telephone { get; set; }
    public string email { get; set; }
    public int active { get; set; }
    public int addressId { get; set; }
    public virtual Address address { get; set; }
}