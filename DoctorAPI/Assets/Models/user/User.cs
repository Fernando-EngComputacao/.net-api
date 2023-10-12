using Microsoft.AspNetCore.Identity;

namespace DoctorAPI.Models;

public class User : IdentityUser
{
    public DateTime birth { get; set; }
    public string cpf { get; set; }

    public User(): base()
    {
        
    }
}