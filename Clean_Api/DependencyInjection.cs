using Clean_Api.Common.Errors;
using Clean_Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Clean_Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailFactory>();
            services.AddMappings();
            return services;
        }
    }
}
