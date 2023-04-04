using domain.cargoowner;
using dtos.cargoowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.cargoowner;

[ApiController]
public class SaveCargoOwnerController : ControllerBase
{
    private readonly CargoOwnerRepository _repository;

    public SaveCargoOwnerController(CargoOwnerRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<CargoOwner> Call([FromBody] SaveCargoOwnerRequestDto requestDto)
    {
        var cargoOwner = CargoOwner.parseFromDto(requestDto);
        await _repository.Save(cargoOwner);
        return cargoOwner;
    }
}