using System.ComponentModel.DataAnnotations;
using DoctorAPI.Models;

namespace DoctorAPI.Assets.Models.appointment;

public class Appointment
{
    [Key]
    [Required]
    public int id { get; set; }
    public int? doctorId { get; set; }
    public virtual Doctor doctor { get; set; }
    public int? patientId { get; set; }
    public Patient patient { get; set; }
    public DateTime date { get; set; }
    
}