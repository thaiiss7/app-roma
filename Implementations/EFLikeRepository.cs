using AppRoma.Models;
using AppRoma.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AppRoma.Implementations;

public class EFLikeRepository(AppRomaDbContext ctx) : ILikeRepository
{
    public async Task<Guid> Create(Like like)
    {
        ctx.Likes.Add(like);
        await ctx.SaveChangesAsync();
        return like.ID;
    }

    public async Task? Delete(Guid id)
    {
        var like = await ctx.Likes
            .Where(l => l.ID == id)
            .FirstOrDefaultAsync();
        ctx.Likes
            .Remove(like);

        await ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Like>> GetLikesByProfileId(Guid profileId)
    {
        var user = await ctx.Profiles
            .Where(u => u.ID == profileId)
            .FirstOrDefaultAsync();

        return user.Likes;

    }
}