namespace DoctorAPI.Models.dto;

public class ReadSpecialtyDoctor
{
    public int id { get; set; }
    public string name { get; set; }
    public string specialty { get; set; }
    public int addressId { get; set; }
    public string active { get; set; }
}