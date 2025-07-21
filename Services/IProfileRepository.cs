using AppRoma.Models;

namespace AppRoma.Services;

public interface IProfileRepository
{
   Task<Profile> GetbyId(Guid id);
   Task<Guid> Create(Profile profile);
   Task<IEnumerable<Profile>> Search(string name);
   //listar os perfis é importante?
}