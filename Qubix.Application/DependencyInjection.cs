using Microsoft.Extensions.DependencyInjection;
using Qubix.Application.Authentication;

namespace Qubix.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
