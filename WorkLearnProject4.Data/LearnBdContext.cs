using Microsoft.EntityFrameworkCore;

namespace WorkLearnProject4.Data;

public class LearnBdContext : DbContext
{
    public virtual DbSet<TestDto> Test { get; set; }
    
    public LearnBdContext(DbContextOptions<LearnBdContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}