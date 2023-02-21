using domain.cargoowner;

namespace persistence.cargoowner;
public class CargoOwnerRepositoryImpl : CargoOwnerRepository
{
    public Task<CargoOwner?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CargoOwner>> GetAllCargoOwners()
    {
        return Task.Run(() => new List<CargoOwner>());
    }

    public Task Save(CargoOwner entity)
    {
        throw new NotImplementedException();
    }
}