﻿// <auto-generated />
using DoctorAPI.Assets.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorAPI.Migrations
{
    [DbContext(typeof(DoctorContext))]
    partial class DoctorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorAPI.Assets.Models.patient.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<string>("birth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("addressId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorAPI.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("complement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DoctorAPI.Models.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<string>("crm")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("specialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("addressId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorAPI.Assets.Models.patient.Patient", b =>
                {
                    b.HasOne("DoctorAPI.Models.Address", "address")
                        .WithOne("patientId")
                        .HasForeignKey("DoctorAPI.Assets.Models.patient.Patient", "addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");
                });

            modelBuilder.Entity("DoctorAPI.Models.Doctor", b =>
                {
                    b.HasOne("DoctorAPI.Models.Address", "address")
                        .WithOne("doctorId")
                        .HasForeignKey("DoctorAPI.Models.Doctor", "addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");
                });

            modelBuilder.Entity("DoctorAPI.Models.Address", b =>
                {
                    b.Navigation("doctorId")
                        .IsRequired();

                    b.Navigation("patientId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}