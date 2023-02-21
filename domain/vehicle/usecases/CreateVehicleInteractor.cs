using domain.common;
using domain.driver;
using domain.vehicleowner;
using dtos.vehicle;

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

    public async Task<Vehicle> Call(CreateVehicleRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto);
        await HandleWrongOwnerId(requestDto);

        var vehicle = new Vehicle(
            requestDto.PlateNumber!,
            requestDto.OwnerId!,
            requestDto.DriverId!,
            requestDto.City!,
            requestDto.Type!,
            requestDto.LoadType!,
            requestDto.ManufacturedDate,
            requestDto.Make!,
            requestDto.Model!, 
            requestDto.LoadCapacity!, 
            requestDto.Color!, 
            new PersonId(
                new List<Uri>{
                    new Uri("google.com"),
                    new Uri("google.com"),
                }
            ),
            // new Uri(requestDto.CarRelatedImage.CarImage),
            // new Uri(requestDto.CarRelatedImage.LibreImage),
            // new Uri(requestDto.CarRelatedImage.InsuranceImage),

            new Uri("google.com"),
            new Uri("google.com"),
            new Uri("google.com"),
            requestDto.LibreExpiryDate,
            requestDto.InsuranceExpiryDate
        );

        await _vehicleRepo.Save(vehicle);
        return vehicle;
    }

    private async Task HandleWrongOwnerId(CreateVehicleRequestDto requestDto)
    {
        var vehicleOwners = await _vehicleOwnerRepo.GetAllVehicleOwners();

        if (!vehicleOwners.Any(vo => vo.Id.Equals(requestDto.OwnerId)))
        {
            throw new Exception("Invalid Owner");
        }
    }

    private async Task HandleWrongDriverId(CreateVehicleRequestDto requestDto)
    {
        var drivers = await _driverRepo.GetAllDrivers();

        if (!drivers.Any(d => d.Id.Equals(requestDto.DriverId)))
        {
            throw new Exception("Invalid Driver");
        }
    }
}