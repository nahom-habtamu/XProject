using dtos.vehicleowner;

namespace domain.vehicleowner.usecases;

public class CreateVehicleOwnerInteractor
{
    private readonly VehicleOwnerRepository _repository;

    public CreateVehicleOwnerInteractor(VehicleOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<VehicleOwner> Call(CreateVehicleOwnerRequest requestDto)
    {
        var vehicleOwner = VehicleOwner.buildFromDto(requestDto);
        await _repository.Save(vehicleOwner);
        return vehicleOwner;
    }
}