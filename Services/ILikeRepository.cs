using AppRoma.Models;

namespace AppRoma.Services;

public interface ILikeRepository
{
    Task<Guid> Create(Like like);
    Task<IEnumerable<Like>> GetLikesByProfileId(Guid profileId);
    Task Delete(Guid id);
}