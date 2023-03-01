namespace domain.cargoowner;
public interface CargoOwnerRepository : DomainRepository<CargoOwner>
{
    Task<List<CargoOwner>> GetAllCargoOwners();
}