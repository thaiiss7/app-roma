using AppRoma.Models;
using AppRoma.Services;
using Microsoft.EntityFrameworkCore;

namespace AppRoma.Implementations;

public class EFProfileRepository(AppRomaDbContext ctx) : IProfileRepository
{
    public async Task<Guid?> Create(Profile profile)
    {
        ctx.Profiles.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.ID;
    }

    public async Task? Delete(Guid id)
    {
        var user = await ctx.Profiles
            .Where(u => u.ID == id)
            .FirstOrDefaultAsync();

        ctx.Profiles
            .Remove(user);

        await ctx.SaveChangesAsync();

    }

    public async Task<Profile?> GetbyId(Guid id)
    {
        return await ctx.Profiles
            .FirstOrDefaultAsync(u => u.ID == id);
    }

    public async Task<Guid?> Login(string username, string password)
    {
        var user = await ctx.Profiles
            .Where(u => username == u.Username && password == u.Password)
            .FirstOrDefaultAsync();

        return user?.ID;
    }

    public async Task<IEnumerable<Profile>> Search()
    {
        return await ctx.Profiles
            .ToListAsync();
    }
}