namespace DoctorAPI.Models.dto;

public class ReadPatient
{
    public string name { get; set; }
    public string birth { get; set; }
    public string telephone { get; set; }
    public string email { get; set; }
    public ReadPatient address { get; set; }
}