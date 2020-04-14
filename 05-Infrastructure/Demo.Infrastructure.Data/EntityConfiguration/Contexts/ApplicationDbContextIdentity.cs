using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Demo.Infrastucture.Data.EntityConfiguration
{
    public class ApplicationDbContextIdentity : IdentityDbContext
    {
        public ApplicationDbContextIdentity(DbContextOptions<ApplicationDbContextIdentity> options): base(options)   
        {
        }

        // public DbSet<User> User { get; set; }
        // public DbSet<UserPhone> UserPhone { get; set; }
        // public DbSet<Phone> Phone { get; set; }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //         modelBuilder.ApplyConfiguration(new UserMap());
        //         modelBuilder.ApplyConfiguration(new UserPhoneMap());
        //         modelBuilder.ApplyConfiguration(new PhoneMap());

        // }


    }
}