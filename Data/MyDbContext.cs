using Microsoft.EntityFrameworkCore;
using MyApi.Users;
using MyApi.Caris;
using MyApi.Finances;

namespace MyApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Finance> Finances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Finance>()
                .Property(f => f.miktar)
                .HasColumnType("decimal(18, 8)");



            modelBuilder.Entity<Finance>()
              .HasOne(f => f.Cari)
              .WithMany()
              .HasForeignKey(f => f.cari_id)
              .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Cari>()
                .Property(c => c.borc )
                .HasColumnType("decimal(18, 8)");

            modelBuilder.Entity<Cari>()
                .Property(c => c.alacak)
                .HasColumnType("decimal(18, 8)");

        }

   
    }
}