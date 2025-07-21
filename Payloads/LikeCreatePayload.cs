namespace AppRoma.Payloads;

public record likeCreatePayload(
    List<Guid> ProfilesIds
);