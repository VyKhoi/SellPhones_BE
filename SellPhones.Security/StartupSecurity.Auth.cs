using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SellPhones.Domain.Entity.Identity;
using SellPhones.Security.Authorization;
using SellPhones.Security.Identity;

namespace SellPhones.Security
{
    public static class Startup
    {
        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<SecurityDbContext>(options =>
                                           options.UseNpgsql(connectionString));
            }

            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<SecurityDbContext>()
            .AddDefaultTokenProviders();
            services.AddTransient<IAuthorizationHandler, RolesInDBAuthorizationHandler>();

            services.Configure<Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromSeconds(15);
            });
        }
    }
}