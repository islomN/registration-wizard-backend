using Api.DataAccess;
using Api.Services;
using Database;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddControllers()
    .AddNewtonsoftJson();

var value = builder.Configuration.GetSection("DbSection");
builder.Services.Configure<EntityContextOptions>(value);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();
builder.Services.AddScoped<ICountryDataAccess, CountryDataAccess>();
builder.Services.AddScoped<IProvinceDataAccess, ProvinceDataAccess>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader()
);

app.UseHttpsRedirection();
app.Run();

