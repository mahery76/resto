using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resto.domain.Repositories;
using resto.application.Services;
using resto.application.Contracts;
using resto.infrastructure.Data;
using resto.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProduitContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IProductContract, ProduitService>();

builder.Services.AddControllers();  

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
