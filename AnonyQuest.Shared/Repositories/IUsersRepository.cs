using AnonyQuest.Shared.DTOs;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnonyQuest.Shared.Repositories
{
    public interface IUsersRepository
    {
        Task<string> GetUserEmail(ClaimsPrincipal user);
    }
}
