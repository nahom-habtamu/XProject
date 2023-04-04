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
    public async Task<Vehicle> Call([FromBody] SaveVehicleRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto);
        await HandleWrongOwnerId(requestDto);

        var vehicle = Vehicle.parseFromDto(requestDto);
        await _vehicleRepo.Save(vehicle);
        return vehicle;
    }

    private async Task HandleWrongOwnerId(SaveVehicleRequestDto requestDto)
    {
        var vehicleOwner = await _vehicleOwnerRepo.Get(requestDto.OwnerId!);

        if (vehicleOwner == null)
        {
            throw new Exception("Invalid Owner");
        }
    }

    private async Task HandleWrongDriverId(SaveVehicleRequestDto requestDto)
    {
        var driver = await _driverRepo.Get(requestDto.DriverId!);
        if (driver == null)
        {
            throw new Exception("Invalid Driver");
        }
    }
}
