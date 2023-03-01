using domain.cargoowner;
using dtos.cargoowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.cargoowners;

[ApiController]
public class CreateCargoOwnerController : ControllerBase
{
    private readonly ILogger<CreateCargoOwnerController> _logger;
    private readonly CargoOwnerRepository _repository;

    public CreateCargoOwnerController(
        ILogger<CreateCargoOwnerController> logger,
        CargoOwnerRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<CargoOwner> Call([FromBody] CreateCargoOwnerRequestDto requestDto)
    {
        var cargoOwner = CargoOwner.parseFromDto(requestDto);
        await _repository.Save(cargoOwner);
        return cargoOwner;
    }
}