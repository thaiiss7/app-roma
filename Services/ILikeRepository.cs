using AppRoma.Models;

namespace AppRoma.Services;

public interface ILikeRepository
{
    Task<Guid> Create(Like like);
    Task<IEnumerable<Like>> GetLikesByProfileId(Guid profileId);
    Task<bool> UpdateLikeStatus(Guid id, bool liked);
    Task Delete(Guid id);
    //se eu tenho um delete, eu preciso de um update?
}