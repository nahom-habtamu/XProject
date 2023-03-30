using domain.cargoowner;
using domain.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.cargoowner;

[ApiController]
public class GetCargoOwnerController : ControllerBase
{
    private readonly CargoOwnerRepository _repository;

    public GetCargoOwnerController(
        CargoOwnerRepository repository
    )
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<CargoOwner?> Call(string id)
    {
        var result = await _repository.Get(id);
        if (result == null) throw new NoDataFoundWithThisIdException("CargoOwner", id);
        return result;
    }
}
