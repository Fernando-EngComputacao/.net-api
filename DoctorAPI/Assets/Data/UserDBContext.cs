using DoctorAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorAPI.Assets.data;

public class UserDBContext : IdentityDbContext<User>
{
    public UserDBContext(DbContextOptions<UserDBContext> ops) : base(ops)
    {
        
    }
}