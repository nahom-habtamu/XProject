using domain.auction;
using domain.auction.usecases;
using domain.cargoowner;
using domain.driver;
using domain.driver.usecases;
using domain.vehicle;
using domain.vehicle.usecases;
using domain.vehicleowner;
using domain.vehicleowner.usecases;
using persistence.auction;
using persistence.cargoowner;
using persistence.driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Injections

RegisterRepostories(builder);
RegisterGetUseCases(builder);
RegisterCreateUseCases(builder);

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

static void RegisterRepostories(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<DriverRepository, DriverRepositoryImpl>();
    builder.Services.AddScoped<VehicleRepository, VehicleRepositoryImpl>();
    builder.Services.AddScoped<VehicleOwnerRepository, VehicleOwnerRepositoryImpl>();
    builder.Services.AddScoped<CargoOwnerRepository, CargoOwnerRepositoryImpl>();
    builder.Services.AddScoped<AuctionRepository, AuctionRepositoryImpl>();
}

static void RegisterCreateUseCases(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<CreateVehicleInteractor>();
    builder.Services.AddScoped<CreateAuctionInteractor>();
    builder.Services.AddScoped<CreateVehicleOwnerInteractor>();
}

static void RegisterGetUseCases(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<GetAllDriversInteractor>();
    builder.Services.AddScoped<GetAllVehiclesInteractor>();
    builder.Services.AddScoped<GetAllVehicleOwnersInteractor>();
}