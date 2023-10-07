using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class RegisterDoctor
{
    [Required(ErrorMessage = "The name is mandatory.")]
    public string name { get; set; }
    [Required]
    [MaxLength(7)][MinLength(4)]
    public string crm { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    [Required]
    public string specialty { get; set; }
    // [Required]
    // public InputAddress address { get; set; }
    

    public Doctor convertToDoctor(int idDoctor, int idAddress, RegisterDoctor doctor)
    {
        return new Doctor(idDoctor, doctor.name, doctor.specialty, doctor.crm, doctor.email,
            doctor.telephone); //,convertToAddress(idAddress, doctor.address));
    }

    public Address convertToAddress(int id, InputAddress ad)
    {
        return new Address(id, ad.place, ad.neighborhood, ad.cep, ad.city, ad.uf, ad.complement, ad.number);
    }
}