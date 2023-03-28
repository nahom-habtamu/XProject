using Dapper;
using domain.vehicle;

namespace persistence.vehicle;
public class VehicleRepositoryImpl : VehicleRepository
{
    private readonly DatabaseContext _context;

    private readonly string baseGetSql = @"select id, plateNumber, ownerId, driverId, city, 
        type, loadType, manufacturedDate, make, model, 
        loadCapacity, color, carImage, libreImage, 
        insuranceImage, libreExpiryDate, insuranceExpiryDate, 
        driverIdentificationDocument as driverDocument from Vehicle
    ";

    public VehicleRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public Task<Vehicle?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> GetAllPlateNumbers()
    {
        var connection = _context.Get();
        var sql = @"select plateNumber from Vehicle";
        var plateNumbers = (await connection.QueryAsync<string>(sql)).ToList();
        return plateNumbers;
    }

    public async Task<List<Vehicle>> GetAllVehicles()
    {
        var vehicles = await QuerySelectAndParseToListOfVehicle(baseGetSql);
        return vehicles;
    }


    public Task<List<Vehicle>> GetVehiclesByDriver(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Vehicle>> GetVehiclesByOwner(string id)
    {
        var sql = baseGetSql + " where ownerId = " + "'" + id + "'";
        var vehicles = await QuerySelectAndParseToListOfVehicle(sql);
        return vehicles;
    }

    private async Task<List<Vehicle>> QuerySelectAndParseToListOfVehicle(string sql)
    {
        var connection = _context.Get();
        var vehicles = (await connection.QueryAsync<Vehicle>(sql)).ToList();
        return vehicles;
    }

    public Task Save(Vehicle entity)
    {
        throw new NotImplementedException();
    }
}