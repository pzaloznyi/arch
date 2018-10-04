using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "demouser@onlineshop.com", Email = "demouser@onlineshop.com" };
            await userManager.CreateAsync(defaultUser, "Pass@word1");
        }
    }
}
