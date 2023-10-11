namespace DoctorAPI.Models.dto;

public class ReadNameAppointment
{
    public ReadNameDoctor doctor { get; set; }
    public ReadNamePatient patient { get; set; }
    public DateTime date { get; set; }
}