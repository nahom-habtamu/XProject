using Dapper;
using domain.vehicle;

namespace persistence.vehicle;
public class VehicleRepositoryImpl : VehicleRepository
{
    private readonly DatabaseContext _context;

    public VehicleRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public Task<Vehicle?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetAllPlateNumbers()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Vehicle>> GetAllVehicles()
    {
        var connection = _context.Get();
        var sql = @"select id, plateNumber, ownerId, driverId, city, 
            type, loadType, manufacturedDate, make, model, 
            loadCapacity, color, carImage, libreImage, 
            insuranceImage, libreExpiryDate, insuranceExpiryDate, 
            driverIdentificationDocument as driverDocument from Vehicle
        ";
        var vehicles = (await connection.QueryAsync<Vehicle>(sql)).ToList();
        return vehicles;
    }

    public Task<List<Vehicle>> GetVehiclesByDriver(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Vehicle>> GetVehiclesByOwner(string id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Vehicle entity)
    {
        throw new NotImplementedException();
    }
}