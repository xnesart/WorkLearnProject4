using Microsoft.EntityFrameworkCore;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data;

public class LearnBdContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CurrentWeather> Weathers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }

    public LearnBdContext(DbContextOptions<LearnBdContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new Customer
            { Id = Guid.NewGuid(), Name = "Nick", Email = "nick@example.com", BirthDate = new DateTime(2000, 10, 10) });
        modelBuilder.Entity<Customer>().HasData(new Customer
            { Id = Guid.NewGuid(), Name = "Petr", Email = "petr@example.com", BirthDate = new DateTime(1990, 10, 10) });
    }
}