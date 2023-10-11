namespace DoctorAPI.Models.dto;

public class UpdateAppointment
{
    public int? doctorId { get; set; }
    public int? patientId { get; set; }
    public DateTime date { get; set; }
}