namespace DoctorAPI.Models.dto;

public class ReadAddress
{
    public int id { get; set; }
    public string place { get; set; }
    public string neighborhood { get; set; }
    public string cep { get; set; }
    public string city { get; set; }
    public string uf { get; set; }
    public string complement { get; set; }
    public string number { get; set; }
}