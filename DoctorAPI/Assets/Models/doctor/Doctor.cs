using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models;

public class Doctor
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required(ErrorMessage = "The name is mandatory.")]
    public string name { get; set; }
    [Required]
    [MaxLength(7)][MinLength(4)]
    public string crm { get; set; }
    public string email { get; set; }
    [Required]
    public string specialty { get; set; }
    public string telephone { get; set; }
    // [Required]
    // public Address address { get; set; }


    public Doctor(int id, string name, string specialty, string crm, string email, string telephone)//, Address address)
    {
        this.id = id;
        this.name = name;
        this.specialty = specialty;
        this.crm = crm;
        this.email = email;
        this.telephone = telephone;
        // this.address = address;
    }
    public Doctor(){}
}