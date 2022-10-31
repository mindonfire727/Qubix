using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qubix.Application.Common.Interfaces.Authentication;
using Qubix.Application.Common.Services;
using Qubix.Infrastructure.Authentication;
using Qubix.Infrastructure.Services;

namespace Qubix.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}

