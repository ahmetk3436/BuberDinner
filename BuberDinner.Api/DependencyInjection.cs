using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection service)
        {
            service.AddControllers();
               service.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
            service.AddMappings();
            return service;
        }
    }
}