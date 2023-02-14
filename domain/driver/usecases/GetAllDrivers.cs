namespace domain.driver.usecases;

public class GetAllDriversInteractor
{
    private readonly DriverRepository _repository;

    public GetAllDriversInteractor(DriverRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Driver>> Call()
    {
        return _repository.GetAllDrivers();
    }

}