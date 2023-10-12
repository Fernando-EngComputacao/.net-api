namespace DoctorAPI.Models;

public class TokenDTO
{
    public string token { get; set; }

    public TokenDTO(string token)
    {
        this.token = token;
    }
}