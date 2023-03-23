using domain.vehicle;

public class VehicleRepositoryImpl : VehicleRepository
{
    public Task<Vehicle?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetAllPlateNumbers()
    {
        throw new NotImplementedException();
    }

    public Task<List<Vehicle>> GetAllVehicles()
    {
        throw new NotImplementedException();
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