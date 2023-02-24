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
                    new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
                    new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
                }
            ),
            // new Uri(requestDto.CarRelatedImage.CarImage),
            // new Uri(requestDto.CarRelatedImage.LibreImage),
            // new Uri(requestDto.CarRelatedImage.InsuranceImage),

            new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
            new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
            new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
            requestDto.LibreExpiryDate,
            requestDto.InsuranceExpiryDate
        );

        await _vehicleRepo.Save(vehicle);
        return vehicle;
    }

    private async Task HandleWrongOwnerId(CreateVehicleRequestDto requestDto)
    {
        var vehicleOwner = await _vehicleOwnerRepo.Get(requestDto.OwnerId!);

        if (vehicleOwner == null)
        {
            throw new Exception("Invalid Owner");
        }
    }

    private async Task HandleWrongDriverId(CreateVehicleRequestDto requestDto)
    {
        var driver = await _driverRepo.Get(requestDto.DriverId!);
        if (driver == null)
        {
            throw new Exception("Invalid Driver");
        }
    }
}