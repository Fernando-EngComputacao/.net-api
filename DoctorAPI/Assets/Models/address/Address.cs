using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;

public class Address
{
    // [Key]
    public int id { get; set; }
    public string place { get; set; }
    public string neighborhood { get; set; }
    public string cep { get; set; }
    public string city { get; set; }
    public string uf { get; set; }
    public string complement { get; set; }
    public string number { get; set; }

    public Address(int id, string place, string neighborhood, string cep, string city, string uf, string complement, string number)
    {
        this.id = id;
        this.place = place;
        this.neighborhood = neighborhood;
        this.cep = cep;
        this.city = city;
        this.uf = uf;
        this.complement = complement;
        this.number = number;
    }

    public Address(){}
}