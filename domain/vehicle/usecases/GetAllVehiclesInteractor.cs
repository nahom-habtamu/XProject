namespace domain.vehicle.usecases;

public class GetAllVehiclesInteractor
{
    private readonly VehicleRepository _repository;

    public GetAllVehiclesInteractor(VehicleRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Vehicle>> Call()
    {
        return _repository.GetAllVehicles();
    }
}