using domain.cargoowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.cargoowner;

[ApiController]
public class GetAllCargoOwnersController : ControllerBase
{
    private readonly CargoOwnerRepository _repository;
    private readonly ILogger<GetAllCargoOwnersController> _logger;

    public GetAllCargoOwnersController(
        ILogger<GetAllCargoOwnersController> logger,
        CargoOwnerRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<CargoOwner>> Call()
    {
        return await _repository.GetAllCargoOwners();
    }
}
