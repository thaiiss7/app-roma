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
                // var user = await repo.Search(profile.Username);
                // repo.
                
            }
        );
    }
}