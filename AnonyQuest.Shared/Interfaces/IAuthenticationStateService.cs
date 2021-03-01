using System.Threading.Tasks;

namespace AnonyQuest.Shared.Interfaces
{
    public interface IAuthenticationStateService
    {
        Task<string> GetCurrentUserEmail();
        Task<string> GetCurrentUserId();
    }
}
