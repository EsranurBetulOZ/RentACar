using Arac_Kiralama.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Contexts;
public class BaseDbContext:IdentityDbContext<User,IdentityRole,string>
{
    public BaseDbContext(DbContextOptions<BaseDbContext> opt) : base(opt)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB ; Database=rent_a_car_db;Trusted_connection=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
        modelBuilder.Entity<Car>()
            .Property(c => c.DailyPrice)
            .HasPrecision(12, 4);
    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Models.Entity.Color> Colors { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}