using ClinicProject.Models; 
using Microsoft.EntityFrameworkCore;

namespace ClinicProject.Data
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Patient)
                .WithMany()
                .HasForeignKey(v => v.PatientId);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Doctor)
                .WithMany()
                .HasForeignKey(v => v.DoctorId);
        }
    }
}