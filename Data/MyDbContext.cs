using Microsoft.EntityFrameworkCore;
using MyApi.Users;
using MyApi.Caris;

namespace MyApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cari> Caris { get; set; }
    }
}
