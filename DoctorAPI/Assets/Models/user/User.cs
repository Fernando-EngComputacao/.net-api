using Microsoft.AspNetCore.Identity;

namespace DoctorAPI.Models;

public class User : IdentityUser
{
    public DateTime birth { get; set; }
    public DateTime cpf { get; set; }

    public User(): base()
    {
        
    }
}