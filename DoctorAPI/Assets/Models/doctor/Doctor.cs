using DoctorAPI.Models.dto;

namespace DoctorAPI.Models;

public class Doctor
{
    public int id { get; set; }
    public string name { get; set; }
    public string specialty { get; set; }
    public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    public Address address { get; set; }


    public Doctor(int id, string name, string specialty, string crm, string email, string telephone, Address address)
    {
        this.id = id;
        this.name = name;
        this.specialty = specialty;
        this.crm = crm;
        this.email = email;
        this.telephone = telephone;
        this.address = address;
    }
}