
using System.Net.Mime;
using System;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Api.Middlewares;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    //builder.Services.AddSingleton<ProblemDetailsFactory ,BubberDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    app.Map("/error", (HttpContext httpContext) =>
    {
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Results.Problem();
    });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
