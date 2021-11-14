using Microsoft.EntityFrameworkCore;
using USSDiscovery.Application.Interfaces;
using USSDiscovery.Application.Services;
using USSDiscovery.Domain.Interfaces;
using USSDiscovery.Infra.Data.Context;
using USSDiscovery.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<USSDiscoveryContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IPlanetaRepository, PlanetaRepository>();
builder.Services.AddTransient<IPlanetaService, PlanetaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
