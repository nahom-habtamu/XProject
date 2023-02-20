using domain.driver;
using domain.driver.usecases;
using domain.vehicle;
using domain.vehicle.usecases;
using domain.vehicleowner;
using domain.vehicleowner.usecases;
using persistence.driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Injections
builder.Services.AddScoped<DriverRepository, DriverRepositoryImpl>();
builder.Services.AddScoped<VehicleRepository, VehicleRepositoryImpl>();
builder.Services.AddScoped<VehicleOwnerRepository, VehicleOwnerRepositoryImpl>();
builder.Services.AddScoped<GetAllDriversInteractor>();
builder.Services.AddScoped<GetAllVehiclesInteractor>();
builder.Services.AddScoped<GetAllVehicleOwnersInteractor>();


var app = builder.Build();

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
