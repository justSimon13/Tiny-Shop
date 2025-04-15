using Microsoft.EntityFrameworkCore;
using TinyStore.Domain;

namespace TinyStore.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureProduct(modelBuilder);
        ConfigureCategory(modelBuilder);
    }

    private void ConfigureProduct(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();

        product.ToTable("Products");

        product.HasKey(p => p.Id);

        product.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        product.Property(p => p.Price)
            .HasPrecision(10, 2)
            .IsRequired();

        product.Property(p => p.CategoryId)
            .IsRequired();

        product.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        var category = modelBuilder.Entity<Category>();

        category.ToTable("Categories");

        category.HasKey(c => c.Id);

        category.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}