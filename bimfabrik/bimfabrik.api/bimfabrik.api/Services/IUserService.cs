using bimfabrik.api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bimfabrik.api.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
