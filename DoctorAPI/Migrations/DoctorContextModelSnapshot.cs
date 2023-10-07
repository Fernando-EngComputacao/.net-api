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

            modelBuilder.Entity("DoctorAPI.Models.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
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

                    b.ToTable("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}