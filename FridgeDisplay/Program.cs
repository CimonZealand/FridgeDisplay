using FridgeAid.Api.Data;
using FridgeDisplay.Repositories;
using Microsoft.EntityFrameworkCore;
using FridgeDisplay.Models;
using Microsoft.AspNetCore.Identity;

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
builder.Services.AddSingleton<IMeasurementRepository, MeasurementsRepoList>();

//builder.Services.AddScoped<IAdminRepo, AdminRepoDB>();  //login til admin 

var app = builder.Build();

// ----------Opretter admin-brugeren én gang, hvis den ikke findes i databasen----------
//using (IServiceScope scope = app.Services.CreateScope())
//{
//    FridgeAidDbContext context = scope.ServiceProvider.GetRequiredService<FridgeAidDbContext>();

//    if (!context.Admins.Any())
//    {
//        string? adminPassword = builder.Configuration["AdminPassword"];

//        if (!string.IsNullOrEmpty(adminPassword))
//        {
//            Admin admin = new Admin { UserName = "admin" };
//            PasswordHasher<Admin> hasher = new PasswordHasher<Admin>();
//            admin.PasswordHash = hasher.HashPassword(admin, adminPassword);

//            context.Admins.Add(admin);
//            context.SaveChanges();
//        }
//    }
//}



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