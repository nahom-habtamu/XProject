namespace domain.vehicleowner.usecases;

public class GetAllVehicleOwnersInteractor
{
    private readonly VehicleOwnerRepository _repository;

    public GetAllVehicleOwnersInteractor(VehicleOwnerRepository repository)
    {
        _repository = repository;
    }

    public Task<List<VehicleOwner>> Call()
    {
        return _repository.GetAllVehicleOwners();
    }
}