namespace DoctorAPI.Models;

public class Doctor
{
    public long id { get; set; }
    public string name { get; set; }
    public string specialty { get; set; }
    public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    public Address address { get; set; }
    
}