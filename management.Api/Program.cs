using management.Application.Services;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//  Configurar la base de datos 
// Asegúrate de tener en appsettings.json una conexión llamada "DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios 
builder.Services.AddScoped<OrderService>();

// Agregar controladores y Swagger 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Configurar el pipeline 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear controladores 
app.MapControllers();

app.Run();