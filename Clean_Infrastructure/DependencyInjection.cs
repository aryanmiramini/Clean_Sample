using Clean_Application.Common.Interfaces.Authentication;
using Clean_Application.Common.Interfaces.Persistance;
using Clean_Application.Common.Interfaces.Services;
using Clean_Infrastructure.Authentication;
using Clean_Infrastructure.Persistance;
using Clean_Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
            
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository , UserRepository>();
            return services;
        }
    }
}
