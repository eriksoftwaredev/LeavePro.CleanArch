using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using Microsoft.Extensions.DependencyInjection;

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

