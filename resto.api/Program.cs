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

// Add Swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new() { Title = "Resto API", Version = "v1" });
}); 

builder.Services.AddApplicationLayer();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Enable middleware to serve generated Swagger as a JSON endpoint. 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resto API V1");
    });
}

app.Run();

