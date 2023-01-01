using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Sydney",
                    Email = "sydney@test.com",
                    UserName = "cindicate",
                    Address = new Address
                    {
                        FirstName = "Ikenaa",
                        LastName = "Ogbonna",
                        Street = "5 Asa Afariogun Street",
                        City = "Lagos",
                        State = "Lagos",
                        Country = "Nigeria",
                        PostalCode = "73038",
                    }
                };
                await userManager.CreateAsync(user, "Pa$$W0rd");
            }
        }

    }
}
