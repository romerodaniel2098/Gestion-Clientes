using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using management.Application.Services;
using management.Infrastructure.Interfaces;
using management.Infrastructure.Repository;
var builder = WebApplication.CreateBuilder(args);

//dependences injection
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run();