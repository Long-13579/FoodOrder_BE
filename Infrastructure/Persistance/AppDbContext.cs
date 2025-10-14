using Domain;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
        modelBuilder.Entity<CartItem>().ToTable("CartItems");
        modelBuilder.Entity<Food>().ToTable("Foods");
        modelBuilder.Entity<Customer>().ToTable("Customers");

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(c => c.Customer)
            .WithOne()
            .HasForeignKey<Customer>(c => c.UserId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Customer)
            .HasForeignKey(ci => ci.CustomerId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
}
