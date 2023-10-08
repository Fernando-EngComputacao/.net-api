namespace DoctorAPI.Models.dto;

public class ReadDoctor
{
    public string name { get; set; }
    public string crm { get; set; }
    public string email { get; set; }
    public string specialty { get; set; }
    public string telephone { get; set; }
    public ReadAddress address { get; set; }
}