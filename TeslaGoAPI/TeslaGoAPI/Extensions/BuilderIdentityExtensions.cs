using Microsoft.AspNetCore.Identity;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TeslaGoAPI.Extensions
{
    public static class BuilderIdentityExtensions
    {
        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Password = GetIdentityPasswordOptions();
            })
            .AddEntityFrameworkStores<APIContext>();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder, string jwtSettingsSection)
        {
            var jwtSettings = builder.Configuration.GetSection(jwtSettingsSection);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = GetJWTTokenOptions(jwtSettings);
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Cookies["TeslaGoJWTCookie"];
                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        private static TokenValidationParameters GetJWTTokenOptions(IConfigurationSection jwtSettingsSection)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettingsSection["validIssuer"],
                ValidAudience = jwtSettingsSection["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(jwtSettingsSection.GetSection("securityKey").Value!)),
                RoleClaimType = "userRoles"
            };
        }

        private static PasswordOptions GetIdentityPasswordOptions()
        {
            return new PasswordOptions
            {
                RequireNonAlphanumeric = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequiredUniqueChars = 0,
                RequiredLength = 8
            };
        }
    }
}
