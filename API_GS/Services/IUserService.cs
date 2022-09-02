using API_GS.Domain.Entities.Logging;
using API_GS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_GS.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
