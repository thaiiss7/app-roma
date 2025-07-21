using AppRoma.Models;

namespace AppRoma.Services;

public interface IProfileRepository
{
   Task<Guid?> Create(Profile profile);
   Task<Guid?> Login(string username, string password);
   Task<Profile?> GetbyId(Guid id);
   Task<IEnumerable<Profile>> Search();
   Task? Delete(Guid id);
}