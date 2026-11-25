using FridgeAid.Api.Data;
using FridgeDisplay.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// CORS - backenden skal give tilladelse til frontenden, fordi frontenden kører på en anden origin
builder.Services.AddCors(options =>  // slår CORS-funktionen til i API'et
{
    options.AddPolicy("AllowAll", policy =>  // laver en regel med navnet "AllowAll", som bruges senere
    {
        policy.AllowAnyOrigin()    // alle websider (origins) må kalde API'et
              .AllowAnyMethod()    // alle HTTP-metoder er tilladt (GET, POST, DELETE…)
              .AllowAnyHeader();   // alle headers er tilladt (fx Content-Type og Authorization)
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger implementering
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FridgeAidDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("FridgeAidDb")));

//Dependency injection til MeasurementRepoDB, så den kan bruges i controlleren.
//builder.Services.AddScoped<IMeasurementRepository, MeasurementRepoDB>();
builder.Services.AddSingleton<IMeasurementRepository>(new MeasurementsRepoList(includesTestData: true));

var app = builder.Build();

//Cors
app.UseCors("AllowAll");

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Når vi skal sætte roller på
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();