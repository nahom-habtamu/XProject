using domain.auction;
using domain.bid;
using domain.cargoowner;
using domain.driver;
using domain.vehicle;
using domain.vehicleowner;
using Npgsql;
using persistence;
using persistence.auction;
using persistence.bid;
using persistence.cargoowner;
using persistence.driver;
using persistence.vehicle;
using persistence.vehicleowner;
using web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CustomInjections

RegisterDatabaseContext(builder);
RegisterFileUploaderInstanceFactory(builder);
RegisterRepostories(builder);

#endregion

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

static void RegisterDatabaseContext(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("TestDbConnection");
    builder.Services.AddScoped(o => new NpgsqlConnection(connectionString));
    builder.Services.AddScoped<DatabaseContext>();
}

static void RegisterFileUploaderInstanceFactory(WebApplicationBuilder builder)
{
    var accessKey = builder.Configuration["Minio:AccessKey"];
    var secretKey = builder.Configuration["Minio:SecretKey"];
    var endPoint = builder.Configuration["Minio:EndPoint"];

    builder.Services.AddScoped(o => new FileStoreInstanceFactory(
        accessKey, secretKey, endPoint
    ));
}

static void RegisterRepostories(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<DriverRepository, DriverRepositoryImpl>();
    builder.Services.AddScoped<VehicleRepository, VehicleRepositoryImpl>();
    builder.Services.AddScoped<VehicleOwnerRepository, VehicleOwnerRepositoryImpl>();
    builder.Services.AddScoped<CargoOwnerRepository, CargoOwnerRepositoryImpl>();
    builder.Services.AddScoped<AuctionRepository, AuctionRepositoryImpl>();
    builder.Services.AddScoped<BidRepository, BidRepositoryImpl>();
}