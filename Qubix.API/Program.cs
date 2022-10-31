using Qubix.Application;
using Qubix.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.RegisterApplication()
                    .RegisterInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

