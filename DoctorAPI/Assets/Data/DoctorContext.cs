using DoctorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAPI.Assets.data;

public class DoctorContext : DbContext
{
    public DoctorContext(DbContextOptions<DoctorContext> opts) : base(opts)
    {
        
    }
    
    public DbSet<Doctor> Doctors { get; set; }
}