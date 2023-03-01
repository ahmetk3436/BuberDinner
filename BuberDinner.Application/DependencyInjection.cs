using System.Reflection;
using BuberDinner.Api.Common.Behaviours;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service )
    {
        service.AddMediatR(typeof(DependencyInjection));
        
        service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));    
        
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    return service;
    }
}