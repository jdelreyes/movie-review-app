using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>()
            .HasKey(key => new { key.ItemId, key.ReviewerId });
        modelBuilder.Entity<Review>()
            .HasOne(p => p.Item);
        modelBuilder.Entity<Review>()
            .HasOne(p => p.Reviewer);

        modelBuilder.Entity<Like>()
            .HasKey(key => new { key.ReviewId, key.UserId });
        modelBuilder.Entity<Like>()
            .HasOne(p => p.User);
        modelBuilder.Entity<Like>()
            .HasOne(p => p.Review);
    }
}