using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SytemHospital.Model.Entities;

namespace SytemHospital.Model.SystemContex
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Date> Dates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
