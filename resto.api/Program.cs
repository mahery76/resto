using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resto.domain.Repositories;
using resto.application.Services;
using resto.application.Contracts;
using resto.infrastructure.Data;
using resto.infrastructure.Repositories;
using resto.application;

var builder = WebApplication.CreateBuilder(args);

// for serialization of circular references
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IProduitContract, ProduitService>();

builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICommandeContract, CommandeService>();

builder.Services.AddControllers();

builder.Services.AddApplicationLayer();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
