namespace DoctorAPI.Models.dto;

public class ReadAppointment
{
    public ReadDoctor doctor { get; set; }
    public ReadPatient patient { get; set; }
    public DateTime date { get; set; }
}