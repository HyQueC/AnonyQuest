using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnonyQuest.App.Helpers
{
    public class AuthenticationStateService : IAuthenticationStateService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationStateService(AuthenticationStateProvider authenticationStateProvider)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetCurrentUserId()
        {
            var userState = await authenticationStateProvider.GetAuthenticationStateAsync();

            if (!userState.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var claims = userState.User.Claims;

            var claimWithUserId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (claimWithUserId == null)
            {
                throw new ApplicationException("Could not find User's ID");
            }

            return claimWithUserId.Value;
        }

        public async Task<string> GetCurrentUserEmail()
        {
            var userState = await authenticationStateProvider.GetAuthenticationStateAsync();

            if (!userState.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var claims = userState.User.Claims;

            var claimWithUserId = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

            if (claimWithUserId == null)
            {
                throw new ApplicationException("Could not find User's Email");
            }

            return claimWithUserId.Value;
        }
    }
}
