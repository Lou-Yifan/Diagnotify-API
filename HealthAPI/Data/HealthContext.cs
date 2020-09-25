using System;
using HealthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Data
{
    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<ObservedItem> ObservedItems { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BodyHeat> BodyHeats { get; set; }
        public DbSet<BloodPressure> BloodPressures { get; set; }
        public DbSet<SinusRhythm> SinusRhythms { get; set; }
        public DbSet<RespiratoryRate> RespiratoryRates { get; set; }
    }
}
