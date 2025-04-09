using Coravel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;
using System.Reflection;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Common;
using TeslaGoAPI.Logic.Mapper.Profiles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add Serilog
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

// Add App Configuration
builder.AddAppConfiguration();

// Add connection to DB
builder.AddConnectionToDb(connectionString: "MSSQLTeslaGoDB");

// Add Identity
builder.AddIdentity();

// Add JWT Token, Google Auth and Facebook Auth
builder.AddAuthentication(jwtSettingsSection: "JWTSettings");

// UnitOfWork
builder.Services.AddUnitOfWork();

// Add Scheduling
builder.Services.AddScheduler();

// Add Validators
builder.Services.AddValidatorsFromAssemblyContaining<ILogicAssemblyMarker>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// App Services
builder.Services.AddApplicationAuthServices();
builder.Services.AddCRUDServices();
builder.Services.AddOtherServices();

// Add Other Services
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// CORS
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TeslaGoApi");
    });


}

app.UseHttpsRedirection();

app.UseSchediling();

app.AddApplicationMiddleware();

app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.UseAutoMapper();

app.MapControllers();

app.Run();
