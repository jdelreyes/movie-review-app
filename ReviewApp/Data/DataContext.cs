using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data;

public class DataContext : DbContext
{
    public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}