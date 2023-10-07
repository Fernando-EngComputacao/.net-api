namespace DoctorAPI.Models.dto;

public class EvokeDoctor
{
    public string name { get; set; }
    public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    public string specialty { get; set; }
    public InputAddress address { get; set; }
}