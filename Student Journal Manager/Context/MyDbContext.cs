using Microsoft.EntityFrameworkCore;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<InvoiceData> InvoiceData { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public MyDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guardian>()
                .HasOne(g => g.InvoiceData)
                .WithOne(i => i.Guardian)
                .HasForeignKey<InvoiceData>(i => i.GuardianId);

            modelBuilder.Entity<Attendance>()
                .Property(a => a.SerializedHours)
                .HasColumnName("SerializedHours")
                .HasColumnType("nvarchar(max)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.; Database = StudentJournalManager; trusted_connection = true; TrustServerCertificate = true; ");
            }
        }

    }
}
