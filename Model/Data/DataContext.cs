using Microsoft.EntityFrameworkCore;
using SmacoteriaBDFinal.Model.Models;

namespace SmacoteriaBDFinal.Model.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }

    public DbSet<Dish> Dishes => this.Set<Dish>();

    public DbSet<Addition> Additions => this.Set<Addition>();

    public DbSet<Category> Categories => this.Set<Category>();

    public DbSet<DishInOrder> DishesInOrders => this.Set<DishInOrder>();

    public DbSet<Order> Orders => this.Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smakoteria.sqlite;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addition>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Additions)
            .HasForeignKey(a => a.CategoryId);

        modelBuilder.Entity<Dish>()
            .HasOne(d => d.Category)
            .WithMany(c => c.Dishes)
            .HasForeignKey(d => d.CategoryId);

        modelBuilder.Entity<DishInOrder>()
            .HasOne(d => d.Dish)
            .WithMany(d => d.Orders)
            .HasForeignKey(d => d.DishId);

        modelBuilder.Entity<DishInOrder>()
            .HasOne(d => d.Order)
            .WithMany(o => o.Dishes)
            .HasForeignKey(d => d.OrderId);
    }
}
