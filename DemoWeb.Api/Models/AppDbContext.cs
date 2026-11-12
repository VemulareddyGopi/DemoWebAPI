using Microsoft.EntityFrameworkCore;

namespace SirIthara.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.Name).HasMaxLength(300).IsRequired();
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            entity.Property(p => p.Stock).IsRequired();
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(pt => pt.ProductTypeId);
            entity.Property(pt => pt.Type).HasMaxLength(100).IsRequired();
        });
    }
}

