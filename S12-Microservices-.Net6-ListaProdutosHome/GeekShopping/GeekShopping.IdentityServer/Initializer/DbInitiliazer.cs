using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.ModelDatabase.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitiliazer : IDbInitiliazer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitiliazer(ApplicationDbContext context, 
            UserManager<ApplicationUser> user, 
            RoleManager<IdentityRole> role)
        {
            _context=context;
            _user=user;
            _role=role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
                return;

            _role.CreateAsync(
                new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(
                new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Samu-admin",
                Email = "tanjiro-admin@g.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (24) 4002-8922",
                FirstName = "Samuel",
                LastName = "Admin",
            };

            _user.CreateAsync(admin, "Sp159357@1#").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;
            
            // new //

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "Samu-client",
                Email = "tanjiro-client@g.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (24) 4002-8922",
                FirstName = "Samuel",
                LastName = "Client",
            };

            _user.CreateAsync(client, "Sp159357@1#").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;

            // new //

            ApplicationUser peakyBlinda = new ApplicationUser()
            {
                UserName = "Samu-Peaky-Admin",
                Email = "Samu-Peaky@g.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (24) 4002-8922",
                FirstName = "Samuel",
                LastName = "Peaky",
            };

            _user.CreateAsync(client, "Sp159357@1#").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var peakyClaims = _user.AddClaimsAsync(peakyBlinda, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{peakyBlinda.FirstName} {peakyBlinda.LastName}"),
                new Claim(JwtClaimTypes.GivenName, peakyBlinda.FirstName),
                new Claim(JwtClaimTypes.FamilyName, peakyBlinda.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result;

        }
    }
}

