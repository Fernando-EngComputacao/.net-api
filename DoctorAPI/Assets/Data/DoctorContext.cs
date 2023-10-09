using DoctorAPI.Assets.Models.appointment;
using DoctorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAPI.Assets.data;

public class DoctorContext : DbContext
{
    public DoctorContext(DbContextOptions<DoctorContext> opts) : base(opts)
    {
        
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}