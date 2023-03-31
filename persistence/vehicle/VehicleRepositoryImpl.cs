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

    public async Task<Vehicle?> Get(string id)
    {
        var sql = baseGetSql + " where id = " + "'" + id + "'";
        var vehicles = await QuerySelectAndParse(sql);
        return vehicles.FirstOrDefault();
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
        var vehicles = await QuerySelectAndParse(baseGetSql);
        return vehicles;
    }

    public async Task<List<Vehicle>> GetVehiclesByDriver(string id)
    {
        var sql = baseGetSql + " where driverId = " + "'" + id + "'";
        var vehicles = await QuerySelectAndParse(sql);
        return vehicles;
    }

    public async Task<List<Vehicle>> GetVehiclesByOwner(string id)
    {
        var sql = baseGetSql + " where ownerId = " + "'" + id + "'";
        var vehicles = await QuerySelectAndParse(sql);
        return vehicles;
    }

    private async Task<List<Vehicle>> QuerySelectAndParse(string sql)
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