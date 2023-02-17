using System.Collections.Generic;

namespace domain.vehicle;

public interface VehicleRepository : DomainRepository<Vehicle>
{
    Task<List<Vehicle>> GetAllVehicles();
    Task<List<string>> GetAllPlateNumbers();
    Task<List<Vehicle>> GetVehiclesByOwner(string id);
    Task<List<Vehicle>> GetVehiclesByDriver(string id);
}