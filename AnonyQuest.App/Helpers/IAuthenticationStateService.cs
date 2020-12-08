using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnonyQuest.App.Helpers
{
    public interface IAuthenticationStateService
    {
        Task<string> GetCurrentUserEmail();
        Task<string> GetCurrentUserId();
    }
}
