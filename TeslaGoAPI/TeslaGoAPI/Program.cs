using FluentValidation;
using FluentValidation.AspNetCore;
using Scalar.AspNetCore;
using Serilog;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Common;
using TeslaGoAPI.Logic.Mapper.Profiles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add Serilog
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

// Add connection to DB
builder.AddConnectionToDb(connectionString: "MSSQLTeslaGoDB");

// Add Validators
builder.Services.AddValidatorsFromAssemblyContaining<ILogicAssemblyMarker>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Add Other Services
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAutoMapper();

app.MapControllers();

app.Run();
