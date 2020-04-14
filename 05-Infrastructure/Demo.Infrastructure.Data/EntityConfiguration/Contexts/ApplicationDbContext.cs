using Microsoft.EntityFrameworkCore;
using Demo.Domain.Entities;
using Demo.Infrastucture.Data.Mapping;

namespace Demo.Infrastucture.Data.EntityConfiguration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)   
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<Phone> Phone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.ApplyConfiguration(new UserMap());
                modelBuilder.ApplyConfiguration(new UserClaimsMap());
                modelBuilder.ApplyConfiguration(new PhoneMap());
        }
    }
}