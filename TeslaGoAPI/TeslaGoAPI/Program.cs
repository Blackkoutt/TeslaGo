using Scalar.AspNetCore;
using Serilog;
using TeslaGoAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add Serilog
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

// Add connection to DB
builder.AddConnectionToDb(connectionString: "MSSQLTeslaGoDB");

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
