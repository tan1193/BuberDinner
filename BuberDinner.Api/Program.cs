
using System.Net.Mime;
using System;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Api.Middlewares;
using BuberDinner.Api.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


