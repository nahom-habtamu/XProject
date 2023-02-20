using domain.driver;
using domain.vehicleowner;

namespace domain.vehicle.usecases;

public class CreateVehicleInteractor
{
    private readonly VehicleRepository _vehicleRepo;
    private readonly DriverRepository _driverRepo;
    private readonly VehicleOwnerRepository _vehicleOwnerRepo;

    public CreateVehicleInteractor(
        DriverRepository driverRepo,
        VehicleRepository vehicleRepo,
        VehicleOwnerRepository vehicleOwnerRepo
    )
    {
        _driverRepo = driverRepo;
        _vehicleRepo = vehicleRepo;
        _vehicleOwnerRepo = vehicleOwnerRepo;
    }

    public async Task<Vehicle> Call(Vehicle vehicle)
    {
        await HandleWrongDriverId(vehicle);
        await HandleWrongOwnerId(vehicle);
        await _vehicleRepo.Save(vehicle);
        return vehicle;
    }

    private async Task HandleWrongOwnerId(Vehicle vehicle)
    {
        var vehicleOwners = await _vehicleOwnerRepo.GetAllVehicleOwners();

        if (!vehicleOwners.Any(vo => vo.Id.Equals(vehicle.OwnerId)))
        {
            throw new Exception("Invalid Owner");
        }
    }

    private async Task HandleWrongDriverId(Vehicle vehicle)
    {
        var drivers = await _driverRepo.GetAllDrivers();

        if (!drivers.Any(d => d.Id.Equals(vehicle.DriverId)))
        {
            throw new Exception("Invalid Driver");
        }
    }
}