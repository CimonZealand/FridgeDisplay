using FridgeAid.Api.Data;
using FridgeDisplay.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger implementering
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FridgeAidDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("FridgeAidDb")));

//Dependency injection til MeasurementRepoDB, så den kan bruges i controlleren.
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepoDB>();

var app = builder.Build();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();