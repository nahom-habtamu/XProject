using System.Collections.Generic;

namespace domain.vehicle;

interface VehicleRepository : DomainRepository<Vehicle>
{
    List<Vehicle> GetAllVehicles();
    List<string> GetAllPlateNumbers();
    List<Vehicle> GetVehiclesByOwner(string id);
    List<Vehicle> GetVehiclesByDriver(string id);
}