using Microsoft.AspNetCore.Mvc;
using AppRoma.Payloads;
using AppRoma.Models;
using AppRoma.Services;

namespace AppRoma.Endpoints;

public static class ProfileEndpoints
{
    public static void ConfigureProfileEndpoints(this WebApplication app)
    {
        app.MapPost("profile", async (
            [FromBody] ProfileCreatePayload profile,
            [FromServices] IProfileRepository repo) =>
            {
                var user = await repo.Search(profile.Username);
                if (user.Any(u => u.Username == profile.Username))
                    return Results.BadRequest("Already exists another User with this Username");

                await repo.Create(new Profile
                {
                    Username = profile.Username
                });
                return Results.Ok();
            });

        app.MapPost("profile/auth", async (
            [FromBody] ProfileCreatePayload profile,
            [FromServices] IProfileRepository repo) =>
            {

            var user = await repo.Login(profile.Username, profile.Password);
            if (user == null)
                return Results.NotFound("Username or password not found");

            return Results.Ok();
        });
            
        app.MapGet("profile/feed", async (
            [FromBody] ProfileCreatePayload profile,
            [FromServices] IProfileRepository repo) =>
            {
                // Busca todos os perfis
                var feed = await repo.Search();
                // Retira o perfil do usuário
                feed = feed.Where(p => p.Guid != profile.Guid).ToList();

                // Filtra por idade e localização
                feed = feed.Where(p => p.Age >= profile.Age - 5 
                && p.Age <= profile.Age + 5).ToList();
                feed = feed.Where(p => p.Location == profile.Location).ToList();

                if (feed.Count == 0)
                    return Results.NotFound();

                // Sorteia um perfil aleatório
                var random = new Random();
                var randomProfile = feed[random.Next(feed.Count)];

                return Results.Ok(randomProfile);
                
            }
        );

        app.MapGet("profile/{id}", async (
            Guid id,
            [FromBody] ProfileCreatePayload profile,
            [FromServices] IProfileRepository repo) =>
            {
                var user = await repo.GetbyId(id);
                if (user == null)
                    return Results.NotFound();
                
                return Results.Ok(user);
            });
    }
}