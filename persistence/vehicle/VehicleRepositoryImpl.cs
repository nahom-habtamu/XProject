using Dapper;
using domain.common;
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

    public async Task Save(Vehicle entity)
    {
        var jsonFormatter = new JsonListFormatter();
        var sql = String.Format(@"insert into Vehicle values 
            (
                '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',
                '{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'
            ) on conflict (id) do update set
                (
                    plateNumber, ownerId, driverId, city, 
                    type, loadType, manufacturedDate, make, model, 
                    loadCapacity, color, carImage, libreImage, 
                    insuranceImage, libreExpiryDate, insuranceExpiryDate, 
                    driverIdentificationDocument
                ) = 
                (
                    excluded.plateNumber, excluded.ownerId, excluded.driverId, excluded.city, 
                    excluded.type, excluded.loadType, excluded.manufacturedDate, 
                    excluded.make, excluded.model, excluded.loadCapacity, excluded.color, 
                    excluded.carImage, excluded.libreImage, 
                    excluded.insuranceImage, excluded.libreExpiryDate, excluded.insuranceExpiryDate, 
                    excluded.driverIdentificationDocument
                )
            ;",
            entity.Id, entity.PlateNumber, entity.OwnerId, entity.DriverId, entity.City,
            entity.Type, entity.LoadType, entity.ManufacturedDate,
            entity.Make, entity.Model, entity.LoadCapacity,
            entity.Color, entity.CarImage, entity.LibreImage,
            entity.InsuranceImage, entity.LibreExpiryDate, entity.InsuranceExpiryDate,
            jsonFormatter.Encode(entity.DriverIdentificationDocument.Value)
        );
        var connection = _context.Get();
        await connection.ExecuteAsync(sql);
    }
}