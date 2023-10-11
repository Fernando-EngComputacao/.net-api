using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;
public class Appointment
{
    [Key]
    [Required]
    public int id { get; set; }
    public int? doctorId { get; set; }
    public virtual Doctor doctor { get; set; }
    public int? patientId { get; set; }
    public virtual Patient patient { get; set; }
    public DateTime date { get; set; }
    
}