using domain.driver;
using domain.vehicle;
using domain.vehicleowner;
using dtos.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class SaveVehicleController : ControllerBase
{
    private readonly VehicleRepository _vehicleRepo;
    private readonly DriverRepository _driverRepo;
    private readonly VehicleOwnerRepository _vehicleOwnerRepo;

    public SaveVehicleController(
        VehicleRepository vehicleRepo,
        DriverRepository driverRepo,
        VehicleOwnerRepository vehicleOwnerRepo
    )
    {
        _vehicleRepo = vehicleRepo;
        _driverRepo = driverRepo;
        _vehicleOwnerRepo = vehicleOwnerRepo;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call([FromBody] SaveVehicleRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto.DriverId!);
        await HandleWrongOwnerId(requestDto.OwnerId!);
        await HandleDuplicatePlateNumber(requestDto.PlateNumber!);

        var vehicle = Vehicle.parseFromDto(requestDto);
        await _vehicleRepo.Save(vehicle);
        return vehicle.Id;
    }

    private async Task HandleDuplicatePlateNumber(string plateNumber)
    {
        var plateNumbers = await _vehicleRepo.GetAllPlateNumbers();
        if (plateNumbers.Any(p => p.Equals(plateNumber)))
        {
            throw new Exception("Duplicate Plate Number");
        }
    }

    private async Task HandleWrongOwnerId(string ownerId)
    {
        var vehicleOwner = await _vehicleOwnerRepo.Get(ownerId!);

        if (vehicleOwner == null)
        {
            throw new Exception("Invalid Owner");
        }
    }

    private async Task HandleWrongDriverId(string driverId)
    {
        var driver = await _driverRepo.Get(driverId!);
        if (driver == null)
        {
            throw new Exception("Invalid Driver");
        }
    }
}
