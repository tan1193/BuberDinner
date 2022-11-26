using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
        services.AddMapping();
        return services;
    }
}