using System.Collections.Generic;

namespace domain.cargoowner;
interface CargoOwnerRepository : DomainRepository<CargoOwner>
{
    List<CargoOwner> GetCargoOwners();
}