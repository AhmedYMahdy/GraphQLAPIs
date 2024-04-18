using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Database;

public class RealEstateContext : DbContext
{
    public RealEstateContext(DbContextOptions<RealEstateContext> options)
        : base(options) { }

    public DbSet<Property> Properties { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Property>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Payment>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Payment>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}