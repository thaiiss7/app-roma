using Microsoft.EntityFrameworkCore;

namespace AppRoma.Models;

public class AppRomaDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Profile> Profiles => Set<Profile>();
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Like>();

        model.Entity<Profile>()
            .HasMany(p => p.Likes)
            .WithMany(l => l.Profiles)
            .UsingEntity(j => j.ToTable("LikeProfile"));
    }
}

