using AnonyQuest.App.Data;
using AnonyQuest.Shared.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnonyQuest.App.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public UsersRepository(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        public async Task<string> GetUserEmail(ClaimsPrincipal user)
        {
            var currentUser = await userManager.GetUserAsync(user);

            return currentUser.Email;
        }
    }
}
