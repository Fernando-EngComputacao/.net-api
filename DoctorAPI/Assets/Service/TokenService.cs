using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoctorAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAPI.Assets.service;

public class TokenService
{
    public string generateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5DFA4F56ASDFA6SF54A6SD5F4")); //Valor digitado aleatoriamente 
        Claim[] claimsCreated = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.birth.ToString()),
            new Claim("cpf", user.cpf),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };
        var signingCredentialsCreated = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(2),
            claims: claimsCreated,
            signingCredentials: signingCredentialsCreated
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}