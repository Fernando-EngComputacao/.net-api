using DoctorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAPI.Assets.data;

public class DoctorContext : DbContext
{
    public DoctorContext(DbContextOptions<DoctorContext> opts) : base(opts)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Appointment>()
            .HasKey(ap => new { ap.doctorId, ap.patientId });
        
        builder.Entity<Appointment>()
            .HasOne(appointment => appointment.doctor)
            .WithMany(doctor => doctor.appointments)
            .HasForeignKey(appointment => appointment.doctorId);
        
        builder.Entity<Appointment>()
            .HasOne(appointment => appointment.patient)
            .WithMany(patient => patient.appointments)
            .HasForeignKey(appointment => appointment.patientId);

        builder.Entity<Address>()
            .HasOne(address => address.doctorId)
            .WithOne(doctor => doctor.address)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<Address>()
            .HasOne(address => address.patientId)
            .WithOne(patient => patient.address)
            .OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}