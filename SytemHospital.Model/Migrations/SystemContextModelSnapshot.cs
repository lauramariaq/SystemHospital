﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SytemHospital.Model.SystemContex;

namespace SytemHospital.Model.Migrations
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SytemHospital.Model.Entities.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId");

                    b.Property<string>("DoctorName");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTimeOffset>("OpendDate");

                    b.Property<int>("PatientId");

                    b.Property<string>("PatientName");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exequator");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("IncomeDate");

                    b.Property<int>("PatientId");

                    b.Property<string>("PatientName");

                    b.Property<int>("RoomId");

                    b.Property<string>("TypeRoom");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula");

                    b.Property<bool>("Insurance");

                    b.Property<string>("InsuranceName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Number");

                    b.Property<int>("Price");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Date", b =>
                {
                    b.HasOne("SytemHospital.Model.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SytemHospital.Model.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SytemHospital.Model.Entities.Income", b =>
                {
                    b.HasOne("SytemHospital.Model.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SytemHospital.Model.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
