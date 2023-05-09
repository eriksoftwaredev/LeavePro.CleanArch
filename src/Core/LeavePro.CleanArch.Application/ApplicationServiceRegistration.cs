using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeavePro.CleanArch.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddValidatorsFromAssemblyContaining<CreateLeaveTypeCommandValidator>();

        return services;
    }
}

