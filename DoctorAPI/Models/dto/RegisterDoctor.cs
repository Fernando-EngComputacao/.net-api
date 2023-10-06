namespace DoctorAPI.Models.dto;

public class RegisterDoctor
{
    public string name { get; set; }
    public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    public string specialty { get; set; }
    public Address address { get; set; }
}