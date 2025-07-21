using Microsoft.EntityFrameworkCore;

namespace AppRoma.Models;

public class AppRomaDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Profile> Profiles => Set<Profile>();
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Like>()
            .HasOne(l => l.LikedProfiles)
            .WithMany(u => u.ReceivedLikes)
            .HasForeignKey(l => l.LikedProfileID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Like>()
            .HasOne(l => l.LikedByProfiles)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.LikedByProfielID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Profile>();
    }
}

