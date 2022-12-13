using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Projet_2022.Models.Entities;
using System.Security.Claims;

namespace Projet_2022.Data.Extensions
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Email", user.Email ?? ""));
            identity.AddClaim(new Claim("Name", user.FirstName+" "+user.LastName ?? ""));
            identity.AddClaim(new Claim("Id", user.Id ?? ""));
            identity.AddClaim(new Claim("City", user.City ?? ""));
            identity.AddClaim(new Claim("ZipCode", user.Zipcode ?? ""));
            identity.AddClaim(new Claim("Address", user.Address ?? ""));
            identity.AddClaim(new Claim("Phonee", user.Phone ?? ""));
            return identity;
        }
    }
}
