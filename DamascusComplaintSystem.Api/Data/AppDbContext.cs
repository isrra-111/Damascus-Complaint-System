using DamascusComplaintSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DamascusComplaintSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintType> ComplaintTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.ComplaintType)
                .WithMany()
                .HasForeignKey(c => c.ComplaintTypeId);



            modelBuilder.Entity<ComplaintType>().HasData(
        new ComplaintType { Id = 1, Name = "BuildingViolation", ArabicName = "مخالفة بناء" },
        new ComplaintType { Id = 2, Name = "UnlicensedProfession", ArabicName = "ممارسة مهنة بدون ترخيص" },
        new ComplaintType { Id = 3, Name = "Personal", ArabicName = "شخصية" },
        new ComplaintType { Id = 4, Name = "RealEstate", ArabicName = "عقارية" },
        new ComplaintType { Id = 5, Name = "PublicPropertyViolation", ArabicName = "التعدي على أملاك العامة" },
        new ComplaintType { Id = 6, Name = "SidewalkOccupation", ArabicName = "إشغال رصيف" }
    );
        }


    }
}
