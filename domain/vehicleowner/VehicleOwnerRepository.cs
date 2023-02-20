namespace domain.vehicleowner;

public interface VehicleOwnerRepository : DomainRepository<VehicleOwner>
{
    Task<List<VehicleOwner>> GetAllVehicleOwners();
}