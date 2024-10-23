using Microsoft.EntityFrameworkCore;
using resto.domain.Repositories;
using resto.application.Services;
using resto.application.Contracts;
using resto.infrastructure.Data;
using resto.infrastructure.Repositories;
using resto.application;
using resto.application.Mapping;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IProduitContract, ProduitService>();

builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICommandeContract, CommandeService>();

builder.Services.AddControllers();

builder.Services.AddApplicationLayer();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
