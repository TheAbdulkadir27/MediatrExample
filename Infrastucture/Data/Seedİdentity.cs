using Domain.Entity.Model;
using Microsoft.AspNetCore.Identity;

namespace Infrastucture.Data
{
    public class SeedIdentity
    {
        public static void Seed(UserManager<User> userManager)
        {
            var user = new User()
            {
                UserName = "JwtUser",
                Email = "jwtuser@gmail.com"
            };
            if (userManager.FindByNameAsync("JwtUser").Result == null)
            {
                var IdentityResult = userManager.CreateAsync(user, "jwt123456").Result;
            }
        }
    }
}
