using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Settings;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.IdentityData.DbContext;
using InventoryManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryManagementSystem.Infrastructure.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices<TContext>(this IServiceCollection Services, IConfiguration Configuration) where TContext : DbContext
        {
            Services.AddDbContext<TContext>(Option =>
            {
                Option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            Services.AddDbContext<InventoryManagementSystemIdentityDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("IdentityConnectionString"));
            });

            Services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            Services.AddIdentity<ApplicationUser, ApplicationRoles>().AddEntityFrameworkStores<InventoryManagementSystemIdentityDbContext>();

            Services.AddMemoryCache();
            Services.AddTransient<IEmailService, EmailService>();
            Services.AddTransient<IJwtProvider, JwtProvider>();
            Services.ConfigureJWT(Configuration);

            return Services;
        }

        private static IServiceCollection ConfigureJWT(this IServiceCollection Services, IConfiguration Configuration)
        {
             Services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            Services.AddAuthentication(Config =>
            {
                Config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option => 
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecretKey"] ?? "LongEnoughSecretKeyForSecurity"))
                };
            });
            return Services;
        }
    }
}


