namespace AppRoma.Payloads;

public record ProfileCreatePayload(
    string Username,
    string Password,
    string Name,
    int Age,
    string? Location,
    string? Interests,
    string? Bio
    );