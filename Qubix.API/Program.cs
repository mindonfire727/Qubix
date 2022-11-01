using Microsoft.AspNetCore.Mvc.Infrastructure;
using Qubix.API.Errors;
using Qubix.Application;
using Qubix.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.RegisterApplication()
                    .RegisterInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, QubixProblemDetailsFactory>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}

