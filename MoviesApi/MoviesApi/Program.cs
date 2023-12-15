using System.Runtime.CompilerServices;
using MoviesApiBL.Interfaces;
using MoviesApiBL.Models;
using MoviesApiDAL;
using MoviesApiDAL.Interfaces;
using MoviesApiDAL.Models;
using MoviesApiIL.Models;
using MoviesApiSL.Interfaces;
using MoviesApiSL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Layer
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IValidationService, ValidationService>();

// Business Layer
builder.Services.AddScoped<IDataManager, DataManager>();
builder.Services.AddScoped<IMoviesManager, MoviesManager>();

// Data Access Layer
builder.Services.AddScoped<IDataImport, DataImport>();
builder.Services.AddScoped<IMovieDal, MovieDal>();
builder.Services.AddScoped<MoviesDbContext>();



var app = builder.Build();

// Initialize and populate the SQLite database using the csv file.
using (var scope = app.Services.CreateScope())
{
    IDataService dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
    dataService.Initialize();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();