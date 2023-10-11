﻿// <auto-generated />
using System;
using DoctorAPI.Assets.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorAPI.Migrations
{
    [DbContext(typeof(DoctorContext))]
    [Migration("20231011231632_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("DoctorAPI.Models.Appointment", b =>
                {
                    b.Property<int?>("doctorId")
                        .HasColumnType("int");

                    b.Property<int?>("patientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("doctorId", "patientId");

                    b.HasIndex("patientId");

                    b.ToTable("Appointments");
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

            modelBuilder.Entity("DoctorAPI.Models.Patient", b =>
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

                    b.Property<string>("cpf")
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

            modelBuilder.Entity("DoctorAPI.Models.Appointment", b =>
                {
                    b.HasOne("DoctorAPI.Models.Doctor", "doctor")
                        .WithMany("appointments")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorAPI.Models.Patient", "patient")
                        .WithMany("appointments")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("DoctorAPI.Models.Doctor", b =>
                {
                    b.HasOne("DoctorAPI.Models.Address", "address")
                        .WithOne("doctorId")
                        .HasForeignKey("DoctorAPI.Models.Doctor", "addressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("address");
                });

            modelBuilder.Entity("DoctorAPI.Models.Patient", b =>
                {
                    b.HasOne("DoctorAPI.Models.Address", "address")
                        .WithOne("patientId")
                        .HasForeignKey("DoctorAPI.Models.Patient", "addressId")
                        .OnDelete(DeleteBehavior.Restrict)
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

            modelBuilder.Entity("DoctorAPI.Models.Doctor", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("DoctorAPI.Models.Patient", b =>
                {
                    b.Navigation("appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
