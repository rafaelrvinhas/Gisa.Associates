using Associates.Domain.RabbitQueue;
using Associates.Services.Api.Configurations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

// Add services to the container.

builder.Services.AddDatabaseSetup(configurationBuilder.Build());

builder.Services.AddControllers();

builder.Services.AddAutoMapperSetup();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton(sp => RabbitConnection.CreateBus("localhost"));
builder.Services.AddDependencyInjectionSetup();
builder.Services.AddSwaggerSetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GISA");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
