using LeavePro.CleanArch.Application.Contracts.Email;
using LeavePro.CleanArch.Application.Contracts.Logging;
using LeavePro.CleanArch.Application.Models.Email;
using LeavePro.CleanArch.Infrastructure.EmailService;
using LeavePro.CleanArch.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeavePro.CleanArch.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}

