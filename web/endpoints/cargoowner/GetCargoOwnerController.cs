using domain.cargoowner;
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
        if (result == null) throw new Exception("CargoOwner With This Id NotFound");
        return result;
    }
}
