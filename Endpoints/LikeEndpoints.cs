namespace AppRoma.Endpoints;

public static class LikeEndpoints
{
    public static void ConfigureLikeEndpoints(this WebApplication app)
    {
        app.MapPost("like/add", async (
            [FromBody] LikeCreatePayload like,
            [FromServices] ILikeRepository repo) =>
            {
                // var profiles = await repo.GetProfilesByIds(like.ProfilesIds);
                // if (profiles.Count == 0)
                //     return Results.NotFound("No profiles found with the provided IDs");

                // foreach (var profile in profiles)
                // {
                //     await repo.Create(new Like
                //     {
                //         ProfileId = profile.Id,
                //         LikedAt = DateTime.UtcNow
                //     });
                // }

                // return Results.Ok();
            }
        );
    }
}