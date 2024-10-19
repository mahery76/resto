using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resto.domain.Repositories;
using resto.application.Services;
using resto.application.Contracts;
using resto.infrastructure.Data;
using resto.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<SqlLiteProduitContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));


builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IProduitRepository, ProduitRepository>(); 
builder.Services.AddScoped<IProductContract, ProduitService>();

builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICommandeContract, CommandeService>();

builder.Services.AddControllers();  

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
